define(['jquery','methods'], function($,methods) {
  
  // private var 
var s;
var privateVar=123;
var jsonobj;
  
  
  
  Container = {
 

 settings: {
    numArticles: 5,
    parentContainer: $("#page"),
  },
  
  
  init: function(arg) {
	console.log('module :container.js,   method: init , param: ' + arg);
    s = this.settings;
   // this.bindUIActions();
   this.loadContainer(arg,7);
  	
  }
  
  
  
  // bind
 ,bindUIActions: function() {
    s.moreButton.on("click", function() {
      NewsWidget.getMoreArticles(s.numArticles);
	
    });
  }
	  	  
	
	
	
 ,loadContainer(newTemplate, currentScreenContainerId) {
	 
	 console.log('module: container, method: loadContainer');
	 
	// if (newTemplate.ScreenContainer != currentScreenContainerId) {
		//var container = 'containers/' + newTemplate.ContainerFile;
		var container = 'containers/' + newTemplate;
		//alert(container);
		s.parentContainer.empty();
		s.parentContainer.load(container, function (responseTxt, statusTxt, xhr) {
			if (statusTxt == "success") {
				console.log('loading container:' + container);
				
				/*
				if (newTemplate.BGMediaType != '') {
					ProcessMediaType(newTemplate.BGMediaType, newTemplate.BGMediaSource, "body");
				}
				*/
								
				//this.Playlist(newTemplate);
			}
			if (statusTxt == "error")
				alert("Error: " + xhr.status + ": " + xhr.statusText);
		});
	 
 }
  
  
    
  
  ,getPrivateFN: function() { return privateVar;}
  
 }
   

  
  return Container;
});