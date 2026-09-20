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

**Après tout changement de `.devcontainer/devcontainer.json`, reconstruire le conteneur** (« Dev
Containers: Rebuild Container »). Ses variables et ses réglages de ports ne sont lus qu'à la
création : sans reconstruction, l'ancien comportement continue de s'appliquer.

Le navigateur s'ouvre **une seule fois** par session dans le dev container, et jamais depuis
`launchSettings.json` (`launchBrowser` est à `false`) : sinon chaque redémarrage de
`dotnet watch` rouvrait une fenêtre. Hors dev container, l'adresse s'affiche dans le terminal.

## Un dossier, deux environnements

Le dossier du projet est monté dans le dev container : la machine hôte et le conteneur y compilent
tous les deux. Or une compilation contient des chemins absolus, dont celui du fichier qui regroupe
les styles des composants (`portfolio_siwa.….styles.css`). Compilé sur l'hôte, il pointait vers
`/home/...`, que le conteneur ne voit pas : le site répondait, mais **sans sa mise en page**, comme
une page qui charge dans le vide.

`Directory.Build.props` sépare donc les deux. Le conteneur, la construction Docker et la CI (qui
posent `DOTNET_RUNNING_IN_CONTAINER`) gardent `bin/` et `obj/`. Tout le reste écrit dans
`.artifacts/hote/`, ignoré par git. Une compilation faite sur l'hôte ne peut plus toucher ce que le
conteneur exécute.

Si le site s'affiche un jour sans mise en page, supprimer `bin/` et `obj/` puis relancer.
Le port **5087** est celui du dev container : un autre serveur qui l'occupe sur l'hôte entre en
conflit avec la redirection de port de VS Code.

## Organisation

| Dossier | Contenu |
|---|---|
| `Donnees/CatalogueProjets.cs` | **Tout le contenu des projets**, dans les trois langues. C'est le seul fichier à modifier pour ajouter ou corriger un projet. |
| `Donnees/CatalogueAffiliations.cs` | Les organisations de mon parcours (INSA, Enedis, Institut occitan, Valorium), dans les trois langues. Elles alimentent la section « À propos », `llms.txt` et les données structurées. |
| `Donnees/Traductions.cs` | Toutes les autres chaînes affichées : navigation, accroche, à propos, pied de page, erreurs, mentions légales. |
| `Donnees/PlanDuSite.cs` | Domaine, contacts, et génération de `robots.txt`, `sitemap.xml` et `llms.txt`. |
| `Donnees/DonneesStructurees.cs` | Le JSON-LD posé dans le head de chaque page. |
| `Modeles/` | `FicheProjet`, `TechnoProjet`, `Texte` (un contenu en trois langues), `Langue`, `Requete`. |
| `Infrastructure/` | `AntiforgerySansFormulaire` : voir « Aucun cookie » plus bas. |
| `Composants/Sections/` | Hero, carte projet, parcours (les organisations), à propos, contacts. |
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

**La typographie est appliquée pour vous.** En français et en occitan, `Typographie.Francaise` remplace
l'espace avant `?`, `!`, `:`, `;` et `%`, entre les groupes de chiffres (`5 000`) et dans les guillemets
par une espace insécable : le signe ne reste plus seul en début de ligne, et un nombre ne se coupe plus.
Écrire les textes avec des espaces ordinaires, la règle passe dessus.

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

## Ajouter une organisation

Ajouter une `Affiliation` dans `CatalogueAffiliations.Toutes`, avec son nom, son rôle et une
présentation dans les trois langues. Son logo est une **tuile PNG de 280 x 160 px** (elle s'affiche
en 140 x 80, en double densité), à la couleur de fond du logo lui-même : logo rogné, centré, dans un
cadre de 250 x 120 px. Le logo n'est jamais déformé ni recoloré, les chartes graphiques l'interdisent.
Avec ImageMagick :

```bash
magick logo.png -trim +repage -resize 250x120 -background "#ffffff" -gravity center -extent 280x160 tuile.png
```

