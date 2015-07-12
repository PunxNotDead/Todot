
angular.module('TodoApp').controller('RegisterController', ['$scope', 'UserFactory', function($scope, UserFactory) {
    $scope.register = function() {
        UserFactory.post($scope.user);
    };
}])