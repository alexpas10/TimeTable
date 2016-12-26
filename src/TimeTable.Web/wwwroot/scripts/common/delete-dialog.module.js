angular.module('timeTableApp.deleteDialog', ['ngMaterial'])

.controller('dialogController', function ($scope, $mdDialog) {
    $scope.status = '  ';
    $scope.customFullscreen = false;

    $scope.hide = function () {
        $mdDialog.hide();
    };

    $scope.showDeleteConfirmationDialog = function (ev) {
    	$mdDialog.show({
    		contentElement: '#deleteDialog',
    		parent: angular.element(document.body),
    		targetEvent: ev,
    		clickOutsideToClose: true,
    	});
    };
});