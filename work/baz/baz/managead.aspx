<%@ Page Title="" ValidateRequest="false" Language="C#" MasterPageFile="test.Master" AutoEventWireup="True" CodeBehind="managead.aspx.cs" Inherits="PlayV.managead" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <link href="style/adbox.css" rel="stylesheet" />

    <link href="style/fonts.css"  rel="stylesheet" />

    

    <style>


        .FormatRadioButtonList label
{
  margin-right: 15px;
}




        #myInstance1 {
border: 1px dashed #4cff00;
}


.nicEdit-selected {
border: 1px dashed #808080 !important;
}
 

.nicEdit-panel {
background-color: #fff !important;
}
 
.nicEdit-button {
background-color: #fff !important;
}


    </style>

</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    

    <form runat="server"  name="sentMessage" id="contactForm" novalidate>



     <!-- Page Content -->
    <div class="container">


        

        <!-- Page Heading/Breadcrumbs -->
        <div class="row">
            <div class="col-lg-12">
               <!-- <h1 class="page-header">Manage ads
                    <small>+ post</small>
                </h1>--><br />
                <ol class="breadcrumb">
                    <li><a href="index.aspx">Home</a>
                    </li>
                    <li class="active">Post new Ad</li>
                </ol>
            </div>
        </div>
        <!-- /.row -->

        

        <!-- Content Row -->
        <div class="row">
            <!-- Sidebar Column -->
            <div class="col-sm-3  col-md-3">
                <div class="list-group">
                    <a href="managead.aspx" class="list-group-item active"><i  class="fa fa-file"></i>&nbsp;&nbsp;&nbsp;Post new ad</a>
                    <a href="listsad.aspx" class="list-group-item"> <i  class="fa fa-list-alt"></i> &nbsp;List my ads</a>
                    <a href="myaccount.aspx" class="list-group-item"> <i  class="fa fa-gear  fa"></i> &nbsp;&nbsp;Account settings</a>
                </div>
            </div>
            <!-- Content Column -->
            <div class="col-sm-9 col-md-9">
                        
               
                 <!-- Contact Form -->
        <!-- In order to set the email address and subject line for the contact form go to the bin/contact_me.php file. -->
    
                
                <ul class="nav nav-tabs">
  <li id='tab1' role="presentation" class="active"><a id="btvTab1Link" href="#">Step one - 
      <asp:Label ID="lblUpdateMode" runat="server" Text="Post New Ad"></asp:Label>
      <asp:Label ID="lblUpdateReferenceId" runat="server" Text=""></asp:Label></a></li>
  <li id='tab2' role="presentation"><a  id="btvTab2Link" href="#">Step two - check location</a></li>
  <li id='tab3' role="presentation"><a  id="btvTab3Link" href="#">Step three - preview</a></li>
</ul>



                <div id="btvTab1" >

                 <!-- category div-->
                    <div class="control-group form-group">
                        <div class="controls">
                        <div id="categorydiv" runat="server">
                               <label>Category:</label>
                                <asp:DropDownList  CssClass="form-control input-sm" ID="ddlCategory" runat="server">
             <asp:ListItem>Services</asp:ListItem>
             <asp:ListItem>Accommodation</asp:ListItem>
         </asp:DropDownList> 
                           </div>
                        </div>
                    </div>

               <!-- category div-->





                  <!-- heading div-->
                    <div class="control-group form-group">
                        <div class="controls">
                         
                                <div id="headingdiv" runat="server">
                            
                        
                                     <asp:TextBox ID="txtHeading"   placeholder="enter heading or title here"  CssClass="form-control" runat="server"></asp:TextBox>
                       </div>
                                     </div>
                    </div>
                  <!-- heading div-->







	 
                    <!-- box size  -->
 <div class="control-group form-group">
    <div class="controls">
     <div id="boxsizediv" runat="server">
