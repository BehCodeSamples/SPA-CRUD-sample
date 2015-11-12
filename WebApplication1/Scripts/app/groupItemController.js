(function () {
    'use strict';

    angular
      .module('groupsApp')
      .controller('groupItemController', groupItemController); //имя контроллера

    //зависимости контроллера
    groupItemController.$inject = ['$scope', 'Groups', '$location', '$routeParams', '$route', 'Teachers'];

    //конструктор контроллера
    function groupItemController($scope, Groups, $location, $routeParams, $route, Teachers) {
        $scope.isEdit = $route.current.$$route.isEdit; //признак того что открыли группы на редактирование
        $scope.Teachers = Teachers.query();            //список всех учителей
       

        if ($scope.isEdit)
            $scope.groupItem = Groups.get({ id: $routeParams.id }); //получаем группу для рдактирования
        else
            $scope.groupItem = new Groups();  //открыли форму для создяния группы - создаем новый элемент
      
        //метод сохранения изменений
        $scope.makeSave = function () {
            if ($scope.isEdit)
                //в случае редактирования вызваем метод изменения объекта
                //веб апи потребуется пробросить ид объекта
                $scope.groupItem.$updateMethod({ id: $routeParams.id }, 
                function () {
                    //метод выполниля успешно
                    //возвращаемся к списку объектов
                    $location.path("/groups");
                },
                function () {
                    //метод выполнился с ошибкой
                    alert("error");
                });
            else
                //в случае создания группы вызываем метод создания объекта
                //он реализова по уолчанию, его нет в нашей фабрике
                $scope.groupItem.$save(function () {
                    //метод выполниля успешно
                    //возвращаемся к списку объектов
                    $location.path("/groups");
                },
                function () {
                    //метод выполнился с ошибкой
                    alert("error");
                });
        };
    }

})();
