(function () {
    'use strict';
    
    angular
    .module('inspinia')
        .controller('Sorteio', Sorteio);

    Sorteio.$inject = ['$scope', '$state', '$http','blockUI', 'NgTableParams','sorteioservice', '$uibModal', '$ngConfirm'];
    function Sorteio($scope, $state, $http, blockUI, NgTableParams, sorteioservice, $uibModal, $ngConfirm) {

        var vm = this;
        vm.init = init;
        vm.visualizar = visualizar;
        vm.createjogo = createjogo;
        vm.gerarJogos = gerarJogos;
        vm.realizarSorteio = realizarSorteio;

        init();

    function init() {

        sorteioservice.listar().success(function (res) {
            vm.dados = new NgTableParams({ sorting: { IdSorteio: "desc" } }, { dataset: res });
        }).error(function (res) {
            vm.msgalert = res.Message;
        });
    }

    function gerarJogos(id) {

        blockUI.start('Carregando..');
        sorteioservice.gerarJogos(id).success(function (res) {
            toastr.success("Jogos gerados com sucesso ");
            init();
        }).error(function (res) {
            vm.msgalert = res.Message;
            });

        blockUI.stop();
    }

    function realizarSorteio(id) {
        blockUI.start('Carregando..');
        sorteioservice.realizarSorteio(id).success(function (res) {
            toastr.success("Sorteio realizado com sucesso ");
            init();
        }).error(function (res) {
            vm.msgalert = res.Message;
            });
        blockUI.stop();
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

    function createjogo(idsorteio) {
        var modalInstance = $uibModal.open({
            templateUrl: 'views/jogo/crud_jogo.html',
            controller: "CrudJogo as vm",
            //windowClass: "animated flipInY",
            backdrop: 'static',
            size: 'lg',
            resolve: {
                idsorteio: function () {
                    return idsorteio;
                }
            }
        });
        modalInstance.result.then(function () {
            init();
        });
    }
 }
})();