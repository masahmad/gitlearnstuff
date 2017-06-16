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
    public partial class confirmemail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string em = Request.QueryString["email"];
                string gcheck = Request.QueryString["g"];

             int result =    MySqlManagers.MySqlDbManager.CheckEmailGuid(em, gcheck);
             if (result > 0)
             {
                 lblConfirmEmailCheck.Text = "Congratulations - your account is now active";

                 Session["auth"] = true;
                 //Response.Redirect("index.aspx");

             }
             else
                 lblConfirmEmailCheck.Text = "Check failure - Email address not found";
                

            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {


           
            /*
            String guid = Guid.NewGuid().ToString();
            MySqlManagers.MySqlDbManager.RegisterUser(name, email,p,guid);
            btnRegister.Enabled = false;
            Email.Utils.EmailHelper.SendEmail(email, "register", guid);
             * 
             * */


        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {


            /*
            bool isValid = false;
            string email = txtLoginUserName.Text;
            string p = txtLoginPassword.Text;
            isValid =  MySqlManagers.MySqlDbManager.CheckLoginUser(email, p);

            if (isValid)
            {
                Session["auth"] = true;
                Response.Redirect("index.aspx");
            }
            else
            {
                lblLoginErrorStatus.Visible = true;
                lblLoginErrorStatus.Text = "user / password  incorrect - try again";

            }

               * */

        }
            
          

     
      



    }
}