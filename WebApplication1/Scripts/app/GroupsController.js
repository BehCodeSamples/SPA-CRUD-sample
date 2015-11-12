(function () {
    'use strict';

    angular
        .module('groupsApp')
        .controller('groupsController', groupsController);

    groupsController.$inject = ['$scope', 'Groups', '$window'];

    function groupsController($scope, Groups, $window) {
        $scope.Groups = Groups.query(); //получаем список всех групп от веб апи

        //метод удаления группы
        $scope.deleteGroup = function (group) { 
           
            group.$deleteMethod({ id: group.Id }, function () {
                //этот код выполнится в случае успешного удаления
                $scope.updateList();
                });
           
        };

        //метод заново получает список групп от веб апи
        $scope.updateList = function () {
            Groups.query(function (data) {
                $scope.Groups = data;
            });
        };
    }

})();