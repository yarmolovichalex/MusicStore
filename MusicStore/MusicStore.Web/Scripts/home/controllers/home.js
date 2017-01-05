export default [
    '$scope', '$http', '$uibModal', function($scope, $http, $uibModal) {

        let $ctrl = this;

        $scope.artists = {};

        let getArtists = function() {
            $http.get('/musicstore/home/getArtists')
                .then(function(response) {
                    $scope.artists = response.data;
                });
        }

        getArtists();

        $ctrl.showAlbums = function(artistId) {
            $http.get('/musicstore/home/getAlbumsOfArtist?artistId=' + artistId)
                .then(function(response) {
                    $uibModal.open({
                        animation: true,
                        ariaLabelledBy: 'modal-title',
                        ariaDescribedBy: 'modal-body',
                        templateUrl: '../Scripts/home/templates/albumList.html',
                        controller: 'AlbumListController',
                        controllerAs: '$ctrl',
                        resolve: {
                            data: function() {
                                return response.data;
                            }
                        }
                    }).result.catch(function() {});
                });
        }
    }
];