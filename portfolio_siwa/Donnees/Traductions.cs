using portfolio_siwa.Modeles;

namespace portfolio_siwa.Donnees
{
    /// <summary>
    /// Toutes les chaînes d'interface, dans les trois langues du site.
    /// Les textes des projets vivent dans <see cref="CatalogueProjets"/>.
    /// </summary>
    public static class Traductions
    {
        // ===== Métadonnées de la page =====
        public static Texte TitrePage { get; } = new(
            "Jean Marcillac, développeur",
            "Jean Marcillac, developer",
            "Jean Marcillac, desvolopaire");

        public static Texte Description { get; } = new(
            "Jean Marcillac, étudiant en ingénierie informatique à l'INSA Lyon et data analyste en alternance chez Enedis. Projets web, IA et infrastructure.",
            "Jean Marcillac, computer engineering student at INSA Lyon and data analyst apprentice at Enedis. Web, AI and infrastructure projects.",
            "Jean Marcillac, estudiant en engenhariá informatica a l'INSA Lyon e analista de donadas en alternància a Enedis. Projèctes web, IA e infrastructura.");

        public static Texte DescriptionPartage { get; } = new(
            "Étudiant ingénieur à l'INSA Lyon et data analyste en alternance. Découvrez mes projets web, IA et infrastructure.",
            "Engineering student at INSA Lyon and data analyst apprentice. Discover my web, AI and infrastructure projects.",
            "Estudiant engenhaire a l'INSA Lyon e analista de donadas en alternància. Descobrissètz mos projèctes web, IA e infrastructura.");

        public static Texte DescriptionLegales { get; } = new(
            "Mentions légales du portfolio de Jean Marcillac : éditeur, hébergement, propriété intellectuelle et données personnelles.",
            "Legal notice for Jean Marcillac's portfolio: publisher, hosting, intellectual property and personal data.",
            "Mencions legalas del portfòli de Jean Marcillac : editor, albergament, proprietat intellectuala e donadas personalas.");

        public static Texte Metier { get; } = new(
            "Étudiant ingénieur en informatique et data analyste en alternance",
            "Computer engineering student and data analyst apprentice",
            "Estudiant engenhaire en informatica e analista de donadas en alternància");

        public static Texte PhotoAlt { get; } = new(
            "Portrait de Jean Marcillac", "Portrait of Jean Marcillac", "Retrach de Jean Marcillac");

        // ===== Navigation =====
        public static Texte NavAccueil { get; } = new("Accueil", "Home", "Acuèlh");
        public static Texte NavProjets { get; } = new("Projets", "Projects", "Projèctes");
        public static Texte NavAPropos { get; } = new("À propos", "About", "A prepaus");
        public static Texte NavMenu { get; } = new("Menu", "Menu", "Menut");
        public static Texte NavLangue { get; } = new("Langue", "Language", "Lenga");
        public static Texte NavCvTitre { get; } = new(
            "Mon CV en ligne", "My resume online", "Mon CV en linha");

        public static Texte AllerAuContenu { get; } = new(
            "Aller au contenu", "Skip to content", "Anar al contengut");

        public static Texte OuvrirMenu { get; } = new(
            "Ouvrir le menu", "Open the menu", "Dobrir lo menut");

        public static Texte FermerMenu { get; } = new(
            "Fermer le menu", "Close the menu", "Tampar lo menut");

        // ===== Haut de page =====
        public static Texte HeroEtiquette { get; } = new(
            "Ingénierie informatique", "Computer engineering", "Engenhariá informatica");

        public static Texte HeroRole { get; } = new(
            "Étudiant en ingénierie informatique à l'INSA Lyon, data analyste en alternance chez Enedis.",
            "Computer engineering student at INSA Lyon, data analyst apprentice at Enedis.",
            "Estudiant en engenhariá informatica a l'INSA Lyon, analista de donadas en alternància a Enedis.");

        public static Texte HeroApproche { get; } = new(
            "Je développe une approche concrète et expérimentale du numérique, attentive aux avancées de l'IA, aux méthodologies de développement et aux technologies émergentes.",
            "I take a hands-on, experimental approach to technology, with an eye on advances in AI, on development methods and on emerging tools.",
            "Desvolopi una aprocha concreta e experimentala del numeric, atentiva a las avançadas de l'IA, a las metodologias de desvolopament e a las tecnologias emergentas.");

        public static Texte BoutonProjets { get; } = new(
            "Voir mes projets", "See my projects", "Veire mos projèctes");

        public static Texte BoutonAPropos { get; } = new(
            "À propos de moi", "About me", "A prepaus");

