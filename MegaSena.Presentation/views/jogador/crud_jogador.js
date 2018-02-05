(function () {
    'use strict';

    angular
    .module('inspinia')
        .controller('CrudJogador', CrudJogador);

    CrudJogador.$inject = ['$scope', 'gservice', '$http', 'jogadorservice', 'blockUI', '$timeout', '$uibModal', '$uibModalInstance', 'id'];

    function CrudJogador($scope, gservice, $http, jogadorservice, blockUI, $timeout, $uibModal, $uibModalInstance, id) {

        var vm = this;
        $scope.frm = {};
        vm.formValid = true;
        
        vm.salvar = salvar;
        vm.fechar = fechar;
        vm.init = init;      

        init();

        function init() {
            blockUI.start('Carregando..');
            
            if (id > 0) {

                jogadorservice.obter(id).success(function (response) {
                    vm.jogador = response;
                });
            } 
            blockUI.stop();
        }

        function salvar() {
            $scope.showErrorsCheckValidity = true;
            if ($scope.frm.$valid) {

                blockUI.start('Carregando..');
                jogadorservice.salvar(vm.jogador).success(function (res) {
                    if (id > 0) {
                        toastr.success("Alteração realizada com sucesso");
                    } else {
                        toastr.success("Cadastro realizado com sucesso");
                    }
                    $uibModalInstance.close(res);
                }).error(function (res) {
                    vm.msgalert = res.Message;
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

