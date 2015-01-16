using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml.Linq;
using System.Xml;
using System.Text;
using System.Timers;

namespace C4A_demo_2
{
    public class Global : System.Web.HttpApplication
    {

        public static CTicket ticket = new CTicket();

        public static String current_language = "de";       // default language
        public static String current_theme = "normal";      // default theme
        
        public static int timeout = 1500;

        protected void Application_Start(object sender, EventArgs e)
        {
            ticket.destination = "Lichtwiese";
            fillWordingTable("current_language");
            set_timeout("normal");

        }

        public static System.Web.UI.Page tvm;

        public void OnNFC(String code)
        {
            askGPII();
            // tu was mit dem UI!
        }


        public void OnBarCode(String code)
        {
            // frag GPII nach code
            // tu was mit dem UI!
        }

        public void askGPII()
        {

        }


        public static void set_timeout(String timeout_constant)
        {
                       
            if (timeout_constant.ToLower().Contains("normal")) timeout = 30000;
            if (timeout_constant.ToLower().Contains("long")) timeout = 60000;
            
        }

        public static void set_timeout(int milliseconds)
        {
            timeout = milliseconds;
        }


        public void printTicket(CTicket ticket)
        {
            // tu's wirklich, ist schon in Class Printer drin
        }



            
        public static String[] wordingtable = new String[99];

        public static String fillWordingTable(String lang)
        {
            XmlTextReader reader = new XmlTextReader("C:/C4A-TVM-WORDING/WORDING.xml");
            StringBuilder sb = new StringBuilder();
            int k = 0;
            wordingtable[k] = lang;

           

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // The node is an element.

                        if (reader.Name.Contains(lang))
                        {
                            reader.Read();
                            k++;
                            wordingtable[k] = reader.Value;
                            // sb.Append(reader.Value);

                        }
                        break;
                }





            }

            reader.Close();
            return (sb.ToString());
        }



        protected void Session_Start(object sender, EventArgs e)
        {
            
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
           
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}