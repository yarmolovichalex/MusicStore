﻿import controllers from "./controllers";

angular.module('musicStoreApp', ['ngRoute', controllers.name])
    .config([
        '$routeProvider', function($routeProvider) {
            $routeProvider
                .when('/artist', {
                    templateUrl: '../Scripts/admin/templates/artist.html',
                    controller: 'AdminController',
                    controllerAs: 'ctrl'
                })
                .when('/album', {
                    templateUrl: '../Scripts/admin/templates/album.html',
                    controller: 'AdminController',
                    controllerAs: 'ctrl'
                })
                .otherwise({ redirectTo: '/artist' });
        }
    ]);