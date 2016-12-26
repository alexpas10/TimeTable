angular
    .module('timeTableApp.details-info', ['ngMaterial'])
    .controller('detailsInfoController', function ($scope) {
    	$scope.show = true;
    	$scope.items;
    	$scope.searchTerm;

    	$scope.toggle = function () {
    		$scope.show = !$scope.show;
    	};

    	$scope.init = function (path) {
    		$http.get(path)
			   .success(function (data, status, headers, config) {
			   	$scope.items = data;
			   })
			   .error(function (data, status, header, config) {
			   	$scope.ResponseDetails = "Data: " + data +
					"<br />status: " + status +
					"<br />headers: " + jsonFilter(header) +
					"<br />config: " + jsonFilter(config);
			   });
    	};

    	$scope.clearSearchTerm = function () {
    		$scope.searchTerm = '';
    	};
    });