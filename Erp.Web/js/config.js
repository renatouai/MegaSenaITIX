/**
 * INSPINIA - Responsive Admin Theme
 *
 * Inspinia theme use AngularUI Router to manage routing and views
 * Each view are defined as state.
 * Initial there are written state for all view in theme.
 *
 */
function config($httpProvider, $stateProvider, $urlRouterProvider, $locationProvider, $ocLazyLoadProvider, IdleProvider, KeepaliveProvider) {
  
    // Configure Idle settings
   // IdleProvider.idle(5); // in seconds
   // IdleProvider.timeout(120); // in seconds

  //  $httpProvider.interceptors.push('authInterceptor');
    
    $ocLazyLoadProvider.config({
        // Set to true if you want to see what and when is dynamically loaded
        debug: false
    });

    $stateProvider.state('principal', {
        url: "/principal",
        templateUrl: "views/principal.html",
        data: { pageTitle: 'Outlook view', specialClass: 'fixed-sidebar' }

    }).state('login', {
        url: "/login",
        controller: "Login as vm",
        templateUrl: "login.html"

    }).state('app', {
        url: '',
        abstract: true,
        templateUrl: 'layout.html'
    });
    


    $urlRouterProvider.otherwise("dashboard");


    /* .state('login', {
        url: "/login",
        views: {
            layout: {
                templateUrl: "login.html"
            }
        }
    }) */
    
   /*  (window.history && window.history.pushState) {
        $locationProvider.html5Mode(true);
    } */
    // C


    /*
    var data = localStorage.getItem('apptoken');
    if (data) {
        $httpProvider.defaults.headers.common['Authorization'] = "Bearer " + localStorage.getItem('apptoken');
    }*/

    // COnfiguração default HTTP 
    //   $httpProvider.defaults.headers.common['Authorization'] = "Bearer " + localStorage.getItem('apptoken');

}
angular
    .module('inspinia')
    .config(config)
    .run(function($rootScope, $state) {
        $rootScope.$state = $state;

    });

angular.module('inspinia').service('authInterceptor', function ($location, $q) {    
    return {
       /* request: function (config) {
            config.headers = config.headers || {};

            if (localStorage.getItem('apptoken')) {
                config.headers['Authorization'] = 'Bearer ' + localStorage.getItem('apptoken');
            }

            return config;
        }, */

        responseError: function (response) {
            if (response.status === 401 || response.status === 403) {
                $location.path('/login');
            }

            return $q.reject(response);
        }
    }
})

