window.copyToClipboardFallback = (text) => {
    let textarea = document.createElement("textarea");
    textarea.value = text;
    document.body.appendChild(textarea);
    textarea.select();
    try {
        document.execCommand("copy");
        console.log("Texte copié avec succès !");
    } catch (err) {
        console.error("Erreur lors de la copie : ", err);
    }
    document.body.removeChild(textarea);
};

window.copyToClipboard = (text) => {
    if (navigator.clipboard) {
        navigator.clipboard.writeText(text).then(() => {
            console.log("Texte copié avec succès !");
        }).catch(err => {
            console.error("Erreur lors de la copie : ", err);
        });
    } else {
        window.copyToClipboardFallback(text);
    }
};
