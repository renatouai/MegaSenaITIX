(function () {
    'use strict';

    angular
    .module('inspinia')
    .controller('AuditoriaCliente', AuditoriaCliente);

    AuditoriaCliente.$inject = ['$scope', 'commonservice', 'gservice', 'clienteservice', 'planoservice', 'servicebase', '$http', 'blockUI', '$state', '$uibModal','$uibModalInstance','item'];

    function AuditoriaCliente($scope, commonservice, gservice, clienteservice, planoservice, servicebase, $http, blockUI, $state, $uibModal,$uibModalInstance, item) {

        var vm = this;
        vm.init = init;
        vm.fechar = fechar;

        init();
        vm.Cliente = item;

        function init() {
          
        }
        function fechar() {
            $uibModalInstance.dismiss();
        }
    }
})();

