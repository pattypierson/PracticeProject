(function () {
    //console.log("scrape service works");
    "use strict";

    angular 
        .module("mainApp")
        .factory("imgScrapeService", imgScrapeService)

    imgScrapeService.$inject = ["$http", "$q"];

    function imgScrapeService($http, $q) {
        return {
            getAll: _getAll
        };

        //--THE FOLD--

        function _getAll(img) {
            var settings = {
                url: "/api/scrape/" + img,
                method: 'GET',
                cache: false,
                responseType: 'json',
                withCredentials: true
            };
            return $http(settings)
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