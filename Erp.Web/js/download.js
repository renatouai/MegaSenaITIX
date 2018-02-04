(function () {
    'use strict';

    angular.module('inspinia')
           .factory('download', download);

    download.$inject = ['$http', '$window', '$document']; // 'exception',

    function download($http, $window, $document) { // exception

        var header = { headers: { 'Authorization': "Bearer " + localStorage.getItem('apptoken') } };

        var service = {
            requestSave: requestSave,
            requestLoad: requestLoad,
            requestLoadPost: requestLoadPost,
            request: request
        };

        return service;

        //Salvar o arquivo 
        function requestSave(options) {

            var url = options.url;
            var dados = options.dados;
            var nomeDoArquivo = options.nomeDoArquivo;
            var contentType = options.contentType;
            var accept = options.accept;

            return $http.get(url, {
                //responseType: 'arraybuffer',
                params: dados,
                headers: {
                    'Content-type': contentType,
                    'Accept': accept,
                    'Authorization': "Bearer " + localStorage.getItem('apptoken')
                }
            }).then(function (arquivo) {
                var blob = new Blob([arquivo.data], {
                    type: accept
                });
                saveAs(blob, nomeDoArquivo);
                return arquivo;
            }).catch(function (error) {
                // exception.throwEx(error);
                throw error;
            });
        }

        //Abrir o arquivo em outra janela GET
        function requestLoad(options) {

            return $http.get(options.url, {
                cache: false,
                params: options.params,
                responseType: 'arraybuffer',
                headers: {
                    'Authorization': "Bearer " + localStorage.getItem('apptoken')
                }
            }).success(function (data, status, headers) {
                if (status == 200) {
                    headers = headers();
                    var filename = headers['x-filename'];
                    var contentType = headers['content-type'];
                    var blob = new Blob([data], { type: contentType });
                    var urlFile = $window.URL.createObjectURL(blob);
                    $window.open(urlFile, options.name, options.window);
                }
            });
        }

        //Abrir o arquivo em outra janela POST
        function requestLoadPost(options) {

            var config = {
                responseType: 'arraybuffer',
                cache:false
            }

            return $http.post(options.url, options.params, config).success(function (data, status, headers) {
                console.log(status)
                if (status == 200) {
                    headers = headers();
                    var filename = headers['x-filename'];
                    var contentType = headers['content-type'];
                    var blob = new Blob([data], { type: contentType });
                    var urlFile = $window.URL.createObjectURL(blob);
                    $window.open(urlFile, options.name, options.window);
                }
            });
        }

        //Efetua o dowload do arquivo no browser
        function request(options) {
            return $http.get(options.url, {
                cache: false,
                params: options.params,
                responseType: 'arraybuffer',
                headers: {
                    'Authorization': "Bearer " + localStorage.getItem('apptoken')
                }
            }).success(function (data, status, headers) {
                if (status == 200) {
                    headers = headers();
                    var filename = headers['x-filename'];
                    var contentType = headers['content-type'];
                    var blob = new Blob([data], { type: contentType });
                    var urlFile = $window.URL.createObjectURL(blob);

                    var a = document.createElement('a');
                    a.href = urlFile;
                    a.download = options.filename;
                    a.target = '_blank';
                    a.click();
                    $window.URL.revokeObjectURL(urlFile);
                }
            });
        }
    }
})();