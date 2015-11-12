(function () {
    'use strict';

    var groupsService = angular.module('groupsService', //имя фабрики
        ['ngResource']);                                //зависимости фабрики
    groupsService.factory('Groups', //имя фабрики, которе мы будем использовать в контроллерах
        ['$resource',
        function ($resource) {
            return $resource('http://localhost:53638/api/Group', {}, {
                query: { method: 'GET', params: {}, isArray: true }, //список объектов
                updateMethod: { //редактирование объекта
                    method: 'PUT',
                    params: {
                        id: '@id'
                    },
                },
                deleteMethod: { //удаление объекта
                    method: 'DELETE',
                    params: {
                        id: '@id'
                    },
                }
             
            });
        }
    ]);
})();