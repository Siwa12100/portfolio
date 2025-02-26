using Microsoft.AspNetCore.Components;
using portfolio_siwa.Modeles;


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
        protected string? GenseSenseGithub = "https://github.com/Siwa12100/projet-ia";
        protected MarkupString? GenseSenseTextePresentation;
        protected DetailsProjet? DetailsProjetGenseSense;

        protected string? TitreProjetDrosolab;
        protected MarkupString? DescriptionProjetDrosolab;
        protected string? DrosolabDescriptionSymfony;
        protected string? DrosolabDescriptionVue;
        protected string? DrosolabDescriptionDocker;
        protected string? DrosolabDescriptionMysql;

        protected string? TitreProjetSiteElendil;
        protected MarkupString? DescriptionProjetSiteElendil;
        protected string? ElendilDescriptionBlazor;
        protected string? ElendilDescriptionNginx;
        protected string? ElendilDescriptionDocker;
        protected string? ElendilDescriptionLetsencrypt;

        protected string? TitreProjetLibPais;
        protected MarkupString? DescriptionProjetLibPais;
        protected string? LibPaisDescriptionBlazor;
        protected string? LibPaisDescriptionSpringBoot;
        protected string? LibPaisDescriptionJava;
        protected string? LibPaisDescriptionMongoDB;
        protected string? LibPaisDescriptionDocker;
        protected string? LibPaisDescriptionGoogleDriveApi;

        protected string? TitreProjetIoaCi;
        protected MarkupString? DescriptionProjetIoaCi;
        protected string? IoaCiDescriptionDroneCI;
        protected string? IoaCiDescriptionDockerCompose;
        protected string? IoaCiDescriptionSonar;
        protected string? IoaCiDescriptionDebian;
        protected string? IoaCiDescriptionRegistry;

        protected string? TitreProjetJogaires;
        protected MarkupString? DescriptionProjetJogaires;
        protected string? JogairesDescriptionBlazor;
        protected string? JogairesDescriptionKotlin;
        protected string? JogairesDescriptionSpringBoot;
        protected string? JogairesDescriptionMongoDB;
        protected string? JogairesDescriptionDocker;

        protected string? TitreProjetMyriade;
        protected MarkupString? DescriptionProjetMyriade;
        protected string? MyriadeDescriptionBlazor;
        protected string? MyriadeDescriptionSpringBoot;
        protected string? MyriadeDescriptionMongoDB;
        protected string? MyriadeDescriptionJava;
        protected string? MyriadeDescriptionKotlin;
        protected string? MyriadeDescriptionRedis;
        protected string? MyriadeDescriptionPaper;

        protected override void OnInitialized()
        {
            TitreProjetGenseSense = "GenseSense IA";
            DescriptionProjetGenseSense = new MarkupString("GenseSense est un projet ayant consisté à développer deux intelligences artificielles. La première détecte le genre d'une personne à partir d'une image, tandis que la seconde reconnaît certaines personnes de ma promotion de BUT. <br> En complément, une IA dédiée à la segmentation des visages facilite la classification par genre et par personnes. Enfin, un panel web a été développé pour permettre une interaction simple et directe avec le système.");
            this.GeneSenseDescriptionPython = "Langage utilisé pour développer les modèles d'IA et traiter les images.";
            this.GeneSenseDescriptionFlask = "Framework employé pour créer l'API Web qui communique entre les IA et le panel web.";
            this.GeneSenseDescriptionBlazor = "Plateforme utilisée pour concevoir le panel web interactif. Elle offre une communication en temps réel entre le client et le serveur.";
            this.GeneSenseDescriptionDocker = "Utilisation pour le déploiement de l'ensemble du projet dans un environnement homogène.";
            this.GeneSenseDescriptionYolo = "Bibliothèque utilisée pour détecter et segmenter les visages dans les images. Elle fournit des performances rapides et précises pour l'extraction des zones d'intérêt.";

            this.GenseSenseTextePresentation = new MarkupString("GenseSense repose sur trois modules : segmentation, classification par genre et reconnaissance de personnes. " + 
                "La segmentation utilise Ultralytics/YOLO pour détecter et isoler automatiquement les visages dans les images. " + 
                "La classification par genre s’appuie sur un dataset équilibré (99% pour les hommes, 95% pour les femmes). " +
                "La reconnaissance de personnes identifie des individus spécifiques de ma promotion avec une précision d’environ 85 %.  " + 
                "Les modèles sont développés en Python 3 et intégrés dans une API Flask assurant la communication avec l’interface web.  " + 
                "Le panel interactif, conçu en Blazor Server, permet aux utilisateurs de charger des images et d’obtenir des résultats en temps réel. " +  
                "L’ensemble est conteneurisé avec Docker pour garantir un déploiement stable et reproductible sur un serveur.");

            this.DetailsProjetGenseSense = new DetailsProjet
            {
                Titre = "GenseSense IA - Détails",
                Texte = this.GenseSenseTextePresentation,
                CheminImage = "images/projets/schemaGenseSense.png"
            };

            this.TitreProjetDrosolab = "Virtogen";
            this.DescriptionProjetDrosolab = new MarkupString("Projet réalisé en partenariat avec des professeurs de l'UFR de biologie de Clermont-Ferrand. Il  permet de simuler l’évolution des caractéristiques génétiques dans des populations de drosophiles. Les étudiants manipulent une paillasse expérimentale où ils ajoutent des flacons contenant des populations d'insectes aux phénotypes spécifiques. Ils peuvent observer l’évolution des générations et tester différentes interactions génétiques. ");
            this.DrosolabDescriptionVue = "Framework utilisé pour développer l’interface interactive, permettant aux étudiants de manipuler facilement les flacons et d’observer l’évolution des populations en temps réel.";
            this.DrosolabDescriptionSymfony = "Back-end assurant la gestion des données et des règles métier liées aux populations et aux simulations. Il expose une API REST utilisée par le front.";
            this.DrosolabDescriptionDocker = "Utilisé pour conteneuriser l’ensemble du projet et simplifier son déploiement, garantissant un environnement stable et reproductible.";
            this.DrosolabDescriptionMysql = "Base de données relationnelle stockant les phénotypes, les configurations de simulations et l’évolution des générations, avec Doctrine comme ORM pour gérer les entités.";
        
            this.TitreProjetSiteElendil = "Site de l'Alliance d'Elendil";
            this.DescriptionProjetSiteElendil = new MarkupString("Réalisation du site vitrine du projet dans le domaine du jeu vidéo : <a style='color: #2E9CCA;' class='projet' href='https://elendil-mc.fr'>Alliance d'Elendil</a>. Présentation des différents serveurs de jeu, des différents concepts de l'Alliance et récupération depuis l'api du jeu des informations en direct sur les serveurs et leurs joueurs");
            this.ElendilDescriptionBlazor = "Framework utilisé pour développer le site web. Utilisation de la bibliothèque de composants MudBlazor. ";
            this.ElendilDescriptionNginx = "Utilisé en mode reverse proxy pour rediriger les requêtes vers le bon conteneur Docker.";
            this.ElendilDescriptionDocker = "Utilisé pour conteneuriser l’ensemble du projet et simplifier son déploiement.";
            this.ElendilDescriptionLetsencrypt = "Utilisé pour générer des certificats SSL et sécuriser les communications en https.";

            this.TitreProjetLibPais = "PAÍS TV & Librariá";
            this.DescriptionProjetLibPais = new MarkupString("<a class='projet' style='color: #2E9CCA;' href='https://ioa-pais.fr'>PAÍS TV</a> & <a style='color: #2E9CCA;' class='projet' href='https://libraria.ioa-pais.fr'>Librariá</a> sont deux plateformes créées pour valoriser le patrimoine occitan. Librariá répertorie et met en avant plus de 2500 ouvrages disponibles à l'Institut occitan de l'Aveyron, offrant une exploration détaillée grâce à un moteur de recherche et une interface intuitive. PAÍS TV regroupe et classe les vidéos produites par l’IOA sur YouTube, facilitant l’accès aux séries pédagogiques et documentaires sur la langue et la culture occitanes.");
            this.LibPaisDescriptionBlazor = "Framework utilisé pour le développement du front-end, permettant de créer une interface dynamique et réactive en C#. ";
            this.LibPaisDescriptionSpringBoot = "Back-end du projet, servant d’API pour gérer les opérations CRUD sur les données stockées dans MongoDB. Il gère également l’interaction avec Google Drive pour le stockage et la récupération des images.";
            this.LibPaisDescriptionJava = "Langage utilisé pour développer l’API avec Spring Boot.";
            this.LibPaisDescriptionMongoDB = "Base de données NoSQL utilisée pour stocker les données du projet sous forme de documents JSON.";
            this.LibPaisDescriptionGoogleDriveApi = "Service utilisé pour stocker et gérer les images du projet. L’API permet à Spring Boot d’accéder aux fichiers de manière sécurisée et organisée.";
            this.LibPaisDescriptionDocker = "Utilisé pour conteneuriser l’ensemble du projet et simplifier son déploiement.";
        
            this.TitreProjetIoaCi = "Environnement de développement sécurisé pour l'IOA";
            this.DescriptionProjetIoaCi = new MarkupString("Ce projet a consisté en la mise en place d'un environnement de développement sécurisé pour l'Institut Occitan de l'Aveyron. Il a s'agit d'administrer un VPS sous Debian, d'assurer sa sécurisation (pare-feu, SSH, etc.) ainsi que le déploiement d’un processus de CI/CD complet. Un serveur Drone CI orchestre l'intégration continue, tandis que SonarQube assure l'analyse de la qualité du code. Une registry privée stocke les images Docker, et l’ensemble est géré via Docker Compose pour assurer la communication et la gestion des services.");
            this.IoaCiDescriptionDroneCI = "Outil utilisé pour l'intégration continue, permettant l'exécution automatisée des tests et des déploiements des projets hébergés sur le serveur. Il assure une gestion efficace des workflows CI/CD.";
            this.IoaCiDescriptionDockerCompose = "Utilisé pour orchestrer le déploiement et la configuration des services (Drone CI, SonarQube, registry). Il facilite la mise en place des réseaux Docker et la communication entre les différents conteneurs.";
            this.IoaCiDescriptionSonar = "Analyse statique du code permettant d'évaluer la qualité, la sécurité et la maintenabilité des projets. Il est intégré au pipeline CI/CD pour fournir des rapports détaillés sur les vulnérabilités et les bonnes pratiques.";
            this.IoaCiDescriptionDebian = "Système d’exploitation du VPS sur lequel l’environnement de développement est déployé. La sécurisation inclut la configuration d’un pare-feu, le durcissement de SSH et la gestion des accès.";
            this.IoaCiDescriptionRegistry = "Stocke en privé sur le VPS les images Docker des projets pour un déploiement contrôlé et sécurisé..";
        
            this.TitreProjetJogaires = "Jogaires Inspector";
            this.DescriptionProjetJogaires = new MarkupString("Ce projet permet aux administrateurs de serveurs Minecraft de répertorier les comportements des joueurs. Ils peuvent signaler un bannissement, un avertissement, une information générale ou une recommandation. Chaque administrateur peut consulter les notes laissées par d’autres, facilitant la gestion des joueurs entre serveurs. Sécurisé et fiable, le système est déjà utilisé par une dizaine d’administrateurs et recense plusieurs milliers de joueurs.");
            this.JogairesDescriptionBlazor = "Utilisé pour le développement du front-end, offrant une interface fluide et interactive permettant aux administrateurs de consulter et ajouter des informations sur les joueurs en temps réel.";
            this.JogairesDescriptionSpringBoot = "API principale assurant la gestion des données et la logique métier. Il permet d’exposer des endpoints sécurisés pour la création, la modification et la consultation des signalements des joueurs.";
            this.JogairesDescriptionMongoDB = "Base de données NoSQL stockant les signalements des joueurs sous forme de documents JSON.";
            this.JogairesDescriptionDocker = "Assure la conteneurisation du projet, facilitant le déploiement et la gestion des services sur le serveur, garantissant un environnement stable et sécurisé.";        
            this.JogairesDescriptionKotlin = "Langage utilisé pour le back-end. Son intégration avec Spring Boot facilite l’écriture d’un code concis et performant.";
        
            this.TitreProjetMyriade = "Myriade";
            this.DescriptionProjetMyriade = new MarkupString("Myriade est un projet encore en bêta, permettant une communication instantanée bidirectionnelle entre serveurs Minecraft sans dépendre d’un proxy comme Velocity ou BungeeCord. Il permet de créer des réseaux de serveurs massifs, bien plus étendus que ceux limités par les proxys traditionnels. Un système de portails assure le transfert des joueurs entre serveurs, exploitant cette infrastructure de communication en temps réel. Ce projet s'inscrit dans une dynamique d’univers virtuel interconnecté, posant les prémices d’un métavers dans Minecraft et ouvrant la voie à un écosystème de plugins inter-serveurs.");
            this.MyriadeDescriptionBlazor = "Langage principal des plugins Minecraft, permettant l'intégration du système de communication et des portails directement dans le jeu.";
            this.MyriadeDescriptionPaper = "API Minecraft utilisée pour développer les plugins serveur, permettant l’intégration fluide du système de communication et de transfert des joueurs.";
            this.MyriadeDescriptionRedis = "Technologie clé du projet, utilisée pour la communication instantanée entre serveurs via Redis Pub/Sub, ainsi que pour stocker en mémoire vive des données temporaires liées aux transferts de joueurs.";
            this.MyriadeDescriptionSpringBoot = "Framework utilisé pour créer les APIs REST, assurant la gestion et la sécurisation des échanges de données entre les serveurs et la base de données.";
            this.MyriadeDescriptionKotlin = "Utilisé pour le développement des services back-end, apportant une syntaxe moderne et concise, tout en garantissant performance et maintenabilité.";
            this.MyriadeDescriptionMongoDB = "Base de données NoSQL stockant les informations des serveurs, les coordonnées des portails, ainsi que les identifiants des utilisateurs pour les connexions.";
            this.MyriadeDescriptionJava = "Langage principal des plugins Minecraft, permettant l'intégration du système de communication et des portails directement dans le jeu.";
        
        }
    }
}