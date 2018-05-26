



window.map="";
/**
 * List Controller
 * @version v0.2.2 - 2015-04-23 * @link http://csluni.org
 * @author Eisson Alipio <eisson.alipio@gmail.com>
 * @license MIT License, http://www.opensource.org/licenses/MIT
 */
(function(){
  'use strict';

  angular.module('Controllers', ['uiGmapgoogle-maps'])

  
  .controller('TabsController',['$scope', '$route','$http', function($scope, $route, $http){
    ////console.log($route.current);
     $scope.$route = $route;
  }])


.controller('acercaController',['$scope', '$http', function($scope, $http){
  }])

.controller('RegistrateController',['$scope', '$http', function($scope, $http){
  }])
.controller('mapaController',['$scope', '$http', function($scope, $http){
  }])


.controller('perfilController',['$scope', '$http', function($scope, $http){

         $scope.getperfilbyId= function(){
        console.log("ejecuta funcion get alarma byid")
             $http.post('api/getperfilbyId.php', {id: "100"} )
                .success(function(data) {
                  console.log(data);
                  $scope.agencia=data;
                })
                .error(function(data) {
                  console.log('Error: ' + data);
                  });
         };
         
         $scope.getperfilbyId();
  }])
})();
