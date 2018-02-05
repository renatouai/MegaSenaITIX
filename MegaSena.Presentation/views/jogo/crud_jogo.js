(function () {
    'use strict';

    angular
    .module('inspinia')
        .controller('CrudJogo', CrudJogo);

    CrudJogo.$inject = ['$scope', 'gservice', '$http', 'jogadorservice', 'jogoservice','sorteioservice', 'blockUI', '$timeout', '$uibModal', '$uibModalInstance', 'idsorteio'];

    function CrudJogo($scope, gservice, $http, jogadorservice, jogoservice, sorteioservice , blockUI, $timeout, $uibModal, $uibModalInstance, idsorteio) {

        var vm = this;
        $scope.frm = {};
        vm.formValid = true;
        
        vm.salvar = salvar;
        vm.fechar = fechar;
        vm.init = init;      

        $scope.itens = [];
        vm.itensJogadores = [];
        vm.addItem = addItem;
        vm.removeItem = removeItem;

        init();

        function init() {
            blockUI.start('Carregando..');

            if (idsorteio > 0) {
                sorteioservice.obter(idsorteio).success(function (response) {
                    vm.sorteio = response;
                });
            } 
            blockUI.stop();
        }

        function salvar() {
            $scope.showErrorsCheckValidity = true;
            if ($scope.frm.$valid) {
                
                blockUI.start('Carregando..');

                
                vm.jogo.Jogadores = $scope.itens;
                vm.jogo.IdSorteio = idsorteio;

                jogoservice.salvar(vm.jogo).success(function (res) {
                    toastr.success("Cadastro realizado com sucesso");
                    $uibModalInstance.close();
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


        function limpaForm() {
            vm.CPF = "";
            vm.Nome = "";
        }


        function addItem() {

            if ((vm.CPF == undefined) || (vm.Nome == "")) {
                toastr.error("Informe um Jogador ");
                return;
            }
            var arrItens = [];

            arrItens = {
                Nome: vm.Nome,
                CPF: vm.CPF
            };

            // verifica se o jogador está na lista
            for (var i = 0; i < $scope.itens.length; i++) {
                if ($scope.itens[i].CPF == vm.CPF) {
                    toastr.error("Jogador já adicionado ");
                    return;
                }
            }

            $scope.itens.push(arrItens);
            vm.itensJogadores.push(arrItens);
            limpaForm()
        }

        function removeItem(index) {
            $scope.itens.splice(index, 1);
        };


    }
})();

