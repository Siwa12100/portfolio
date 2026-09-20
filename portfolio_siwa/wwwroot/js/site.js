// Interactions du site. Le rendu des pages est statique côté serveur :
// tout ce qui bouge ici est du JS classique, sans connexion permanente.
(() => {
    "use strict";

    const mouvementRefuse = window.matchMedia("(prefers-reduced-motion: reduce)").matches;

    // ----- Puces de technologies : le rôle s'ouvre au toucher -----
    // Le survol n'existe pas au doigt, et sur iOS un bouton ne prend pas le focus à l'appui :
    // l'état est donc porté par aria-expanded, que le CSS lit pour afficher la bulle.
    const puces = document.querySelectorAll(".puce[aria-expanded]");

    const fermerPuces = (sauf) => {
        puces.forEach((puce) => {
            if (puce !== sauf) puce.setAttribute("aria-expanded", "false");
        });
    };

    puces.forEach((puce) => {
        puce.addEventListener("click", () => {
            const ouverte = puce.getAttribute("aria-expanded") === "true";
            fermerPuces(puce);
            puce.setAttribute("aria-expanded", String(!ouverte));
        });
    });

    // Un appui ailleurs referme la bulle ouverte.
    document.addEventListener("click", (e) => {
        if (!e.target.closest(".puce")) fermerPuces(null);
    });

    // ----- Menu mobile -----
    const burger = document.getElementById("nav-burger");
    const menu = document.getElementById("nav-menu");
    const nav = document.getElementById("nav");

    // Les deux libellés viennent du HTML : le JS n'a pas à connaître la langue affichée.
    const libelle = (ouvert) =>
        (ouvert ? burger?.dataset.fermer : burger?.dataset.ouvrir) || "";

    const fermerMenu = () => {
        menu?.classList.remove("ouvert");
        burger?.setAttribute("aria-expanded", "false");
        burger?.setAttribute("aria-label", libelle(false));
    };

    if (burger && menu) {
        burger.addEventListener("click", () => {
            const ouvert = menu.classList.toggle("ouvert");
            burger.setAttribute("aria-expanded", String(ouvert));
            burger.setAttribute("aria-label", libelle(ouvert));
        });

        // Un lien cliqué referme le menu ; un clic à l'extérieur aussi.
        menu.addEventListener("click", (e) => {
            if (e.target.closest("a")) fermerMenu();
        });

        document.addEventListener("click", (e) => {
            if (!menu.contains(e.target) && !burger.contains(e.target)) fermerMenu();
        });

        document.addEventListener("keydown", (e) => {
            if (e.key === "Escape") fermerMenu();
        });
    }

    document.addEventListener("keydown", (e) => {
        if (e.key === "Escape") fermerPuces(null);
    });

    // ----- Barre de navigation au défilement + bouton de retour en haut -----
    const retourHaut = document.getElementById("retour-haut");

    const auDefilement = () => {
        const y = window.scrollY;
        nav?.classList.toggle("nav--posee", y > 12);
        retourHaut?.classList.toggle("visible", y > 700);
    };

    // Le calcul est reporté à la prochaine image : sur les navigateurs intégrés,
    // un évènement de défilement par pixel suffit à faire saccader la page.
    let defilementPrevu = false;

    window.addEventListener("scroll", () => {
        if (defilementPrevu) return;
        defilementPrevu = true;
        window.requestAnimationFrame(() => {
            defilementPrevu = false;
            auDefilement();
        });
    }, { passive: true });

    auDefilement();

    retourHaut?.addEventListener("click", () => {
        window.scrollTo({ top: 0, behavior: mouvementRefuse ? "auto" : "smooth" });
    });

    // ----- Apparition des blocs au défilement -----
    const aReveler = document.querySelectorAll("[data-reveal]");

    if (!mouvementRefuse && "IntersectionObserver" in window && aReveler.length) {
        // La classe déclenche le masquage CSS : on ne la pose qu'une fois sûr de pouvoir révéler.
        document.documentElement.classList.add("reveal-actif");

        const observateur = new IntersectionObserver((entrees) => {
            entrees.forEach((entree) => {
                if (entree.isIntersecting) {
                    entree.target.classList.add("visible");
                    observateur.unobserve(entree.target);
                }
            });
        }, { rootMargin: "0px 0px -8% 0px", threshold: 0.08 });

        aReveler.forEach((el) => observateur.observe(el));
    }

    // ----- Copie dans le presse-papier + petit message -----
    const toast = document.getElementById("toast");
    let minuteurToast;

    const afficherMessage = (message) => {
        if (!toast) return;
        toast.textContent = message;
        toast.classList.add("visible");
        clearTimeout(minuteurToast);
        minuteurToast = setTimeout(() => toast.classList.remove("visible"), 2600);
    };

    const copier = async (texte) => {
        try {
            await navigator.clipboard.writeText(texte);
            return true;
        } catch {
            // Les navigateurs intégrés (Instagram…) refusent parfois l'API presse-papier.
            try {
                const zone = document.createElement("textarea");
                zone.value = texte;
                zone.setAttribute("readonly", "");
                zone.style.position = "fixed";
                zone.style.opacity = "0";
                document.body.appendChild(zone);
                zone.select();
                const ok = document.execCommand("copy");
                document.body.removeChild(zone);
                return ok;
            } catch {
                return false;
            }
        }
    };

    document.querySelectorAll("[data-copier]").forEach((bouton) => {
        bouton.addEventListener("click", async () => {
            const texte = bouton.dataset.copier;
            const ok = await copier(texte);
            // Copie refusée : le texte lui-même s'affiche, à recopier à la main.
            afficherMessage(ok ? (bouton.dataset.message || texte) : texte);
        });
    });
})();
