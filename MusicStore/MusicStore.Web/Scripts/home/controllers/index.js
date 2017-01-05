import home from "./home";
import albumList from "./albumList";

export default angular.module('musicStoreApp.controllers', [])
    .controller('HomeController', home)
    .controller('AlbumListController', albumList);