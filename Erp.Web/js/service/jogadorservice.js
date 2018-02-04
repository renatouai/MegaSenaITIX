(function () {
    'use strict';

    angular
           .module('inspinia') // Define a qual módulo seu .service pertence
        .factory('cardapioservice', cardapioservice); //Define o nome a função do seu .service

    cardapioservice.$inject = ['$http', 'servicebase']; //Lista de dependências
    function cardapioservice($http, servicebase) {

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
            return $http.get(servicebase.urlApi() + "/cadastro/obterCardapio/?id=" + id, header);
        }

        function salvar(obj) {
            return $http.post(servicebase.urlApi() + "/cadastro/salvarCardapio", obj, header);
        }

        function listar() {
            return $http.get(servicebase.urlApi() + "/cadastro/listarCardapio", header);
        }


        function excluir(id) {
            return $http.get(servicebase.urlApi() + "/cadastro/excluirCardapio/?id=" + id, header);
        }
    }
})();