using Microsoft.AspNetCore.Components;


namespace portfolio_siwa.Pages.Index
{
    public partial class Index
    {
        protected string? TitreProjetGenseSense;
        protected MarkupString? DescriptionProjetGenseSense;
        protected string? GeneSenseDescriptionPython;
        protected string? GeneSenseDescriptionFlask;
        protected string? GeneSenseDescriptionBlazor;
        protected string? GeneSenseDescriptionDocker;
        protected string? GeneSenseDescriptionYolo;
        protected string? GenseSenseGithub;

        protected override void OnInitialized()
        {
            TitreProjetGenseSense = "GenseSense IA";
            DescriptionProjetGenseSense = new MarkupString("GenseSense est un projet ayant consisté à développer deux intelligences artificielles. La première détecte le genre d'une personne à partir d'une image, tandis que la seconde reconnaît certaines personnes de ma promotion de BUT. <br> En complément, une IA dédiée à la segmentation des visages facilite la classification par genre et par personnes. Enfin, un panel web a été développé pour permettre une interaction simple et directe avec le système.");
            this.GeneSenseDescriptionPython = "Langage utilisé pour développer les modèles d'IA et traiter les images.";
            this.GeneSenseDescriptionFlask = "Framework employé pour créer l'API Web qui communique entre les IA et le panel web.";
            this.GeneSenseDescriptionBlazor = "Plateforme utilisée pour concevoir le panel web interactif. Elle offre une communication en temps réel entre le client et le serveur.";
            this.GeneSenseDescriptionDocker = "Utilisation pour le déploiement de l'ensemble du projet dans un environnement homogène.";
            this.GeneSenseDescriptionYolo = "Bibliothèque utilisée pour détecter et segmenter les visages dans les images. Elle fournit des performances rapides et précises pour l'extraction des zones d'intérêt.";

        }
    }
}