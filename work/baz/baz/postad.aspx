<%@ Page Title="" Language="C#" MasterPageFile="test.Master" AutoEventWireup="True" CodeBehind="postad.aspx.cs" Inherits="PlayV.postad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">



</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    

    <form runat="server"  name="sentMessage" id="contactForm" novalidate>



     <!-- Page Content -->
    <div class="container">

        <!-- Page Heading/Breadcrumbs -->
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Post Ad
                    <small>write a message / notice!</small>
                </h1>
                <ol class="breadcrumb">
                    <li><a href="index.html">Home</a>
                    </li>
                    <li class="active">Contact</li>
                </ol>
            </div>
        </div>
        <!-- /.row -->



        <!-- Contact Form -->
        <!-- In order to set the email address and subject line for the contact form go to the bin/contact_me.php file. -->
        <div class="row">
            <div class="col-md-8">
                <h3>Message</h3>
              





                <!-- category-->
                    <div class="control-group form-group">
                        <div class="controls">
<div id="categorydiv" runat="server">
                           <label>Category:</label>
                                <asp:DropDownList  CssClass="form-control" ID="ddlCategory" runat="server">
             <asp:ListItem>Services</asp:ListItem>
             <asp:ListItem>Accommodation</asp:ListItem>
         </asp:DropDownList> 
                   </div>        

                        </div>
                    </div>
<!-- category-->





                <!-- heading div-->
                    <div class="control-group form-group">
                        <div class="controls">
                            <div id="headingdiv" runat="server">
                           <label>Heading:</label>
                           <asp:TextBox ID="txtHeading"  CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                        </div>
                    </div>
                <!-- heading div-->





                  
	 


                    <div class="control-group form-group">
                        <div class="controls">
                           <label>Message/ Text </label>
                            <asp:TextBox   Columns="40"  Rows="5"  CssClass="form-control" TextMode="MultiLine" ID="txtAdText" runat="server"></asp:TextBox>
                        </div>
                    </div>






<!-- ad length -->

                     <div class="control-group form-group">
                        <div class="controls">
                           <label>Ad length</label>
                             <asp:DropDownList ID="ddlAdLength" CssClass="form-control" runat="server">
 <asp:ListItem Value="1">1 week</asp:ListItem>
  <asp:ListItem Value="2">2 weeks</asp:ListItem>
  <asp:ListItem Value="3">4 weeks</asp:ListItem>
    </asp:DropDownList>
                        </div>
                    </div>
<!-- ad length -->







<!-- contact-->
          <div class="control-group form-group">
                        <div class="controls">
                           <label>Contact </label>
                             <asp:TextBox  CssClass="form-control" ID="txtContact" runat="server"></asp:TextBox>
                        </div>
                    </div>

<!-- contact -->





<!-- qr -->
   <div class="control-group form-group">
      <div class="controls">
    <div id="qrdiv" runat="server">
<label>Enable QR code</label>
    <asp:CheckBox ID="chkQRcode"  CssClass="form-control" runat="server" /> 
    </div>
</div>
</div>
<!-- qr -->







<!-- premium -->
 <div class="control-group form-group">
    <div class="controls">
    <div id="premiumdiv" runat="server">
    <label for="adpremium" accesskey="t">Premium ad</label>
    <asp:CheckBox CssClass="form-control" ID="chkPremium" runat="server" /> 
    </div>
    </div>
</div>
<!-- premium -->







<!-- priority -->
 <div class="control-group form-group">
    <div class="controls">
    
    <div id="prioritydiv" runat="server">
        <label for="adpriority" accesskey="t">Priority</label>
    <asp:DropDownList ID="ddlPriority" runat="server" CssClass="form-control">
        <asp:ListItem Value="1">Low</asp:ListItem>
        <asp:ListItem Value="2">Medium</asp:ListItem>
        <asp:ListItem Value="3">High</asp:ListItem>
    </asp:DropDownList>  
    </div>
    </div>
</div>
<!-- priority -->









<!-- box size  -->
 <div class="control-group form-group">
    <div class="controls">
     <div id="boxsizediv" runat="server">
<label>Box size</label>
        <asp:DropDownList CssClass="form-control" ID="ddlAdBoxSize" runat="server">
 <asp:ListItem Value="1">small (postit note sixe)</asp:ListItem>
        <asp:ListItem Value="2">Medium (postcard size)</asp:ListItem>
        <asp:ListItem Value="3">Large (approx A4)</asp:ListItem>
        <asp:ListItem Value="4">xLarge (full screen)</asp:ListItem>
    </asp:DropDownList> 
    </div>
    </div>
</div>
<!-- box size -->







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






<!-- expiry date -->
<div class="control-group form-group">
    <div class="controls">
        <div id="expirydiv" runat="server">
     <label>Expiry date</label>
    <asp:TextBox ID="txtExpiry" CssClass="form-control" runat="server"></asp:TextBox>
    </div>
    </div>
</div>
<!-- expiry date -->







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





<!-- spare
<div class="control-group form-group">
    <div class="controls">
    XZXXXXXXXXXXXXXXXXXXXXXXX
    </div>
</div>

 publish date -->




                    <div id="success"></div>
                    <!-- For success/fail messages -->
                 
                 <asp:Button ID="btnSaveAd"  class="btn btn-primary" runat="server" Text="Save/ preview" 
        onclick="btnSaveAd_Click" />
               
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


</form>


       

    <!-- Contact Form JavaScript -->
    <!-- Do not edit these files! In order to set the email address and subject line for the contact form go to the bin/contact_me.php file. -->
    <script src="js/jqBootstrapValidation.js"></script>
    <script src="js/contact_me.js"></script>




</asp:Content>
