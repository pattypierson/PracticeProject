(function () {
    console.log("people controller works")
    "use strict";

    angular
        .module("mainApp")
        .controller("peopleController", peopleController);

    peopleController.$inject = ["$scope", "peopleService"];

    function peopleController($scope, peopleService) {
        var vm = this;
        //vm.$scope = $scope;
        vm.peopleService = peopleService;
        vm.items = [];
        vm.item = {};     
        vm.$onInit = _init;

        //--THE FOLD

        //--GET ALL COMPANIES--
        function _init() {
            vm.peopleService.peopleGetAll()
                .then(_peopleGetAllSuccess, _peopleGetAllError);
        }

        //--Get All SUCCESS--
        function _peopleGetAllSuccess(response) {
            vm.items = response.data.items;
            console.log(vm.items);
        }

        //--Get All ERROR--
        function _peopleGetAllError(error) {
            console.log(error);
        }
    }
})();