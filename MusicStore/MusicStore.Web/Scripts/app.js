﻿import angular from 'angular';
import 'angular-route';

import controllers from "./controllers";

console.log(controllers);

angular.module('musicStoreApp', ['ngRoute', controllers.name])
    .config([
        '$routeProvider', function($routeProvider) {
            $routeProvider
                .when('/artistList', {
                    templateUrl: '../scripts/templates/artistList.html',
                    controller: 'HomeController',
                    controllerAs: 'ctrl'
                })
                .when('/albumList', {
                    templateUrl: '../scripts/templates/albumList.html',
                    controller: 'HomeController',
                    controllerAs: 'ctrl'
                })
                .when('/artist', {
                    templateUrl: '../scripts/templates/artist.html',
                    controller: 'AdminController',
                    controllerAs: 'ctrl'
                })
                .when('/album', {
                    templateUrl: '../scripts/templates/album.html',
                    controller: 'AdminController',
                    controllerAs: 'ctrl'
                })
                .otherwise({ redirectTo: '/404.html' });
        }
    ]);