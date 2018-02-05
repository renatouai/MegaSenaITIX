(function () {
    'use strict';
    
    angular
    .module('inspinia')
    .controller('Dashboard', Dashboard);

    Dashboard.$inject = ['$scope','$state', '$http', 'NgTableParams','sorteioservice', '$uibModal', '$ngConfirm'];
    function Dashboard($scope, $state, $http, NgTableParams, sorteioservice, $uibModal, $ngConfirm) {

        var vm = this;
        vm.init = init;

        init();

    function init() {

    }

    

 }
})();