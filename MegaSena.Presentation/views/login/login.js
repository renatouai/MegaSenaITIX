(function () {
    'use strict';
    
    angular
    .module('inspinia')
    .controller('Login', Login);

    Login.$inject = ['$q', '$scope', 'servicebase', '$state', '$http', '$uibModal', '$ngConfirm', 'localStorageService'];
    function Login($q, $scope, servicebase, $state, $http, $uibModal, $ngConfirm, localStorageService) {
       
        var vm = this;
        vm.login = login;
        vm.logout = logout;
        vm.init = init;

        init();

        function init() {
           
            
        }

        function login() {
            var data = "grant_type=password&username=" + vm.user.Login + "&password=" + vm.user.Senha;
            console.log(data);

            var config = {
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
                }
            }
            $http.post(servicebase.urlApi() + "/token", data, config).then(function successCallback(response) {

                localStorageService.clearAll();
                localStorage.removeItem('userName');
                localStorage.removeItem('apptoken');

                console.log(response);
                localStorage.setItem('apptoken', response.data.access_token);
                localStorage.setItem('userName', vm.user.Login);

                 if (response.data.access_token != '') {
                     $state.go('dashboard');
                 }

            }, function errorCallback(response) {
                toastr.error("Usuário ou senha inválidos");
            });
        }

        function logout() {

        }

 }
})();