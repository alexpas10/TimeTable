angular
    .module('timeTableApp.load', ['ngMaterial'])
    .controller('loadTabController', function ($scope, $http, $mdToast, $mdDialog) {
    	$scope.show = true;
    	$scope.items;
    	$scope.teachers;
    	$scope.subjects;
    	$scope.subjectTypes;
    	$scope.groups;
    	$scope.newLoad = load();
    	$scope.searchTerm;

    	$scope.toggle = function () {
    		$scope.show = !$scope.show;
    	};

    	$scope.setEditMode = function(load) {
    		load.isEdit = true;
    	}

    	$scope.setViewMode = function (load) {
    		load.isEdit = false
    	}

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

    	$scope.initSubjectItems = function (teacherId) {
    		$http.get('/subject/getsubjects?teacherId=' + teacherId)
			   .success(function (data, status, headers, config) {
			   	$scope.subjects = data;
			   	$scope.newLoad.subjectId = $scope.subjects[0];
			   })
			   .error(function (data, status, header, config) {
			   	$scope.ResponseDetails = "Data: " + data +
					"<br />status: " + status +
					"<br />headers: " + jsonFilter(header) +
					"<br />config: " + jsonFilter(config);
			   });
    	}

    	$scope.initTeacherItems = function () {
    		$http.get('/teacher/getteachers')
			   .success(function (data, status, headers, config) {
			   	$scope.teachers = data;
			   	$scope.newLoad.teacherId = $scope.teachers[0];
			   })
			   .error(function (data, status, header, config) {
			   	$scope.ResponseDetails = "Data: " + data +
					"<br />status: " + status +
					"<br />headers: " + jsonFilter(header) +
					"<br />config: " + jsonFilter(config);
			   });
    	}

    	$scope.initGroupItems = function () {
    		$http.get('/group/getgroups')
			   .success(function (data, status, headers, config) {
			   	$scope.groups = data;
			   	$scope.newLoad.groupId = $scope.groups[0];
			   })
			   .error(function (data, status, header, config) {
			   	$scope.ResponseDetails = "Data: " + data +
					"<br />status: " + status +
					"<br />headers: " + jsonFilter(header) +
					"<br />config: " + jsonFilter(config);
			   });
    	}

    	$scope.initLoadListForTeacher = function (teacherId) {
    		$http.get('/load/getloads?teacherId=' + teacherId)
			   .success(function (data, status, headers, config) {
			   		$scope.items = data;
			   		for (var i = 0; i < $scope.items.length; i++) {
			   			$scope.items[i].isEdit = false;
			   		}
			    })
			   .error(function (data, status, header, config) {
			   	$scope.ResponseDetails = "Data: " + data +
					"<br />status: " + status +
					"<br />headers: " + jsonFilter(header) +
					"<br />config: " + jsonFilter(config);
			   });
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

    	$scope.showCreateDialog = function (ev, teacherId) {
    		$mdDialog.show({
    			templateUrl: '/load/create?teacherId=' + teacherId,
    			parent: angular.element(document.body),
    			targetEvent: ev,
    			clickOutsideToClose: true,
    			fullscreen: true
    		})
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