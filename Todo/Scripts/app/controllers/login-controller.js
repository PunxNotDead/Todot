angular.module('TodoApp').controller('LoginController', ['$scope', 'UserFactory', '$routeParams', '$location', function($scope, UserFactory, $routeParams, $location) {
	$scope.user = {};
	$scope.errors = [];
	
	function getParameterByName(name) {
		var match = RegExp('[?&]' + name + '=([^&]*)').exec(window.location.search);
		return match && decodeURIComponent(match[1].replace(/\+/g, ' '));
	}

	$scope.login = function() {
		$scope.errors = [];
		
		UserFactory.login($scope.user).then(function(response) {
			var errors = response.data.errors;
			$scope.errors = errors;

			if (errors && errors.length === 0)
			{
				var path = getParameterByName('ReturnUrl');

				window.location = path ? path : '/';
			}
		});
	};
}]);