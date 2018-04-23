'use strict';
angular.module('carServiceApp')
  .factory('orderService', function ($http) {
    var basePath = "http://localhost:14036/api/Order/";
    
    var service = {
      getOpenOrdersReport : getOpenOrdersReport
    }

    function getOpenOrdersReport(){
        return $http.get(basePath + "GetOpenOrdersReport");
    }
    
    return service;

  });
