(function () {
    'use strict';
    
    angular
    .module('inspinia')
        .controller('Jogador', Jogador);

    Jogador.$inject = ['$scope', '$state', '$http', 'NgTableParams','jogadorservice', '$uibModal', '$ngConfirm'];
    function Jogador($scope, $state, $http, NgTableParams, jogadorservice, $uibModal, $ngConfirm) {

        var vm = this;
        vm.init = init;
        vm.create = create;
        vm.excluir = excluir;


        init();

    function init() {

        jogadorservice.listar().success(function (res) {
            vm.dados = new NgTableParams({ sorting: { IdJogador: "desc" } }, { dataset: res });  
        }).error(function (res) {
            vm.msgalert = res.Message;
        });
        }

    function create(id) {
        var modalInstance = $uibModal.open({
            templateUrl: 'views/jogador/crud_jogador.html',
            controller: "CrudJogador as vm",
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
                        jogadorservice.excluir(id).success(function (result, status) {
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