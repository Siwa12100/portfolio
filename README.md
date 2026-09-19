# Portfolio

Portfolio personnel de Jean Marcillac, en .NET 9 Blazor.

Le site est rendu **statiquement côté serveur** : aucun composant interactif, donc aucun
circuit SignalR à maintenir. C'est voulu, le site est surtout consulté depuis le navigateur
intégré d'Instagram, qui coupe les connexions persistantes dès qu'on quitte l'application.
Les quelques interactions (menu, copie, animations) tiennent dans `wwwroot/js/site.js`.

## Démarrer

Le projet fournit un dev container (.NET 9 SDK, rien d'autre) :

1. Ouvrir le dossier dans VS Code, puis **Reopen in Container**.
2. `dotnet watch --project portfolio_siwa`, le site écoute sur le port 5087.

Sans dev container, il suffit du SDK .NET 9 et de la même commande.

## Organisation

| Dossier | Contenu |
|---|---|
| `Donnees/CatalogueProjets.cs` | **Tout le contenu des projets.** C'est le seul fichier à modifier pour ajouter ou corriger un projet. |
| `Modeles/` | `FicheProjet`, `TechnoProjet`. |
| `Composants/Sections/` | Hero, carte projet, à propos, contacts. |
| `Composants/Global/` | Navbar et pied de page. |
| `wwwroot/css/` | `variables.css` (tokens), `base.css` (reset et typographie), `utilitaires.css` (boutons, sections, animations). |
| `wwwroot/js/site.js` | Menu mobile, apparition au défilement, copie dans le presse-papier. |

## Ajouter un projet

Ajouter une `FicheProjet` dans `CatalogueProjets.Tous`. Les champs `ImageLargeur` et
`ImageHauteur` doivent correspondre au fichier réel : ils évitent que la page saute
pendant le chargement des images.

**L'ordre du catalogue décide de l'affichage** : les quatre premières fiches sortent en
grandes cartes, les suivantes en cartes compactes sous « Autres projets ». Pour mettre un
projet en avant, il suffit de le remonter dans la liste.

Les images restent légères, moins de 150 Ko chacune, largeur 1100 px. C'est le premier
facteur de confort sur mobile.

## Tests

```bash
dotnet test portfolio_siwa.sln
```

## Déploiement

`.drone.yml` construit l'image, la pousse sur la registry privée puis redéploie le
conteneur sur le VPS via `docker compose`.
