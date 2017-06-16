using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PlayV.baz.utils;

namespace PlayV
{
    public partial class adminMaster: System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string so = "0";
            so = Request.QueryString["so"];

            if (so == "1")
            {
                Session["auth"] = false;
                Session["admin"] = false;
                Session["userDTobj"] = null;

            }

            
            
            
                if (bazutils.isUserAuthenticated())
                {
                    HyperLinkSignin.Text = "Sign out";
                    HyperLinkSignin.NavigateUrl = "signin.aspx?so=1";

                    HyperLinkWelcome.Visible = true;

                    try
                    {
                        HyperLinkWelcome.Text = Session["user"].ToString();
                    }

                    catch (Exception ex)
                    {

                        HyperLinkWelcome.Text = "?";

                    }


                    manageddl.Visible = true;
                    manageddlParnt.Visible = true;
                   

                  
                }





                if (!bazutils.isUserAuthenticated())
                {
                    HyperLinkSignin.Text = "Sign in";
                    HyperLinkSignin.NavigateUrl = "signin.aspx?so=0";


                    HyperLinkWelcome.Visible = false;
                    HyperLinkWelcome.Text = "Welcome";

                    manageddl.Visible = false;
                    manageddlParnt.Visible = false;
                   
                }



            }

          

        





        protected void lnkSignIn_Click(object sender, EventArgs e)
        {
                       

        }
    }
}