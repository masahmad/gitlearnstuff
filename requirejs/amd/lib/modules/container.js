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
  
  
  init: function() {
	alert('init called');
    s = this.settings;
   // this.bindUIActions();
   //this.loadContainer('split12.htm',7);
   var rtn = this.getAjaxFN('http://localhost/playUX/api/playlistmasterapi/');
   
   console.log('xxxx');
   console.log(rtn);
	
  },
  
  
  
  // bind
  bindUIActions: function() {
    s.moreButton.on("click", function() {
      NewsWidget.getMoreArticles(s.numArticles);
	
    });
  }
	  	  
	
	
	
	
 ,loadContainer(newTemplate, currentScreenContainerId) {
	 
	 alert('loadcontainer called');
	 
	// if (newTemplate.ScreenContainer != currentScreenContainerId) {
		//var container = 'containers/' + newTemplate.ContainerFile;
		var container = 'containers/' + newTemplate;
		alert(container);
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
	//} 
	/*
	else {
		this.Playlist(newTemplate);
	}
	*/
	
	
	
	 
 }
  
  
    
  
  ,getPrivateFN: function() { return privateVar;}
  
  
  ,getAjaxFN: function(arg) {   
  
  alert('get Ajax called');
  	var dataz = 'templateClientKey=mas&fis=';

	$.ajax({
		type : 'GET',
		url : arg,
		async : false,
		jsonpCallback : 'jsonCallback',
		contentType : "application/json",
		dataType : 'json',
		data : null, // multiple data sent using ajax
		success : function (json) {
			jsonobj = json;

			/* copied */
			//xvar MyPlayListTemplate
			// save in global ref var
			
			//xplaylistsObj = jsonobj;
			//xMyPlayListTemplate = jsonobj.MyPlayLists[0];
			//xconsole.log(MyPlayListTemplate);
			 //x loadContainer(MyPlayListTemplate, -1);

			/* end  */
			
			alert('ajax success');
			//console.log(json[0].playname);
			//console.log(json);
			
			jsonobj=json;

		},
		error : function (e) {
			console.log(e.message);
			//alert('fail');
			jsonobj = 'fail';
		}
	});
	  
  return jsonobj;
  
  } 
  
  
  ,Playlist: function(a) {alert('playlist called')}
  }
  
  return Container;
});