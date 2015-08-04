
angular.module('TodoApp').factory('UserFactory', function($http) {
	var url = '/User'

	function get(id) {

	};

	function create(data) {
		return $http.post(url + '/New', data);
	}

	function login(data) {
		return $http.post(url + '/Login', data);
	}

	return {
		get: get,
		create: create,
		login: login
	};
});