
angular.module('TodoApp').factory('UserFactory', function($http) {
	var url = '/User'

	function get(id) {

	};

	function post(data) {
		return $http.post(url + '/New', data);
	}

	return {
		get: get,
		post: post
	};
});