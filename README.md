# Portfolio

Portfolio personnel de Jean Marcillac, en .NET 9 Blazor, publié en français, anglais et occitan.

Le site est rendu **statiquement côté serveur** : aucun composant interactif, donc aucun
circuit SignalR à maintenir. C'est voulu, le site est surtout consulté depuis le navigateur
intégré d'Instagram, qui coupe les connexions persistantes dès qu'on quitte l'application.
Les quelques interactions (menu, copie, animations) tiennent dans `wwwroot/js/site.js`.

## Démarrer

Le projet fournit un dev container (.NET 9 SDK, rien d'autre) :

1. Ouvrir le dossier dans VS Code, puis **Reopen in Container**.
2. `dotnet watch --project portfolio_siwa`, le site écoute sur le port 5087.

Sans dev container, il suffit du SDK .NET 9 et de la même commande.

Le navigateur s'ouvre **une seule fois** par session dans le dev container, et jamais depuis
`launchSettings.json` (`launchBrowser` est à `false`) : sinon chaque redémarrage de
`dotnet watch` rouvrait une fenêtre. Hors dev container, l'adresse s'affiche dans le terminal.

## Organisation

| Dossier | Contenu |
|---|---|
| `Donnees/CatalogueProjets.cs` | **Tout le contenu des projets**, dans les trois langues. C'est le seul fichier à modifier pour ajouter ou corriger un projet. |
| `Donnees/Traductions.cs` | Toutes les autres chaînes affichées : navigation, accroche, à propos, pied de page, erreurs, mentions légales. |
| `Donnees/PlanDuSite.cs` | Domaine, contacts, et génération de `robots.txt`, `sitemap.xml` et `llms.txt`. |
| `Donnees/DonneesStructurees.cs` | Le JSON-LD posé dans le head de chaque page. |
| `Modeles/` | `FicheProjet`, `TechnoProjet`, `Texte` (un contenu en trois langues), `Langue`, `Requete`. |
| `Infrastructure/` | `AntiforgerySansFormulaire` : voir « Aucun cookie » plus bas. |
| `Composants/Sections/` | Hero, carte projet, à propos, contacts. |
| `Composants/Global/` | Navbar, pied de page et sélecteur de langue (partagé entre le menu et le pied de page). |
| `wwwroot/css/` | `variables.css` (tokens), `base.css` (reset et typographie), `utilitaires.css` (boutons, sections, animations). |
| `wwwroot/js/site.js` | Menu mobile, bulles des technologies, apparition au défilement, copie dans le presse-papier. |
| `wwwroot/fonts/` | Les polices, hébergées ici : voir « Polices ». |

## Les trois langues

Aucun fichier de ressources : un texte traduit est un `Texte(fr, en, oc)`, et les trois
versions se lisent côte à côte dans le code. Corriger une traduction ou en ajouter une se
fait donc toujours au même endroit.

La langue est déduite du premier segment de l'URL, une fois par requête, puis descendue à
tout l'arbre de composants par un `CascadingValue`. Le français n'a pas de préfixe :

| Page | Français | Anglais | Occitan |
|---|---|---|---|
| Accueil | `/` | `/en` | `/oc` |
| Mentions légales | `/mentions-legales` | `/en/legal-notice` | `/oc/mencions-legalas` |

**Ajouter une page** demande trois choses : une valeur dans l'énumération `PageSite`, ses
trois adresses dans `Langues.Adresse`, et les trois directives `@page` sur le composant.
Le sélecteur de langue, les liens `hreflang` et le sitemap suivent tout seuls.

**Ajouter une langue** demande une valeur dans l'énumération `Langue` et un cas dans chaque
méthode de `Langues`. Le compilateur ne signalera rien : ce sont les tests qui rattrapent
les traductions oubliées.

## Ajouter un projet

Ajouter une `FicheProjet` dans `CatalogueProjets.Tous`. Les champs `ImageLargeur` et
`ImageHauteur` doivent correspondre au fichier réel : ils évitent que la page saute
pendant le chargement des images.

**L'ordre du catalogue décide de l'affichage** : les quatre premières fiches sortent en
grandes cartes, les suivantes en cartes compactes sous « Autres projets ». Pour mettre un
projet en avant, il suffit de le remonter dans la liste.

Les images restent légères, moins de 150 Ko chacune, largeur 1100 px. C'est le premier
facteur de confort sur mobile. Les chemins d'images commencent tous par `/`.

**Chaque image a deux variantes réduites**, à côté de l'original : pour `x.jpg`, les fichiers
`x-480.jpg` et `x-800.jpg`. Le navigateur prend la plus légère qui suffit à son écran au lieu de
télécharger systématiquement les 1100 px. Avec ImageMagick :

```bash
magick x.jpg -resize 480x -quality 76 x-480.jpg
magick x.jpg -resize 800x -quality 78 x-800.jpg
```

Un test échoue si une variante manque, ou si `ImageLargeur` et `ImageHauteur` ne correspondent
pas au fichier.

## Polices

Inter et Roboto Slab sont hébergées dans `wwwroot/fonts/`, en variables (un fichier couvre
toutes les graisses) et limitées au sous-ensemble latin, qui contient tous les accents du
français, de l'anglais et de l'occitan. Licence SIL OFL, redistribution libre.

Ne pas les remplacer par un lien vers Google Fonts : la requête enverrait l'adresse IP de chaque
visiteur à Google, alors que les mentions légales promettent qu'aucune donnée n'est transmise.
Un test échoue si une ressource est chargée chez un tiers.

## Aucun cookie

Le moteur Blazor demande un jeton antiforgery à chaque réponse, même sans formulaire. Le service
par défaut y répondait en posant un cookie sur toutes les pages, et un `Cache-Control: no-store`
qui empêchait le retour instantané en arrière. `Infrastructure/AntiforgerySansFormulaire` le
remplace : il ne pose rien et refuse toute validation.

**Ajouter un formulaire demande donc de retirer ce service**, de réactiver `UseAntiforgery()` dans
`Program.cs`, et de corriger les mentions légales, puisqu'un cookie sera de nouveau posé.

## Référencement

Le site sert quatre choses aux moteurs et aux assistants d'IA, toutes construites à partir
du catalogue et de la liste des langues, donc jamais désynchronisées du contenu :

- `robots.txt`, qui ouvre le site et nomme un par un les robots d'IA. Sans mention
  explicite, plusieurs s'abstiennent d'indexer.
- `sitemap.xml`, avec les six adresses et leurs équivalences de langue.
- `llms.txt` ([llmstxt.org](https://llmstxt.org)), un résumé en texte clair du site et de
  ses projets, pour les assistants qui préfèrent ça au HTML de la page.
- Du JSON-LD schema.org dans le head : qui est l'auteur, ce que contient la page, et une
  fiche par projet.

Chaque page déclare son adresse canonique et ses traductions en `hreflang`. Les pages
d'erreur, elles, sortent de l'index.

L'adresse du site vit dans `PlanDuSite.Domaine` : c'est la seule valeur à changer si le
domaine bouge.

## Tests

```bash
dotnet test portfolio_siwa.sln
```

Ils couvrent le catalogue, les adresses, les traductions et les images, et démarrent aussi le site
pour de bon (`SiteHttpTests`) : chaque page dans chaque langue avec ses balises `hreflang` et son
adresse canonique, aucun cookie, compression, réponse à `HEAD`, aucune ressource chez un tiers.
Un texte ajouté sans sa version anglaise ou occitane fait échouer la suite.

## Intégration continue et déploiement

`.drone.yml` porte deux pipelines :

- **verification** construit la solution et lance les tests. Elle part sur chaque poussée,
  quelle que soit la branche, et sur chaque pull request.
- **deploiement-main** ne part que sur `main`, et seulement si la vérification est passée.
  Elle construit l'image, la pousse sur la registry privée, puis redéploie le conteneur sur
  le VPS via `docker compose`.

Pousser une branche de travail la fait donc valider sans rien déployer.
