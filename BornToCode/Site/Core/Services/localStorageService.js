var localStorageService = (function () {
    var selectedArticleKey = 'selArt';

    function put(key, value) {
        let stringify = JSON.stringify(value);
        sessionStorage.setItem(key, stringify);
    }

    function get(key) {
        let value = sessionStorage.getItem(key);
        let obj = JSON.parse(value);
        return obj;
    }

    function rememberArticle(value) {
        put(selectedArticleKey, value);
    }

    function getSelectedArticle() {
        return get(selectedArticleKey);
    }

    return {
        get: get,
        put: put,
        rememberArticle: rememberArticle,
        getSelectedArticle: getSelectedArticle
    };
})();