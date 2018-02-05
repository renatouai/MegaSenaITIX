(function () {
    'use strict';

    angular
        .module('inspinia')
        .controller('CrudCliente', CrudCliente);

    CrudCliente.$inject = ['$scope', 'gservice', '$http', 'clienteservice', 'commonservice','blockUI', '$timeout', '$uibModal', '$uibModalInstance', 'id'];

    function CrudCliente($scope, gservice, $http, clienteservice, commonservice, blockUI, $timeout, $uibModal, $uibModalInstance, id) {

        var vm = this;
        $scope.frm = {};
        vm.formValid = true;

        vm.salvar = salvar;
        vm.fechar = fechar;
        vm.init = init;
        vm.carregacidadesporestado = carregacidadesporestado;

        init();

        vm.TipoPessoa = [
            { Id: "PF", Nome: "Pessoa Física" },
            { Id: "PJ", Nome: "Pessoa Jurídica" }
        ];
        vm.Cliente = {};


        function init() {
            blockUI.start('Carregando..');

            commonservice.obterestados().success(function (result, status) {
                vm.estados = result;
            });

            if (id > 0) {
                // busca dados 
                clienteservice.obtercliente(id).success(function (response) {
                    vm.Cliente = response;
                    vm.Tipo = vm.Cliente.Tipo;

                    commonservice.obtercidadesporestado(vm.Cliente.IdEstado).success(function (result, status) {
                        vm.cidades = result;
                        vm.Cliente.IdCidade = response.IdCidade;
                    });
                });
            } else {
                vm.Tipo = "PF";
            }
            blockUI.stop();
        }

        function carregacidadesporestado() {
            blockUI.start('Carregando..');
            commonservice.obtercidadesporestado(vm.Cliente.IdEstado).success(function (result, status) {
                vm.cidades = result;
                vm.cliente.IdCidade = "";
            });
            blockUI.stop();
        }

        function salvar() {
            $scope.showErrorsCheckValidity = true;
            if ($scope.frm.$valid) {

                blockUI.start('Carregando..');

                vm.Cliente.Tipo = vm.Tipo;

                vm.msgaler = '';

                clienteservice.salvar(vm.Cliente).success(function (res) {
                    if (id > 0) {
                        toastr.success("Alteração realizada com sucesso");
                    } else {
                        toastr.success("Cadastro realizado com sucesso");
                    }
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

    }
})();

