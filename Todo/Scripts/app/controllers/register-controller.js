angular.module('TodoApp').controller('RegisterController', ['$scope', 'UserFactory', function($scope, UserFactory) {
	$scope.user = {};

	$scope.register = function() {
		UserFactory.create($scope.user);
	};
}])