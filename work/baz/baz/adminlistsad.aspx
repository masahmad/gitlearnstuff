<%@ Page Title="" Language="C#"  MaintainScrollPositionOnPostback="true"  MasterPageFile="test.Master" AutoEventWireup="True" CodeBehind="adminlistsad.aspx.cs" Inherits="PlayV.adminlistad" %>
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
          
            <!-- Content Column -->
            <div class="col-sm-12 col-md-12">
                <h2>Ads center</h2>
                <p>Moderators check and approve  all new and modified ads. </p>
               <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
              <asp:GridView   OnRowCommand = "gvAds_OnRowCommand"  OnRowDataBound="gvAds_RowDataBound"  GridLines="none" BorderWidth="0" CssClass="table table-striped" ID="gvAds" runat="server" 
                    EnableModelValidation="True" AutoGenerateColumns="False" OnRowDeleting="gvAds_RowDeleting">
                  <Columns>


    <asp:TemplateField >
    <ItemTemplate>
<a  href="#" onClick="javascript:modalAlert('<%# Eval("idcontentad")%>')" >
    <i class="fa fa-eye"></i>
</a>
     </ItemTemplate>
</asp:TemplateField>



                      <asp:BoundField DataField="idcontentad" Visible="true" HeaderText="id" 
                          SortExpression="idcontentad" />
                     
                       <asp:BoundField DataField="category" Visible="false" HeaderText="category" 
                          SortExpression="category" />
                     
                       <asp:BoundField DataField="heading" HeaderText="Heading" 
                          SortExpression="heading" />
                      
                      
                        <asp:BoundField DataField="expirydate" HeaderText="Expires" 
                          SortExpression="expirydate" />

                        <asp:BoundField DataField="approved" HeaderText="Approved" 
                          SortExpression="approved" />
                       


                        <asp:BoundField DataField="systemid" HeaderText="sys id"  />
                      <asp:BoundField DataField="sysname" HeaderText="sys name"  />
                      <asp:BoundField DataField="templateid"  Visible="false" HeaderText="template"  />

                        <asp:BoundField DataField="name" HeaderText="name"  />
                        <asp:BoundField DataField="email" HeaderText="email"  />


                          <asp:CommandField HeaderText="approve" Visible="false" ButtonType="Link"   ShowSelectButton="true"  SelectText="approve"  />



   <asp:TemplateField >
    <ItemTemplate>
<asp:LinkButton  CommandName="approve" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"  runat="server"> <i class="fa fa-check "></i></asp:LinkButton>
     </ItemTemplate>
</asp:TemplateField>


   <asp:TemplateField >
    <ItemTemplate>
<asp:LinkButton  CommandName="delete" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"  runat="server"> <i class="fa fa-trash-o "></i></asp:LinkButton>
 

     </ItemTemplate>
</asp:TemplateField>


                        
                  </Columns>
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
