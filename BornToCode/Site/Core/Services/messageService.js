/// <reference path="../../_defaultScripts.js" />
app.factory('messageService', ['$http', messageService]);

function messageService($http) {
    this._POST = (address, message, token) => {
        return $http({
            method: 'POST',
            url: address,
            headers: { 'Authorization': token },
            data: message
        });
    };

    this._GET = (address) => {
        return $http.get(address);
    };

    return this;
}