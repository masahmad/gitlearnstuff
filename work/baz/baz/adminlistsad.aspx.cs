using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using PlayV.obj;
using System.Data;
using System.Configuration;



namespace PlayV
{
    public partial class adminlistad : System.Web.UI.Page
    {


        enum GridCol
        {
            modalpreview,
            idcontentad,
            category,
            heading,
            expirydate,
            approved,
            systemid,
            sysname,
            templateid,
            name,
            email,
            approveLink,
            deleteLink
         
            
        };



        void Page_PreInit(Object sender, EventArgs e)
        {
            bool adminFlag = false;
            try
            {
                adminFlag = Convert.ToBoolean(Session["admin"]);
            }

            catch (Exception exadmin)
            {
                adminFlag = false;
            }

            if (adminFlag) this.MasterPageFile = "~/admin.master";
        }






        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RefreshGrid();

            }
        }




        protected void gvAds_RowDataBound(object sender, GridViewRowEventArgs e)
        {   //Get data row view
            DataRowView drview = e.Row.DataItem as DataRowView;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                
                DateTime expdt = Convert.ToDateTime(drview["expirydate"]);
                bool approved = Convert.ToBoolean(drview["approved"]);

                if (expdt < DateTime.Now)
                {
                    e.Row.Cells[(int)GridCol.expirydate].Text = "Expired";
                    e.Row.ForeColor = System.Drawing.Color.Silver;
                }

                if (expdt >= DateTime.Now && approved)
                {
                    e.Row.Cells[(int)GridCol.expirydate].BackColor = System.Drawing.Color.LightGreen;
                    e.Row.Cells[(int)GridCol.expirydate].Text = "Live!";
                }


                if (expdt >= DateTime.Now && (!approved))
                {
                    e.Row.Cells[(int)GridCol.expirydate].BackColor = System.Drawing.Color.Orange;
                    e.Row.Cells[(int)GridCol.expirydate].Text = "Pending";
                }
               
            }






        }




        protected void gvAds_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {

            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow gvRow = gvAds.Rows[index];
            string idContentAd = gvRow.Cells[(int)GridCol.idcontentad].Text;


            if (e.CommandName == "delete")
            {
                MySqlManagers.MySqlDbManager.AdminDeleteContentAd(idContentAd);
            }


            if (e.CommandName == "approve")
            {
                MySqlManagers.MySqlDbManager.AdminApprovedContentAd(idContentAd);
            }

           
           
            RefreshGrid();

        }


      protected void RefreshGrid()
        {

            gvAds.DataSource = MySqlManagers.MySqlDbManager.GetAdminAds();
            gvAds.DataBind();

        }

      protected void gvAds_RowDeleting(object sender, GridViewDeleteEventArgs e)
      {

      }

    }
}