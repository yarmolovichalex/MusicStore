import angular from angular;

let defaultRoute = angular
    .directive('defaultRoute', function() {
        return {
            restrict: 'A',
            scope: {
                defaultRoute: '@'
            },

            controller: [
                '$scope', '$location', function($scope, $location) {
                    $scope.checkDefaultRoute = function() {
                        if ($location.path() === '') {
                            $location.path($scope.defaultRoute);
                        }
                    };

                    $scope.$watch(function() { return $location.path(); }, $scope.checkDefaultRoute);
                }
            ],

            link: function(scope, element, attrs) {
                scope.checkDefaultRoute(attrs);
            }
        }
    });