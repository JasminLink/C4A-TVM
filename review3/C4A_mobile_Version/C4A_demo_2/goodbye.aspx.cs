using Demo_GPII_Adapter;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace C4A_demo_2
{
    public partial class goodbye : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


           /*
             // Test parameters
            String ticketType = "Einzelkarte";
            String special = "";
            String destination = "Flughafen";
            String price = "3,60 €";
            String person = "keine Ermäßigung";
            */


            String ticketType = Global.ticket.type;
            String special = Global.ticket.special;
            String destination = Global.ticket.destination;
            String price = Global.ticket.price.ToString() +"0 €";
            String person = Global.ticket.tarif;

            if (Global.printed == false)
            {
                TVM.printTicket(ticketType, special, destination, price, person);
                Global.printed = true; 
            }
            
            

            goodbyemessage.Text = Global.wordingtable[41];
            goodbyemessage2.Text = Global.wordingtable[42];
            timeout_ticker.Interval = 5000;

            if (Global.current_theme.Contains("contrast"))
            {
                display.Attributes["class"] = "startseite_C4A_contrast";
                goodbyemessage.CssClass = "area_header_contrast";
                goodbyemessage2.CssClass = "area_header_contrast";
                Uhr.Attributes["class"] = "time_contrast";

            }

            if (Global.current_theme.Contains("normal"))
            {
                display.Attributes["class"] = "startseite_C4A";
                Uhr.Attributes["class"] = "time";
                goodbyemessage.CssClass = "area_header";
                goodbyemessage2.CssClass = "area_header";
               
                

            }



            // add_service_value.Text = Global.ticket.special;


            applyFontFace(Global.current_fontface);
        }



         protected void navigate_back_Click(object sender, EventArgs e)
        {
            if (ViewState["PreviousPage"] != null)	//Check if the ViewState 
            //contains Previous page URL
            {
                Response.Redirect(ViewState["PreviousPage"].ToString());//Redirect to 
                //Previous page by retrieving the PreviousPage Url from ViewState.
            }
        }


        protected void timeout_ticker_Tick(object sender, EventArgs e)
        {
            Global.current_language = "de";
            Global.current_fontface = "Calibri";
            Global.current_theme = "normal";
            Global.set_timeout("normal");

            Server.Transfer("Default.aspx");
        }

        protected void ccl_Click(object sender, EventArgs e)
        {
            Global.ticket.reset();
            Response.Redirect("Default.aspx");
        }


        public void applyFontFace(String family)
        {




            Uhr.Attributes["style"] = "font-family: " + family;

            
            goodbyemessage.Attributes["style"] = "font-family: " + family;
            goodbyemessage2.Attributes["style"] = "font-family: " + family;


        }
    }
}
