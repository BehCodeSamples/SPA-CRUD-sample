(function () {
    'use strict';

    var teachersService = angular.module('teachersService', ['ngResource']);
    teachersService.factory('Teachers', ['$resource',
        function ($resource) {
            return $resource('http://localhost:53638/api/Teacher', {}, {
                query: { method: 'GET', params: {}, isArray: true },
                updateMethod: {
                    method: 'PUT',
                    params: {
                        id: '@id'
                    },
                },
                deleteMethod: {
                    method: 'DELETE',
                    params: {
                        id: '@id'
                    },
                }

            });
        }
    ]);
})();