'use strict';

/**
 * @ngdoc function
 * @name carServiceApp.controller:AboutCtrl
 * @description
 * # AboutCtrl
 * Controller of the carServiceApp
 */
angular.module('carServiceApp')
  .controller('AboutCtrl', function (orderService) {

    orderService.getOpenOrdersReport().then(function(data){
      console.log(data);
    });
    
    this.awesomeThings = [
      'HTML5 Boilerplate',
      'AngularJS',
      'Karma'
    ];
  });
