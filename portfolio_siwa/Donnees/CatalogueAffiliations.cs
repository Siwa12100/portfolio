using portfolio_siwa.Modeles;

namespace portfolio_siwa.Donnees
{
    /// <summary>
    /// Les organisations qui comptent dans mon parcours, dans les trois langues. Elles
    /// s'affichent en tête de la section « À propos » et alimentent aussi llms.txt et les
    /// données structurées, donc une seule liste à tenir à jour.
    /// Le rôle fait le titre de la carte : la présentation dit seulement ce qu'est l'organisation.
    /// Chaque logo est une tuile de 280 x 160 px : voir le README.
    /// </summary>
    public static class CatalogueAffiliations
    {
        public static IReadOnlyList<Affiliation> Toutes { get; } =
        [
            new Affiliation(
                Nom: Texte.Unique("INSA Lyon"),
                Logo: "/Images/organisations/insa-lyon.png",
                Teinte: "#ff7563",
                Role: new Texte(
                    "Étudiant en ingénierie informatique",
                    "Computer engineering student",
                    "Estudiant en engenhariá informatica"),
                Presentation: new Texte(
                    "École d'ingénieurs publique fondée en 1957, sur le campus de la Doua à Villeurbanne, près de Lyon. Elle accueille plus de 6\u00A0000 étudiants.",
                    "Public engineering school founded in 1957 on the La Doua campus in Villeurbanne, near Lyon. It welcomes more than 6,000 students.",
                    "Escòla d'engenhaires publica fondada en 1957, sul campus de la Doua a Villeurbanne, pròche de Lion. Aculhís mai de 6\u00A0000 estudiants.")),

            new Affiliation(
                Nom: Texte.Unique("Enedis"),
                Logo: "/Images/organisations/enedis.png",
                Teinte: "#8397ff",
                Role: new Texte(
                    "Alternant, analyse de données et développement web",
                    "Apprentice, data analysis and web development",
                    "En alternància, analisi de donadas e desvolopament web"),
                Presentation: new Texte(
                    "Filiale d'EDF, gestionnaire du réseau public de distribution d'électricité sur 95\u00A0% de la France métropolitaine, pour plus de 37\u00A0millions de clients.",
                    "Subsidiary of EDF and operator of the public electricity distribution network across 95% of mainland France, serving over 37 million customers.",
                    "Filiala d'EDF que gerís la ret publica de distribucion d'electricitat sus 95\u00A0% de la França metropolitana, per mai de 37\u00A0milions de clients.")),

            new Affiliation(
                Nom: new Texte(
                    "Institut occitan de l'Aveyron",
                    "Institut occitan de l'Aveyron",
                    "Institut occitan de l'Avairon"),
                Logo: "/Images/organisations/institut-occitan.png",
                Teinte: "#f0a63a",
                Role: new Texte(
                    "Développeur web et trésorier",
                    "Web developer and treasurer",
                    "Desvolopaire web e tresaurièr"),
                Presentation: new Texte(
                    "Association déclarée en 2003, dédiée à la sauvegarde, à la valorisation et à la transmission du patrimoine occitan de l'Aveyron. Elle mène des enquêtes de collectage en occitan, l'Opération País, et en ouvre les archives au public.",
                    "Association registered in 2003, devoted to safeguarding, promoting and passing on the Occitan heritage of the Aveyron. It runs Occitan-language field surveys, Operation País, and opens the archives to the public.",
                    "Associacion declarada en 2003, dedicada a la salvagarda, a la valorizacion e a la transmission del patrimòni occitan d'Avairon. Mena d'enquèstas de collectatge en occitan, l'Operacion País, e ne dobrís los archius al public.")),

            new Affiliation(
                Nom: Texte.Unique("Valorium"),
                Logo: "/Images/organisations/valorium.png",
                Teinte: "#3de8c4",
                LogoSansFond: true,
                Role: new Texte(
                    "Développeur et président",
                    "Developer and president",
                    "Desvolopaire e president"),
                Presentation: new Texte(
                    "Association autour des univers virtuels et des communautés en ligne, œuvrant à connecter les serveurs Minecraft francophones au sein d'un même métavers.",
                    "Non-profit built around virtual worlds and online communities, working to connect French-speaking Minecraft servers within a single metaverse.",
                    "Associacion a l'entorn dels univèrses virtuals e de las comunautats en linha, qu'òbra a connectar los servidors Minecraft francofòns dins un meteis metavèrs.")),
        ];
    }
}
