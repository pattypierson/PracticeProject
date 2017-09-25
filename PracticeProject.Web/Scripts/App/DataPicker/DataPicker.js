(function () {
    //console.log("data picker ctrl works");
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

        $('.personBtn').click(function () {
            $('.winner').text(randomEl(names));
            selectElementContents($('.winner')[0]);
        });

        $('.foodBtn').click(function () {
            event.preventDefault();
            var cuisines = [];
            $("#selections input:checkbox:checked").map(function () {
                cuisines.push($(this).val());
            });
            //console.log(cuisines);
            $('.foodChoice').text(randomEl(cuisines));
            selectElementContents($('.foodChoice')[0]);
            console.log($('.foodChoice').textContent);
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

        var names = ["Vic", "Patty", "Sam", "Eddie", "Austin", "Seung", "Andrew", "Jason", "Mike"];

        //var cuisines = ["American", "Thai", "Pizza", "Burgers", "Sushi", "Italian", "Mexican",
        //    "New American", "Sandwiches", "Vietnamese", "Chinese", "German", "Healthy"];
    }
})();