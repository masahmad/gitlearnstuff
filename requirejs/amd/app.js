require.config({
  paths: {
    "jquery": "lib/jquery-3.1.1",
	"underscore": "lib/underscore"
  }
});


require(['lib/modules/template'], function(template) {
  template.showName("Masood");
});
