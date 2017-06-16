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
    public partial class signin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               

            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {


            string name = txtRegistrationName.Text;
            string email = txtUserName.Text;
            string p = txtUserPass.Text;

            String guid = Guid.NewGuid().ToString();

            // first check
            if (!MySqlManagers.MySqlDbManager.IsUserAlreadyRegistered(email))
            {
                MySqlManagers.MySqlDbManager.RegisterUser(name, email, p, guid);
                btnRegister.Enabled = false;
                Email.Utils.EmailHelper.SendEmail(email, "register", guid);
            }

            else
            {
                lblLoginErrorStatus.Visible = true;
                lblLoginErrorStatus.Text = "Account already exists!";
            }



        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            bool isValid = false;

            DataTable dt;

            string email = txtLoginUserName.Text.ToLower();
            string p = txtLoginPassword.Text.ToLower();
            dt = MySqlManagers.MySqlDbManager.CheckLoginUser(email, p);


            if (dt.Rows.Count > 0)
            {
                isValid = true;
                Session["userDTobj"] = dt;
            }



            


            if (isValid)
            {
                Session["auth"] = true;
                Session["user"] = email;



               // Session["auth"] = false;

                string adminEmailChk = email.Substring(email.IndexOf('@') + 1);
                if (adminEmailChk=="bazaartv.co.uk")  Session["admin"] = true;
                Response.Redirect("index.aspx");
            }
            else
            {
                lblLoginErrorStatus.Visible = true;
                lblLoginErrorStatus.Text = "user / password  incorrect - try again";

            }

        }

     
      


    }
}