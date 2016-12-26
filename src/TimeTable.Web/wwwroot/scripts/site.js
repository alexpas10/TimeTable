$('#deletemodal').on('show.bs.modal', function (e) {

    //get data-id attribute of the clicked element
    var id = $(e.relatedtarget).data('id');

    //populate the textbox
    $(e.currenttarget).find('input[name="id"]').val(id);
});

var appModule = angular.module('timeTableApp', ['timeTableApp.ui', 'timeTableApp.room', 'timeTableApp.group', 'timeTableApp.subject', 'timeTableApp.teacher', 'timeTableApp.deleteDialog', 'timeTableApp.details-info', 'timeTableApp.load', 'timeTableApp.class', 'ngMaterial', 'ngAnimate']);
