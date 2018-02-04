(function () {
    'use strict';

    angular
           .module('inspinia') // Define a qual módulo seu .service pertence
           .service('servicebase', servicebase); //Define o nome a função do seu .service

    servicebase.$inject = ['$http']; //Lista de dependências

    function servicebase($http) {

        var vm = this;

        //
        vm.urlApi = urlApi;

        //Implementação das funções
        function urlApi() {
             return "http://localhost:56738";
            // return "http://localhost:50603"
        }

    }
})();