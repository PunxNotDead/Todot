angular.module('TodoApp').controller('RegisterController', ['$scope', 'UserFactory', function($scope, UserFactory) {
	$scope.user = {};
	$scope.errors = [];
	$scope.registered = false;

	$scope.register = function() {
		$scope.erros = [];

		UserFactory.create($scope.user).then(function(response) {
			var errors = response.data.errors || [];
			$scope.errors = errors;
			$scope.registered = errors.length === 0;
		});
	};
}]);