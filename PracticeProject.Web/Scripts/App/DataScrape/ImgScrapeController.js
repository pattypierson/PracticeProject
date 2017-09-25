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
        vm.item = {};
        vm.single = {};
        vm.data = {};
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
            vm.single = vm.items[1];        
            vm.data = { imageName: vm.img, image: vm.single};
            vm.imgScrapeService.postScrape(vm.data)
                .then(_postCallSuccess, _postCallError);
        }

        //--Get All ERROR--
        function _imgGetAllError(error) {
            console.log(error);
        }

        //--Post/Put Success
        function _postCallSuccess(response) {
            console.log(response);
            vm.item = {};
        }

        //--Post/Put Error
        function _postCallError(error) {
            console.log(error);
        }
    }
})();