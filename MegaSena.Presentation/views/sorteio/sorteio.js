(function () {
    'use strict';
    
    angular
    .module('inspinia')
        .controller('Sorteio', Sorteio);

    Sorteio.$inject = ['$scope','$state', '$http', 'NgTableParams','sorteioservice', '$uibModal', '$ngConfirm'];
    function Sorteio($scope, $state, $http, NgTableParams, sorteioservice, $uibModal, $ngConfirm) {

        var vm = this;
        vm.init = init;
        vm.visualizar = visualizar;


        init();

    function init() {

        sorteioservice.listar().success(function (res) {
            vm.dados = new NgTableParams({ sorting: { IdSorteio: "desc" } }, { dataset: res });  
        }).error(function (res) {
            vm.msgalert = res.Message;
        });
        }

    function visualizar(item) {
        var modalInstance = $uibModal.open({
            templateUrl: 'views/sorteio/visualizasorteio.html',
            controller: "VisualizaSorteio as vm",
            //windowClass: "animated flipInY",
            backdrop: 'static',
            size: 'lg',
            resolve: {
                item: function () {
                    return item;
                }
            }
        });
        modalInstance.result.then(function () {
            init();
        });
    }

    

 }
})();