using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using PlayV.obj;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using PlayV.baz.utils;



namespace PlayV
{
    public partial class managead : System.Web.UI.Page
    {

       public  bool isUpdate = false;
       public string idcontentQS = "";
        


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!bazutils.isUserAuthenticated())
            {
                Response.Redirect("signin.aspx");
            }



            if (!IsPostBack)

            {


                // populate 
                PopulateSystem();

                bool config_category = Convert.ToBoolean(ConfigurationManager.AppSettings["Adconfig_category_visible"]);
                bool config_heading = Convert.ToBoolean(ConfigurationManager.AppSettings["Adconfig_heading_visible"]);
                bool config_contact = Convert.ToBoolean(ConfigurationManager.AppSettings["Adconfig_contact_visible"]);
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
                headingdiv.Visible = config_heading;
                contactdiv.Visible = config_contact;
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



                // edit mode
                if (Request.QueryString["contentId"] != "" && Request.QueryString["contentId"] != null)
                {
                    idcontentQS = Request.QueryString["contentId"];
                    isUpdate = true;
                    lblUpdateMode.Text = "Update ref:";
                    lblUpdateReferenceId.Text = idcontentQS;
                    PopulateForm(idcontentQS);
                   
                    

                    //
                    if (lblUpdateDraft.Text!="draft")
                    { 
                    
                    ddlSystemsList.Enabled = false;
                    ddlAdLength.Enabled = false;
                    expirydiv.Visible = true;
                    txtExpiry.Enabled = false;
                    adlengthDiv.Visible = false;
                    ddlAdBoxSize.Enabled = false;

                    // dont want user to save a live / publised ad back to draft and therefore modify expiry etc.
                    btnSaveDraft.Enabled = false;

                    }


                }
                               

            }
        }

        protected void btnSaveAd_Click(object sender, EventArgs e)
        {
            SavePostAd(false);
        }


        protected void SavePostAd(bool draft)
        {

            string recordStatus = "";
            string heading = txtHeading.Text;
            string category = ddlCategory.SelectedValue;
            string priority = ddlPriority.SelectedValue;
          
            string adText = hidInnerHtml.Value;
           
            string adboxsize = ddlAdBoxSize.SelectedValue;
            string adstyle = txtStyle.Text;
            string bgcolor = ddlBGColor1.SelectedValue;
            string adfont = ddlFont.SelectedValue;
            string adfontsize = txtFontsize.Text;
            string adcontact = txtContact.Text;


            bool adpremium = chkPremium.Checked;
            bool adqr = chkQRcode.Checked;

            int approved = 0;
                       

            // if in draft mode we dont want to set any dates yet!
            DateTime adexpiry = DateTime.Now;


            double numofdays = 0;
            numofdays = Convert.ToDouble(ddlAdLength.SelectedValue);


            // if submitting live
            if (!draft)
            {


                //auto approved
                if (bazutils.GetWebConfigSetting("autoAdminApprove") == "true") approved = 1;


                // if its a new record
                //numofdays = Convert.ToDouble(ddlAdLength.SelectedValue);
               
                if (numofdays > 0) adexpiry = DateTime.Now.AddDays(numofdays);

                //test hour select
                if (numofdays <= 0) adexpiry = DateTime.Now.AddMinutes(60);


                // however if its being updated...
                // db insert needs previous vlaue
               
               // if lblUpdateMode
                if (lblUpdateDraft.Text!="draft")
                { 
                 if (txtExpiry.Text != "")
                {
                    adexpiry = Convert.ToDateTime(txtExpiry.Text);
                }
            }

            }

            
             


            DateTime adpublish = DateTime.Now;
            string btvsystem = ddlSystemsList.SelectedValue;


            if (draft) recordStatus = "draft"; else recordStatus = "new";


            // assign default values from web.config

            if (!categorydiv.Visible) category = Convert.ToString(ConfigurationManager.AppSettings["Adconfig_category_defaultValue"]);
            if (!contactdiv.Visible) adcontact= Convert.ToString(ConfigurationManager.AppSettings["Adconfig_contact_defaultValue"]);
            //if (!headingdiv.Visible) heading = Convert.ToString(ConfigurationManager.AppSettings["Adconfig_heading_defaultValue"]); 
            
            if (!qrdiv.Visible) adqr= Convert.ToBoolean(ConfigurationManager.AppSettings["Adconfig_qr_defaultValue"]);
           if (!premiumdiv.Visible) adpremium = Convert.ToBoolean(ConfigurationManager.AppSettings["Adconfig_premium_defaultValue"]);
           if (!prioritydiv.Visible) priority = Convert.ToString(ConfigurationManager.AppSettings["Adconfig_priority_defaultValue"]);
           if (!boxsizediv.Visible) adboxsize = Convert.ToString(ConfigurationManager.AppSettings["Adconfig_boxSize_defaultValue"]); 
           if (!stylediv.Visible) adstyle = Convert.ToString(ConfigurationManager.AppSettings["Adconfig_style_defaultValue"]);
           if (!bgcolordiv.Visible) bgcolor = Convert.ToString(ConfigurationManager.AppSettings["Adconfig_bgcolor_defaultValue"]);
           if (!fontdiv.Visible) adfont = Convert.ToString(ConfigurationManager.AppSettings["Adconfig_font_defaultValue"]);
           if (!fontsizediv.Visible) adfontsize = Convert.ToString(ConfigurationManager.AppSettings["Adconfig_fontsize_defaultValue"]);
           //if (!expirydiv.Visible) adexpiry = Convert.ToDateTime(ConfigurationManager.AppSettings["Adconfig_adexpiry_defaultValue"]);
           if (!publishdiv.Visible) adpublish = Convert.ToDateTime(ConfigurationManager.AppSettings["Adconfig_adpublish_defaultValue"]);

            
           heading = HidHeading.Value;
           if (heading == "" || heading==" ") heading = "draft note";

           string strSupercedeId = lblUpdateReferenceId.Text;
           if (strSupercedeId == "") strSupercedeId = "-1";

            // add new record
            MySqlManagers.MySqlDbManager.SaveContentAd(
                adboxsize, adexpiry, numofdays.ToString(),  adpublish,
                priority, adstyle,bgcolor, adfont, adfontsize,
                adpremium, category, heading,
                adcontact, 
                adText,adqr,btvsystem,recordStatus,approved,strSupercedeId);


            if (lblUpdateMode.Text=="Update ref:") { 
            // mark existing id as status deleted
                MySqlManagers.MySqlDbManager.MarkContentRecordasDeleted(lblUpdateReferenceId.Text);
            // send commandq to remove from btv

            }



            btnSaveAd.Enabled = false;

            Response.Redirect("listsad.aspx");

        }



        protected void PopulateForm(string idcontentAdfromQS)
        {
            isUpdate = true;
     string userId = bazutils.GetUserSessionVal("idbtvusers");
     MySqlDataReader msqdr =   MySqlManagers.MySqlDbManager.GetContentAdRecord(idcontentAdfromQS, userId);

            while (msqdr.Read()) 
            {

               // txtAdText.Text = msqdr["htmltext"].ToString();
                myArea1.InnerHtml = msqdr["htmltext"].ToString();
                txtHeading.Text = msqdr["heading"].ToString();
                txtExpiry.Text = msqdr["expirydate"].ToString();

                

                try
                {
                    ddlSystemsList.SelectedValue = msqdr["systemid"].ToString();
                }


                catch (Exception eee)
                {
                    ddlSystemsList.SelectedIndex = 0;
                }


                int adlendays = 0;

                try
                {
                    adlendays = Convert.ToInt32(msqdr["expirylength"]);
                    ddlAdLength.SelectedValue = adlendays.ToString();
                }


                catch (Exception ex)
                {
                   ddlAdLength.SelectedIndex = 0;
                }





                ddlAdBoxSize.SelectedValue = msqdr["adboxsize"].ToString();
                string recstatus =  msqdr["recordStatus"].ToString();
                  lblUpdateDraft.Text = recstatus;

            }

            msqdr.Close();

        }



        

        protected void PopulateSystem()
        {

            ddlSystemsList.DataSource = MySqlManagers.MySqlDbManager.GetAllSystems();
            ddlSystemsList.DataTextField = "name";
            ddlSystemsList.DataValueField = "systemid";
            ddlSystemsList.DataBind();
            ddlSystemsList.Items.Insert(0, new ListItem("select system", "-1"));
            
            // add attributes dynamically per system for costings
            AddDataAttributetoSystemListItems();

        }

        protected void btnSaveDraft_Click(object sender, EventArgs e)
        {
            SavePostAd(true);
        }



        

        // we store data cost for system in html5 data attributes
        protected void AddDataAttributetoSystemListItems() 
        
        {
           DataTable dt = MySqlManagers.MySqlDbManager.GetAdboxCost();
           DataView dv = new DataView(dt);
                      
            foreach (ListItem item in ddlSystemsList.Items)
            {
                dv.RowFilter = "systemid=" + item.Value;
               
                foreach (DataRowView rowView in dv)
                {
                     DataRow row = rowView.Row;
                     item.Attributes.Add("data-" + row["adsize"].ToString(), row["cost"].ToString());
                }
               
                
            }

            
            
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