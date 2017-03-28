require.config({
  paths: {
    "jquery": "lib/jquery-3.1.1",
	"underscore": "lib/underscore",
	"methods": "lib/modules/methods"
  }
});






// main

/*
require(['lib/modules/template'], function(template) {
  template.showName("Masoodqqqqqq");
});


require(['lib/modules/playlist'], function(template) {
 template.getJsonPlay("vw play");
});

*/


/* news widget
require(['lib/modules/widget'], function(nw) {
  nw.init();
  alert('private var = ' + nw.getPrivateFN());
  
 console.dir(nw.getAjaxFN('http://localhost/playUX/api/playerdataapi'));
});
*/






/* load PlayerData */
require(['lib/modules/loadPlayerData'], function(playerx) {
  playerx.init();
 // alert('asyn check');
  var json = playerx.getPrivateFN();
  var  containerfile = json[0].playlistmaster_template_map[0].playlistname.container.containerfile;
  var  containerId = json[0].playlistmaster_template_map[0].playlistname.container.idcontainers;
  
  
	  /* load container */
	require(['lib/modules/container'], function(container) {
	  container.init(containerfile,containerId);
	});
	/* end container */
  
  
  /* process playlist */
  require(['lib/modules/playlist'], function(playlist) {
	  playlist.init(json[0].playlistmaster_template_map);
	});
  
});




