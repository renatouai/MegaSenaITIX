(function () {
    'use strict';
    
    angular
    .module('inspinia')
        .controller('Jogo', Jogo);

    Jogo.$inject = ['$scope', '$state', '$http', 'NgTableParams', 'jogadorservice', 'jogoservice', '$uibModal', '$ngConfirm'];
    function Jogo($scope, $state, $http, NgTableParams, jogadorservice,jogoservice, $uibModal, $ngConfirm) {

        var vm = this;
        vm.init = init;
        vm.create = create;
        vm.excluir = excluir;


        init();

    function init() {

        jogoservice.listar().success(function (res) {
            vm.dados = new NgTableParams({ sorting: { IdJogo: "desc" } }, { dataset: res });  
        }).error(function (res) {
            vm.msgalert = res.Message;
        });
        }

    function create(id) {
        var modalInstance = $uibModal.open({
            templateUrl: 'views/jogoservice/crud_jogo.html',
            controller: "CrudJogo as vm",
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
                        jogoservice.excluir(id).success(function (result, status) {
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