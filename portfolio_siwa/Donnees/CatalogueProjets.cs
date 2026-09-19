using Microsoft.AspNetCore.Components;
using portfolio_siwa.Modeles;

namespace portfolio_siwa.Donnees
{
    /// <summary>
    /// Contenu des projets présentés sur la page d'accueil.
    /// Tout le texte vit ici : la page et les composants ne font que l'afficher.
    /// </summary>
    public static class CatalogueProjets
    {
        public static IReadOnlyList<FicheProjet> Tous { get; } =
        [
            new FicheProjet
            {
                Titre = "Site de l'Institut occitan de l'Aveyron",
                Categorie = "Plateforme patrimoniale",
                Annee = "2025",
                Cadre = "Stage de BUT informatique",
                Realisation = "Réalisé seul, un an de développement",
                Image = "/Images/projets/paistv.jpg",
                ImageLargeur = 1100,
                ImageHauteur = 589,
                LienSite = "https://ioa-pais.fr",
                Resume = new MarkupString(
                    "La plateforme ouvre au public trente ans de collectage occitan : plus de " +
                    "<strong>5\u00A0000 vidéos</strong>, <strong>29\u00A0000 sources</strong> et " +
                    "<strong>4\u00A0500 informateurs</strong>, répartis sur <strong>310 communes aveyronnaises</strong>. " +
                    "Chaque commune y retrouve son histoire, ses paysages et la voix de ses habitants. " +
                    "J'en assure toujours la maintenance et les évolutions."),
                ResumeCourt =
                    "Trente ans de collectage occitan ouverts au public : vidéos, sources, informateurs et communes.",
                Technos =
                [
                    new TechnoProjet("Blazor Server", "Images/logos/logoBlazor.png",
                        "Front-end dynamique et réactif, écrit en C#."),
                    new TechnoProjet("Java", "Images/logos/logoJava.png",
                        "Langage de l'API développée avec Spring Boot."),
                    new TechnoProjet("Spring Boot", "Images/logos/logoSpring.svg",
                        "API du projet : opérations CRUD sur MongoDB et dialogue avec Google Drive."),
                    new TechnoProjet("MongoDB", "Images/logos/logoMongo.png",
                        "Base NoSQL stockant les données sous forme de documents JSON."),
                    new TechnoProjet("Google Drive API", "Images/logos/logoGoogledrive.png",
                        "Stockage et récupération sécurisés des images du projet."),
                ],
            },

            new FicheProjet
            {
                Titre = "Pilotage des phases de chantiers",
                Categorie = "Outil métier",
                Annee = "2026",
                Cadre = "Alternance chez Enedis",
                Image = "/Images/projets/enedis-chantiers.jpg",
                ImageLargeur = 1100,
                ImageHauteur = 557,
                Resume = new MarkupString(
                    "Les chantiers de l'agence ingénierie d'Enedis Auvergne s'étalent sur plusieurs années. " +
                    "L'outil réunit leurs phases sur des diagrammes de Gantt et des graphiques de charge, " +
                    "pour planifier les travaux longue durée et répartir le travail entre prestataires et " +
                    "chargés de projet. Les données affichées ici sont anonymisées."),
                ResumeCourt =
                    "Planification des chantiers longue durée de l'agence ingénierie, en Gantt et graphiques de charge.",
                Technos =
                [
                    new TechnoProjet("Python", "Images/logos/logoPython.svg",
                        "Traitement des données de chantiers et calcul des plannings."),
                    new TechnoProjet("Streamlit", "Images/logos/logoStreamlit.svg",
                        "Interface de l'outil : filtres, diagrammes de Gantt et graphiques de charge."),
                    new TechnoProjet("MinIO", "Images/logos/logoMinio.svg",
                        "Stockage objet des données sauvegardées par l'application."),
                ],
            },

            new FicheProjet
            {
                Titre = "Myriade",
                Categorie = "Infrastructure distribuée",
                Annee = "2025 et 2026",
                Cadre = "Projet associatif",
                Realisation = "Réalisé seul",
                Image = "/Images/projets/logoMyriade.jpg",
                ImageLargeur = 1100,
                ImageHauteur = 586,
                Resume = new MarkupString(
                    "Myriade fait dialoguer des serveurs Minecraft dans les deux sens, y compris lorsqu'ils " +
                    "vivent derrière des proxys indépendants les uns des autres. Un système de portails " +
                    "transfère les joueurs d'un serveur à l'autre en s'appuyant sur cette communication " +
                    "instantanée. C'est techniquement le projet le plus poussé que j'aie mené : il permet " +
                    "des réseaux bien plus étendus que ce qu'autorise un proxy classique."),
                ResumeCourt =
                    "Communication instantanée entre serveurs Minecraft, sans proxy central, avec transfert des joueurs par portails.",
                Technos =
                [
                    new TechnoProjet("Redis", "Images/logos/logoRedis.svg",
                        "Cœur du projet : communication entre serveurs via Pub/Sub et données temporaires des transferts."),
                    new TechnoProjet("Java", "Images/logos/logoJava.png",
                        "Langage des plugins Minecraft embarquant la communication et les portails."),
                    new TechnoProjet("Paper MC", "Images/logos/logoPaper.webp",
                        "API Minecraft utilisée pour développer les plugins serveur."),
                    new TechnoProjet("Kotlin", "Images/logos/logoKotlin.png",
                        "Services back-end, pour une syntaxe concise et maintenable."),
                    new TechnoProjet("Spring Boot", "Images/logos/logoSpring.svg",
                        "APIs REST sécurisant les échanges entre serveurs et base de données."),
                    new TechnoProjet("MongoDB", "Images/logos/logoMongo.png",
                        "Serveurs, coordonnées des portails et identifiants des utilisateurs."),
                    new TechnoProjet("Blazor Server", "Images/logos/logoBlazor.png",
                        "Panel web d'administration des réseaux de serveurs."),
                ],
            },

            new FicheProjet
            {
                Titre = "GenseSense IA",
                Categorie = "Intelligence artificielle",
                Annee = "2025",
                Cadre = "TP noté de BUT informatique",
                Realisation = "Réalisé en binôme",
                Image = "/Images/projets/genesense.jpg",
                ImageLargeur = 1100,
                ImageHauteur = 550,
                LienGithub = "https://github.com/Siwa12100/projet-ia",
                Resume = new MarkupString(
                    "Deux intelligences artificielles : la première détecte le genre d'une personne à partir " +
                    "d'une image, la seconde reconnaît des personnes de ma promotion de BUT. Une IA de " +
                    "segmentation des visages prépare le travail des deux autres, et un panel web permet " +
                    "d'interagir directement avec le système. La classification par genre atteint " +
                    "<strong>99\u00A0%</strong> sur les hommes et <strong>95\u00A0%</strong> sur les femmes, " +
                    "la reconnaissance de personnes environ <strong>85\u00A0%</strong>."),
                ResumeCourt =
                    "Détection du genre et reconnaissance de personnes sur image, avec segmentation des visages et panel web.",
                Technos =
                [
                    new TechnoProjet("Python 3", "Images/logos/logoPython.svg",
                        "Développement des modèles d'IA et traitement des images."),
                    new TechnoProjet("Flask", "Images/logos/flask.svg",
                        "API web faisant le lien entre les IA et le panel."),
                    new TechnoProjet("YOLO", "Images/logos/logoYolo.png",
                        "Détection et segmentation des visages, rapides et précises."),
                    new TechnoProjet("Blazor Server", "Images/logos/logoBlazor.png",
                        "Panel web interactif, en communication temps réel avec le serveur."),
                    new TechnoProjet("Docker", "Images/logos/logoDocker.png",
                        "Déploiement de l'ensemble dans un environnement homogène."),
                ],
            },

            new FicheProjet
            {
                Titre = "Radar, suivi des affaires",
                Categorie = "Tableau de bord",
                Annee = "2026",
                Cadre = "Alternance chez Enedis",
                Image = "/Images/projets/enedis-radar.jpg",
                ImageLargeur = 1002,
                ImageHauteur = 561,
                Resume = new MarkupString(
                    "Radar suit l'avancée des affaires jalon par jalon, pour l'agence ingénierie comme pour " +
                    "les bases opérationnelles. Chaque étape est chiffrée et filtrable, ce qui permet de voir " +
                    "où les dossiers s'accumulent et de fluidifier leur déroulé jusqu'à la réalisation."),
                ResumeCourt =
                    "Tableau de bord du suivi des affaires, jalon par jalon, pour l'ingénierie et les bases opérationnelles.",
                Technos =
                [
                    new TechnoProjet("Power BI", "Images/logos/logoPowerbi.svg",
                        "Modélisation des données et tableau de bord distribué aux équipes."),
                ],
            },

            new FicheProjet
            {
                Titre = "Environnement de développement sécurisé pour l'IOA",
                Categorie = "DevOps & sécurité",
                Annee = "2025",
                Cadre = "Stage de BUT informatique",
                Realisation = "Réalisé seul",
                Image = "/Images/projets/ciioa.jpg",
                ImageLargeur = 1100,
                ImageHauteur = 588,
                Resume = new MarkupString(
                    "Administration d'un VPS sous Debian pour l'institut : sécurisation (pare-feu, SSH) et " +
                    "mise en place d'une chaîne CI/CD complète. Drone CI orchestre l'intégration continue, " +
                    "SonarQube analyse la qualité du code et une registry privée stocke les images Docker. " +
                    "<strong>Tous les projets de développement de l'institut</strong> passent désormais par " +
                    "cette chaîne, avec un gain net de temps et de fiabilité."),
                ResumeCourt =
                    "VPS Debian sécurisé et chaîne CI/CD complète, utilisée par tous les projets de développement de l'institut.",
                Technos =
                [
                    new TechnoProjet("Drone CI", "Images/logos/logoDrone.svg",
                        "Intégration continue : tests et déploiements automatisés des projets hébergés."),
                    new TechnoProjet("SonarQube", "Images/logos/logoSonar.png",
                        "Analyse statique du code : qualité, sécurité et maintenabilité."),
                    new TechnoProjet("Docker Compose", "Images/logos/logoCompose.png",
                        "Orchestration des services et des réseaux Docker."),
                    new TechnoProjet("Docker Registry", "Images/logos/logoRegistry.png",
                        "Stockage privé des images Docker, pour un déploiement contrôlé."),
                    new TechnoProjet("Debian", "Images/logos/logoDebian.png",
                        "Système du VPS : pare-feu, durcissement SSH et gestion des accès."),
                ],
            },

            new FicheProjet
            {
                Titre = "Site de l'Alliance d'Elendil",
                Categorie = "Site vitrine",
                Annee = "2025",
                Cadre = "Projet associatif",
                Realisation = "Réalisé seul, design compris",
                Image = "/Images/projets/elendil.jpg",
                ImageLargeur = 1100,
                ImageHauteur = 572,
                LienSite = "https://elendil-mc.fr",
                Resume = new MarkupString(
                    "Les joueurs francophones qui cherchent un serveur tombent souvent sur des vitrines " +
                    "confuses. Celle-ci présente clairement les serveurs de jeu et les concepts de l'Alliance, " +
                    "avec des informations récupérées en direct depuis l'API du jeu. Le projet est en train " +
                    "de devenir une référence dans la communauté."),
                ResumeCourt =
                    "Vitrine d'un réseau de serveurs de jeu, alimentée en direct par l'API du jeu.",
                Technos =
                [
                    new TechnoProjet("Blazor Server", "Images/logos/logoBlazor.png",
                        "Développement du site, avec la bibliothèque de composants MudBlazor."),
                    new TechnoProjet("Nginx", "Images/logos/logoNginx.png",
                        "Reverse proxy redirigeant les requêtes vers le bon conteneur."),
                    new TechnoProjet("Let's Encrypt", "Images/logos/logoEncrypt.png",
                        "Certificats SSL et communications en HTTPS."),
                    new TechnoProjet("Docker", "Images/logos/logoDocker.png",
                        "Conteneurisation du projet et déploiement simplifié."),
                ],
            },

            new FicheProjet
            {
                Titre = "Jogaires Inspector",
                Categorie = "Outil communautaire",
                Annee = "2024",
                Cadre = "Projet associatif",
                Image = "/Images/projets/jogaires.jpg",
                ImageLargeur = 1100,
                ImageHauteur = 567,
                Resume = new MarkupString(
                    "Les administrateurs de serveurs Minecraft y répertorient les comportements des joueurs : " +
                    "bannissement, avertissement, information ou recommandation. Chacun consulte les notes des " +
                    "autres, ce qui facilite la gestion entre serveurs. L'outil est utilisé par une " +
                    "<strong>dizaine d'administrateurs</strong> et recense <strong>plusieurs milliers de " +
                    "joueurs</strong>."),
                ResumeCourt =
                    "Répertoire partagé des comportements de joueurs, utilisé par une dizaine d'administrateurs de serveurs.",
                Technos =
                [
                    new TechnoProjet("Kotlin", "Images/logos/logoKotlin.png",
                        "Back-end du projet, pour un code concis et performant."),
                    new TechnoProjet("Spring Boot", "Images/logos/logoSpring.svg",
                        "API exposant des endpoints sécurisés pour créer et consulter les signalements."),
                    new TechnoProjet("MongoDB", "Images/logos/logoMongo.png",
                        "Stockage des signalements sous forme de documents JSON."),
                    new TechnoProjet("Blazor Server", "Images/logos/logoBlazor.png",
                        "Interface de consultation et d'ajout, en temps réel."),
                    new TechnoProjet("Docker", "Images/logos/logoDocker.png",
                        "Conteneurisation et gestion des services sur le serveur."),
                ],
            },

            new FicheProjet
            {
                Titre = "Virtogen",
                Categorie = "Application pédagogique",
                Annee = "2024",
                Cadre = "SAE de 3e année de BUT informatique",
                Realisation = "Réalisé en équipe, sur trois mois",
                Image = "/Images/projets/drosolab.jpg",
                ImageLargeur = 1075,
                ImageHauteur = 357,
                Resume = new MarkupString(
                    "Conçu avec des enseignants de l'UFR de biologie de Clermont-Ferrand, Virtogen simule " +
                    "l'évolution des caractéristiques génétiques dans des populations de " +
                    "drosophiles. Les étudiants manipulent une paillasse expérimentale, ajoutent des flacons " +
                    "de populations aux phénotypes choisis, puis observent les générations et testent les " +
                    "interactions génétiques."),
                ResumeCourt =
                    "Simulation de génétique des populations de drosophiles, pour les TP de biologie.",
                Technos =
                [
                    new TechnoProjet("Vue.js", "Images/logos/logoVue.png",
                        "Interface de manipulation des flacons et d'observation des populations en temps réel."),
                    new TechnoProjet("Symfony", "Images/logos/logoSymfony.png",
                        "Back-end des données et des règles métier, exposé en API REST."),
                    new TechnoProjet("Doctrine & MySQL", "Images/logos/logoDoctrine.png",
                        "Phénotypes, configurations de simulation et évolution des générations."),
                    new TechnoProjet("Docker", "Images/logos/logoDocker.png",
                        "Conteneurisation du projet pour un environnement stable et reproductible."),
                ],
            },
        ];
    }
}
