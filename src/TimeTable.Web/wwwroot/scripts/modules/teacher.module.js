angular.module('timeTableApp.teacher', ['ngMessages'])

.controller('teacherDetailsController', function ($scope, $timeout, $http, $mdDialog, $element) {
	$scope.isEditMode = false;
	$scope.subjects;
	$scope.teachers;
	$scope.needLoadTab = false;
	$scope.searchTerm = '';

	$scope.loadTab = function () {
		$scope.needLoadTab = true;
	};

	$scope.setEditMode = function () {
		$timeout(function () {
			$scope.isEditMode = true;
		}, 100);
	};

	$scope.setViewMode = function () {
		$timeout(function () {
			$scope.isEditMode = false;
		}, 100);
		$scope.teacherForm.$rollbackViewValue();
	};

	$scope.init = function (strArray) {
		$http.get('/subject/getsubjects')
		   .success(function (data, status, headers, config) {
		   	$scope.subjects = data;
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
})

.controller('teacherListController', function ($scope, $mdDialog, $mdToast) {
	$scope.showCreateDialog = function (ev) {
		$mdDialog.show({
			templateUrl: '/teacher/Create',
			parent: angular.element(document.body),
			targetEvent: ev,
			clickOutsideToClose: true,
			fullscreen: true
		})
	}
});
