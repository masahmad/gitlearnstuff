

var app = angular.module('myApp',[]);

app.controller('mainCtrl',function($scope){
$scope.a = 'hello Masood';
});


app.directive("message",function() {
return {
		template:'hello from the child directive {{a}}',
		scope: true
}

});