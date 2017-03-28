define(['underscore', 'jquery','methods'], function(_,$,methods) {
  
  /*
  var getJsonPlay = function(n) {
    methods.getAjax('http://localhost/playUX/api/playerdataapi');
  };
  
  return { getJsonPlay: getJsonPlay};
  */
  
  
  // private var 
var s;
var privateVar=123;
var jsonobj;
  
  
  
  Playlist = {
 

 settings: {
    numArticles: 5,
    parentContainer: $("#page"),
  },
  
  
  init: function(playTemplateObj) {
	console.log('module :playlist,   method: init , param: ' + playTemplateObj);
    s = this.settings;
   
   // call  custom methods
   // this.bindUIActions();
   this.processPlaylist(playTemplateObj);
  	
  }
  
  
  
  // bind
 ,bindUIActions: function() {
    s.moreButton.on("click", function() {
      NewsWidget.getMoreArticles(s.numArticles);
	
    });
  }
	  	  
	
	,processPlaylist(json) {
		alert('ok am processing' + json.length);
		
		  $(json).each(function(i,item){
        alert(i + ' ' + item.playlistname.name + '   timeout:' + item.playlistname.templatetimeout);
    });
		
	}
  
  ,getPrivateFN: function() { return privateVar;}
  
  
  
  
 }
   

  
  return Playlist;
  
  
  
});