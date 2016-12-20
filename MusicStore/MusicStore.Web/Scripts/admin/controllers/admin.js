export default [
    '$scope', '$http', '$location', function($scope, $http, $location) {

        $scope.changeTab = function(tab) {
            $scope.selectedTab = tab;
            switch ($scope.selectedTab) {
            case 'Artist':
                $location.path('/artist');
                break;
            case 'Album':
                $location.path('/album');
                break;
            default:
                $location.path('/artist');
            }
        }

        $scope.$watch(function() {
            return $location.path();
        }, function(value) {
            switch (value) {
            case '/artist':
                $scope.selectedTab = 'Artist';
                break;
            case '/album':
                $scope.selectedTab = 'Album';
                break;
            default:
                $scope.selectedTab = 'Artist';
            }
        });

        $scope.saveArtists = function() {
            $http.post('/musicstore/admin/saveartists', {
                artists: $scope.artists
            });
        }

        $scope.saveAlbum = function() {
            $http.post('/musicstore/admin/addalbum', {
                Name: $scope.album.name,
                ArtistName: $scope.album.artist,
                Year: $scope.album.year,
                Price: {
                    Amount: $scope.album.price.amount,
                    Currency: "USD" // todo DDL for currencies
                }
            });
        }

        let getArtists = function() {
            $http.get('/musicstore/admin/getArtists')
                .then(function(response) {
                    $scope.artists = response.data;
                });
        }

        if ($scope.selectedTab === 'Artist') {
            getArtists();
        }
    }
];