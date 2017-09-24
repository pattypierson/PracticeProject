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
            //names = vm.items.firstName;
            //console.log(names);
        }

        //--Get All ERROR--
        function _peopleGetAllError(error) {
            console.log(error);
        }

        //--RANDOMIZER--

        $('button').click(function () {
            $('h4').text(randomEl(names) + ' ' + randomEl(cuisines));
            selectElementContents($('h4')[0]);
        });

        function randomEl(list) {
            var i = Math.floor(Math.random() * list.length);
            return list[i];
        }

        function selectElementContents(el) {
            var range = document.createRange();
            range.selectNodeContents(el);
            var sel = window.getSelection();
            sel.removeAllRanges();
            sel.addRange(range);
        }

        var names = ["test", "test2", "test3"];

        var cuisines = ["American", "Thai", "Pizza", "Burgers"];
    }
})();