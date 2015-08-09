angular.module('TodoApp').controller('ListController', ['$scope', 'UserFactory', function($scope, UserFactory) {
	$scope.logout = function() {
		UserFactory.logout().then(function(response) {
			window.location = '/User/Login';
		});
	};
}]);