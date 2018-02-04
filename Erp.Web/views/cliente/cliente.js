(function () {
    'use strict';

    angular
        .module('inspinia')
        .controller('Cliente', Cliente);

    Cliente.$inject = ['$scope', 'gservice','clienteservice', '$state', '$http', 'NgTableParams', '$uibModal', '$ngConfirm'];
    function Cliente($scope, gservice, clienteservice, $state, $http, NgTableParams, $uibModal, $ngConfirm) {

        var vm = this;

        vm.excluir = excluir;
        vm.crud = crud;
        vm.init = init;
        vm.listar = listar;
        vm.pesquisar = pesquisar;
        vm.auditoria = auditoria;

        init();

        function init() {
            listar();
        }

        function listar() {
            clienteservice.listar().then(function successCallback(response) {
                vm.clientes = new NgTableParams({ sorting: { IdCliente: "desc" } }, { dataset: response.data });

            });
        }

        function pesquisar() {

            if (vm.busca.Descricao == undefined) {
                vm.busca.Descricao = "";
            }

            clienteservice.pesquisar(vm.busca.Tipo,vm.busca.Descricao).then(function successCallback(response) {
                vm.clientes = new NgTableParams({ sorting: { IdCliente: "desc" } }, { dataset: response.data });

            }, function errorCallback(response) {
                alert('erro' + response)
            });
        }

        function crud(id) {
            var modalInstance = $uibModal.open({
                templateUrl: 'views/cliente/crud_cliente.html',
                controller: "CrudCliente as vm",
                //windowClass: "animated flipInY",
                backdrop: 'static',
                size: 'lg',
                resolve: {
                    id: function () {
                        return id;
                    }
                }
            });
            modalInstance.result.then(function () {
                init();
            });
        }

        function auditoria(item) {
            var modalInstance = $uibModal.open({
                templateUrl: 'views/cliente/auditoria.html',
                controller: "AuditoriaCliente as vm",
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

        function excluir(id) {
            $ngConfirm({
                title: 'Tem certeza que deseja excluir o registro selecionado?',
                content: '',
                scope: $scope,
                buttons: {
                    sayBoo: {
                        text: 'Sim, Apagar isso',
                        btnClass: 'btn-green',
                        action: function ($scope, button) {
                            clienteservice.excluir(id).success(function (result, status) {
                                toastr.success("Exclusão realizada com sucesso");
                                init();
                            }).error(function (res) {
                                toastr.error(res.Message);
                            });;
                        }
                    },
                    somethingElse: {
                        text: 'Cancelar',
                        btnClass: 'btn-danger',
                        action: function ($scope, button) {

                        }
                    }
                }
            });
        }
    }
})();