define(['jquery','methods'], function($,methods) {
  
  
// private variables go here
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
	this.render(arg.templateinstance);
	CoolClock.findAndCreateClocks();
  // this.loadContainer(arg,conId);
  	
  }
  
      
  ,render: function(templateDataObj) {

  var TemplateZone=templateDataObj.templatesettings[0].zone;
  var templateCSS=templateDataObj.templatesettings[0].theme;
  var TemplateBGMediaType = templateDataObj.templatesettings[0].bgmediatype; // json.TemplateBGMediaType;
  var TemplateBGMediaSource = templateDataObj.templatesettings[0].bgmediasource; // json.TemplateBGMediasource;
  var TemplateBGFXon = templateDataObj.templatesettings[0].fxOn; //json.TemplateBGFXon;
    
  var $zone = $('#' + TemplateZone);
  
  $zone.addClass(templateCSS);
  
  //$zone.append(`<div class="T6groupcontent" id="T6groupPaging_${TemplateZone}_${rootobj.group}"></div>`);
    
  $.each(templateDataObj.template06, function (tblIndex, rootobj) {
  
		//$zone.addClass(templateCSS);
		
		// if group div does not exist then create a new group div
		//if ($('#T6groupPaging_' + TemplateZone + '_' + rootobj.group).length == 0) {
						
			//es6  back tick and string variables
			$zone.append(`
			<div class="T6groupcontent" id="T6groupPaging_${TemplateZone}_${rootobj.group}">
				<div class="t6ClockContainer" id="t6ClockContainer${tblIndex}">
					<canvas id="canvasclock${tblIndex}"></canvas><br><br>
					<div style='mas' id="clockcitylabeldiv${tblIndex}" class="clockcitylabel">${rootobj.cityname}</div>
				</div>
			</div>`);
		//}

				
		
		//var groupContainer = $('#T6groupPaging_' + TemplateZone + '_' + rootobj.group);
		//groupContainer.append('<div class="t6ClockContainer" id="t6ClockContainer' + tblIndex + '"></div>');
		
		
		//var divContainer = $('#t6ClockContainer' + tblIndex);

		// NOT DIGITAL
		if (rootobj.clockstyle != 'digital') {
			// analog clock bit
			var gmtoffset = 0;
			
			if (rootobj.gmtoffset == 0)
				gmtoffset = 0;
			else
				gmtoffset = rootobj.gmtoffset / 60;

			var clockSettings = 'CoolClock:' + rootobj.clockstyle + ':' + rootobj.clockradius + '::' + gmtoffset;
			
			//var canvasclock = '<canvas id="canvasclock' + tblIndex + '"></canvas><br><br>';
			//divContainer.append(canvasclock);
			$('#canvasclock' + tblIndex).addClass(clockSettings);

			//divContainer.append('<div id="clockcitylabeldiv' + tblIndex + '" class="clockcitylabel"></div>')
			//$('#clockcitylabeldiv' + tblIndex).html(rootobj.cityname);
			
			//divContainer.css("width", rootobj.clockradius * 2 + 'px');
		} else {

			// digital clock
			//divContainer.append('<div id="t6Digital_' + tblIndex + '" style="disply:inline-block;" class="digitalTime digitalSmall "></div>');
			//divContainer.append('<div id="clockcitylabeldiv' + tblIndex + '" class="clockcitylabel"></div>')
			//$('#clockcitylabeldiv' + tblIndex).html(rootobj.cityname);
			
/*
			if (IsJsonString(rootobj.stylecss)) {
				if (rootobj.stylecss != null) {
					var styleJsonObj = $.parseJSON(rootobj.stylecss);
					// It is JSON
					$('#' + 't6Digital_' + tblIndex).css(styleJsonObj);
				} // if not null
			}
			*/
			
			
			//startTime('t6Digital_' + tblIndex, rootobj.gmtoffset);
		}

	})
  
  

  }
  
 }
   
  return ClocksWg;
});