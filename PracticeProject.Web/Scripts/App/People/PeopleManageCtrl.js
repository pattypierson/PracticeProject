(function () {
    console.log("ppl manage controller works");
    "use strict";

    angular
        .module("mainApp")
        .controller("peopleManageCtrl", peopleManageCtrl);

    peopleManageCtrl.$inject = ["$scope", "peopleService"];

    function peopleManageCtrl($scope, peopleservice) {

    }


})();