'use strict';

var App = angular.module('routingDemoApp',['ui.router']);

App.config(['$stateProvider', '$urlRouterProvider', function($stateProvider, $urlRouterProvider){
				// For any unmatched url, send to /business
				$urlRouterProvider.otherwise("/business")
				
				$stateProvider
						.state('create', {
							url: "/create",
							templateUrl: "createblog.html"
						})
						.state('create.products', {
							url: "/products",
							templateUrl: "products.html",
							controller: function($scope){
								$scope.products = ["Computer", "Printers", "Phones", "Bags"];
							}
						})
						.state('create.services', {
							url: "/services",
							templateUrl: "services.html",
							controller: function($scope){
								$scope.services = ["Selling", "Support", "Delivery", "Reparation"];
							}
						})

						.state('list', {
							url: "/list",
							views: {
								"" 	:    { templateUrl: "bloghome.html" },
								"view1@list": { templateUrl: "blogdetail.html" },
								"view2@list": { templateUrl: "bloglisting.html" ,
									controller: function($scope){
											//$scope.bloglist = ["HP", "IBM", "MicroSoft"];
									$scope.bloglist =[
									{"id":1,"heading":"test heading1","content":"this is content","category":"apples","keywords":"a,b,c", "datecreated": "1 May 2017"},
									{"id":2,"heading":"test heading1","content":"this is content","category":"apples","keywords":"a,b,c", "datecreated": "1 May 2017"},
									{"id":3,"heading":"test heading1","content":"this is content","category":"apples","keywords":"a,b,c", "datecreated": "1 May 2017"}
									];
											
									}
								}
							}
						})
			}]);

			
			
			
			