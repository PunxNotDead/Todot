var todoControllers = angular.module('todoControllers', []);

todoControllers.controller('RegisterCtrl', ['$scope', '$http', function ($scope, $http) {
    $scope.register = function() {
        console.log($scope.user);


    };
}]);
