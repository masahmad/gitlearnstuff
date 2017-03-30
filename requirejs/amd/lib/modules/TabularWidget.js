define(['jquery','methods'], function($,methods) {
  
  
  
  // private var 
var s;
var privateVar=123;
var jsonobj;
  
  
  
  Clocks = {
 

 settings: {
    numArticles: 5,
    parentContainer: $("#page"),
  },
  
  
  init: function(arg, conId ) {
	console.log('module :container.js,   method: init , param: ' + arg);
    s = this.settings;
   // this.bindUIActions();
   this.loadContainer(arg,conId);
  	
  }
  
  
  
  // bind
 ,bindUIActions: function() {
    s.moreButton.on("click", function() {
      NewsWidget.getMoreArticles(s.numArticles);
	
    });
  }
	  	  
	
	

  
  
    
  
  ,getPrivateFN: function() { return privateVar;}
  
 }
   

  
  return Clocks;
});