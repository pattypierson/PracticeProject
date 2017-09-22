(function () {
    console.log("ppl manage controller works");
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
        //vm.submit = _submit;
        vm.itemId = parseInt($("#itemId").val());
        //vm.$onInit = _init;

        //--THE FOLD--
    }


})();