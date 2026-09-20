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

        public static Texte HeroDissonance { get; } = new(
            "Au-delà de la technique, la dissonance entre les promesses du numérique et ses réalités énergétiques et matérielles m'interroge, tout comme la place d'un numérique résilient et durable dans un monde sous contraintes.",
            "Beyond the technical side, the gap between what technology promises and what it actually costs in energy and materials keeps me questioning, as does the place of a resilient, sustainable digital world under constraint.",
            "Al delà de la tecnica, la dissonància entre las promesas del numeric e sas realitats energeticas e materialas m'interròga, coma la plaça d'un numeric resilient e durable dins un mond jos constrenchas.");

        public static Texte HeroAssociatif { get; } = new(
            "Au-delà des études et du professionnel, plusieurs associations occupent mon temps libre, et mes compétences y sont mises à contribution.",
            "Outside of studies and work, several non-profits take up my free time, and my skills go into them.",
            "Al delà dels estudis e del professional, mantuna associacion ocupa mon temps liure, e mas competéncias i son mesas a contribucion.");

        public static Texte BoutonProjets { get; } = new(
            "Voir mes projets", "See my projects", "Veire mos projèctes");

        public static Texte BoutonAPropos { get; } = new(
            "À propos de moi", "About me", "A prepaus de ieu");

        // ===== Section des projets =====
        public static Texte TitreRealisations { get; } = new(
            "Réalisations", "Work", "Realizacions");

        public static Texte AutresProjets { get; } = new(
            "Autres projets", "Other projects", "Autres projèctes");

        public static Texte VoirLeSite { get; } = new("Voir le site", "Visit the site", "Veire lo sit");
        public static Texte CodeSource { get; } = new("Code source", "Source code", "Còde font");

        /// <summary>Texte alternatif des captures de projets, complété par le titre.</summary>
        public static Texte ApercuDe { get; } = new(
            "Aperçu du projet", "Screenshot of", "Ulhada del projècte");

        // ===== À propos =====
        public static Texte TitreAPropos { get; } = new("À propos", "About", "A prepaus");

        public static Texte AProposOrigine { get; } = new(
            "Originaire de l'Aveyron, j'aime créer des projets concrets, utiles et porteurs de sens. Mes études, mon engagement associatif et mes expériences professionnelles m'ont appris à allier la technique et la gestion de projet.",
            "I grew up in the Aveyron, and I like building things that are concrete, useful and meaningful. Studies, non-profit work and professional experience taught me to hold together the technical side and the project management side.",
            "Originari de l'Avairon, m'agrada crear de projèctes concrets, utils e portaires de sens. Mos estudis, mon engatjament associatiu e mas experiéncias professionalas m'an apres a ligar la tecnica e la gestion de projècte.");

        public static Texte AProposEnedis { get; } = new(
            "En alternance chez <strong>Enedis</strong>, je fais de l'analyse de données et je développe des outils métiers pour l'agence ingénierie d'Auvergne : planification des chantiers longue durée, suivi des affaires, visualisation de la charge des équipes.",
            "As an apprentice at <strong>Enedis</strong>, I work on data analysis and build internal tools for the Auvergne engineering department: planning long-running worksites, tracking projects, visualising team workload.",
            "En alternància a <strong>Enedis</strong>, fau d'analisi de donadas e desvolopi d'aisinas de mestièr per l'agéncia engenhariá d'Auvèrnhe : planificacion dels chantièrs de longa durada, seguit de las afars, visualizacion de la carga de las equipas.");

        public static Texte AProposAssociations { get; } = new(
            "Le reste de mon temps va au milieu associatif, entre le <strong>Valorium</strong> et l'<strong>Alliance d'Elendil</strong>, où j'explore le développement d'univers virtuels et la gestion de communautés en ligne. Les projets m'y ont amené à prendre des responsabilités : la présidence de ces deux associations, et la trésorerie de l'Institut occitan de l'Aveyron depuis mon passage chez eux.",
            "The rest of my time goes to non-profits, between <strong>Valorium</strong> and the <strong>Alliance d'Elendil</strong>, where I explore virtual worlds and the running of online communities. The projects brought responsibilities with them: chairing both associations, and serving as treasurer of the Institut occitan de l'Aveyron since my time there.",
            "La rèsta de mon temps va al mitan associatiu, entre lo <strong>Valorium</strong> e l'<strong>Aliança d'Elendil</strong>, ont explori lo desvolopament d'univèrses virtuals e la gestion de comunautats en linha. Los projèctes m'an menat a prene de responsabilitats : la presidéncia d'aquelas doas associacions, e la tresauriá de l'Institut occitan de l'Avairon dempuèi mon passatge amb eles.");

        public static Texte AProposCulture { get; } = new(
            "Curieux d'histoire et de culture, je regarde comment le numérique peut servir à transmettre et à valoriser ces sujets. Mon travail à l'<strong>Institut occitan de l'Aveyron</strong> m'a permis d'expérimenter cette approche, en développant des outils pour mettre en avant la culture occitane auprès des jeunes générations.",
            "Curious about history and culture, I look at how technology can help pass them on. My work at the <strong>Institut occitan de l'Aveyron</strong> let me try that out, building tools that bring Occitan culture to younger generations.",
            "Curiós d'istòria e de cultura, espii cossí lo numeric pòt servir a transmetre e a valorizar aqueles subjèctes. Mon trabalh a l'<strong>Institut occitan de l'Avairon</strong> m'a permés d'ensajar aquela aprocha, en desvolopant d'aisinas per metre en davant la cultura occitana demest las joves generacions.");

        public static Texte AProposConclusion { get; } = new(
            "D'où l'envie de mettre mes compétences au service de projets et d'organisations porteurs de sens, utiles, responsables et durables, et un engagement pour la protection, la valorisation et la transmission de la langue et de la culture occitanes.",
            "Hence the wish to put my skills at the service of meaningful, useful, responsible and sustainable projects and organisations, along with a commitment to protecting, promoting and passing on the Occitan language and culture.",
            "D'aquí l'enveja de metre mas competéncias al servici de projèctes e d'organizacions portaires de sens, utils, responsables e durables, e un engatjament per la proteccion, la valorizacion e la transmission de la lenga e de la cultura occitanas.");

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
            "Les textes et le code de ce site sont l'œuvre de son éditeur. Les captures d'écran présentent des projets réalisés dans un cadre scolaire, professionnel ou associatif, et restent la propriété de leurs commanditaires respectifs. Les logos des technologies appartiennent à leurs détenteurs et ne sont utilisés qu'à des fins d'identification.",
            "The texts and the code of this site are the work of its publisher. The screenshots show projects carried out in an academic, professional or non-profit setting, and remain the property of their respective owners. Technology logos belong to their holders and are used for identification only.",
            "Los tèxtes e lo còde d'aqueste sit son l'òbra de son editor. Las capturas d'ecran presentan de projèctes realizats dins un encastre escolar, professional o associatiu, e demòran la proprietat de lors comanditaris. Los logos de las tecnologias apartenon a lors detentors e son pas utilizats que per identificacion.");

        public static Texte LegalDonneesTitre { get; } = new(
            "Données personnelles", "Personal data", "Donadas personalas");

        public static Texte LegalDonneesTexte { get; } = new(
            "Ce site ne dépose aucun cookie, n'utilise aucun outil de mesure d'audience et ne collecte aucune donnée personnelle. Aucun formulaire n'y figure : les prises de contact se font par courrier électronique, à votre initiative.",
            "This site sets no cookies, uses no analytics and collects no personal data. There is no form: getting in touch happens by email, at your own initiative.",
            "Aqueste sit depausa pas cap de cookie, utiliza pas cap d'aisina de mesura d'audiéncia e amassa pas cap de donada personala. I a pas cap de formulari : las presas de contacte se fan per corrièl, a vòstra iniciativa.");
    }
}
