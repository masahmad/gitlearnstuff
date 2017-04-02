define(['underscore', 'jquery','methods','clockswidget'], function(_,$,methods,clocks) {
  
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
	

	
	// processes the template part 
	,processPlaylist(json) {
		alert('ok processing templates: ' + json.length);
		
		  $(json).each(function(i,item){
        //alert(i + ' ' + item.playlistname.name + '   timeout:' + item.playlistname.templatetimeout);
		//
		Playlist.processWidget(item.playlistname.playlists);
    });
		
	}
  
  // processes each widget
,processWidget(widgets) {
	
	//alert('w');
console.log('processing ' + widgets.length + 'widgets');
	console.log(widgets);
	 $(widgets).each(function(i,w) {
		 //alert(i + ' ' + w.templateinstance.templateId +'  ' +  w.templateinstance.idtemplateInstance );
		 
		 var templateid = w.templateinstance.templateId;
		 var templateinstanceid = w.templateinstance.idtemplateinstance;
	 
		 
 switch(templateid) {
    case 1:
        alert('1');
        break;
    case 2:
        alert('2');
        break;
	
case 3:
        alert('3');
        break;
		
		case 4:
        alert('4');
        break;
	
	case 5:
        alert('5');
        break;
	
	case 6:
        alert('6');
		//we pass playlists[x] to init
		clocks.init(w);
        break;
	
	
    default:
       alert('xxx');
} 
		 
		 
	 });
	 
	 
	 
	 
	 
	
	 
	 
}
  
  
  ,getPrivateFN: function() { return privateVar;}
  
  
  
  
 }
   

  
  return Playlist;
  
  
  
});