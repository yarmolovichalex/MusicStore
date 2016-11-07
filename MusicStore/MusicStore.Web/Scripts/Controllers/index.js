import admin from "./admin";
import home from "./home";

export default angular.module('musicStoreApp.controllers', [])
    .controller('AdminController', admin)
    .controller('HomeController', home);