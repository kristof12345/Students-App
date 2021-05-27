const setTheme = type => {
    switch (type) {
        case "auto":
            return setDefaultTheme();
        case "light":
            document.body.className = "body-light";
            return "light";
        case "dark":
            document.body.className = "body-dark";
            return "dark";
    }
};

const setDefaultTheme = () => {
    if (window.matchMedia && window.matchMedia("(prefers-color-scheme: dark)").matches) {
        document.body.className = "body-dark";
        return "dark";
    } else {
        document.body.className = "body-light";
        return "light";
    }
};

var appTheme = "auto";

const query = window.matchMedia("(prefers-color-scheme: dark)");
query.addListener(() => {
    if (appTheme === "auto") {
        setDefaultTheme();
    }
});

window.changeTheme = theme => {
    appTheme = theme;
    return setTheme(theme);
};


setDefaultTheme();