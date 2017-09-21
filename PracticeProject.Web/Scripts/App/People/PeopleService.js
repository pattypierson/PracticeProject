(function () {
    console.log("people service works");
    "use strict";

    angular
        .module("mainApp")
        .factory("peopleService", peopleService);

    peopleService.$inject = ["$http", "$q"];

    function peopleService($http, $q) {
        return {
            peopleGetAll: _peopleGetAll,
        };

        //--THE FOLD

        //--GET ALL--
        function _peopleGetAll() {
            return $http.get("/api/people", { withCredentials: true })
                .then(_serviceCallComplete, _serviceCallFailed);
        }

        //--SERVICE CALL SUCCESS--
        function _serviceCallComplete(response) {
            return response;
        }

        //--SERVICE CALL FAILURE--
        function _serviceCallFailed(error) {
            var msg = 'error';
            if (error.data && error.data.description) {
                msg += '\n' + error.data.description;
            }
            error.data.description = msg;
            return $q.reject(error, "Oops. Something went wrong");
        }
    }
})();