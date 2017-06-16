using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace PlayV
{
    public partial class previewad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string id = Request.QueryString["id"];

            MySqlDataReader msqdr = MySqlManagers.MySqlDbManager.GetPreviewAd(id);


            while (msqdr.Read())
           {
               previewBox.InnerHtml = msqdr["htmltext"].ToString();
                string adboxsize = msqdr["adboxsize"].ToString();
                previewBox.Attributes.Add("class","adboxBase adbox" + adboxsize);
           }

         

        }
    }
}