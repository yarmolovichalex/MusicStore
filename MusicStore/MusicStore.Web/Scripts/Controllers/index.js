import angular from 'angular';
import AdminController from "../controllers/admin-controller.js";
import HomeController from "../controllers/home-controller.js";

export default function() {

    var app = angular.module('musicStoreApp');
    app.controller('AdminController', AdminController);
    app.controller('HomeController', HomeController);

};