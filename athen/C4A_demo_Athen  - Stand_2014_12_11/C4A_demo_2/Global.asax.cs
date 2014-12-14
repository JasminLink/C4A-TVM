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

        protected void Application_Start(object sender, EventArgs e)
        {
            ticket.destination = "Lichtwiese";
            fillWordingTable("current_language");
            resetTimeout(3000); // ms

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


        public void printTicket(CTicket ticket)
        {
            // tu's wirklich, ist schon in Class Printer drin
        }

        public void resetTimeout(int t)
        {
            Timer timeoutTimer = new System.Timers.Timer();
            timeoutTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timeoutTimer.Interval = t;
            timeoutTimer.Start();
        }

        public void resetTVM()
        {
            // Server.Transfer("~/WebForm1.aspx");
            // tvm.Server.Transfer("~/WebForm1.aspx");
            // Response.Write("<script type='text/javascript'>window.open('/WebForm1.aspx', 'Default1');</script>");
            
        }

             public void OnTimedEvent(object source, ElapsedEventArgs e) //Timer für Timeout
        {
            Console.Write("+++");
            try
            {
                // Response.Write("<h2>Global Page Error</h2>\n");
                // Server.Transfer("/WebForm1.aspx");

                Console.Write("...");

                // Console.WriteLine("-->" + HttpContext.Current.Request.Url.ToString());
                // Server.Transfer("WebForm1.aspx");

                // Response.Write("<script type='text/javascript'>window.open('/WebForm1.aspx', 'Default1');</script>");
                // Server.TransferRequest("/WebForm1.aspx");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.Write("---");
            }
        }

        public static String[] wordingtable = new String[99];

        public static String fillWordingTable(String lang)
        {
            XmlTextReader reader = new XmlTextReader("C:/GPII_GitHub/C4A-TVM/athen/C4A_demo_Athen  - Stand_2014_12_11/C4A_demo_2/WORDING.xml");
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