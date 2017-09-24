(function () {
    console.log("data picker ctrl works");
    "use strict";

    angular
        .module("mainApp")
        .controller("dataPickerCtrl", dataPickerCtrl);

    dataPickerCtrl.$inject = ["$scope", "$window", "peopleService"];

    function dataPickerCtrl($scope, $window, peopleService) {
        var vm = this;

        vm.peopleService = peopleService;
        vm.items = [];
        vm.item = {};
        vm.$onInit = _init;

        //--THE FOLD--

        //--GET ALL People--
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