        // ===== Section des projets =====
        public static Texte TitreRealisations { get; } = new(
            "Réalisations", "Work", "Realizacions");

        public static Texte AutresProjets { get; } = new(
            "Autres projets", "Other projects", "Autres projèctes");

        public static Texte VoirLeSite { get; } = new("Voir le site", "Visit the site", "Veire lo sit");
        public static Texte CodeSource { get; } = new("Code source", "Source code", "Còde font");

        public static Texte EnSavoirPlus { get; } = new(
            "En savoir plus", "Read more", "Ne saber mai");

        /// <summary>Texte alternatif des captures de projets, complété par le titre.</summary>
        public static Texte ApercuDe { get; } = new(
            "Aperçu du projet", "Screenshot of", "Ulhada del projècte");

        // ===== À propos =====
        public static Texte TitreAPropos { get; } = new("À propos", "About", "A prepaus");

        public static Texte AProposOrigine { get; } = new(
            "Originaire de l'Aveyron, j'aime créer des projets concrets, utiles et porteurs de sens. Mes études, mon engagement associatif et mes expériences professionnelles m'ont appris à allier la technique et la gestion de projet.",
            "I grew up in the Aveyron, and I like building things that are concrete, useful and meaningful. Studies, non-profit work and professional experience taught me to hold together the technical side and the project management side.",
            "Originari de l'Avairon, m'agrada crear de projèctes concrets, utils e portaires de sens. Mos estudis, mon engatjament associatiu e mas experiéncias professionalas m'an apres a ligar la tecnica e la gestion de projècte.");

        public static Texte AProposReflexion { get; } = new(
            "Au-delà de la technique, la dissonance entre les promesses du numérique et ses réalités énergétiques et matérielles m'interroge. Curieux d'histoire et de culture, je regarde aussi comment il peut servir à transmettre et valoriser ces sujets, notamment la culture occitane auprès des jeunes générations.",
            "Beyond the technical side, the gap between what technology promises and what it actually costs in energy and materials keeps me questioning. Curious about history and culture, I also look at how it can help pass those subjects on, notably Occitan culture to younger generations.",
            "Al delà de la tecnica, la dissonància entre las promesas del numeric e sas realitats energeticas e materialas m'interròga. Curiós d'istòria e de cultura, espii tanben cossí lo numeric pòt servir a transmetre e a valorizar aqueles subjèctes, en particular la cultura occitana demest las joves generacions.");

        public static Texte AProposConclusion { get; } = new(
            "D'où l'envie de mettre mes compétences au service de projets et d'organisations utiles, responsables et durables, et un engagement pour la transmission de la langue et de la culture occitanes.",
            "Hence the wish to put my skills at the service of useful, responsible and sustainable projects and organisations, along with a commitment to passing on the Occitan language and culture.",
            "D'aquí l'enveja de metre mas competéncias al servici de projèctes e d'organizacions utils, responsables e durables, e un engatjament per la transmission de la lenga e de la cultura occitanas.");

        // ===== Contact =====
        public static Texte MeContacter { get; } = new("Me contacter", "Get in touch", "Me contactar");

        public static Texte ContactAccroche { get; } = new(
            "Une question, une opportunité, ou juste envie d'échanger ?",
            "A question, an opportunity, or simply a chat?",
            "Una question, una escasença, o solament enveja de charrar ?");

        public static Texte EcrivezMoi { get; } = new("Écrivez-moi", "Write to me", "Escrivètz-me");
        public static Texte CopierAdresse { get; } = new(
            "Copier l'adresse", "Copy the address", "Copiar l'adreça");

        public static Texte CopierDiscord { get; } = new(
            "Copier mon identifiant Discord", "Copy my Discord handle", "Copiar mon identificant Discord");

        public static Texte DiscordCopie { get; } = new(
            "Identifiant Discord copié", "Discord handle copied", "Identificant Discord copiat");

        public static Texte AdresseCopiee { get; } = new(
            "Adresse mail copiée", "Email address copied", "Adreça de corrièl copiada");

        public static Texte EnvoyerMail { get; } = new(
            "M'envoyer un mail", "Send me an email", "Me mandar un corrièl");

        public static Texte ProfilGithub { get; } = new(
            "Mon profil GitHub", "My GitHub profile", "Mon perfil GitHub");

        // ===== Pied de page et divers =====
        public static Texte PiedPortfolio { get; } = new(
            "Portfolio réalisé par mes soins, en .NET Blazor.",
            "Portfolio built by me, with .NET Blazor.",
            "Portfòli realizat per ieu meteis, amb .NET Blazor.");

        public static Texte CodeDuPortfolio { get; } = new(
            "Code du portfolio", "Portfolio source", "Còde del portfòli");

