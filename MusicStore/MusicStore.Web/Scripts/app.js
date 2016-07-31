angular.module('musicStoreApp', ['ngRoute'])
    .config([
        '$routeProvider', function($routeProvider) {
            $routeProvider
                .when('/', {
                    templateUrl: '../scripts/templates/add-artist.html',
                    controller: 'AdminController',
                    controllerAs: 'ctrl'
                })
                .when('/artist', {
                    templateUrl: '../scripts/templates/add-artist.html',
                    controller: 'AdminController',
                    controllerAs: 'ctrl'
                })
                .when('/album', {
                    templateUrl: '../scripts/templates/add-album.html',
                    controller: 'AdminController',
                    controllerAs: 'ctrl'
                });
        }
    ]);