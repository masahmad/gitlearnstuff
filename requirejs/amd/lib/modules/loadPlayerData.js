define(['jquery','methods'], function($,methods) {
  
// private var 
var s;
var privateVar=123;
var jsonobj;
  
  
  
  PlayerData = {
 

 settings: {
    numArticles: 5,
    parentContainer: $("#page"),
	getUrl:'http://localhost/playUX/api/playerdataapi'
  },
  
  
  init: function() {
	console.log('module: loadPlayerData, method: init called');
    s = this.settings;
   // this.bindUIActions();
   //this.loadContainer('split12.htm',7);
   var rtn = this.getAjaxFN(s.getUrl);
   
  // console.log('xxxx');
   //console.log(rtn);
	
  }
  
  
      
  ,getPrivateFN: function() { return jsonobj;}
  
  ,getAjaxFN: function(arg) {   
  
  console.log('module: loadplayerdata , method: getAjax');
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
			
			console.log('module: loadplayerdata, ajax success');
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
  
  
  
  }
  
  return PlayerData;
});