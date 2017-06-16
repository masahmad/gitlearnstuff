using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace baz
{
    public partial class index : System.Web.UI.Page
    {


        void Page_PreInit(Object sender, EventArgs e)
        {
            bool adminFlag= false;
            try {
            adminFlag = Convert.ToBoolean(Session["admin"]);
            }

            catch (Exception exadmin) 
            {
                adminFlag=false;
            }

            if (adminFlag) this.MasterPageFile = "~/admin.master";
        }




        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}