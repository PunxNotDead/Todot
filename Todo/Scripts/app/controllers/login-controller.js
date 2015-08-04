angular.module('TodoApp').controller('LoginController', ['$scope', 'UserFactory', function($scope, UserFactory) {
	$scope.user = {};

	$scope.login = function() {
		UserFactory.login($scope.user);
	};
}])