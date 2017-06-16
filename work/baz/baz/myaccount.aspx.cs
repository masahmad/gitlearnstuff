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
    public partial class myaccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               

            }
        }

        protected void btnSaveAd_Click(object sender, EventArgs e)
        {
            SavePostAd();
        }


        protected void SavePostAd()
        {

            string name = txtName.Text;
            string pass = txtPassword.Text;


            
           /*
            //MySqlManagers.MySqlDbManager.SaveContentAd(
                adboxsize, adexpiry, adpublish,
                priority, adstyle,bgcolor, adfont, adfontsize,
                adpremium, category, heading,
                adcontact, 
                adText,adqr);
            */
            btnSaveAd.Enabled = false;


          


          

           

        }

      /*  protected void btnGetJson_Click(object sender, EventArgs e)
        {

            ListBox1.DataSource = MySqlManagers.MySqlDbManager.GetcontentadList().Tables[0];
            ListBox1.DataTextField = "expirydate";
            ListBox1.DataBind();

            List<AdObj> AdObjList = new List<AdObj>();
            foreach (DataRow  dr  in MySqlManagers.MySqlDbManager.GetcontentadList().Tables[0].Rows)
            {

                AdObj contentAd = new AdObj();
                contentAd.Adboxsize = dr["adboxsize"].ToString() ;
                contentAd.Category = dr["category"].ToString();
                contentAd.Contact = dr["contact"].ToString();
                contentAd.Cssstyle = dr["cssstyle"].ToString();
                contentAd.Expirydate = Convert.ToDateTime(dr["expirydate"]);
                contentAd.Bgcolor = dr["bgcolor"].ToString();
                contentAd.Font = dr["font"].ToString();
                contentAd.Fontsize = Convert.ToInt32(dr["fontsize"]);
                contentAd.Heading = dr["Heading"].ToString();
                contentAd.Htmltext = dr["htmltext"].ToString();
                contentAd.IdcontentAd = Convert.ToInt32(dr["idContentAd"]);
                contentAd.Premium = dr["premium"].ToString();
                contentAd.Priorty = dr["premium"].ToString();
                contentAd.Publishdate = Convert.ToDateTime(dr["publishdate"]);
                contentAd.Systemid = Convert.ToInt32(dr["systemid"]);
                contentAd.Templateid = Convert.ToInt32(dr["templateid"]);

                AdObjList.Add(contentAd);

            }

            string json = JSONHelper.ToJSON(AdObjList);
            txtAdText.Text = json;

        }

       * */



    }
}