        public static Texte RetourHaut { get; } = new(
            "Revenir en haut", "Back to top", "Tornar amont");

        public static Texte RetourAccueil { get; } = new(
            "Retour à l'accueil", "Back to home", "Tornar a l'acuèlh");

        // ===== Pages d'erreur =====
        public static Texte Erreur { get; } = new("Erreur", "Error", "Error");

        public static Texte PageIntrouvableTitre { get; } = new(
            "Cette page n'existe pas", "This page does not exist", "Aquesta pagina existís pas");

        public static Texte PageIntrouvableTexte { get; } = new(
            "Le lien est peut-être incomplet, ou la page a changé d'adresse.",
            "The link may be incomplete, or the page may have moved.",
            "Benlèu que lo ligam es incomplet, o que la pagina a cambiat d'adreça.");

        public static Texte ErreurTitre { get; } = new(
            "Quelque chose s'est mal passé", "Something went wrong", "Quicòm a mal virat");

        public static Texte ErreurTexte { get; } = new(
            "Réessayez dans un instant. Si le problème persiste, écrivez-moi.",
            "Try again in a moment. If it keeps happening, write to me.",
            "Ensajatz tornarmai dins un moment. Se lo problèma dura, escrivètz-me.");

        public static Texte ErreurIdentifiant { get; } = new(
            "Identifiant de la requête", "Request identifier", "Identificant de la requèsta");

        // ===== Mentions légales =====
        public static Texte MentionsLegales { get; } = new(
            "Mentions légales", "Legal notice", "Mencions legalas");

        public static Texte LegalEditeurTitre { get; } = new(
            "Éditeur du site", "Site publisher", "Editor del sit");

        public static Texte LegalEditeurTexte { get; } = new(
            "Jean Marcillac, éditeur et directeur de la publication.",
            "Jean Marcillac, publisher and director of publication.",
            "Jean Marcillac, editor e director de la publicacion.");

        public static Texte LegalContact { get; } = new("Contact", "Contact", "Contacte");

        public static Texte LegalHebergementTitre { get; } = new(
            "Hébergement", "Hosting", "Albergament");

        public static Texte LegalHebergementTexte { get; } = new(
            "Site hébergé par l'association SKORPIA, association déclarée régie par la loi du 1er juillet 1901, sur sa propre infrastructure, dans des centres de données situés en France.",
            "This site is hosted by SKORPIA, a French non-profit association under the law of 1 July 1901, on its own infrastructure, in data centres located in France.",
            "Sit albergat per l'associacion SKORPIA, associacion declarada regida per la lei del 1èr de julhet de 1901, sus sa pròpria infrastructura, dins de centres de donadas situats en França.");

        public static Texte LegalProprieteTitre { get; } = new(
            "Propriété intellectuelle", "Intellectual property", "Proprietat intellectuala");

        public static Texte LegalProprieteTexte { get; } = new(
            "Les textes et le code de ce site sont l'œuvre de son éditeur. Les captures d'écran présentent des projets réalisés dans un cadre scolaire, professionnel ou associatif, et restent la propriété de leurs commanditaires respectifs. Les logos des technologies et des organisations citées appartiennent à leurs détenteurs et ne sont utilisés qu'à des fins d'identification.",
            "The texts and the code of this site are the work of its publisher. The screenshots show projects carried out in an academic, professional or non-profit setting, and remain the property of their respective owners. Technology and organisation logos belong to their holders and are used for identification only.",
            "Los tèxtes e lo còde d'aqueste sit son l'òbra de son editor. Las capturas d'ecran presentan de projèctes realizats dins un encastre escolar, professional o associatiu, e demòran la proprietat de lors comanditaris. Los logos de las tecnologias e de las organizacions citadas apartenon a lors detentors e son pas utilizats que per identificacion.");

        public static Texte LegalDonneesTitre { get; } = new(
            "Données personnelles", "Personal data", "Donadas personalas");

        public static Texte LegalDonneesTexte { get; } = new(
            "Ce site ne dépose aucun cookie, n'utilise aucun outil de mesure d'audience et ne collecte aucune donnée personnelle. Aucun formulaire n'y figure : les prises de contact se font par courrier électronique, à votre initiative.",
            "This site sets no cookies, uses no analytics and collects no personal data. There is no form: getting in touch happens by email, at your own initiative.",
            "Aqueste sit depausa pas cap de cookie, utiliza pas cap d'aisina de mesura d'audiéncia e amassa pas cap de donada personala. I a pas cap de formulari : las presas de contacte se fan per corrièl, a vòstra iniciativa.");
    }
}
