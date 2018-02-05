(function () {
    'use strict';

    var appjogo = angular.module('app.jogo', []);

    appjogo.config(["$stateProvider", function ($stateProvider) {

        $stateProvider
            .state('jogo', {
                url: "/jogo",
                parent: 'app',
                templateUrl: "views/jogo/jogo.html",
                controller: "Jogo as vm",
                data: { pageTitle: 'Jogo', specialClass: 'fixed-sidebar' },
                authorize: true
            })
    }]);

})();