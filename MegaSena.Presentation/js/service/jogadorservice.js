(function () {
    'use strict';

    angular
        .module('inspinia') // Define a qual módulo seu .service pertence
        .factory('jogadorservice', jogadorservice); //Define o nome a função do seu .service

    jogadorservice.$inject = ['$http', 'servicebase']; //Lista de dependências
    function jogadorservice($http, servicebase) {

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
            return $http.get(servicebase.urlApi() + "/jogador/obter/?id=" + id, header);
        }

        function salvar(obj) {
            return $http.post(servicebase.urlApi() + "/jogador/salvar", obj, header);
        }

        function listar() {
            return $http.get(servicebase.urlApi() + "/jogador/listar", header);
        }


        function excluir(id) {
            return $http.get(servicebase.urlApi() + "/jogador/excluir/?id=" + id, header);
        }
    }
})();