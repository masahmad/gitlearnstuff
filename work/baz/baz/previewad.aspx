<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="previewad.aspx.cs" Inherits="PlayV.previewad" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>


    
    <link href="style/adbox.css" rel="stylesheet" />
    <link href="style/fonts.css"  rel="stylesheet" />

    


</head>
<body>
    <form id="form1" runat="server">
    <div>


         <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">X</button>
            <h4 class="modal-title" id="myModalLabel">Preview</h4>
            </div>

          <div class="modal-body">
              <div id="previewBox"  runat="server"  style="border:1px dotted red;"  ></div>
      </div>

         <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>




          <!-- modal ->
        <div class="modal fade" id="basicModal" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&amp;times;qqqq</button>
            <h4 class="modal-title" id="myModalLabel">Modal title</h4>
            </div>
            <div class="modal-body">
                <h3>Modal Body</h3>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                <button type="button" class="btn btn-primary">Save changes</button>
        </div>
    </div>
  </div>
</div>
        <-- modal -->





    </div>
    </form>
</body>
</html>
