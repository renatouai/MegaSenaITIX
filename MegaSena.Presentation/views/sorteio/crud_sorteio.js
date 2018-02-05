(function () {
    'use strict';

    angular
    .module('inspinia')
        .controller('CrudSorteio', CrudSorteio);

    CrudSorteio.$inject = ['$scope', 'gservice', '$http', 'sorteioservice', 'blockUI', '$timeout', '$uibModal', '$uibModalInstance', 'id'];

    function CrudSorteio($scope, gservice, $http, sorteioservice, blockUI, $timeout, $uibModal, $uibModalInstance, id) {

        var vm = this;
        $scope.frm = {};
        vm.formValid = true;
        
        vm.salvar = salvar;
        vm.fechar = fechar;
        vm.init = init;      

        init();

        function init() {
            blockUI.start('Carregando..');
            
            /* if (id>0) {
                // busca dados sorteio
                sorteioservice.obterporid(id).success(function (response) {
                    vm.Sorteio = response;
                });
            } */
            blockUI.stop();
        }

        function salvar() {
            $scope.showErrorsCheckValidity = true;
            if ($scope.frm.$valid) {

                blockUI.start('Carregando..');
                grupoprodutoservice.salvar(vm.GrupoProduto).success(function (res) {
                    if (id > 0) {
                        toastr.success("Alteração realizada com sucesso");
                    } else {
                        toastr.success("Cadastro realizado com sucesso");
                    }
                    $uibModalInstance.close();
                }).error(function (res) {
                    toastr.error("Error" + res.MsgError);
                });
                blockUI.stop();
            } else {
                vm.msgalert = 'Existem campos obrigatórios sem o devido preenchimento';
                $('html, body').animate({ scrollTop: 0 }, 'slow');
            }
        }

        function fechar() {
            $uibModalInstance.dismiss();
        }
      
    }
})();

