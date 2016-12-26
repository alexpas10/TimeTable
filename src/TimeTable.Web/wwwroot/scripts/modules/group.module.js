angular.module('timeTableApp.group', ['ngMessages'])

.controller('groupDetailsController', function ($scope, $timeout, $http, $mdDialog, $element) {
	$scope.isEditMode = false;
	$scope.model;
	$scope.groups;
	$scope.searchTerm = '1';

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
		$http.get('/group/getgroups?typeId=19')
		   .success(function (data, status, headers, config) {
		   	$scope.groups = data;
		   })
		   .error(function (data, status, header, config) {
		   	$scope.ResponseDetails = "Data: " + data +
				"<br />status: " + status +
				"<br />headers: " + jsonFilter(header) +
				"<br />config: " + jsonFilter(config);
		   });
	};

	$scope.submit = function () {
		if ($scope.groupCreateForm.$valid) {
			$http({
				url: '/group/create',
				method: 'POST',
				data: $scope.model
			}).then(function () {

			});
		}
	}

	$scope.clearSearchTerm = function () {
		$scope.searchTerm = '';
	};
})

.controller('groupListController', function ($scope, $mdDialog, $mdToast) {
	$scope.showCreateDialog = function (ev) {
		$mdDialog.show({
			templateUrl: '/Group/Create',
			parent: angular.element(document.body),
			targetEvent: ev,
			clickOutsideToClose: true,
			fullscreen: true
		})
	}
});
