(function () {
    //console.log("ppl manage controller works");
    "use strict";

    angular
        .module("mainApp")
        .controller("peopleManageCtrl", peopleManageCtrl);

    peopleManageCtrl.$inject = ["$scope", "$window", "peopleService"];

    function peopleManageCtrl($scope, $window, peopleService) {
        var vm = this;

        vm.peopleService = peopleService;
        vm.item = {};
        vm.items = [];
        vm.save = _save;
        vm.itemId = parseInt($("#itemId").val());
        vm.$onInit = _init;

        //--THE FOLD--

        //--Get BY ID if any on page start up
        function _init() {
            if (vm.itemId > 0) {
                vm.peopleService.personGetById(vm.itemId)
                    .then(_personGetByIdSuccess, _personGetByIdError);
            }
        }

        //--Get BY ID SUCCESS--
        function _personGetByIdSuccess(response) {
            console.log(response);
            vm.item = response.data.item;
        }

        //--Get BY ID ERROR--
        function _personGetByIdError(error) {
            console.log(error);
        }

        //--POST/PUT submit function 
        function _save() {
            if (vm.itemId > 0) {
                //put
                vm.peopleService.updatePerson(vm.item, vm.item.id)
                    .then(_serviceCallSuccess, _serviceCallError);
            } else {
                // post
                vm.peopleService.postNewPerson(vm.item)
                    .then(_serviceCallSuccess, _serviceCallError);
            }
        }

        //--Post/Put Success
        function _serviceCallSuccess(response) {
            console.log(response);
            vm.item = {};
            $window.location.href = "/people";
        }

        //--Post/Put Error
        function _serviceCallError(error) {
            console.log(error);
        }
    }
})();