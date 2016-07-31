angular
    .module('musicStoreApp')
    .controller('HomeController', [
        '$scope', '$http', '$location', function ($scope, $http, $location) {

            $scope.changeTab = function (tab) {
                $scope.selectedTab = tab;
                switch ($scope.selectedTab) {
                    case 'ArtistList':
                        $location.path('/artistList');
                        break;
                    case 'AlbumList':
                        $location.path('/albumList');
                        break;
                    default:
                        $location.path('/artistList');
                }
            }

            $scope.$watch(function () {
                return $location.path();
            }, function (value) {
                switch (value) {
                    case '/artistList':
                        $scope.selectedTab = 'ArtistList';
                        break;
                    case '/albumList':
                        $scope.selectedTab = 'AlbumList';
                        break;
                    default:
                        $scope.selectedTab = 'ArtistList';
                }
            });
        }
    ]);