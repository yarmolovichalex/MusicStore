export default [
    '$scope', '$http', '$location', function($scope, $http, $location) {

        $scope.artists = {};

        var getArtists = function() {
            $http.get('/musicstore/home/getArtists')
                .then(function(response) {
                    $scope.artists = response.data;
                });
        }

        var getAlbums = function() {
            $http.get('/musicstore/home/getAlbums')
                .then(function(response) {
                    $scope.albums = response.data;
                });
        }

        if ($scope.selectedTab === 'ArtistList') {
            getArtists();
        } else if ($scope.selectedTab === 'AlbumList') {
            getAlbums();
        }

        $scope.changeTab = function(tab) {
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

        $scope.$watch(function() {
            return $location.path();
        }, function(value) {
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
];