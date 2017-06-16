<%@ Page Title="" Language="C#" MasterPageFile="test.Master" AutoEventWireup="True" CodeBehind="confirmEm.aspx.cs" Inherits="PlayV.confirmemail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">






</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       

 <form runat="server"  name="sentMessage" id="contactForm" novalidate> 
        
     <!-- Page Content -->
    <div class="container">

        <!-- Page Heading/Breadcrumbs -->
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Email confirmation
                    <small>check</small>
                </h1>
                <ol class="breadcrumb">
                    <li><a href="index.aspx">Home</a>
                    </li>
                    <li class="active">confirmation</li>
                </ol>
            </div>
        </div>
        <!-- /.row -->



        <!-- Contact Form -->
        <!-- In order to set the email address and subject line for the contact form go to the bin/contact_me.php file. -->
        <div class="row">
            <div class="col-sm-12 col-md-12">
              
            
                <asp:Label ID="lblConfirmEmailCheck" runat="server" Text="check.."></asp:Label>
             

        </div> <!-- end col -->

    


        </div>  <!-- /.row -->



        <hr>

        <!-- Footer -->
        <footer>
            <div class="row">
                <div class="col-lg-12">
                    <p>Copyright &copy; Bazaar Kiosk TV 2015                </div>
            </div>
        </footer>

</div>
  <!--end Page Content -->
 </form> 


       

  <script type="text/javascript">

      $(document).ready(function () {

          $('#linkSignUp').click(function () {
              $('#btvregister').show();
              $('#btvlogin').hide();
          });


          $('#linkLogIn').click(function () {
              $('#btvregister').hide();
              $('#btvlogin').show();
          });



          $('#btvregister').hide();
      });
  </script>




</asp:Content>
