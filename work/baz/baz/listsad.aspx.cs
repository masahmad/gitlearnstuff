using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using PlayV.obj;
using System.Data;
using System.Configuration;
using PlayV.baz.utils;



namespace PlayV
{
    public partial class listad : System.Web.UI.Page
    {


        enum GridCol
        {
           modalpreview,
            idcontentad,
            category,
            heading,
            status,
            system,
            expirydate,
            editlink
        };


        protected void Page_Load(object sender, EventArgs e)
        {


            if (!bazutils.isUserAuthenticated())
            {
                
                Response.Redirect("signin.aspx");
            }







            if (!IsPostBack)
            {
                string idbtvuser = baz.utils.bazutils.GetUserSessionVal("idbtvusers");
                gvAds.DataSource = MySqlManagers.MySqlDbManager.GetMyAdContentGrid(idbtvuser);
                gvAds.DataBind();

            }
        }






        protected void gvAds_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {

            int index = Convert.ToInt32(e.CommandArgument);

            GridViewRow gvRow = gvAds.Rows[index];
            string idContentAd = gvAds.DataKeys[index].Value.ToString();
            Response.Redirect("~/managead.aspx?contentId=" + idContentAd);
           // MySqlManagers.MySqlDbManager.AdminApprovedContentAd(idContentAd);
            //RefreshGrid();

        }





        protected void gvAds_RowDataBound(object sender, GridViewRowEventArgs e)
        {   //Get data row view
            DataRowView drview = e.Row.DataItem as DataRowView;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Find dropdown control & get values
                //DropDownList dpEmpdept = (DropDownList)e.Row.FindControl("DrpDwnEmpDept");
                //string value = dpEmpdept.SelectedItem.Value;
                //Find textbox control
                //TextBox txtname = (TextBox)e.Row.FindControl("txtName");
                //string Name = txtname.Text;
                //Find checkbox and checked/Unchecked based on values

                DateTime expdt = Convert.ToDateTime(drview["expirydate"]);
                bool approved = Convert.ToBoolean(drview["approved"]);

                string recStatus = drview["recordStatus"].ToString();


                
                // expired
                if ((expdt < DateTime.Now) &&  (recStatus != "draft"))
                {
                    e.Row.Cells[(int)GridCol.status].Text = "Expired";
                    e.Row.ForeColor = System.Drawing.Color.Silver;

                    LinkButton cmdField = (LinkButton)e.Row.Cells[(int)GridCol.editlink].Controls[0];
                   if (cmdField!=null) cmdField.Visible = false;
                }



                // live
                if ((expdt >= DateTime.Now && approved)  && (recStatus=="new"))
                {
                    e.Row.Cells[(int)GridCol.status].BackColor = System.Drawing.Color.LightGreen;
                    e.Row.Cells[(int)GridCol.status].Text = "Live!";

                    if (bazutils.GetWebConfigSetting("allowLiveEditing")=="false")
                    {
                        LinkButton cmdField = (LinkButton)e.Row.Cells[(int)GridCol.editlink].Controls[0];
                        if (cmdField != null) cmdField.Visible = false;
                    }

                }



                // pending
                if ((expdt >= DateTime.Now && (!approved)) && (recStatus=="new"))
                {
                    e.Row.Cells[(int)GridCol.status].BackColor = System.Drawing.Color.Orange;
                    e.Row.Cells[(int)GridCol.status].Text = "Pending";

                    LinkButton cmdField = (LinkButton)e.Row.Cells[(int)GridCol.editlink].Controls[0];
                    if (cmdField != null) cmdField.Visible = false;

                }


                if (recStatus == "draft")
                {
                    e.Row.Cells[(int)GridCol.status].BackColor = System.Drawing.Color.Silver;
                    e.Row.Cells[(int)GridCol.status].Text = "Draft";
                    e.Row.Cells[(int)GridCol.expirydate].Text = "&nbsp;"; // we dont want to show an expiry date for draft
                   
                }




               
            }

                       
        }




      

    }
}