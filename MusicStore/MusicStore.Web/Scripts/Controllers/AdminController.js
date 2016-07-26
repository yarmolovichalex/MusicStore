angular
    .module('musicStoreApp')
    .controller('AdminController', [
        '$scope', '$http', function($scope, $http) {

            $scope.submit = function() {
                $http.post('/musicstore/admin/addartist', {
                    Name: $scope.name,
                    Country: $scope.country
                });
            }
        }
    ]);