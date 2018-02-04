(function () {
    'use strict';

    angular
    .module('inspinia')
    .controller('PessoaModal', PessoaModal);

    PessoaModal.$inject = ['$scope', 'gservice', 'pessoaservice', '$state', '$http', 'NgTableParams', '$uibModal', '$uibModalInstance', '$ngConfirm'];
    function PessoaModal($scope, gservice, pessoaservice, $state, $http, NgTableParams, $uibModal, $uibModalInstance, $ngConfirm) {
        var vm = this;
        $scope.forms = {};
        vm.formValid = true;
        vm.FormMessage = "";
        vm.busca = {
            nome: '',
            cpfcnpj: ''
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

        }

        function buscar() {
            if (vm.busca.nome == "" && vm.busca.cpfcnpj == "") {
                vm.FormMessage = "Preencha pelo menos um dos campos para realizar a busca.";
            }
            else {
                vm.FormMessage = "";
                pessoaservice
                   .buscapessoa(vm.busca.nome, vm.busca.cpfcnpj)
                   .then(function (result) {
                       vm.pessoas = result.data;
                   })
                   .catch(function (ex) {
                       //exception.throwEx(ex);
                       //})['finally'](function () {
                       //      blocker.stop();
                   });
            }
        }

        function selecionar(item) {
            $uibModalInstance.close(item);
        }

        function cancel() {
            $uibModalInstance.dismiss('cancel');
        }
       
    }
})();