Remplacer `#ffffff` par la couleur de fond du logo (`#1322dc` pour Enedis).

**Un logo lumineux sur fond noir** (Valorium) est fourni sans fond, en PNG transparent, avec
`LogoSansFond: true` : il flotte alors sur la carte au lieu d'être posé sur une plaque, et sa lueur se
fond dans celle de la carte. Sa tuile est cadrée à gauche, dans 272 x 152 px :

```bash
magick logo.png -trim +repage -resize 272x152 -background none -gravity west -extent 280x160 tuile.png
```

Il faut d'abord avoir retiré le fond noir : un simple « noir vers transparent » laisserait une auréole
sombre. Seul le noir relié aux bords de l'image doit devenir transparent, de plus en plus au fur et à
mesure qu'il s'assombrit, pour que l'intérieur du logo reste intact.

**Chaque organisation a une `Teinte`**, sa couleur de marque en `#rrggbb`, qui colore le reflet, la
bordure et le nom de sa carte. Elle doit rester assez claire pour se lire sur le fond bleu nuit du site.

Un test vérifie que chaque tuile existe, fait 280 x 160 px et reste sous 60 Ko.

## La croix occitane

Le menu porte une croix occitane, à gauche du nom, légèrement penchée, qui tourne encore un peu au
survol (et à l'appui, sur un écran tactile). Elle mène à la manifestation Carrièras Occitanas,
`PlanDuSite.CarrierasOccitanas`. **Ce site est daté** (17 et 18 octobre 2026, à Montségur) : à revoir
une fois l'évènement passé.

Le dessin, `wwwroot/Images/croix-occitane.svg`, est celui du site de l'Institut occitan de l'Aveyron
(`ioa-pais.fr/Images/croix-occitane.svg`). L'original est un tracé noir au trait fin : il a été
nettoyé (prologue XML, DOCTYPE et métadonnées retirés), coloré avec le dégradé violet vers orange du
site, et son trait a été épaissi (`stroke-width`), car un filet aussi fin disparaît à 28 px.

Pour le remplacer, déposer un SVG du même nom, avec un `viewBox` et sans script ni lien externe : un
test le vérifie. Un SVG noir sur fond transparent ne survit pas à une conversion en image (il devient
un carré noir), le fournir en texte.

## Les halos : une règle

Les lueurs colorées font la différence du site, à condition de rester rares. La règle : **un halo
porte un sens, une marque ou une action, jamais un ornement.**

- Une **marque** : chaque carte d'organisation porte la couleur de la sienne (reflet, bordure, nom).
- Une **action** : la carte « Me contacter » a le seul halo aux couleurs du site (orange et violet),
  parce que c'est là qu'on veut que le visiteur écrive.
- Une **interaction** : les cartes de projets ne s'éclairent que quand on les vise, ou qu'on touche un
  de leurs éléments. Rien n'est permanent.

Pas d'animation en boucle, pas de flou lourd (les navigateurs intégrés le supportent mal), pas de texte
en dégradé. Avant d'ajouter une lueur, se demander ce qu'elle désigne : si la réponse est « rien, c'est
joli », elle affaiblit celles qui comptent.

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

**Pour reproduire la production en local, lancer la sortie de `dotnet publish`**, pas le `.dll` de
`bin/` : sans elle, le mode production ne charge pas les fichiers statiques, qui répondent alors
`200` avec un corps vide. C'est ce que fait le Dockerfile.

## Intégration continue et déploiement

`.drone.yml` porte deux pipelines :

- **verification** construit la solution et lance les tests. Elle part sur chaque poussée,
  quelle que soit la branche, et sur chaque pull request.
- **deploiement-main** ne part que sur `main`, et seulement si la vérification est passée.
  Elle construit l'image, la pousse sur la registry privée, puis redéploie le conteneur sur
  le VPS via `docker compose`.

Pousser une branche de travail la fait donc valider sans rien déployer.
