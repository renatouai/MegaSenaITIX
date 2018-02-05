(function () {
    'use strict';

    angular
    .module('inspinia')
        .controller('CrudJogo', CrudJogo);

    CrudJogo.$inject = ['$scope', 'gservice', '$http', 'jogadorservice','jogoservice', 'blockUI', '$timeout', '$uibModal', '$uibModalInstance', 'id'];

    function CrudJogo($scope, gservice, $http, jogadorservice, jogoservice, blockUI, $timeout, $uibModal, $uibModalInstance, id) {

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

                jogoservice.obter(id).success(function (response) {
                    vm.jogo = response;
                });
            } 
            blockUI.stop();
        }

        function salvar() {
            $scope.showErrorsCheckValidity = true;
            if ($scope.frm.$valid) {

                blockUI.start('Carregando..');
                jogoservice.salvar(vm.jogo).success(function (res) {
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

