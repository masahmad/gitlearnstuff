<%@ Page Title="" Language="C#" MasterPageFile="test.Master" AutoEventWireup="True" CodeBehind="myaccount.aspx.cs" Inherits="PlayV.myaccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">



</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    

    <form runat="server"  name="sentMessage" id="contactForm" novalidate>



     <!-- Page Content -->
    <div class="container">


        

        <!-- Page Heading/Breadcrumbs -->
        <div class="row">
            <div class="col-lg-12">
              <!--  <h1 class="page-header">My Account
                    <small>settings</small>
                </h1> --><br />
                <ol class="breadcrumb">
                    <li><a href="index.aspx">Home</a>
                    </li>
                    <li class="active">Post Ad</li>
                </ol>
            </div>
        </div>
        <!-- /.row -->

        

        <!-- Content Row -->
        <div class="row">
            <!-- Sidebar Column -->
            <div class="col-sm-3  col-md-3">
                <div class="list-group">
                     <a href="managead.aspx" class="list-group-item"><i  class="fa fa-file"></i>&nbsp;&nbsp;&nbsp;Post new ad</a>
                    <a href="listsad.aspx" class="list-group-item"> <i  class="fa fa-list-alt"></i> &nbsp;List my ads</a>
                    <a href="myaccount.aspx" class="list-group-item active"> <i  class="fa fa-gear  fa"></i> &nbsp;&nbsp;Account settings</a>
                </div>
            </div>
            <!-- Content Column -->
            <div class="col-sm-9 col-md-9">
                <h2>Amend your personal details</h2>
                <p>Change your password or etc.</p>


                 <!-- Contact Form -->
        <!-- In order to set the email address and subject line for the contact form go to the bin/contact_me.php file. -->
    
                <h3>Message</h3>

                   



                    <div class="control-group form-group">
                        <div class="controls">
                           <label>Name:</label>
                           <asp:TextBox ID="txtName"  CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>


	  <div class="control-group form-group">
                        <div class="controls">
                           <label>Password:</label>
                           <asp:TextBox ID="txtPassword"  CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>



                    <div id="success"></div>
                    <!-- For success/fail messages -->
                 
                 <asp:Button ID="btnSaveAd"  class="btn btn-primary" runat="server" Text="update" 
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

        </div>
</form>


       

    <!-- Contact Form JavaScript -->
    <!-- Do not edit these files! In order to set the email address and subject line for the contact form go to the bin/contact_me.php file. -->
    <script src="js/jqBootstrapValidation.js"></script>
    <script src="js/contact_me.js"></script>




</asp:Content>
