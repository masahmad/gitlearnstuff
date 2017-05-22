var element_pos = 0;    // POSITION OF THE NEWLY CREATED ELEMENTS.
    var iCnt = 0;var i=1;
	var alldata='';
    $(document).ready(function() {
       // $(function() { $('#divContainer').draggable(); });
      //  $(function() { $("#divResize").draggable().resizable(); });
        // CREATE MORE DIV, WITH 'ABSOLUTE' POSITIONING.
        $('#btClickMe').click(function() {
			var top1=$("#divResize").height();
			var elm1 = '<div class="block" id="zone'+i+'" ' +
			'style="border:1px dotted; position:absolute;left:'+element_pos+';left:30px;position:absolute;width:200px;height:200px; margin:0;top:'+top1+'"'+
			  '</div>';
			  
			$(elm1).appendTo('.content_block').draggable(
			{ containment: "parent",drag: dragEvent,stop:handleDragStop }).resizable({
	  maxWidth: 610,
      minHeight: 12,
	  minWidth: 15,
	  maxHeight:300
  });
  
  
  function dragEvent(e,ui) {
	 // alert('x');
	  console.log(ui);}
	  
	  
	  function handleDragStop( event, ui ) {
  var offsetXPos = parseInt( ui.offset.left );
  var offsetYPos = parseInt( ui.offset.top );
  alert( "Drag stopped!\n\nOffset: (" + offsetXPos + ", " + offsetYPos + ")\n");
}


  
				
				// APPEND THE NEWLY CREATED DIV TO "divContainer".
			   // $(dynamic_div).appendTo('#divResize').draggable().resizable();
			i=i+1;
            iCnt = iCnt + 1;
        });
    });
	
	
	function createstring(){alldata="";
	var nb = $('.block').length;	
	  for(var i=1;i<=nb;i++){
		var id="zone"+i;
		var width1=($("#zone"+i).width()/$("#zone"+i).parent().width() * 100).toFixed(2);
		var height1=($("#zone"+i).height()/$("#zone"+i).parent().height() * 100).toFixed(2);
		var top1=$("#zone"+i).position().top;
		var left1=$("#zone"+i).position().left;
		var elm = '<div class="block" id="'+id+'"' +
			  'style="width:'+width1+'%;height:'+height1+'%; top:'+top1+';left:'+left1+';position:absolute;border:1px solid #000;"'+
			  '></div>';
		 alldata += elm;
		 $(elm).appendTo('.content_block'); 
	}
	}
	function btnsubmit(){
    
	createstring();
	var nb = $('.block').length;	
	  for(var i=1;i<=nb;i++){
		$("#zone"+i).closest('#zone'+i).remove();
	  }
		alert(alldata);
		 var file_name=$(".form-control").val();
		//  var text="<html><head><title>"+$("#input-fileName").val()+"</title></head><body>"+alldata+"</body></html>";
	}
	function Redesign(){
	
	var nb = $('.block').length;	
	  for(var i=1;i<=nb;i++){
		var id="zone"+i;
		alldata=""
		$("#zone"+i).appendTo('.content_block').draggable({ containment: "parent" }).resizable();
			
		}
	}