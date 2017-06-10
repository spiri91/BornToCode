/// <reference path="../../_defaultScripts.js" />
app.factory('messageService', ['$http', messageService]);

function messageService($http) {
    function returnHttpAction(method, address, message, token) {
        return $http({
            method: method,
            url: address,
            headers: { 'Authorization': token },
            data: message
        });
    }

    this._POST = (address, message, token) => {
        return returnHttpAction('POST', address, message, token);
    };

    this._GET = (address) => {
        return $http.get(address);
    };

    this._PUT = (address, token, id, message) => {
        return returnHttpAction('PUT', address + '(' + id + ')', message, token);
    };

    return this;
}