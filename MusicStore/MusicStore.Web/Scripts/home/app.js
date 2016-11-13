import controllers from "./controllers";

angular.module('musicStoreApp', ['ngRoute', controllers.name])
    .config([
        '$routeProvider', function($routeProvider) {
            $routeProvider
                .when('/artistList', {
                    templateUrl: '../Scripts/home/templates/artistList.html',
                    controller: 'HomeController',
                    controllerAs: 'ctrl'
                })
                .when('/albumList', {
                    templateUrl: '../Scripts/home/templates/albumList.html',
                    controller: 'HomeController',
                    controllerAs: 'ctrl'
                })
                .otherwise({ redirectTo: '/artistList' });
        }
    ]);