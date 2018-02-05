(function () {
    'use strict';

    angular
           .module('inspinia') // Define a qual módulo seu .service pertence
        .factory('sorteioservice', sorteioservice); //Define o nome a função do seu .service

    sorteioservice.$inject = ['$http', 'servicebase']; //Lista de dependências
    function sorteioservice($http, servicebase) {

        var vm = this;
        var header = { headers: { 'Authorization': "Bearer " + localStorage.getItem('apptoken') } };

        var service = {
            salvar: salvar,
            excluir: excluir,
            listar: listar,
            obter: obter
        }
        return service;

        //Implementação das funções
        function obter(id) {
            return $http.get(servicebase.urlApi() + "/sorteio/obterporid/?id=" + id, header);
        }

        function salvar(obj) {
            return $http.post(servicebase.urlApi() + "/sorteio/salvar", obj, header);
        }

        function listar() {
            return $http.get(servicebase.urlApi() + "/sorteio/listar", header);
        }


        function excluir(id) {
            return $http.get(servicebase.urlApi() + "/sorteio/excluir/?id=" + id, header);
        }
    }
})();