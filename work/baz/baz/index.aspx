<%@ Page Title="" Language="C#" MasterPageFile="test.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="baz.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>




<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <!-- Header Carousel -->
    <header id="myCarousel" class="carousel slide">
        <!-- Indicators -->
        <ol class="carousel-indicators">
            <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
            <li data-target="#myCarousel" data-slide-to="1"></li>
           <!-- <li data-target="#myCarousel" data-slide-to="2"></li> -->
        </ol>

        <!-- Wrapper for slides -->
        <div class="carousel-inner">
           
            
            
             <div class="item active">
                <div class="fill" style="background-image:url('images/MATRIX1600color.png');">
 <img style="margin-right:5%;margin-top:30px;float:right;"alt='banner' src="images/tv5.png" /> 
                </div>
             
                   <div class="carousel-caption">
                    <h2><!--caption--></h2>
                </div>
            </div>
         



              
       

            <div class="item">
                <div class="fill" style="background-image:url('images/drawing2.png');">
<img style="margin-right:5%;margin-top:30px;float:right;"alt='banner' src="images/tv5.png" /> 
                  
                </div>
                <div class="carousel-caption">
                     <h2><!-- caption --></h2>
                </div>
            </div>


        </div>

        <!-- Controls -->
        <a class="left carousel-control" href="#myCarousel" data-slide="prev">
            <span class="icon-prev"></span>
        </a>
        <a class="right carousel-control" href="#myCarousel" data-slide="next">
            <span class="icon-next"></span>
        </a>
    </header>


    
    
     <!-- Page Content -->
    <div class="container">

    



       <!-- Marketing Icons Section -->
        <div class="row">
            <div class="col-lg-12">
                <h3 class="page-header" style="font-style:italic;">
                <i  style="color:Green" class="fa fa-quote-left  fa"></i> &nbsp;Bazaar tv is a Community driven digital noticeboard  updated  in realtime every minute of the day! &nbsp;<i  style="color:Green" class="fa fa-quote-right  fa"></i>
                </h3>
            </div>
            <div class="col-md-4">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4><i class="fa fa-fw fa-check"></i> Start posting now..</h4>
                    </div>
                    <div class="panel-body">
                        <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Itaque, optio corporis quae nulla aspernatur in alias at numquam rerum ea excepturi expedita tenetur assumenda voluptatibus eveniet incidunt dicta nostrum quod?</p>
                        <a href="#" class="btn btn-default">Learn More</a>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4><i class="fa fa-fw fa-gift"></i> How it works?</h4>
                    </div>
                    <div class="panel-body">
                        <p>Bazaar kiosk TV is community driven by locals for locals..</p>
                        <a href="#" class="btn btn-default">Learn More</a>
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <h4><i class="fa fa-fw fa-compass"></i>Get Bazaar Kiosk for your Business</h4>
                    </div>
                    <div class="panel-body">
                        <p>Generate extra revenue from your business location. We supply kiosks  for shopfronts and free standing units. Get in touch with a representative. rep@bazaartv.co.uk</p>
                        <a href="#" class="btn btn-default">Learn More</a>
                    </div>
                </div>
            </div>
        </div>
        <!-- /.row -->


	

      <hr>
       
  


  <!-- container -->
   </div>


  
        <!-- Footer -->
        <footer class="navbar " style=" background-color:#333">
          
            <div class="container"

                <p>&nbsp;</p>
                <p>&nbsp;</p>
                <p>&nbsp;</p>
              <div class="row" >
                <div class="col-lg-12">


            <div class="col-sm-2">
        <p class="text-primary small">
            Faqs<br />
            Blog<br />
        </p>
            </div>
<!-- end col -->



              <div class="col-sm-2">
                <p class="text-primary small">
               Contact us<br />
               About us<br />
               Report an issue <br />

           </p>
            </div>
<!-- end col -->




            <div class="col-sm-2">
               <span class="text-primary small ">Partners</span><br />
                   PlayVisual<br />
                   Digital Notices<br />
                   Become an agent
                  
               
            </div>
<!-- end col -->


                       <div class="col-sm-6">
                         
                            <p class="text-primary">Copyright &copy; Bazaar Kiosk TV 2015</p>
                            <h3  style="color:#eee;"> Powered by PlayVisual</h3>
                           </div>


                   
                </div>
            </div>


                </div>
        </footer>

  
</asp:Content>
