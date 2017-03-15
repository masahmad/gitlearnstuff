require.config({
  paths: {
    "jquery": "lib/jquery-3.1.1",
	"underscore": "lib/underscore",
	"methods": "lib/modules/methods"
  }
});



// main

require(['lib/modules/template'], function(template) {
  template.showName("Masoodqqqqqq");
});



require(['lib/modules/playlist'], function(template) {
 template.getJsonPlay("vw play");
});



require(['lib/modules/widget'], function(nw) {
  nw.init();
});




