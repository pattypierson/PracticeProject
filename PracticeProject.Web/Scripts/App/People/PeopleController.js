(function () {
    //console.log("people controller works")
    "use strict";

    angular
        .module("mainApp")
        .controller("peopleController", peopleController);

    peopleController.$inject = ["$scope", "$window", "peopleService"];

    function peopleController($scope, $window, peopleService) {
        var vm = this;
        
        vm.peopleService = peopleService;
        vm.items = [];
        vm.item = {};     
        vm.$onInit = _init;
        vm.add = _add;
        vm.edit = _edit;
        vm.delete = _delete;

        //--THE FOLD

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

        //--on add click, opens form window to create
        function _add() {
            $window.location.href = "/people/create";
        }

        //--on edit click, opens form window to edit
        function _edit(id) {
            vm.item = id;
            console.log("Item ID:", vm.item.id);
            $window.location.href = "/people/" + vm.item.id + "/edit";
        }

        //--DELETE A COMPANY FROM TABLE--
        function _delete(id, index) {
            vm.item = id;
            var id = vm.item.id;
            var index = vm.items.indexOf(vm.item);
            vm.index = index;
            vm.peopleService.deletePerson(id)
                .then(_deletePersonSuccess, _deletePersonError);
        }

        //--DELETE SUCCESS--
        function _deletePersonSuccess(response) {
            console.log(response);
            vm.items.splice(vm.index, 1);
        }

        //--DELETE ERROR--
        function _deletePersonError(error) {
            console.log(error);
        }
    }
})();