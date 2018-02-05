(function () {
    'use strict';

    var appsorteio = angular.module('app.sorteio', []);

    appsorteio.config(["$stateProvider", function ($stateProvider) {

        $stateProvider
            .state('sorteio', {
                url: "/sorteio",
                parent: 'app',
                templateUrl: "views/sorteio/sorteio.html",
                controller: "Sorteio as vm",
                data: { pageTitle: 'Sorteio', specialClass: 'fixed-sidebar' },
                authorize: true
            })
    }]);

})();