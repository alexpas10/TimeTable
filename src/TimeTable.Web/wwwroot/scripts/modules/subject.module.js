angular.module('timeTableApp.subject', ['ngMessages'])

.controller('subjectDetailsController', function ($scope, $timeout, $http, $mdDialog, $element) {
	$scope.isEditMode = false;
	$scope.initial;
	$scope.model;
	$scope.teachers;
	$scope.searchTerm;

	$scope.setEditMode = function () {
		$timeout(function () {
			$scope.isEditMode = true;
		}, 100);
	};

	$scope.setViewMode = function () {
		$timeout(function () {
			$scope.isEditMode = false;
		}, 100);
	};

	$scope.showDeleteConfirmationDialog = function (ev) {
		$mdDialog.show({
			contentElement: '#deleteDialog',
			parent: angular.element(document.body),
			targetEvent: ev,
			clickOutsideToClose: true,
		});
	};

	$scope.init = function () {
		$http.get('/teacher/getteachers')
		   .success(function (data, status, headers, config) {
		   	$scope.teachers = data;
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

.controller('subjectListController', function ($scope, $mdDialog, $mdToast) {

	$scope.showCreateDialog = function (ev) {
		$mdDialog.show({
			templateUrl: '/subject/create',
			parent: angular.element(document.body),
			targetEvent: ev,
			clickOutsideToClose: true,
			fullscreen: true
		});
	}
});
