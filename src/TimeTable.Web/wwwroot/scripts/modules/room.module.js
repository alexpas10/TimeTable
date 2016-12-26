angular.module('timeTableApp.room', ['ngMessages'])

.controller('roomDetailsController', function ($scope, $timeout, $http, $mdDialog) {
	$scope.isEditMode = false;
	$scope.pressedSubmit = false;
	$scope.initial;
	$scope.model;

	$scope.setEditMode = function () {
		$timeout(function () {
			$scope.isEditMode = true;
		}, 100);
	};

	$scope.setViewMode = function () {
		$timeout(function () {
			$scope.isEditMode = false;
			$scope.model = new room($scope.initial.name, $scope.initial.places, $scope.initial.typeId, $scope.initial.buildingId);
		}, 100);
	};

	$scope.init = function (name, places, typeId, buildingId) {
		$scope.initial = new room(name, places, typeId, buildingId);
		$scope.model = new room(name, places, typeId, buildingId);
	}

	$scope.showDeleteConfirmationDialog = function (ev) {
		$mdDialog.show({
			//   controller: DialogController,
			contentElement: '#deleteDialog',
			parent: angular.element(document.body),
			targetEvent: ev,
			clickOutsideToClose: true,
		});
	};
	$scope.submit = function () {
		if ($scope.roomCreateForm.$valid) {
			$http({
				url: '/room/create',
				method: 'POST',
				data: $scope.model
			}).then(function () {
				
			});
		}
	}

	$scope.trySubmit = function () {
		$scope.pressedSubmit = true;
	}

	function room(name, places, typeId, buildingId) {
		this.name = name;
		this.places = places;
		this.typeId = typeId;
		this.buildingId = buildingId;
	}
})

.controller('roomListController', function ($scope, $mdDialog, $mdToast) {
	$scope.showCreateDialog = function (ev) {
		$mdDialog.show({
			templateUrl: '/Room/Create',
			parent: angular.element(document.body),
			targetEvent: ev,
			clickOutsideToClose: true,
			fullscreen: true
		})
	}
});
