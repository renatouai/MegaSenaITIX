(function () {
    'use strict';

    angular
    .module('inspinia')
        .controller('ProdutoVenda', ProdutoVenda);

    ProdutoVenda.$inject = ['$scope', 'gservice', 'produtoservice','tabelaprecoservice', '$state', '$http', 'NgTableParams', '$uibModal', '$uibModalInstance', '$ngConfirm','idtabela'];
    function ProdutoVenda($scope, gservice, produtoservice, tabelaprecoservice, $state, $http, NgTableParams, $uibModal, $uibModalInstance, $ngConfirm, idtabela) {
        var vm = this;
        $scope.forms = {};
        vm.formValid = true;
        vm.FormMessage = "";
        vm.busca = {
            NmProduto: '',
            IdProduto: 0
        };

        //Funções
        vm.init = init;
        vm.cancel = cancel;
        vm.selecionar = selecionar;
        vm.buscar = buscar;

        //Feature Start
        init();

        //Implementations
        function init() {
            tabelaprecoservice.listarProdutosTabelaPrecoPorNome(idtabela, vm.busca.NmProduto, vm.busca.IdProduto)
                .then(function (result) {
                    console.log(result);

                    vm.produtos = new NgTableParams({ sorting: { NmProduto: "asc" } }, { dataset: result.data });

                    console.log(vm.produtos);
                })
                .catch(function (ex) {
                    //exception.throwEx(ex);
                    //})['finally'](function () {
                    //      blocker.stop();
                });
        }

        function buscar() {
            /* if (vm.busca.NmProduto == "" && vm.busca.IdProduto == "") {
                vm.FormMessage = "Preencha pelo menos um dos campos para realizar a busca.";
            }
            else { */
                vm.FormMessage = "";
                tabelaprecoservice
                    .listarProdutosTabelaPrecoPorNome(idtabela, vm.busca.NmProduto, vm.busca.IdProduto)
                   .then(function (result) {
                       vm.produtos = new NgTableParams({ sorting: { NmProduto: "asc" } }, { dataset: result.data });
                   })
                   .catch(function (ex) {
                       //exception.throwEx(ex);
                       //})['finally'](function () {
                       //      blocker.stop();
                   });
            }
       // }

        function selecionar(item) {
            $uibModalInstance.close(item);
        }

        function cancel() {
            $uibModalInstance.dismiss('cancel');
        }
       
    }
})();