<label>Box size</label>
        <asp:DropDownList CssClass="form-control  input-sm" Width="480px"   ID="ddlAdBoxSize" runat="server">
 <asp:ListItem Value="1">small (postit note size</asp:ListItem>
        <asp:ListItem Value="2">Medium (postcard size)</asp:ListItem>
        <asp:ListItem Value="3">Large (approx A4)</asp:ListItem>
        <asp:ListItem Value="4">xLarge (full screen)</asp:ListItem>
    </asp:DropDownList> 

         <!-- *****  unused  ****** -->
         <asp:RadioButtonList ID="rblistBoxsize"  Visible="false" CssClass="FormatRadioButtonList"  RepeatDirection="Horizontal"  CellSpacing="10" runat="server">   
         <asp:ListItem Value="1">small (postit note size)</asp:ListItem>
         <asp:ListItem Value="2">Medium (postcard size)</asp:ListItem>
        <asp:ListItem Value="3">Large (approx A4)</asp:ListItem>
        <asp:ListItem Value="4">xLarge (full screen)</asp:ListItem>
         </asp:RadioButtonList>
         <!-- unused -->

    </div>
    </div>
</div>
<!-- box size -->

                 






                    <!-- ad Text-->
                    <div class="control-group form-group">
                        <div class="controls">
                          
                           <div id="myNicPanel" style="width: 480px;"></div>

                               



                         <!--  <label>Message/ Text </label>-->
                            <asp:TextBox   Visible="false"  Columns="40"  Rows="5"   CssClass="form-control"  TextMode="MultiLine" ID="txtAdText" runat="server"></asp:TextBox>
                               <asp:HiddenField runat="server" ID="hidInnerHtml" />
                                <asp:HiddenField runat="server" ID="HidHeading" />
                             <div id="myArea1"   enableviewstate="true"  clientidmode="Static"  runat="server"   style="border:1px solid #808080;	overflow-x: hidden;	overflow-y: hidden;" class="adboxBase adbox1"> </div>
                            <br />
                            <asp:Label ID="lblUpdateDraft" CssClass="small" runat="server" Text="status"></asp:Label>

                        </div>
                    </div>

                <!-- ad text-->












<!-- contact-->
          <div class="control-group form-group">
                        <div class="controls">
                          <div id="contactdiv" runat="server">
                               <label>Contact </label>
                             <asp:TextBox  CssClass="form-control" ID="txtContact" runat="server"></asp:TextBox>
                       </div>
                               </div>
                    </div>

<!-- contact -->




<!-- qr -->
   <div class="control-group form-group">
      <div class="controls">
    <div id="qrdiv" runat="server">
<label>Enable QR code</label>
    <asp:CheckBox ID="chkQRcode"  CssClass="form-control  input-sm" runat="server" /> 
    </div>
</div>
</div>
<!-- qr -->



<!-- premium -->
 <div class="control-group form-group">
    <div class="controls">
    <div id="premiumdiv" runat="server">
    <label for="adpremium" accesskey="t">Premium ad</label>
    <asp:CheckBox CssClass="form-control  input-sm" ID="chkPremium" runat="server" /> 
    </div>
    </div>
</div>
<!-- premium -->







<!-- priority -->
 <div class="control-group form-group">
    <div class="controls">
    
    <div id="prioritydiv" runat="server">
        <label for="adpriority" accesskey="t">Priority</label>
    <asp:DropDownList ID="ddlPriority" runat="server" CssClass="form-control  input-sm">
        <asp:ListItem Value="1">Low</asp:ListItem>
        <asp:ListItem Value="2">Medium</asp:ListItem>
        <asp:ListItem Value="3">High</asp:ListItem>
    </asp:DropDownList>  
    </div>
    </div>
</div>
<!-- priority -->




<!-- style -->
<div class="control-group form-group">
    <div class="controls">
    <div id="stylediv" runat="server">
    <label for="adStyle">Style</label>
    <asp:TextBox ID="txtStyle" CssClass="form-control" runat="server"></asp:TextBox>
    </div>
    </div>
</div>
<!-- stylee -->



<!-- bg -->
<div class="control-group form-group">
    <div class="controls">
        <div id="bgcolordiv" runat="server">
     <label>BG Color</label>
    <asp:DropDownList  CssClass="form-control" ID="ddlBGColor1" runat="server">
        <asp:ListItem Value="#E9E74A">Neon1</asp:ListItem>
        <asp:ListItem Value="#EE5E9F">Neon2</asp:ListItem>
        <asp:ListItem Value="#FFDD2A">Neon3</asp:ListItem>
        <asp:ListItem Value="#F59DB9">Neon4</asp:ListItem>
        <asp:ListItem Value="#F9A55B">Neon5</asp:ListItem>
        <asp:ListItem Value="#BAB7A9">Classic1</asp:ListItem>
        <asp:ListItem Value="#BFB4AF">Classic2</asp:ListItem>
    </asp:DropDownList> 
    </div>
    </div>
</div>
<!-- bg -->



<!-- font-->
<div class="control-group form-group">
    <div class="controls">
        <div id="fontdiv" runat="server">
    <label for="adfont" >Font</label>
    <asp:DropDownList  CssClass="form-control" ID="ddlFont" runat="server">
        <asp:ListItem Value="angelina.ttf">angelina</asp:ListItem>
        <asp:ListItem>daniel</asp:ListItem>
        <asp:ListItem Value="danielbd.ttf">danielbd</asp:ListItem>
        <asp:ListItem Value="dreamcatcher.ttf">dreamcatcher</asp:ListItem>
        <asp:ListItem Value="ieatcrayons.ttf">ieatcrayons</asp:ListItem>
        <asp:ListItem Value="sweetiepie.ttf">sweetiepie</asp:ListItem>
        <asp:ListItem Value="danila.ttf">danila</asp:ListItem>
    </asp:DropDownList> 
    </div>
    </div>
</div>
<!-- font -->



<!-- fontsize -->
<div class="control-group form-group">
    <div class="controls">
        <div id="fontsizediv" runat="server">
    <label for="adfontsize">Font size</label>
    <asp:TextBox ID="txtFontsize" CssClass="form-control" runat="server">1</asp:TextBox>
    </div>
    </div>
</div>
<!-- fontsize -->








<!-- publish date -->
<div class="control-group form-group">
    <div class="controls">
    <div id="publishdiv" runat="server">
     <label>Publish date</label>
    <asp:TextBox ID="txtPublish"  CssClass="form-control" runat="server"></asp:TextBox><br>
    </div>
    </div>
</div>
<!-- publish date -->

                  

                   
                   

                    <div class="row">
  <div class="col-md-4"><button id="btnNextTab1" class="btn btn-primary btn-sm">Next&nbsp; &gt&gt</button></div>
  <div class="col-md-4 col-md-offset-4"> <!--<button  class="btn btn-default">save draft</button>-->&nbsp;</div>
</div>

                    </div> 
                <!-- ********************* end of tab 1 **************** -->

















               <!-- ********************** TAB 2 ************************   -->
                
 <div id="btvTab2" >

  <p>&nbsp;</p>

       <div class="row">
          
            <!-- Contact Details Column -->
            <div class="col-md-6">

<!-- systems selection -->
<div class="control-group form-group">
    <div class="controls">
    <div id="systemdiv" runat="server">
     <label>System / location</label>
     <asp:DropDownList  CssClass="form-control  input-sm" ID="ddlSystemsList" runat="server">
      <asp:ListItem>Select bazaar kiosk location</asp:ListItem>
    </asp:DropDownList> 
    </div>
    </div>
</div>

                <br />
                               


                    <!-- ad length -->
                     <div class="control-group form-group">
                        <div class="controls">
           <div id="adlengthDiv" runat="server">                   
  <asp:DropDownList ID="ddlAdLength"    CssClass="form-control  input-sm" runat="server"> 
<asp:ListItem Value="-1">Select AD length..</asp:ListItem>
  <asp:ListItem Value="0">Test 1 hour</asp:ListItem>
  <asp:ListItem Value="7">1 week</asp:ListItem>
  <asp:ListItem Value="14">2 weeks</asp:ListItem>
  <asp:ListItem Value="28">4 weeks</asp:ListItem>
    </asp:DropDownList>
               </div>
                        </div>
                    </div>

            <!-- ad length-->






                <!-- expiry date -->
<div class="control-group form-group">
    <div class="controls">
        <div id="expirydiv" runat="server">
     <label>Expiry date</label>
    <asp:TextBox ID="txtExpiry" CssClass="form-control  input-sm" runat="server"></asp:TextBox>
    </div>
    </div>
</div>
<!-- expiry date -->


   </div>
        
       
           
                 <!-- Map Column -->
            <div class="col-md-6">
                <!-- Embedded Google Map -->
              <iframe width="425" height="300" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src="https://maps.google.co.uk/maps?client=firefox-a&amp;q=sl3+7eq&amp;ie=UTF8&amp;hq=&amp;hnear=Slough+SL3+7EQ,+United+Kingdom&amp;t=m&amp;z=14&amp;ll=51.504642,-0.550309&amp;output=embed"></iframe><br /><small><a href="https://maps.google.co.uk/maps?client=firefox-a&amp;q=sl3+7eq&amp;ie=UTF8&amp;hq=&amp;hnear=Slough+SL3+7EQ,+United+Kingdom&amp;t=m&amp;z=14&amp;ll=51.504642,-0.550309&amp;source=embed" style="color:#0000FF;text-align:left">View Larger Map</a></small>
            </div>
    
          
           
              
     </div>   <!-- row-->   
             


     <p>&nbsp;</p>
     
                    <div class="row">
  <div class="col-md-4"><button  id="btnPrevTab2" class="btn btn-primary btn-sm ">&lt&lt&nbsp;Previous</button>  &nbsp;   <button   id="btnNextTab2" class="btn btn-primary btn-sm">Next&nbsp;&gt&gt</button></div>
  <div class="col-md-4 col-md-offset-4"> <!--<button  class="btn btn-default">save draft</button>-->&nbsp;</div>
</div>



     </div>  <!-- ******** end of tab 2 ************ -->









 <div id="btvTab3" >


        <div class="row">
            <!-- Sidebar Column -->
            <div class="col-sm-6  col-md-6">


<h4>  Preview</h4>
     <div id="previewBox" style="border:1px dotted red;"  ></div>
                            
  </div> <!-- preview col 8 -->


             <div class="col-sm-6  col-md-6">
                 <h4>Summary</h4>
                 <div id="success" >
         
                     <span id="vAdtextFail" class="small"><i style="color:red;" class="fa fa-exclamation-triangle"></i> Ad text - no text detected</span>
                     <span id="vAdtextSuccess" class="small"><i style="color:green;" class="fa fa-check-circle"></i> Ad text - ok</span>
                     <br />
                     <span  id="vAdlocationFail" class="small"><i style="color: red;" class="fa fa-exclamation-triangle"></i> System / Location - not specified</span>
                     <span  id="vAdlocationSuccess" class="small"></span>
                     <br />
                     <span  id="vAdlengthFail" class="small"><i style="color:red;" class="fa fa-exclamation-triangle"></i> Ad Time Length - not specified</span>
                     <span  id="vAdlengthSucess" class="small"><i style="color:green;" class="fa fa-check-circle"></i> Ad Time Length -ok</span>
         <br /><hr />

                   
           
                 <ul>
                     <li>
                        <small> note: All ads are moderated to comply with terms and conditions<br />We aim to approve within 24 hours though usually takes less than 2 hrs.</small>
                     </li>

                     <li>
                         <small> The preview is an inidcator and not necessarily a reflection of style / ad size / layout. </small>
                     </li>

                     <li>
                         <small>For full terms / conditions -  please read them here.</small>
                     </li>
                    </ul>
                     

                      </div><!-- success /validation div-->


                 <br />


                  <div id='costDiv'> 
                      <h3><span id="totalCostLabel">£0</span></h3>
                       <h4><span id="totalCreditLabel">£0</span></h4><br />
                     <hr />

                      <asp:Button ID="btnSaveAd"  class="btn btn-success btn-lg" runat="server" Text="Submit now!" 
        onclick="btnSaveAd_Click" />

                 </div>

                  </div> <!-- col -->

            </div> <!-- row-->

     
     <p>&nbsp;</p>
                 
        

           <div class="row">
  <div class="col-sm-6">
         <button  id="btnPrevTab3" class="btn btn-primary btn-sm">&lt&lt&nbsp;Previous</button> 
  

      <asp:Button  OnClick="btnSaveDraft_Click" CssClass="btn btn-default btn-sm" ID="btnSaveDraft" runat="server" Text="save draft" />
      </div>
  <div class="col-sm-6  col-sm-offset-6">
       
      &nbsp;
  </div>
</div>

     

     </div><!-- end of tab 3 -->





                  
               
         </div>

        </div>
        <!-- /.row -->







        <hr>

        <!-- Footer -->
        <footer>
            <div class="row">
                <div class="col-lg-12">
                    <p>Copyright &copy; Bazaar Kiosk TV 2015</p><br />
                </div>
            </div>
        </footer>

        </div>
</form>


       

    <!-- Contact Form JavaScript -->
    <!-- Do not edit these files! In order to set the email address and subject line for the contact form go to the bin/contact_me.php file. -->
    <script src="js/jqBootstrapValidation.js"></script>
    <script src="js/contact_me.js"></script>


    <script>

        $().ready(function () {

            $("#btvTab1").show();
            $("#btvTab2").hide();
            $("#btvTab3").hide();



            $("vAdtextFail").hide();
            $("vAdtextSuccess").hide();
            $("vAdlocationFail").hide();
            $("vAdlocationSuccess").hide();
            $("vAdlengthFail").hide();
            $("vAdlengthSucess").hide();




            var adboxSizeR = $("#<%=ddlAdBoxSize.ClientID%>").val();
            $("#myArea1").removeClass();
            $("#myArea1").addClass('adboxBase adbox' + adboxSizeR);

        });

    

       



        $('#btvTab1Link').click(function (event) {
            event.preventDefault();
            $("#btvTab1").show();
            $("li#tab1").addClass('active');
            
            $("#btvTab2").hide();
            $("li#tab2").removeClass('active');

            $("#btvTab3").hide();
            $("li#tab3").removeClass('active');

        });

        
        $('#btvTab2Link').click(function (event) {
            event.preventDefault();
            $("#btvTab1").hide();
            $("li#tab1").removeClass('active');

            $("#btvTab2").show();
            $("li#tab2").addClass('active');

            $("#btvTab3").hide();
            $("li#tab3").removeClass('active');
        });








        $('#btvTab3Link').click(function (event) {
            event.preventDefault();
            $("#btvTab1").hide();
            $("li#tab1").removeClass('active');

            $("#btvTab2").hide();
            $("li#tab2").removeClass('active');

            $("#btvTab3").show();
            $("li#tab3").addClass('active');

            
            //populate from rich text
            var niccontent = nicEditors.findEditor('myArea1').getContent();
            //alert(niccontent);
            $('#previewBox').html(niccontent);

            
            
            document.getElementById('<%=  hidInnerHtml.ClientID %>').value = niccontent;
        
            //set heading from ad
            var headingTxt = $('#previewBox').text().substr(0,20);            
            $('#<%=HidHeading.ClientID %>').val(headingTxt);
           

           


            // *** VALIDATE on TAB 3 ****
            var adboxSizeR = $("#<%=ddlAdBoxSize.ClientID%>").val();
            var adLengthVal = $("#<%=ddlAdLength.ClientID%>").val();
            var adSystem = $("#<%=ddlSystemsList.ClientID%>").val();
            var adSystemtxt = $("#<%=ddlSystemsList.ClientID%> option:selected").text();
            

            // if there is on content then disable submit button
            if ((headingTxt.length <= 1) || (adLengthVal<0) || (adSystem =="-1") ) {
              
                $('#costDiv').hide();
                $('#<%=btnSaveAd.ClientID %>').attr('disabled','disabled');
            } else
            {

                var adLengthValWk = adLengthVal / 7;
                // get the data attributes from the list items for system
                var dataatrr1 = $('#<%=ddlSystemsList.ClientID%> option:selected').data(adboxSizeR);
                //alert(dataatrr1);
                $('#totalCostLabel').text('Total cost for this Ad: £' + (dataatrr1 * adLengthValWk).toFixed(2));
                $('#totalCreditLabel').text('Total credit available: £<%=PlayV.baz.utils.bazutils.GetUserSessionVal("credit")%>');
                $('#costDiv').show();
                $('#<%=btnSaveAd.ClientID %>').removeAttr('disabled');
                

            }



            if (headingTxt.length <= 1)
            {
                $('#vAdtextSuccess').hide();
                $('#vAdtextFail').show();
            }
            else
            {
                $('#vAdtextSuccess').show();
                $('#vAdtextFail').hide();

            }

            if (adLengthVal < 0) {
                $('#vAdlengthSucess').hide();
                $('#vAdlengthFail').show();
            }
            else
            {
                $('#vAdlengthSucess').show();
                $('#vAdlengthFail').hide();

            }


            if (adSystem == "-1") {
                //fail
                $('#vAdlocationFail').show();
                $('#vAdlocationSuccess').hide();
            }
            else
            {
                // success
                $('#vAdlocationFail').hide();
                $('#vAdlocationSuccess').show();
                $('#vAdlocationSuccess').html('<i style=\"color: green;\" class=\"fa fa-check-circle\"></i>&nbsp;');
                $('#vAdlocationSuccess').append(adSystemtxt);

            }

                        

            // style review 
            //Calling removeClass with no parameters will remove all of the item's classes.
            var adboxSize = $("#<%=ddlAdBoxSize.ClientID%>").val();
           
         
             
            // if it DOES NOT have class then assign it
            if (!$("#<%=ddlAdBoxSize.ClientID%>").hasClass('adbox' + adboxSize)) {

                // remove
                $("#previewBox").removeClass();

                //add
                $("#previewBox").addClass('adboxBase adbox' + adboxSize);
            }

        });
        

    
       

        $("#<%=ddlAdBoxSize.ClientID%>").change(function () {            
            
            var adboxSizeR = $("#<%=ddlAdBoxSize.ClientID%>").val();
            $("#myArea1").removeClass();
            $("#myArea1").addClass('adboxBase adbox' + adboxSizeR);
        });

        


        $('#btnNextTab1').click(function (event) {
            event.preventDefault();
            //alert('1');
            $('#btvTab2Link').click();

        });



        $('#btnNextTab2').click(function (event) {
            event.preventDefault();
            //alert('2');
            $('#btvTab3Link').click();

        });


        $('#btnPrevTab2').click(function (event) {
            event.preventDefault();
            $('#btvTab1Link').click();

        });


        $('#btnPrevTab3').click(function (event) {
            event.preventDefault();
            $('#btvTab2Link').click();

        });


             

    </script>

    
      <script  type="text/javascript" src="nicEdit/nicEdit.js"></script>

    
    <script type="text/javascript">

        var area1, area2;

        function toggleArea1() {
          
            if (!area1)
            {
                area1 = new nicEditor({
                    fullPanel: false,
                    iconsPath: 'nicEdit/nicEditorIcons.gif',
                    buttonList: ['fontSize', 'fontformat', 'fontFamily', 'bold', 'italic', 'underline', 'strikeThrough', 'indent', 'outdent', 'forecolor', 'hr', 'left', 'right', 'justify', 'center', 'ol', 'ul', 'upload']
                });
                area1.setPanel('myNicPanel');
                area1.addInstance('myArea1');
                    
            }

                

            else {
                area1.removeInstance('myArea1');
                area1 = null;
            }



        }




       // bkLib.onDomLoaded(nicEditors.allTextAreas);

        var nic;
        toggleArea1();

       


    </script>


</asp:Content>
