define(['underscore', 'jquery','methods'], function(_,$,methods) {
  
  var getJsonPlay = function(n) {
   
   // methods.showAlert('playingxxxx ' + n);
   
    methods.getAjax('http://localhost/playUX/api/playerdataapi');
  };
  
  return {
    getJsonPlay: getJsonPlay
  };
});