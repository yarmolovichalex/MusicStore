import controllers from "./controllers";

angular.module('musicStoreApp', ['ui.bootstrap', 'ngAnimate', controllers.name])
    .filter('secondsToDateTime', [function() {
        return function(seconds) {
            return new Date(1970, 0, 1).setSeconds(seconds);
        };
    }]);