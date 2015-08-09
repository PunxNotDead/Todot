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

	function logout() {
		return $http.post(url + '/Logout');
	}

	return {
		get: get,
		create: create,
		login: login,
		logout: logout
	};
});