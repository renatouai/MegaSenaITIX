(function () {
    'use strict';

    angular
           .module('inspinia') // Define a qual módulo seu .service pertence
        .factory('jogoservice', jogoservice); //Define o nome a função do seu .service

    jogoservice.$inject = ['$http', 'servicebase']; //Lista de dependências
    function jogoservice($http, servicebase) {

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
            return $http.get(servicebase.urlApi() + "/cadastro/obterJogo/?id=" + id, header);
        }

        function salvar(obj) {
            return $http.post(servicebase.urlApi() + "/cadastro/salvarJogo", obj, header);
        }

        function listar() {
            return $http.get(servicebase.urlApi() + "/cadastro/listarJogo", header);
        }


        function excluir(id) {
            return $http.get(servicebase.urlApi() + "/cadastro/excluirJogo/?id=" + id, header);
        }
    }
})();