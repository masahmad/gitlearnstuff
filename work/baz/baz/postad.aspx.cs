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
    public partial class postad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                bool config_category = Convert.ToBoolean(ConfigurationManager.AppSettings["Adconfig_category_visible"]);

                bool config_heading= Convert.ToBoolean(ConfigurationManager.AppSettings["Adconfig_heading_visible"]);

                bool config_qr = Convert.ToBoolean(ConfigurationManager.AppSettings["Adconfig_qr_visible"]);
                bool config_premium = Convert.ToBoolean(ConfigurationManager.AppSettings["Adconfig_premium_visible"]);
                bool config_priority = Convert.ToBoolean(ConfigurationManager.AppSettings["Adconfig_priority_visible"]);

                bool config_boxsize = Convert.ToBoolean(ConfigurationManager.AppSettings["Adconfig_boxsize_visible"]);
                bool config_style = Convert.ToBoolean(ConfigurationManager.AppSettings["Adconfig_style_visible"]);
                bool config_bgcolor = Convert.ToBoolean(ConfigurationManager.AppSettings["Adconfig_bgcolor_visible"]);

                bool config_font = Convert.ToBoolean(ConfigurationManager.AppSettings["Adconfig_font_visible"]);
                bool config_fontsize = Convert.ToBoolean(ConfigurationManager.AppSettings["Adconfig_fontsize_visible"]);

                bool config_adexpiry = Convert.ToBoolean(ConfigurationManager.AppSettings["Adconfig_adexpiry_visible"]);
                bool config_adpublish = Convert.ToBoolean(ConfigurationManager.AppSettings["Adconfig_adpublish_visible"]);



                // make em visible  or not

                categorydiv.Visible = config_category;
                headingdiv.visible = config_heading;

                qrdiv.Visible = config_qr;
                premiumdiv.Visible = config_premium;
                prioritydiv.Visible = config_priority;
                boxsizediv.Visible = config_boxsize;
                stylediv.Visible = config_style;
                bgcolordiv.Visible = config_bgcolor;
                fontdiv.Visible = config_font;
                fontsizediv.Visible = config_fontsize;
                expirydiv.Visible = config_adexpiry;
                publishdiv.Visible = config_adpublish;

            }
        }

        protected void btnSaveAd_Click(object sender, EventArgs e)
        {
            SavePostAd();
        }


        protected void SavePostAd()
        {

            string heading = txtHeading.Text;
            string category = ddlCategory.SelectedValue;
            string priority = ddlPriority.SelectedValue;
            string adText = txtAdText.Text;
           
            string adboxsize = ddlAdBoxSize.SelectedValue;
            string adstyle = txtStyle.Text;
            string bgcolor = ddlBGColor1.SelectedValue;
            string adfont = ddlFont.SelectedValue;
            string adfontsize = txtFontsize.Text;
            string adcontact = txtContact.Text;


            bool adpremium = chkPremium.Checked;
            bool adqr = chkQRcode.Checked;


            DateTime adexpiry = DateTime.Now; // txtExpiry.Text;
            DateTime adpublish = DateTime.Now;





            // assign default values from web.config

            if (!categorydiv.Visible) category= Convert.ToString(ConfigurationManager.AppSettings["Adconfig_category_defaultValue"]); 

           if (!qrdiv.Visible) adqr= Convert.ToBoolean(ConfigurationManager.AppSettings["Adconfig_qr_defaultValue"]);
           if (!premiumdiv.Visible) adpremium = Convert.ToBoolean(ConfigurationManager.AppSettings["Adconfig_premium_defaultValue"]);
           if (!prioritydiv.Visible) priority = Convert.ToString(ConfigurationManager.AppSettings["Adconfig_priority_defaultValue"]);
           if (!boxsizediv.Visible) adboxsize = Convert.ToString(ConfigurationManager.AppSettings["Adconfig_boxSize_defaultValue"]); 
           if (!stylediv.Visible) adstyle = Convert.ToString(ConfigurationManager.AppSettings["Adconfig_style_defaultValue"]);
           if (!bgcolordiv.Visible) bgcolor = Convert.ToString(ConfigurationManager.AppSettings["Adconfig_bgcolor_defaultValue"]);
           if (!fontdiv.Visible) adfont = Convert.ToString(ConfigurationManager.AppSettings["Adconfig_font_defaultValue"]);
           if (!fontsizediv.Visible) adfontsize = Convert.ToString(ConfigurationManager.AppSettings["Adconfig_fontsize_defaultValue"]);
           if (!expirydiv.Visible) adexpiry = Convert.ToDateTime(ConfigurationManager.AppSettings["Adconfig_adexpiry_defaultValue"]);
           if (!publishdiv.Visible) adpublish = Convert.ToDateTime(ConfigurationManager.AppSettings["Adconfig_adpublish_defaultValue"]);

           
            MySqlManagers.MySqlDbManager.SaveContentAd(
                adboxsize, adexpiry, adpublish,
                priority, adstyle,bgcolor, adfont, adfontsize,
                adpremium, category, heading,
                adcontact, 
                adText,adqr);

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