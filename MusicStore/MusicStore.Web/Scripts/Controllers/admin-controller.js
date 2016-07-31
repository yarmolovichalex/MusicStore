angular
    .module('musicStoreApp')
    .controller('AdminController', [
        '$scope', '$http', function($scope, $http) {

            $scope.saveArtist = function() {
                $http.post('/musicstore/admin/addartist', {
                    Name: $scope.artistName,
                    Country: $scope.artistCountry
                });
            }

            $scope.saveAlbum = function () {
                $http.post('/musicstore/admin/addalbum', {
                    Name: $scope.albumName,
                    ArtistName: $scope.albumArtist,
                    Year: $scope.albumYear
                });
            }
        }
    ]);