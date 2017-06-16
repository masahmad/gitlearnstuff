using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace PlayV.baz.utils
{
    public class bazutils
    {




        public bazutils() { }




        public static bool  isUserAuthenticated() 
        {
            bool isAuth = false;
            try
            {
                if ((bool)HttpContext.Current.Session["auth"] == true)
                {
                    isAuth = true;
                }
         
                else
                {
                    isAuth = false;
                }
            }


            catch (NullReferenceException n)
            {
                isAuth = false;
            }

            return isAuth;
        }



        public static string GetUserSessionVal(string key)
        {

            System.Data.DataTable dt = (System.Data.DataTable)HttpContext.Current.Session["userDTobj"];

            string rtnVal = dt.Rows[0][key].ToString();

            return rtnVal;              


        }


        public static string GetWebConfigSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];

        }





    }
}