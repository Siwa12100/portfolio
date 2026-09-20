using portfolio_siwa.Donnees;
using portfolio_siwa.Modeles;

namespace tests;

public class ImagesTests
{
    [Fact]
    public void Chaque_fiche_a_ses_variantes_reduites()
    {
        foreach (var fiche in CatalogueProjets.Tous)
        {
            Assert.True(File.Exists(Fichier(fiche.Image)), $"{fiche.Image} est introuvable");

            foreach (var largeur in FicheProjet.LargeursVariantes)
            {
                var variante = fiche.Variante(largeur);

                Assert.True(File.Exists(Fichier(variante)), $"{variante} manque : voir « Ajouter un projet » dans le README");
                Assert.Equal(largeur, LireDimensions(Fichier(variante)).Largeur);
            }
        }
    }

    [Fact]
    public void Les_dimensions_declarees_sont_celles_des_fichiers()
    {
        // Elles partent dans width et height : fausses, elles ne réservent plus la bonne place
        // et la page saute pendant le chargement.
        foreach (var fiche in CatalogueProjets.Tous)
        {
            var (largeur, hauteur) = LireDimensions(Fichier(fiche.Image));

            Assert.Equal((fiche.ImageLargeur, fiche.ImageHauteur), (largeur, hauteur));
        }
    }

    [Fact]
    public void La_photo_d_accueil_a_sa_variante_reduite()
    {
        Assert.True(File.Exists(Fichier("/Images/PhotoProfil.jpg")));
        Assert.Equal(640, LireDimensions(Fichier("/Images/PhotoProfil-640.jpg")).Largeur);
    }

    [Fact]
    public void Chaque_logo_est_une_tuile_au_bon_format()
    {
        // Le CSS et les attributs width et height comptent sur 280 x 160 px (140 x 80 en double
        // densité) : une tuile d'une autre taille serait déformée ou décalerait la page.
        foreach (var affiliation in CatalogueAffiliations.Toutes)
        {
            var chemin = Fichier(affiliation.Logo);

            Assert.True(File.Exists(chemin), $"{affiliation.Logo} est introuvable");
            Assert.Equal((Affiliation.LargeurLogo * 2, Affiliation.HauteurLogo * 2), LireDimensionsPng(chemin));
            Assert.True(new FileInfo(chemin).Length < 60 * 1024, $"{affiliation.Logo} pèse plus de 60 Ko");
        }
    }

    [Fact]
    public void Le_srcset_liste_les_variantes_puis_l_original()
    {
        var fiche = CatalogueProjets.Tous[0];
        var racine = fiche.Image[..fiche.Image.LastIndexOf('.')];

        Assert.Equal(
            $"{racine}-480.jpg 480w, {racine}-800.jpg 800w, {fiche.Image} {fiche.ImageLargeur}w",
            fiche.SrcSet);
    }

    [Fact]
    public void Chaque_image_reste_legere()
    {
        // C'est le premier facteur de confort sur mobile : le README fixe la limite à 150 Ko.
        foreach (var fiche in CatalogueProjets.Tous)
        {
            var poids = new FileInfo(Fichier(fiche.Image)).Length;

            Assert.True(poids < 150 * 1024, $"{fiche.Image} pèse {poids / 1024} Ko");
        }
    }

    private static string Fichier(string cheminWeb)
    {
        var dossier = new DirectoryInfo(AppContext.BaseDirectory);

        while (dossier is not null && !File.Exists(Path.Combine(dossier.FullName, "portfolio_siwa.sln")))
        {
            dossier = dossier.Parent;
        }

        Assert.NotNull(dossier);

        return Path.Combine(dossier!.FullName, "portfolio_siwa", "wwwroot", cheminWeb.TrimStart('/'));
    }

    /// <summary>Dimensions d'un PNG : elles sont écrites dans le premier bloc du fichier.</summary>
    private static (int Largeur, int Hauteur) LireDimensionsPng(string chemin)
    {
        var octets = File.ReadAllBytes(chemin);

        // Signature de 8 octets, puis le bloc IHDR : 4 de longueur, 4 de nom, largeur, hauteur.
        if (octets.Length < 24 || octets[1] != (byte)'P' || octets[2] != (byte)'N' || octets[3] != (byte)'G')
        {
            throw new InvalidDataException($"{chemin} n'est pas un PNG");
        }

        int Lire(int debut) => (octets[debut] << 24) | (octets[debut + 1] << 16) | (octets[debut + 2] << 8) | octets[debut + 3];

        return (Lire(16), Lire(20));
    }

    /// <summary>Dimensions d'un JPEG, lues dans son en-tête sans décoder l'image.</summary>
    private static (int Largeur, int Hauteur) LireDimensions(string chemin)
    {
        var octets = File.ReadAllBytes(chemin);
        var position = 2;

        while (position + 9 < octets.Length)
        {
            if (octets[position] != 0xFF)
            {
                position++;
                continue;
            }

            var marqueur = octets[position + 1];

            // SOF0, SOF1 et SOF2 portent la hauteur puis la largeur.
            if (marqueur is 0xC0 or 0xC1 or 0xC2)
            {
                var hauteur = (octets[position + 5] << 8) | octets[position + 6];
                var largeur = (octets[position + 7] << 8) | octets[position + 8];

                return (largeur, hauteur);
            }

            position += 2 + ((octets[position + 2] << 8) | octets[position + 3]);
        }

        throw new InvalidDataException($"{chemin} n'est pas un JPEG lisible");
    }
}
