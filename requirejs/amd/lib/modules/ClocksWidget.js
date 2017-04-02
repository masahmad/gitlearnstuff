define(['jquery','methods'], function($,methods) {
  
  // private var 
var s;
var privateVar=123;
var jsonobj;
  
  
  
  ClocksWg = {
 

 settings: {
    numArticles: 5,
    parentContainer: $("#page"),
  },
  
  
  init: function(arg) {
	console.log('module :Clocks Widget   method: init , param: ' + arg);
	console.log(arg);
    s = this.settings;
	this.render(arg.templateinstance.template06);
	CoolClock.findAndCreateClocks();
   // this.bindUIActions();
  // this.loadContainer(arg,conId);
  	
  }
  
  
  
  // bind
 ,bindUIActions: function() {
    s.moreButton.on("click", function() {
      NewsWidget.getMoreArticles(s.numArticles);
	
    });
  }
	  	  
	
	

  
    
  
  ,getPrivateFN: function() { return privateVar;}
  
  
  ,render: function(templateDataObj) {

  var TemplateZone='zone1';
  var templateCSS='x';
  
  console.log(templateDataObj);
 // alert('pre clock rendering');
  
  $.each(templateDataObj, function (tblIndex, rootobj) {

  
  console.log(rootobj);
 // alert('clock rendering');
		$('#' + TemplateZone).addClass(templateCSS);
		

		// if group div does not exist then create a new group div
		if ($('#T6groupPaging_' + TemplateZone + '_' + rootobj.group).length == 0) {
			$('#' + TemplateZone).append('<div class="T6groupcontent" id="T6groupPaging_' + TemplateZone + '_' + rootobj.group + '"></div>');
		}

		
		var groupContainer = $('#T6groupPaging_' + TemplateZone + '_' + rootobj.group);
		groupContainer.append('<div  class="t6ClockContainer" id="t6ClockContainer' + tblIndex + '"></div>');
		var divContainer = $('#t6ClockContainer' + tblIndex);

		// NOT DIGITAL
		if (rootobj.clockstyle != 'digital') {
			// analog clock bit
			var gmtoffset = 0;
			
			if (rootobj.gmtoffset == 0)
				gmtoffset = 0;
			else
				gmtoffset = rootobj.gmtoffset / 60;

			var clockSettings = 'CoolClock:' + rootobj.clockstyle + ':' + rootobj.clockradius + '::' + gmtoffset;
			
			var canvasclock = '<canvas id="canvasclock' + tblIndex + '"></canvas><br><br>';
			
			divContainer.append(canvasclock);
			$('#canvasclock' + tblIndex).addClass(clockSettings);

			divContainer.append('<div id="clockcitylabeldiv' + tblIndex + '" class="clockcitylabel"></div>')
			$('#clockcitylabeldiv' + tblIndex).html(rootobj.cityname);
			
			divContainer.css("width", rootobj.clockradius * 2 + 'px');
		} else {

			// digital clock
			divContainer.append('<div id="t6Digital_' + tblIndex + '" style="disply:inline-block;" class="digitalTime digitalSmall "></div>');
			divContainer.append('<div id="clockcitylabeldiv' + tblIndex + '" class="clockcitylabel"></div>')
			$('#clockcitylabeldiv' + tblIndex).html(rootobj.cityname);
			

			if (IsJsonString(rootobj.stylecss)) {
				if (rootobj.stylecss != null) {
					var styleJsonObj = $.parseJSON(rootobj.stylecss);
					// It is JSON
					$('#' + 't6Digital_' + tblIndex).css(styleJsonObj);
				} // if not null
			}

			
			//startTime('t6Digital_' + tblIndex, rootobj.gmtoffset);
		}

	})
  
  

  }
  
 }
   

  
  return ClocksWg;
});