<%@ Page Title="" Language="C#" MasterPageFile="test.Master" AutoEventWireup="True" CodeBehind="listad.aspx.cs" Inherits="PlayV.listad" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">



</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    

    <form runat="server"  name="sentMessage" id="contactForm" novalidate>
    
     <!-- Page Content -->
    <div class="container">
     

        <!-- Page Heading/Breadcrumbs -->
        <div class="row">
            <div class="col-lg-12">
              <!--  <h1 class="page-header">Manage ads
                    <small>list</small>
                </h1>

                --><br />
                <ol class="breadcrumb">
                    <li><a href="index.aspx">Home</a>
                    </li>
                    <li class="active">My ad list</li>
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
                    <a href="listsad.aspx" class="list-group-item active"> <i  class="fa fa-list-alt"></i> &nbsp;List my ads</a>
                    <a href="myaccount.aspx" class="list-group-item"> <i  class="fa fa-gear  fa"></i> &nbsp;&nbsp;Account settings</a>
                </div>
            </div>
            <!-- Content Column -->
            <div class="col-sm-9 col-md-9">
              
                <p>My Ads - Modify  ad content and check current status of all your ads. Note: Moderators check and approve  all new and modified ads. </p>
              
              <asp:GridView DataKeyNames="idcontentad"  OnRowCommand = "gvAds_OnRowCommand" OnRowDataBound="gvAds_RowDataBound"  GridLines="none" BorderWidth="0" CssClass="table table-striped table-condensed" ID="gvAds" runat="server" 
                    EnableModelValidation="True" AutoGenerateColumns="False">
                  <Columns>


 <asp:TemplateField >
    <ItemTemplate>
<a  href="#" onClick="javascript:modalAlert('<%# Eval("idcontentad")%>')" >
    <i class="fa fa-eye"></i>
</a>
     </ItemTemplate>
</asp:TemplateField>


                

                      <asp:BoundField DataField="idcontentad" Visible="false" HeaderText="id" 
                          SortExpression="idcontentad" />
                      <asp:BoundField DataField="category" Visible="false" HeaderText="category" 
                          SortExpression="category" />
                      <asp:BoundField DataField="heading" HeaderText="Title" 
                          SortExpression="heading" />


                       

                        

                          <asp:TemplateField HeaderText="Status" SortExpression="Status">
                          <ItemTemplate>
                          &nbsp;
                          </ItemTemplate>
                          </asp:TemplateField>
                    

                    
                         <asp:TemplateField HeaderText="Location" SortExpression="Status">
                          <ItemTemplate> <i class="fa fa-desktop"></i>&nbsp;
                          <%#Eval("sysname")%>
                          </ItemTemplate>
                          </asp:TemplateField>

                       <asp:BoundField DataField="expirydate" HeaderText="Expires" 
                          SortExpression="expirydate" />

                          <asp:CommandField ButtonType="Link"   ShowEditButton="true" SelectText="edit" />
                         
                        
                  </Columns>

                  <EmptyDataTemplate>
                      <p>You currently have no ads listed here! - try posting some new ads</p>

                  </EmptyDataTemplate>
              </asp:GridView>
        
               
     

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


        <!--
        <a href="#" class="btn btn-lg btn-success"
   data-toggle="modal"
   data-target="#basicModal">Click to open Modal</a>

        -->

        <!-- modal -->
        <div class="modal fade" id="basicModal" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">Xx;</button>
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
        <!-- modal -->





        </div>




</form>


       

    <!-- Contact Form JavaScript -->
    <!-- Do not edit these files! In order to set the email address and subject line for the contact form go to the bin/contact_me.php file. -->
    <script src="js/jqBootstrapValidation.js"></script>
    <script src="js/contact_me.js"></script>

    <script>

        function modalAlert(id) {
                   
            var options = {
                "backdrop": "true",
                "show":"true",
                "remote":"previewad.aspx?id=" + id

            }

            $('#basicModal').modal(options);

        }


        // re: cache issue
        //http://stackoverflow.com/questions/12286332/twitter-bootstrap-remote-modal-shows-same-content-everytime
        //A simple remedy is to destroy the Modal object before subsequent toggles.
        //One option is to just destroy it after it finishes hiding:
        $('body').on('hidden.bs.modal', '.modal', function () {
            $(this).removeData('bs.modal');
        });
    </script>
  

</asp:Content>
