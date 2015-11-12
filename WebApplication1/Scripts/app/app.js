(function () {
    'use strict';

    var myApp = angular.module('groupsApp', [                       //имя приложения
        'groupsService', 'ngRoute', 'ngResource', 'teachersService' //зависимости приложения
    ]);


    //Routes
    myApp.config([
      '$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
          $routeProvider.when('/main', {        //путь который мы укажем как гиперссылка элемента    
              templateUrl: 'GetView/Home/Main', //то что уйдет в asp net router
              controller: 'groupsController'    //контроллер, который будет применен к вьюхе после редиректа
          });
          $routeProvider.when('/groups', {
              templateUrl: 'GetView/Groups/GroupList',
              controller: 'groupsController',
              pageTitle: 'Все группы'         //наш собственный кастомный параметр, задает заголовок отображаемой станицы (вкладка браузера и имя самой страницы в контенте)
          });
          $routeProvider.when('/groups/new', {
              templateUrl: 'GetView/Groups/GroupItem',
              controller: 'groupItemController',
              pageTitle: 'Добавить группу',
              isEdit: false                  //наш собственный кастомный параметр, указывает на создание либо на редактирование мы открываем вьюху
          });
          $routeProvider.when('/groups/edit/:id', {
              templateUrl: 'GetView/Groups/GroupItem',
              controller: 'groupItemController',
              pageTitle: 'Изменить группу',
              isEdit: true
          });

          $routeProvider.otherwise({        //страница по умолчанию и при не корректном адресе перехода
              redirectTo: '/main'
          });
      }
    ]);

    //директива которая переьрасывает пользователя на страницу по умолчания если он ввел неправильный урл
    myApp.directive('title', ['$rootScope', '$timeout', function ($rootScope, $timeout) {
        return {
            link: function () {

                var listener = function (event, toState) {

                    $timeout(function () {
                        $rootScope.title = (toState && toState.pageTitle)
                        ? toState.pageTitle
                        : 'Home';
                    });
                };

                $rootScope.$on('$routeChangeSuccess', listener);
            }
        };
    }
    ]);

    //директива запрашивающая подтверждение удаления объекта
    myApp.directive('ngReallyClick', [function () {
        return {
            restrict: 'A',
            link: function (scope, element, attrs) {
                element.bind('click', function () {
                    var message = attrs.ngReallyMessage;
                    if (message && confirm(message)) {
                        scope.$apply(attrs.ngReallyClick);
                    }
                });
            }
        }
    }]);

})();