angular
    .module('timeTableApp.class', ['ngMaterial'])
    .controller('classController', function ($scope, $http, $mdToast, $mdDialog) {
    	$scope.show = true;
    	$scope.items;
    	$scope.loads;
    	$scope.rooms;
    	$scope.groupKeyValues;
    	$scope.groupSelectItems;
    	$scope.weekAlternations;
    	$scope.days;
    	$scope.numbers = [];

    	$scope.searchTerm;

    	$scope.toggle = function () {
    		$scope.show = !$scope.show;
    	};

    	$scope.setEditMode = function (load) {
    		load.isEdit = true;
    	}

    	$scope.setViewMode = function (load) {
    		load.isEdit = false
    	}

    	$scope.initCreate = function (dayId, groupId, number) {
    		$http.get('/class/days')
				.success(function (data, status, headers, config) {
					$scope.days = data;
					$scope.initNumbers();
					$http.get('/group/getgroupselectitems')
					   .success(function (data, status, headers, config) {
					   	$scope.groupSelectItems = data;
					   	$http.get('/load/getavalivableloadselectitems?dayId=' + dayId + '&groupId=' + groupId + '&number=' + number)
						   .success(function (data, status, headers, config) {
						   	$scope.loads = data;
						   	$http.get('/class/weekalternations?dayId=' + dayId + '&groupId=' + groupId + '&number=' + number)
								.success(function (data, status, headers, config) {
									$scope.weekAlternations = data;
									$http.get('/room/getavalivableroomselectitems?dayId=' + dayId + '&number=' + number)
										.success(function (data, status, headers, config) {
											$scope.rooms = data;
										})
										.error($scope.errorHandler(data, status, header, config));
								})
								.error($scope.errorHandler(data, status, header, config));
						   })
						   .error(function (data, status, header, config) {
						   	$scope.ResponseDetails = "Data: " + data +
								"<br />status: " + status +
								"<br />headers: " + jsonFilter(header) +
								"<br />config: " + jsonFilter(config);
						   });
					   })
					   	.error($scope.errorHandler(data, status, header, config));
				})
				.error($scope.errorHandler(data, status, header, config));
    		$scope.initRooms(dayId, number);
    	};

    	$scope.init = function () {
    		$http.get('/class/list')
			   .success(function (data, status, headers, config) {
			   	$scope.items = data;
			   })
			   .error(function (data, status, header, config) {
			   	$scope.ResponseDetails = "Data: " + data +
					"<br />status: " + status +
					"<br />headers: " + jsonFilter(header) +
					"<br />config: " + jsonFilter(config);
			   });

    		$scope.initGroupKeyValues();
    		$scope.initDays();
    		$scope.initNumbers();
    	};

    	$scope.initGroupKeyValues = function () {
    		$http.get('/group/getgroupkeyvalues')
			   .success(function (data, status, headers, config) {
			   	$scope.groupKeyValues = data;
			   })
			   .error(function (data, status, header, config) {
			   	$scope.ResponseDetails = "Data: " + data +
					"<br />status: " + status +
					"<br />headers: " + jsonFilter(header) +
					"<br />config: " + jsonFilter(config);
			   });
    	}

    	$scope.initGroupSelectItems = function () {
    		$http.get('/group/getgroupselectitems')
			   .success(function (data, status, headers, config) {
			   	$scope.groupSelectItems = data;
			   })
			   .error(function (data, status, header, config) {
			   	$scope.ResponseDetails = "Data: " + data +
					"<br />status: " + status +
					"<br />headers: " + jsonFilter(header) +
					"<br />config: " + jsonFilter(config);
			   });
    	}

    	$scope.initLoads = function (dayId, groupId, number) {
    		$http.get('/load/getavalivableloadselectitems?dayId=' + dayId + '&groupId=' + groupId + '&number=' + number)
			   .success(function (data, status, headers, config) {
			   	$scope.loads = data;
			   })
			   .error(function (data, status, header, config) {
			   	$scope.ResponseDetails = "Data: " + data +
					"<br />status: " + status +
					"<br />headers: " + jsonFilter(header) +
					"<br />config: " + jsonFilter(config);
			   });
    	}

    	$scope.initDays = function () {
    		$http.get('/class/days')
				.success(function (data, status, headers, config) {
					$scope.days = data;
				})
				.error(function (data, status, header, config) {
					$scope.ResponseDetails = "Data: " + data +
						"<br />status: " + status +
						"<br />headers: " + jsonFilter(header) +
						"<br />config: " + jsonFilter(config);
				});
    	}

    	$scope.initWeekAlternations = function (dayId, groupId, number) {
    		$http.get('/class/weekalternations?dayId=' + dayId + '&groupId=' + groupId + '&number=' + number)
				.success(function (data, status, headers, config) {
					$scope.weekAlternations = data;
				})
				.error(function (data, status, header, config) {
					$scope.ResponseDetails = "Data: " + data +
						"<br />status: " + status +
						"<br />headers: " + jsonFilter(header) +
						"<br />config: " + jsonFilter(config);
				});
    	}

    	$scope.initRooms = function (dayId, number) {
    		$http.get('/room/getavalivableroomselectitems?dayId=' + dayId + '&number=' + number)
				.success(function (data, status, headers, config) {
					$scope.rooms = data;
				})
				.error(function (data, status, header, config) {
					$scope.ResponseDetails = "Data: " + data +
						"<br />status: " + status +
						"<br />headers: " + jsonFilter(header) +
						"<br />config: " + jsonFilter(config);
				});
    	}

    	$scope.initNumbers = function () {
    		for (var i = 1; i <= 6; i++) {
    			$scope.numbers.push(i);
    		}
    	}

    	$scope.clearSearchTerm = function () {
    		$scope.searchTerm = '';
    	};

    	$scope.delete = function (index) {
    		var load = $scope.items[index];
    		$http.post('/load/delete/' + load.id)
			.then(
				function (response) {
					$scope.items.splice(index, 1);
					$mdToast.showSimple(response.data['message'])
					//$mdToast.show({
					//	hideDelay: 3000,
					//	position: 'bottom right',
					//	templateUrl: '/load/toastmessage?message=' + response.data['message']
					//});
				},
				function (response) {
					$mdToast.show({
						hideDelay: 3000,
						position: 'bottom right',
						templateUrl: '/load/toastmessage?message=' + response.message
					});
				});
    	}

    	$scope.showCreateDialog = function (ev, dayId, groupId, number) {
    		$mdDialog.show({
    			templateUrl: '/class/create?dayId=' + dayId + '&groupId=' + groupId + '&number=' + number,
    			parent: angular.element(document.body),
    			targetEvent: ev,
    			clickOutsideToClose: true,
    			fullscreen: true
    		})
    	}

		$scope.errorHandler = function(data, status, header, config) {
			$scope.ResponseDetails = "Data: " + data +
				"<br />status: " + status +
				"<br />headers: " + jsonFilter(header) +
				"<br />config: " + jsonFilter(config);
    	}

    	function load(teacherId, subjectId, subjectTypeId, groupId) {
    		this.teacherId = teacherId;
    		this.subjectId = subjectId;
    		this.subjectTypeId = subjectTypeId;
    		this.groupId = groupId;
    	}

    	function load() {
    		this.teacherId = '';
    		this.subjectId = '';
    		this.subjectTypeId = '';
    		this.groupId = '';
    	}
    });