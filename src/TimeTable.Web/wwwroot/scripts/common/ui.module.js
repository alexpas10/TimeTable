angular
    .module('timeTableApp.ui', ['ngMaterial'])
    .controller('menuController', function ($scope, $mdSidenav) {
        $scope.toggle = function () {
            $mdSidenav('leftMenu').toggle()
        };
    })
	.controller('toastController', function ($scope, $mdToast, $mdDialog) {

		$scope.closeToast = function() {
			$mdToast.hide();
		};
	});