using portfolio_siwa.Modeles;

namespace portfolio_siwa.Donnees
{
    /// <summary>
    /// Contenu des projets présentés sur la page d'accueil, dans les trois langues.
    /// Tout le texte vit ici : la page et les composants ne font que l'afficher.
    /// L'ordre compte : les quatre premières fiches sortent en grandes cartes.
    /// </summary>
    public static class CatalogueProjets
    {
        // Cadres et rôles récurrents, écrits une fois puis réutilisés.
        private static readonly Texte StageBut =
            new("Stage de BUT informatique", "Computer science degree internship", "Estagi de BUT informatica");

        private static readonly Texte Alternance =
            new("Alternance chez Enedis", "Apprenticeship at Enedis", "Alternància a Enedis");

        private static readonly Texte Associatif =
            new("Projet associatif", "Non-profit project", "Projècte associatiu");

        private static readonly Texte Seul =
            new("Réalisé seul", "Built solo", "Realizat sol");

        private static readonly Texte RoleDocker = new(
            "Conteneurisation du projet, pour un déploiement stable et reproductible.",
            "Containerises the project for a stable, reproducible deployment.",
            "Contenerizacion del projècte, per un desplegament estable e reproductible.");

        public static IReadOnlyList<FicheProjet> Tous { get; } =
        [
            new FicheProjet
            {
                Titre = new Texte(
                    "Site de l'Institut occitan de l'Aveyron",
                    "Website of the Institut occitan de l'Aveyron",
                    "Sit de l'Institut occitan de l'Avairon"),
                Categorie = new Texte("Plateforme patrimoniale", "Heritage platform", "Plataforma patrimoniala"),
                Annee = Texte.Unique("2025"),
                Cadre = StageBut,
                Realisation = new Texte(
                    "Réalisé seul, un an de développement",
                    "Built solo, one year of development",
                    "Realizat sol, una annada de desvolopament"),
                Image = "/Images/projets/paistv.jpg",
                ImageLargeur = 1100,
                ImageHauteur = 615,
                LienSite = "https://ioa-pais.fr",
                Resume = new Texte(
                    "La plateforme ouvre au public trente ans de collectage occitan : plus de " +
                    "<strong>5 000 vidéos</strong>, <strong>29 000 sources</strong> et " +
                    "<strong>4 500 informateurs</strong>, répartis sur <strong>310 communes " +
                    "aveyronnaises</strong>. Chaque commune y retrouve son histoire, ses paysages et la " +
                    "voix de ses habitants. J'en assure toujours la maintenance et les évolutions.",

                    "The platform opens thirty years of Occitan field recordings to the public: over " +
                    "<strong>5,000 videos</strong>, <strong>29,000 sources</strong> and " +
                    "<strong>4,500 contributors</strong>, across <strong>310 towns and villages</strong> " +
                    "of the Aveyron. Each one finds its history, its landscapes and the voices of its " +
                    "people. I still maintain and develop the site.",

                    "La plataforma dobrís al public trenta ans de collectatge occitan : mai de " +
                    "<strong>5 000 vidèos</strong>, <strong>29 000 fonts</strong> e " +
                    "<strong>4 500 informators</strong>, espandits sus <strong>310 comunas " +
                    "avaironesas</strong>. Cada comuna i tròba son istòria, sos paisatges e la votz de " +
                    "sos abitants. Ne fau totjorn la mantenença e las evolucions."),
                ResumeCourt = new Texte(
                    "Trente ans de collectage occitan ouverts au public : vidéos, sources, informateurs et communes.",
                    "Thirty years of Occitan field recordings opened to the public: videos, sources, contributors and towns.",
                    "Trenta ans de collectatge occitan dobèrts al public : vidèos, fonts, informators e comunas."),
                Technos =
                [
                    new TechnoProjet("Blazor Server", "/Images/logos/logoBlazor.png", new Texte(
                        "Front-end dynamique et réactif, écrit en C#.",
                        "Dynamic, reactive front-end written in C#.",
                        "Front-end dinamic e reactiu, escrich en C#.")),
                    new TechnoProjet("Java", "/Images/logos/logoJava.png", new Texte(
                        "Langage de l'API développée avec Spring Boot.",
                        "Language of the API built with Spring Boot.",
                        "Lenguatge de l'API desvolopada amb Spring Boot.")),
                    new TechnoProjet("Spring Boot", "/Images/logos/logoSpring.svg", new Texte(
                        "API du projet : opérations CRUD sur MongoDB et dialogue avec Google Drive.",
                        "Project API: CRUD operations on MongoDB and exchanges with Google Drive.",
                        "API del projècte : operacions CRUD sus MongoDB e escambis amb Google Drive.")),
                    new TechnoProjet("MongoDB", "/Images/logos/logoMongo.png", new Texte(
                        "Base NoSQL stockant les données sous forme de documents JSON.",
                        "NoSQL database storing the data as JSON documents.",
                        "Basa NoSQL qu'emmagazina las donadas en documents JSON.")),
                    new TechnoProjet("Google Drive API", "/Images/logos/logoGoogledrive.png", new Texte(
                        "Stockage et récupération sécurisés des images du projet.",
                        "Secure storage and retrieval of the project images.",
                        "Emmagazinatge e recuperacion securizats dels imatges del projècte.")),
                ],
            },

            new FicheProjet
            {
                Titre = new Texte(
                    "Pilotage des phases de chantiers",
                    "Worksite phase planning",
                    "Pilotatge de las fasas de chantièrs"),
                Categorie = new Texte("Outil métier", "Internal tool", "Aisina de mestièr"),
                Annee = Texte.Unique("2026"),
                Cadre = Alternance,
                Image = "/Images/projets/enedis-chantiers.jpg",
                ImageLargeur = 1100,
                ImageHauteur = 557,
                Resume = new Texte(
                    "Les chantiers de l'agence ingénierie d'Enedis Auvergne s'étalent sur plusieurs " +
                    "années. L'outil réunit leurs phases sur des diagrammes de Gantt et des graphiques " +
                    "de charge, pour planifier les travaux longue durée et répartir le travail entre " +
                    "prestataires et chargés de projet. Les données affichées ici sont anonymisées.",

                    "Worksites at the Enedis Auvergne engineering department run over several years. " +
                    "The tool gathers their phases into Gantt charts and workload graphs, to plan " +
                    "long-running works and spread the load between contractors and project managers. " +
                    "The data shown here is anonymised.",

                    "Los chantièrs de l'agéncia engenhariá d'Enedis Auvèrnhe s'espandisson sus mantuna " +
                    "annada. L'aisina amassa lors fasas sus de diagramas de Gantt e de grafics de carga, " +
                    "per planificar los trabalhs de longa durada e repartir la carga entre prestataris e " +
                    "encargats de projècte. Las donadas afichadas aicí son anonimizadas."),
                ResumeCourt = new Texte(
                    "Planification des chantiers longue durée de l'agence ingénierie, en Gantt et graphiques de charge.",
                    "Planning of long-running engineering worksites, with Gantt charts and workload graphs.",
                    "Planificacion dels chantièrs de longa durada de l'agéncia engenhariá, en Gantt e grafics de carga."),
                Technos =
                [
                    new TechnoProjet("Python", "/Images/logos/logoPython.svg", new Texte(
                        "Traitement des données de chantiers et calcul des plannings.",
                        "Processing of worksite data and schedule computation.",
                        "Tractament de las donadas de chantièrs e calcul dels plannings.")),
                    new TechnoProjet("Streamlit", "/Images/logos/logoStreamlit.svg", new Texte(
                        "Interface de l'outil : filtres, diagrammes de Gantt et graphiques de charge.",
                        "The tool's interface: filters, Gantt charts and workload graphs.",
                        "Interfàcia de l'aisina : filtres, diagramas de Gantt e grafics de carga.")),
                    new TechnoProjet("MinIO", "/Images/logos/logoMinio.svg", new Texte(
                        "Stockage objet des données sauvegardées par l'application.",
                        "Object storage for the data the application saves.",
                        "Emmagazinatge objècte de las donadas salvadas per l'aplicacion.")),
                ],
            },

            new FicheProjet
            {
                Titre = Texte.Unique("Myriade"),
                Categorie = new Texte(
                    "Infrastructure distribuée", "Distributed infrastructure", "Infrastructura distribuida"),
                Annee = new Texte("2025 et 2026", "2025 and 2026", "2025 e 2026"),
                Cadre = Associatif,
                Realisation = Seul,
                Image = "/Images/projets/logoMyriade.jpg",
                ImageLargeur = 1100,
                ImageHauteur = 586,
                Resume = new Texte(
                    "Myriade fait dialoguer des serveurs Minecraft dans les deux sens, y compris " +
                    "lorsqu'ils vivent derrière des proxys indépendants les uns des autres. Un système " +
                    "de portails transfère les joueurs d'un serveur à l'autre en s'appuyant sur cette " +
                    "communication instantanée. <strong>Plus d'une dizaine de serveurs autonomes</strong> " +
                    "sont déjà reliés, dont certains forment eux-mêmes des réseaux, et composent un " +
                    "univers unique que l'on parcourt à pied.",

                    "Myriade lets Minecraft servers talk to each other both ways, even when they sit " +
                    "behind proxies that know nothing of one another. A portal system moves players " +
                    "from one server to the next on top of that instant channel. <strong>More than a " +
                    "dozen independent servers</strong> are already linked, several of them networks in " +
                    "their own right, forming a single world you can walk across.",

                    "Myriade fa dialogar de servidors Minecraft dins los dos senses, quitament quand " +
                    "vivon darrièr de proxys independents los unes dels autres. Un sistèma de portals " +
                    "transferís los jogaires d'un servidor a l'autre en s'apiejant sus aquela " +
                    "comunicacion instantanèa. <strong>Mai d'una detzena de servidors autonòms</strong> " +
                    "son ja ligats, e mantun es el meteis una ret, per formar un univèrs unic que se " +
                    "percor a pè."),
                ResumeCourt = new Texte(
                    "Une dizaine de serveurs Minecraft reliés en un seul univers, sans proxy central, avec transfert par portails.",
                    "A dozen Minecraft servers linked into a single world, with no central proxy and portal-based transfers.",
                    "Una detzena de servidors Minecraft ligats en un sol univèrs, sens proxy central, amb transferiment per portals."),
                Technos =
                [
                    new TechnoProjet("Redis", "/Images/logos/logoRedis.svg", new Texte(
                        "Cœur du projet : communication entre serveurs via Pub/Sub et données temporaires des transferts.",
                        "Heart of the project: server-to-server messaging over Pub/Sub and transient transfer data.",
                        "Còr del projècte : comunicacion entre servidors via Pub/Sub e donadas temporàrias dels transferiments.")),
                    new TechnoProjet("Java", "/Images/logos/logoJava.png", new Texte(
                        "Langage des plugins Minecraft embarquant la communication et les portails.",
                        "Language of the Minecraft plugins carrying the messaging and the portals.",
                        "Lenguatge dels plugins Minecraft que pòrtan la comunicacion e los portals.")),
                    new TechnoProjet("Paper MC", "/Images/logos/logoPaper.webp", new Texte(
                        "API Minecraft utilisée pour développer les plugins serveur.",
                        "Minecraft API used to build the server plugins.",
                        "API Minecraft utilizada per desvolopar los plugins servidor.")),
                    new TechnoProjet("Kotlin", "/Images/logos/logoKotlin.png", new Texte(
                        "Services back-end, pour une syntaxe concise et maintenable.",
                        "Back-end services, for concise and maintainable code.",
                        "Servicis back-end, per una sintaxi concisa e mantenabla.")),
                    new TechnoProjet("Spring Boot", "/Images/logos/logoSpring.svg", new Texte(
                        "APIs REST sécurisant les échanges entre serveurs et base de données.",
                        "REST APIs securing the exchanges between servers and database.",
                        "APIs REST que securizan los escambis entre servidors e basa de donadas.")),
                    new TechnoProjet("MongoDB", "/Images/logos/logoMongo.png", new Texte(
                        "Serveurs, coordonnées des portails et identifiants des utilisateurs.",
                        "Servers, portal coordinates and user identifiers.",
                        "Servidors, coordenadas dels portals e identificants dels utilizaires.")),
                    new TechnoProjet("Blazor Server", "/Images/logos/logoBlazor.png", new Texte(
                        "Panel web d'administration des réseaux de serveurs.",
                        "Web panel for administering the server networks.",
                        "Panèl web d'administracion de las rets de servidors.")),
                ],
            },

            new FicheProjet
            {
                Titre = Texte.Unique("GenseSense IA"),
                Categorie = new Texte(
                    "Intelligence artificielle", "Artificial intelligence", "Intelligéncia artificiala"),
                Annee = Texte.Unique("2025"),
                Cadre = new Texte(
                    "TP noté de BUT informatique",
                    "Graded computer science project",
                    "TP notat de BUT informatica"),
                Realisation = new Texte("Réalisé en binôme", "Built as a pair", "Realizat en binòm"),
                Image = "/Images/projets/genesense.jpg",
                ImageLargeur = 1100,
                ImageHauteur = 550,
                LienGithub = "https://github.com/Siwa12100/projet-ia",
                Resume = new Texte(
                    "Deux intelligences artificielles : la première détecte le genre d'une personne à " +
                    "partir d'une image, la seconde reconnaît des personnes de ma promotion de BUT. Une " +
                    "IA de segmentation des visages prépare le travail des deux autres, et un panel web " +
                    "permet d'interagir directement avec le système. La classification par genre atteint " +
                    "<strong>99 %</strong> sur les hommes et <strong>95 %</strong> sur les " +
                    "femmes, la reconnaissance de personnes environ <strong>85 %</strong>.",

                    "Two artificial intelligences: the first detects a person's gender from an image, " +
                    "the second recognises individuals from my year group. A face segmentation model " +
                    "prepares the ground for both, and a web panel drives the whole system. Gender " +
                    "classification reaches <strong>99%</strong> on men and <strong>95%</strong> on " +
                    "women, person recognition around <strong>85%</strong>.",

                    "Doas intelligéncias artificialas : la primièra devina lo genre d'una persona a " +
                    "partir d'un imatge, la segonda reconeis de personas de ma promocion de BUT. Una IA " +
                    "de segmentacion dels visatges prepara lo trabalh de las doas autras, e un panèl web " +
                    "permet d'interagir dirèctament amb lo sistèma. La classificacion per genre arriba a " +
                    "<strong>99 %</strong> suls òmes e <strong>95 %</strong> sus las femnas, la " +
                    "reconeissença de personas a l'entorn de <strong>85 %</strong>."),
                ResumeCourt = new Texte(
                    "Détection du genre et reconnaissance de personnes sur image, avec segmentation des visages et panel web.",
                    "Gender detection and person recognition from images, with face segmentation and a web panel.",
                    "Deteccion del genre e reconeissença de personas sus imatge, amb segmentacion dels visatges e panèl web."),
                Technos =
                [
                    new TechnoProjet("Python 3", "/Images/logos/logoPython.svg", new Texte(
                        "Développement des modèles d'IA et traitement des images.",
                        "Development of the AI models and image processing.",
                        "Desvolopament dels modèls d'IA e tractament dels imatges.")),
                    new TechnoProjet("Flask", "/Images/logos/flask.svg", new Texte(
                        "API web faisant le lien entre les IA et le panel.",
                        "Web API linking the models to the panel.",
                        "API web que fa lo ligam entre las IA e lo panèl.")),
                    new TechnoProjet("YOLO", "/Images/logos/logoYolo.png", new Texte(
                        "Détection et segmentation des visages, rapides et précises.",
                        "Fast, accurate face detection and segmentation.",
                        "Deteccion e segmentacion dels visatges, rapidas e precisas.")),
                    new TechnoProjet("Blazor Server", "/Images/logos/logoBlazor.png", new Texte(
                        "Panel web interactif, en communication temps réel avec le serveur.",
                        "Interactive web panel talking to the server in real time.",
                        "Panèl web interactiu, en comunicacion en temps real amb lo servidor.")),
                    new TechnoProjet("Docker", "/Images/logos/logoDocker.png", RoleDocker),
                ],
            },

            new FicheProjet
            {
                Titre = new Texte(
                    "Radar, suivi des affaires", "Radar, project tracking", "Radar, seguit de las afars"),
                Categorie = new Texte("Tableau de bord", "Dashboard", "Tablèu de bòrd"),
                Annee = Texte.Unique("2026"),
                Cadre = Alternance,
                Image = "/Images/projets/enedis-radar.jpg",
                ImageLargeur = 1002,
                ImageHauteur = 561,
                Resume = new Texte(
                    "Radar suit l'avancée des affaires jalon par jalon, pour l'agence ingénierie comme " +
                    "pour les bases opérationnelles. Chaque étape est chiffrée et filtrable, ce qui " +
                    "permet de voir où les dossiers s'accumulent et de fluidifier leur déroulé jusqu'à " +
                    "la réalisation.",

                    "Radar tracks how projects progress, milestone by milestone, for the engineering " +
                    "department and the operational units alike. Every stage is counted and filterable, " +
                    "which shows where files pile up and helps smooth their path to completion.",

                    "Radar sèc l'avançada de las afars jalon per jalon, per l'agéncia engenhariá coma " +
                    "per las basas operacionalas. Cada etapa es chifrada e filtrabla, çò que permet de " +
                    "veire ont los dorsièrs s'amontetan e de fluidificar lor desenrotlament fins a la " +
                    "realizacion."),
                ResumeCourt = new Texte(
                    "Tableau de bord du suivi des affaires, jalon par jalon, pour l'ingénierie et les bases opérationnelles.",
                    "Dashboard tracking projects milestone by milestone, for engineering and operational units.",
                    "Tablèu de bòrd del seguit de las afars, jalon per jalon, per l'engenhariá e las basas operacionalas."),
                Technos =
                [
                    new TechnoProjet("Power BI", "/Images/logos/logoPowerbi.svg", new Texte(
                        "Modélisation des données et tableau de bord distribué aux équipes.",
                        "Data modelling and the dashboard shared with the teams.",
                        "Modelizacion de las donadas e tablèu de bòrd distribuit a las equipas.")),
                ],
            },

            new FicheProjet
            {
                Titre = new Texte(
                    "Environnement de développement sécurisé pour l'IOA",
                    "Secure development environment for the IOA",
                    "Environament de desvolopament securizat per l'IOA"),
                Categorie = new Texte("DevOps & sécurité", "DevOps & security", "DevOps e seguretat"),
                Annee = Texte.Unique("2025"),
                Cadre = StageBut,
                Realisation = Seul,
                Image = "/Images/projets/ciioa.jpg",
                ImageLargeur = 1100,
                ImageHauteur = 588,
                Resume = new Texte(
                    "Administration d'un VPS sous Debian pour l'institut : sécurisation (pare-feu, SSH) " +
                    "et mise en place d'une chaîne CI/CD complète. Drone CI orchestre l'intégration " +
                    "continue, SonarQube analyse la qualité du code et une registry privée stocke les " +
                    "images Docker. <strong>Tous les projets de développement de l'institut</strong> " +
                    "passent désormais par cette chaîne, avec un gain net de temps et de fiabilité.",

                    "Administration of a Debian VPS for the institute: hardening (firewall, SSH) and a " +
                    "full CI/CD pipeline. Drone CI runs continuous integration, SonarQube analyses code " +
                    "quality and a private registry stores the Docker images. <strong>Every development " +
                    "project at the institute</strong> now goes through this pipeline, with a clear gain " +
                    "in time and reliability.",

                    "Administracion d'un VPS jol sistèma Debian per l'institut : securizacion (parafuòc, " +
                    "SSH) e mesa en plaça d'una cadena CI/CD completa. Drone CI orquèstra l'integracion " +
                    "contunha, SonarQube analisa la qualitat del còde e una registry privada garda los " +
                    "imatges Docker. <strong>Totes los projèctes de desvolopament de l'institut</strong> " +
                    "passan ara per aquela cadena, amb un ganh net de temps e de fisabilitat."),
                ResumeCourt = new Texte(
                    "VPS Debian sécurisé et chaîne CI/CD complète, utilisée par tous les projets de développement de l'institut.",
                    "Hardened Debian VPS and a full CI/CD pipeline, used by every development project at the institute.",
                    "VPS Debian securizat e cadena CI/CD completa, utilizada per totes los projèctes de desvolopament de l'institut."),
                Technos =
                [
                    new TechnoProjet("Drone CI", "/Images/logos/logoDrone.svg", new Texte(
                        "Intégration continue : tests et déploiements automatisés des projets hébergés.",
                        "Continuous integration: automated tests and deployments for the hosted projects.",
                        "Integracion contunha : tèsts e desplegaments automatizats dels projèctes albergats.")),
                    new TechnoProjet("SonarQube", "/Images/logos/logoSonar.png", new Texte(
                        "Analyse statique du code : qualité, sécurité et maintenabilité.",
                        "Static code analysis: quality, security and maintainability.",
                        "Analisi estatica del còde : qualitat, seguretat e mantenabilitat.")),
                    new TechnoProjet("Docker Compose", "/Images/logos/logoCompose.png", new Texte(
                        "Orchestration des services et des réseaux Docker.",
                        "Orchestration of the services and Docker networks.",
                        "Orquestracion dels servicis e de las rets Docker.")),
                    new TechnoProjet("Docker Registry", "/Images/logos/logoRegistry.png", new Texte(
                        "Stockage privé des images Docker, pour un déploiement contrôlé.",
                        "Private storage of the Docker images, for controlled deployments.",
                        "Emmagazinatge privat dels imatges Docker, per un desplegament contrarotlat.")),
                    new TechnoProjet("Debian", "/Images/logos/logoDebian.png", new Texte(
                        "Système du VPS : pare-feu, durcissement SSH et gestion des accès.",
                        "The VPS operating system: firewall, SSH hardening and access management.",
                        "Sistèma del VPS : parafuòc, endurciment SSH e gestion dels acceses.")),
                ],
            },

            new FicheProjet
            {
                Titre = new Texte(
                    "Site de l'Alliance d'Elendil",
                    "Website of the Alliance d'Elendil",
                    "Sit de l'Aliança d'Elendil"),
                Categorie = new Texte("Site vitrine", "Showcase website", "Sit vitrina"),
                Annee = Texte.Unique("2025"),
                Cadre = Associatif,
                Realisation = new Texte(
                    "Réalisé seul, design compris",
                    "Built solo, design included",
                    "Realizat sol, design comprés"),
                Image = "/Images/projets/elendil.jpg",
                ImageLargeur = 1100,
                ImageHauteur = 572,
                LienSite = "https://elendil-mc.fr",
                Resume = new Texte(
                    "Les joueurs francophones qui cherchent un serveur tombent souvent sur des vitrines " +
                    "confuses. Celle-ci présente clairement les serveurs de jeu et les concepts de " +
                    "l'Alliance, avec des informations récupérées en direct depuis l'API du jeu. Le " +
                    "projet est en train de devenir une référence dans la communauté.",

                    "French-speaking players looking for a server usually land on cluttered pages. This " +
                    "one lays out the game servers and the ideas behind the Alliance clearly, with live " +
                    "data pulled from the game API. It is becoming a reference in the community.",

                    "Los jogaires de lenga francesa que cèrcan un servidor tomban sovent sus de vitrinas " +
                    "confusas. Aquesta presenta clarament los servidors de jòc e los concèptes de " +
                    "l'Aliança, amb d'informacions recuperadas en dirècte dempuèi l'API del jòc. Lo " +
                    "projècte es a venir una referéncia dins la comunautat."),
                ResumeCourt = new Texte(
                    "Vitrine d'un réseau de serveurs de jeu, alimentée en direct par l'API du jeu.",
                    "Showcase for a network of game servers, fed live by the game API.",
                    "Vitrina d'una ret de servidors de jòc, alimentada en dirècte per l'API del jòc."),
                Technos =
                [
                    new TechnoProjet("Blazor Server", "/Images/logos/logoBlazor.png", new Texte(
                        "Développement du site, avec la bibliothèque de composants MudBlazor.",
                        "Development of the site, using the MudBlazor component library.",
                        "Desvolopament del sit, amb la bibliotèca de components MudBlazor.")),
                    new TechnoProjet("Nginx", "/Images/logos/logoNginx.png", new Texte(
                        "Reverse proxy redirigeant les requêtes vers le bon conteneur.",
                        "Reverse proxy routing requests to the right container.",
                        "Reverse proxy que redirigís las requèstas cap al bon contenidor.")),
                    new TechnoProjet("Let's Encrypt", "/Images/logos/logoEncrypt.png", new Texte(
                        "Certificats SSL et communications en HTTPS.",
                        "SSL certificates and HTTPS traffic.",
                        "Certificats SSL e comunicacions en HTTPS.")),
                    new TechnoProjet("Docker", "/Images/logos/logoDocker.png", RoleDocker),
                ],
            },

            new FicheProjet
            {
                Titre = Texte.Unique("Jogaires Inspector"),
                Categorie = new Texte("Outil communautaire", "Community tool", "Aisina comunautària"),
                Annee = Texte.Unique("2024"),
                Cadre = Associatif,
                Image = "/Images/projets/jogaires.jpg",
                ImageLargeur = 1100,
                ImageHauteur = 567,
                Resume = new Texte(
                    "Les administrateurs de serveurs Minecraft y répertorient les comportements des " +
                    "joueurs : bannissement, avertissement, information ou recommandation. Chacun " +
                    "consulte les notes des autres, ce qui facilite la gestion entre serveurs. L'outil " +
                    "est utilisé par une <strong>dizaine d'administrateurs</strong> et recense " +
                    "<strong>plusieurs milliers de joueurs</strong>.",

                    "Minecraft server administrators log player behaviour here: bans, warnings, plain " +
                    "information or recommendations. Everyone reads everyone else's notes, which makes " +
                    "moderation across servers far easier. The tool serves about <strong>a dozen " +
                    "administrators</strong> and lists <strong>several thousand players</strong>.",

                    "Los administrators de servidors Minecraft i repertorian los comportaments dels " +
                    "jogaires : bandiment, avertiment, informacion o recomandacion. Cadun consulta las " +
                    "nòtas dels autres, çò que facilita la gestion entre servidors. L'aisina es " +
                    "utilizada per una <strong>detzena d'administrators</strong> e recensa " +
                    "<strong>mantun milierat de jogaires</strong>."),
                ResumeCourt = new Texte(
                    "Répertoire partagé des comportements de joueurs, utilisé par une dizaine d'administrateurs de serveurs.",
                    "Shared record of player behaviour, used by about a dozen server administrators.",
                    "Repertòri partejat dels comportaments de jogaires, utilizat per una detzena d'administrators de servidors."),
                Technos =
                [
                    new TechnoProjet("Kotlin", "/Images/logos/logoKotlin.png", new Texte(
                        "Back-end du projet, pour un code concis et performant.",
                        "Back-end of the project, for concise and efficient code.",
                        "Back-end del projècte, per un còde concís e performant.")),
                    new TechnoProjet("Spring Boot", "/Images/logos/logoSpring.svg", new Texte(
                        "API exposant des endpoints sécurisés pour créer et consulter les signalements.",
                        "API exposing secure endpoints to create and read the reports.",
                        "API qu'expausa d'endpoints securizats per crear e consultar los senhalaments.")),
                    new TechnoProjet("MongoDB", "/Images/logos/logoMongo.png", new Texte(
                        "Stockage des signalements sous forme de documents JSON.",
                        "Storage of the reports as JSON documents.",
                        "Emmagazinatge dels senhalaments en documents JSON.")),
                    new TechnoProjet("Blazor Server", "/Images/logos/logoBlazor.png", new Texte(
                        "Interface de consultation et d'ajout, en temps réel.",
                        "Real-time interface for reading and adding entries.",
                        "Interfàcia de consultacion e d'apondon, en temps real.")),
                    new TechnoProjet("Docker", "/Images/logos/logoDocker.png", RoleDocker),
                ],
            },

            new FicheProjet
            {
                Titre = Texte.Unique("Virtogen"),
                Categorie = new Texte(
                    "Application pédagogique", "Teaching application", "Aplicacion pedagogica"),
                Annee = Texte.Unique("2024"),
                Cadre = new Texte(
                    "SAE de 3e année de BUT informatique",
                    "Third-year degree project",
                    "SAE de tresena annada de BUT informatica"),
                Realisation = new Texte(
                    "Réalisé en équipe, sur trois mois",
                    "Built as a team, over three months",
                    "Realizat en equipa, sus tres meses"),
                Image = "/Images/projets/drosolab.jpg",
                ImageLargeur = 1075,
                ImageHauteur = 357,
                Resume = new Texte(
                    "Conçu avec des enseignants de l'UFR de biologie de Clermont-Ferrand, Virtogen " +
                    "simule l'évolution des caractéristiques génétiques dans des populations de " +
                    "drosophiles. Les étudiants manipulent une paillasse expérimentale, ajoutent des " +
                    "flacons de populations aux phénotypes choisis, puis observent les générations et " +
                    "testent les interactions génétiques.",

                    "Designed with lecturers from the biology faculty of Clermont-Ferrand, Virtogen " +
                    "simulates how genetic traits evolve in fruit fly populations. Students work at a " +
                    "virtual lab bench, add vials of populations with chosen phenotypes, then watch the " +
                    "generations unfold and test genetic interactions.",

                    "Concebut amb d'ensenhaires de l'UFR de biologia de Clarmont-Ferrand, Virtogen " +
                    "simula l'evolucion de las caracteristicas geneticas dins de populacions de " +
                    "drosofilas. Los estudiants manipulan una taula d'experiéncia, apondon de flascons " +
                    "de populacions amb de fenotips causits, puèi espian las generacions e tèstan las " +
                    "interaccions geneticas."),
                ResumeCourt = new Texte(
                    "Simulation de génétique des populations de drosophiles, pour les TP de biologie.",
                    "Population genetics simulation on fruit flies, for biology lab classes.",
                    "Simulacion de genetica de las populacions de drosofilas, pels TP de biologia."),
                Technos =
                [
                    new TechnoProjet("Vue.js", "/Images/logos/logoVue.png", new Texte(
                        "Interface de manipulation des flacons et d'observation des populations en temps réel.",
                        "Interface for handling the vials and watching the populations in real time.",
                        "Interfàcia de manipulacion dels flascons e d'observacion de las populacions en temps real.")),
                    new TechnoProjet("Symfony", "/Images/logos/logoSymfony.png", new Texte(
                        "Back-end des données et des règles métier, exposé en API REST.",
                        "Back-end for the data and business rules, exposed as a REST API.",
                        "Back-end de las donadas e de las règlas de mestièr, expausat en API REST.")),
                    new TechnoProjet("Doctrine & MySQL", "/Images/logos/logoDoctrine.png", new Texte(
                        "Phénotypes, configurations de simulation et évolution des générations.",
                        "Phenotypes, simulation settings and the evolution of generations.",
                        "Fenotips, configuracions de simulacion e evolucion de las generacions.")),
                    new TechnoProjet("Docker", "/Images/logos/logoDocker.png", RoleDocker),
                ],
            },
        ];
    }
}
