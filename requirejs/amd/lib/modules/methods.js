define(['jquery'], function($) {
  
var methods ={};

methods.changeHTML = function(arg) {
	$('body').html(arg);
}


methods.showAlert = function(arg) {
	alert(arg);
}
  
  
  methods.getAjax = function(arg) {
	  	  
	var dataz = 'templateClientKey=mas&fis=';

	$.get({
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
			alert('loaded');

		},
		error : function (e) {
			console.log(e.message);
			alert('fail');
		}
	});
	  
	  
	  
	  
	  
  }
  
  
  
  
  
  return methods;
});