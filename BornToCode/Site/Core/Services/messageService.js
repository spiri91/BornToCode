/// <reference path="../../_defaultScripts.js" />
app.factory('messageService', ['$http', messageService]);

function messageService($http) {
    this._POST = (address, message, shouldAuthorize) => {

    };

    this._GET = (address) => {
        return $http.get(address);
    }

    return this;
}