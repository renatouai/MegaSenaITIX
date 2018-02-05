(function () {
    'use strict';

    var appdashboard = angular.module('app.dashboard', []);

    appdashboard.config(["$stateProvider", function ($stateProvider) {

        $stateProvider
            .state('dashboard', {
                url: "/dashboard",
                parent: 'app',
                templateUrl: "views/dashboard/dashboard.html",
                controller: "Dashboard as vm",
                data: { pageTitle: 'Dashboard', specialClass: 'fixed-sidebar' },
                authorize: true
            })
    }]);

})();