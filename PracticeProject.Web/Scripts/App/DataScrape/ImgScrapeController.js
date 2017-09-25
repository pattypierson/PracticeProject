(function () {
    //console.log("img scrape controller works")
    "use strict";

    angular
        .module("mainApp")
        .controller("imgScrapeController", imgScrapeController);

    imgScrapeController.$inject = ["$scope", "$window", "imgScrapeService"];

    function imgScrapeController($scope, $window, imgScrapeService) {
        var vm = this;
        vm.$scope = $scope;
        vm.imgScrapeService = imgScrapeService;
        vm.img = "";
        vm.items = [];
        vm.search = _search;
        
        //--THE FOLD

        function _search() {
            vm.imgScrapeService.getAll(vm.img)
                .then(_imgGetAllSuccess, _imgGetAllError);
        }

        //--Get All SUCCESS--
        function _imgGetAllSuccess(response) {
            vm.items = response.data;
            console.log(vm.items);
        }

        //--Get All ERROR--
        function _imgGetAllError(error) {
            console.log(error);
        }
    }
})();