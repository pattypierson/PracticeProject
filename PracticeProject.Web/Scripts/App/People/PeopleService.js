(function () {
    //console.log("people service works");
    "use strict";

    angular
        .module("mainApp")
        .factory("peopleService", peopleService);

    peopleService.$inject = ["$http", "$q"];

    function peopleService($http, $q) {
        return {
            peopleGetAll: _peopleGetAll,
            personGetById: _personGetById,
            postNewPerson: _postNewPerson,
            updatePerson: _updatePerson,
            deletePerson: _deletePerson,          
        };

        //--THE FOLD

        //--GET ALL--
        function _peopleGetAll() {
            return $http.get("/api/people", { withCredentials: true })
                .then(_serviceCallComplete, _serviceCallFailed);
        }

        //--GET By ID--
        function _personGetById(id) {
            return $http.get("/api/people/" + id, { withCredentials: true })
                .then(_serviceCallComplete, _serviceCallFailed);
        }

        function _postNewPerson(data) {
            return $http.post("/api/people", data, { withCredentials: true })
                .then(_serviceCallComplete, _serviceCallFailed);
        }

        //--UPDATE--
        function _updatePerson(data, id) {
            return $http.put("/api/people/" + id, data, { withCredentials: true })
                .then(_serviceCallComplete, _serviceCallFailed);
        }

        //--Company DELETE--
        function _deletePerson(id) {
            return $http.delete("/api/people/" + id, { withCredentials: true })
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