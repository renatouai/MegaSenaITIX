(function () {
    'use strict';

    var appCliente = angular.module('app.cliente', []);

    appCliente.config(["$stateProvider", function ($stateProvider) {

        $stateProvider
            .state('cliente', {
                parent: 'app',
                url: "/cliente",
                templateUrl: "views/cliente/lista_cliente.html",
                controller: "Cliente as vm",
                data: { pageTitle: 'Cliente', specialClass: 'fixed-sidebar' },
                authorize: true
            })
            .state('crud_cliente', {
                parent: 'app',
                url: "/crud_cliente/:id",
                templateUrl: "views/cliente/crud_cliente.html",
                controller: "CrudCliente as vm",
                data: { pageTitle: 'Cliente', specialClass: 'fixed-sidebar' },
                authorize: true
            })
    }]);

})();