(function () {
    'use strict';

    angular
    .module('inspinia')
        .controller('VisualizaSorteio', VisualizaSorteio);

    VisualizaSorteio.$inject = ['$scope', '$http', 'sorteioservice', 'NgTableParams', 'blockUI', '$timeout', '$uibModal', '$uibModalInstance', 'item'];

    function VisualizaSorteio($scope, $http, sorteioservice, NgTableParams, blockUI, $timeout, $uibModal, $uibModalInstance, item) {

        var vm = this;
        $scope.frm = {};
        vm.formValid = true;
        
        vm.fechar = fechar;
        vm.init = init;   

        vm.sorteio = item;

        init();

        function init() {
            blockUI.start('Carregando..');


            vm.jogos = new NgTableParams({ sorting: { IdJogo: "desc" } }, { dataset: item.Jogos });  
            vm.ganhadores = new NgTableParams({ sorting: { IdJogo: "desc" } }, { dataset: item.Ganhadores });  

            blockUI.stop();
        }

        function fechar() {
            $uibModalInstance.dismiss();
        }
      
    }
})();

