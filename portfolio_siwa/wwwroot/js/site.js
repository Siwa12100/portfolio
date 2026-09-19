// Interactions du site. Le rendu des pages est statique côté serveur :
// tout ce qui bouge ici est du JS classique, sans connexion permanente.
(() => {
    "use strict";

    // ----- Menu mobile -----
    const burger = document.getElementById("nav-burger");
    const menu = document.getElementById("nav-menu");
    const nav = document.getElementById("nav");

    const fermerMenu = () => {
        menu?.classList.remove("ouvert");
        burger?.setAttribute("aria-expanded", "false");
        burger?.setAttribute("aria-label", "Ouvrir le menu");
    };

    if (burger && menu) {
        burger.addEventListener("click", () => {
            const ouvert = menu.classList.toggle("ouvert");
            burger.setAttribute("aria-expanded", String(ouvert));
            burger.setAttribute("aria-label", ouvert ? "Fermer le menu" : "Ouvrir le menu");
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

    // ----- Barre de navigation au défilement + bouton de retour en haut -----
    const retourHaut = document.getElementById("retour-haut");

    const auDefilement = () => {
        const y = window.scrollY;
        nav?.classList.toggle("nav--posee", y > 12);
        retourHaut?.classList.toggle("visible", y > 700);
    };

    window.addEventListener("scroll", auDefilement, { passive: true });
    auDefilement();

    retourHaut?.addEventListener("click", () => {
        window.scrollTo({ top: 0, behavior: "smooth" });
    });

    // ----- Apparition des blocs au défilement -----
    const aReveler = document.querySelectorAll("[data-reveal]");
    const mouvementRefuse = window.matchMedia("(prefers-reduced-motion: reduce)").matches;

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
            afficherMessage(ok ? (bouton.dataset.message || "Copié") : texte);
        });
    });
})();
