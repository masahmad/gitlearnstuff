<%@ Page Title="" Language="C#" MasterPageFile="test.Master" AutoEventWireup="True" CodeBehind="signin.aspx.cs" Inherits="PlayV.signin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<style>




/*
    Note: It is best to use a less version of this file ( see http://css2less.cc
    For the media queries use @screen-sm-min instead of 768px.
    For .omb_spanOr use @body-bg instead of white.
*/

@media (min-width: 768px) {
    .omb_row-sm-offset-3 div:first-child[class*="col-"] {
        margin-left: 25%;
    }
}

.omb_login .omb_authTitle {
    text-align: center;
	/*line-height: 300%;*/
}
	
.omb_login .omb_socialButtons a {
	color: white;  /* In yourUse @body-bg */
	opacity:0.9;
}
.omb_login .omb_socialButtons a:hover {
    color: white;
	opacity:1;    	
}
.omb_login .omb_socialButtons .omb_btn-facebook {background: #3b5998;}
.omb_login .omb_socialButtons .omb_btn-twitter {background: #00aced;}
.omb_login .omb_socialButtons .omb_btn-google {background: #c32f10;}


.omb_login .omb_loginOr {
	position: relative;
	font-size: 1.5em;
	color: #aaa;
	margin-top: 1em;
	margin-bottom: 1em;
	padding-top: 0.5em;
	padding-bottom: 0.5em;
}
.omb_login .omb_loginOr .omb_hrOr {
	background-color: #cdcdcd;
	height: 1px;
	margin-top: 0px !important;
	margin-bottom: 0px !important;
}
.omb_login .omb_loginOr .omb_spanOr {
	display: block;
	position: absolute;
	left: 50%;
	top: -0.6em;
	margin-left: -1.5em;
	background-color: white;
	width: 3em;
	text-align: center;
}			

.omb_login .omb_loginForm .input-group.i {
	width: 2em;
}
.omb_login .omb_loginForm  .help-block {
    color: red;
}

	
@media (min-width: 768px) {
    .omb_login .omb_forgotPwd {
        text-align: right;
		margin-top:10px;
 	}		
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
                <h1 class="page-header">Sign in
                    <small>log into bazaar tv</small>
                </h1>
                <ol class="breadcrumb">
                    <li><a href="index.aspx">Home</a>
                    </li>
                    <li class="active">signin</li>
                </ol>
            </div>
        </div>
        <!-- /.row -->



        <!-- Contact Form -->
        <!-- In order to set the email address and subject line for the contact form go to the bin/contact_me.php file. -->
        <div class="row">
            <div class="col-sm-12 col-md-12">
              
              <link href="//netdna.bootstrapcdn.com/font-awesome/4.0.3/css/font-awesome.css" rel="stylesheet">

                <asp:Panel ID="PanelLogin" runat="server">
               
  <div id='btvlogin' class="omb_login">
    	<h3 class="omb_authTitle">Login or <a id='linkSignUp''href="#">Sign up</a></h3>
		<div class="row omb_row-sm-offset-3 omb_socialButtons">
    	    <div class="col-xs-4 col-sm-2">
		        <a href="#" class="btn btn-lg btn-block omb_btn-facebook">
			        <i class="fa fa-facebook visible-xs"></i>
			        <span class="hidden-xs">Facebook</span>
		        </a>
	        </div>
        	<div class="col-xs-4 col-sm-2">
		        <a href="#" class="btn btn-lg btn-block omb_btn-twitter">
			        <i class="fa fa-twitter visible-xs"></i>
			        <span class="hidden-xs">Twitter</span>
		        </a>
	        </div>	
        	<div class="col-xs-4 col-sm-2">
		        <a href="#" class="btn btn-lg btn-block omb_btn-google">
			        <i class="fa fa-google-plus visible-xs"></i>
			        <span class="hidden-xs">Google+</span>
		        </a>
	        </div>	
		</div>

		<div class="row omb_row-sm-offset-3 omb_loginOr">
			<div class="col-xs-12 col-sm-6">
				<hr class="omb_hrOr">
				<span class="omb_spanOr">or</span>
			</div>
		</div>

		<div class="row omb_row-sm-offset-3">
			<div class="col-xs-12 col-sm-6">	
			
					<div class="input-group">
						<span class="input-group-addon"><i class="fa fa-user"></i></span>
						   <asp:TextBox ID="txtLoginUserName"  CssClass="form-control" placeholder="email address" runat="server"></asp:TextBox>
					</div>
					<span class="help-block"></span>
										
					<div class="input-group">
						<span class="input-group-addon"><i class="fa fa-lock"></i></span>
					 <asp:TextBox ID="txtLoginPassword"   runat="server" TextMode="Password" CssClass="form-control" placeholder="Password"></asp:TextBox>
					</div>
                    <!--<span class="help-block">Password error</span>-->
                <asp:Label ID="lblLoginErrorStatus"  runat="server" CssClass="help-block"  Text="">log in</asp:Label>
                        <asp:Button ID="btnLogin" runat="server" 
                    CssClass="btn btn-lg btn-primary btn-block" Text="Login" 
                        onclick="btnLogin_Click" />

			</div>
    	</div>
		<div class="row omb_row-sm-offset-3">
			<div class="col-xs-12 col-sm-3">
				<label class="checkbox">
					<input type="checkbox" value="remember-me">Remember Me
				</label>
			&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</div>
			<div class="col-xs-12 col-sm-3">
				<p class="omb_forgotPwd">
					<a href="#">Forgot password?</a>
				</p>
			</div>
		</div>	    	
	</div>
     </asp:Panel>




                <asp:Panel ID="PanelRegistration" Visible="true" runat="server">
                
                <div id='btvregister' class="omb_login">
    	
             	<h3 class="omb_authTitle">Register or <a id='linkLogIn''href="#">Log in</a></h3>  

		<div class="row omb_row-sm-offset-3">
			<div class="col-xs-12 col-sm-6">	
			  <!--  <form class="omb_loginForm" action="" autocomplete="off" method="POST"> -->
					

                      <div class="input-group">
						<span class="input-group-addon"><i class="fa fa-user"></i></span>
                          <asp:TextBox CssClass="form-control" ID="txtRegistrationName" placeholder="your name" runat="server"></asp:TextBox>
					</div>
                     <span class="help-block">&nbsp;</span>


                    <div class="input-group">
						<span class="input-group-addon"><i class="fa fa-envelope-o"></i></span>
                        <asp:TextBox ID="txtUserName"  CssClass="form-control" placeholder="email address" runat="server"></asp:TextBox>
					</div>
                     <span class="help-block"></span>

                     <div class="input-group">
						<span class="input-group-addon"><i class="fa fa-envelope-o"></i></span>
                        <asp:TextBox ID="TextBox1"  CssClass="form-control" placeholder="confirm email address" runat="server"></asp:TextBox>
					</div>
				 <span class="help-block"></span>

				
										
					
                    <div class="input-group">
						<span class="input-group-addon"><i class="fa fa-lock"></i></span>
					  <asp:TextBox ID="txtUserPass"  runat="server" TextMode="Password" CssClass="form-control" placeholder="Password"></asp:TextBox>
					</div>
                    <span class="help-block">Password error</span>


                <asp:Button ID="btnRegister" runat="server" 
                    CssClass="btn btn-lg btn-warning btn-block" Text="Register" 
                    onclick="btnRegister_Click" />

			<!--	</form> -->
			</div>
    	</div>
		 	
	</div>
                </asp:Panel>

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
