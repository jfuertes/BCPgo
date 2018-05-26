
(function(){

'use strict';

var app = angular.module('eissonApp', [
  'ngRoute',
  'ngAnimate',
  'angular-loading-bar',
  'ui.materialize',
  'angularMoment',
  'Controllers',
  'ui.validate',
  'uiGmapgoogle-maps']);



    app.config(['$routeProvider', 'cfpLoadingBarProvider' , function($routeProvider, cfpLoadingBarProvider){
      cfpLoadingBarProvider.includeSpinner   = true;
      cfpLoadingBarProvider.latencyThreshold = 1;


      $routeProvider.
      
        when('/acerca', {
          templateUrl: 'views/login.html',
          caseInsensitiveMatch: true,
          controller: 'acercaController',
          activetab: 'centros'
        }). when('/mapa', {
          templateUrl: 'views/mapa.html',
          caseInsensitiveMatch: true,
          controller: 'mapaController',
          activetab: 'centros'
        }).
         when('/registrate', {
          templateUrl: 'views/RegistrarAgenteBCP.html',
          caseInsensitiveMatch: true,
          controller: 'RegistrateController',
          activetab: 'centros'
        }).

  when('/perfil', {
          templateUrl: 'views/Perfil.html',
          caseInsensitiveMatch: true,
          controller: 'perfilController',
          activetab: 'centros'
        }).
     
        
        otherwise({
          redirectTo: '/acerca'
        });

      }])
  .config(function(uiGmapGoogleMapApiProvider) {
      uiGmapGoogleMapApiProvider.configure({
          //    key: 'your api key',
          v: '3.17',
          libraries: 'weather,geometry,visualization'
      });
  });

})();