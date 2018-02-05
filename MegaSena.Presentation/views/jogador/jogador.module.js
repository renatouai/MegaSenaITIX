(function () {
    'use strict';

    var appjogador = angular.module('app.jogador', []);

    appjogador.config(["$stateProvider", function ($stateProvider) {

        $stateProvider
            .state('jogador', {
                url: "/jogador",
                parent: 'app',
                templateUrl: "views/jogador/jogador.html",
                controller: "Jogador as vm",
                data: { pageTitle: 'Jogador', specialClass: 'fixed-sidebar' },
                authorize: true
            })
    }]);

})();