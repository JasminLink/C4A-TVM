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
    public partial class specials_spec : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack) //check if the webpage is loaded for the first time.
            {
                ViewState["PreviousPage"] =
                Request.UrlReferrer;//Saves the Previous page url in ViewState
            }


            timeout_ticker.Interval = Global.timeout;

            if (Global.current_theme.Contains("contrast"))
            {
                display.Attributes["class"] = "stepbystep_C4A_contrast";
                no_plus_button.CssClass = "button_contrast";
                bike_plus_button.CssClass = "button_contrast";
                yourticketheadline.CssClass = "time_contrast";
                choice.CssClass = "time_contrast";
                Uhr.Attributes["class"] = "time_contrast";
                ccl.CssClass = "button_180_contrast";
                zeiticon.Attributes["class"] = "zeiticon_contrast";

                navigate_ahead.CssClass = "button_eng_contrast";
                navigate_back.CssClass = "button_eng_contrast";

                navigate_back.Attributes["style"] = "position:absolute; left:394px";
                navigate_ahead.Attributes["style"] = "position:absolute; left:558px";

                if (Global.ticket.special.Length > 5)
                {
                    ahead_label.Attributes["style"] = "color: #f4fc00";
                }
                else
                {
                    ahead_label.Attributes["style"] = "color: #97995C";
                }

            }

            if (Global.current_theme.Contains("normal"))
            {
                display.Attributes["class"] = "stepbystep_C4A";
                no_plus_button.CssClass = "button_normal";
                bike_plus_button.CssClass = "button_normal";

                
                yourticketheadline.CssClass = "time";
                choice.CssClass = "time";
                Uhr.Attributes["class"] = "time";

                zeiticon.Attributes["class"] = "zeiticon";


                ccl.CssClass = "button_eng_normal";
                navigate_ahead.CssClass = "button_eng_normal";
                navigate_back.CssClass = "button_eng_normal";

                navigate_back.Attributes["style"] = "position:absolute; left:404px";
                navigate_ahead.Attributes["style"] = "position:absolute; left:548px";

                if (Global.ticket.special.Length > 5)
                {
                    ahead_label.Attributes["style"] = "color: #000000";
                }
                else
                {
                    ahead_label.Attributes["style"] = "color: #A3A3A3";
                }

            }


            ahead_label.Text = Global.wordingtable[37];
            back_label.Text = Global.wordingtable[38];
            ticket_tarif.Text = Global.ticket.tarif;
            to_label.Text = Global.wordingtable[16];
            ticket_dest.Text = Global.ticket.destination;
            ticket_type.Text = Global.ticket.type;
            no_plus_label.Text = Global.wordingtable[23];
            bike_plus_label.Text = Global.wordingtable[24];
            choice.Text = Global.wordingtable[30];
            add_service_label.Text = Global.wordingtable[21];
            add_service_value.Text = Global.wordingtable[31];
            cancel_label.Text = Global.wordingtable[13];

            applyFontFace(Global.current_fontface);
        }



        protected void navigate_ahead_Click(object sender, EventArgs e)
        {
            
            {
                Response.Redirect("payment.aspx");
            }

        }

        protected void navigate_back_Click(object sender, EventArgs e)
        {
            if (ViewState["PreviousPage"] != null)	//Check if the ViewState 
            //contains Previous page URL
            {
                Response.Redirect("reduction_spec.aspx");
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

        protected void no_plus_button_Click(object sender, EventArgs e)
        {
            Global.ticket.special = Global.wordingtable[23];
            Response.Redirect("payment.aspx");
        }

        protected void bike_plus_button_Click(object sender, EventArgs e)
        {
            Global.ticket.special = Global.wordingtable[24];
            Global.ticket.price = Global.ticket.price + 0.25 * Global.ticket.price;
            Response.Redirect("payment.aspx");
        }

        protected void ccl_Click(object sender, EventArgs e)
        {
            Global.ticket.reset();
            Response.Redirect("Default.aspx");
        }


        public void applyFontFace(String family)
        {


            choice.Attributes["style"] = "font-family: " + family;
            ahead_label.Attributes["style"] = "font-family: " + family;
            back_label.Attributes["style"] = "font-family: " + family;
            cancel_label.Attributes["style"] = "font-family: " + family;
            no_plus_label.Attributes["style"] = "font-family: " + family;
            bike_plus_label.Attributes["style"] = "font-family: " + family;
            

            Uhr.Attributes["style"] = "font-family: " + family;


 
            // single_ticket.Attributes["style"] = "font-family: " + family;
            // ticket_dest.Attributes["style"] = "font-family: " + family;
            // ticket_mode.Attributes["style"] = "font-family: " + family;
            // to_label.Attributes["style"] = "font-family: " + family;
            // total_price.Attributes["style"] = "font-family: " + family;
            // yourticketheadline.Attributes["style"] = "font-family: " + family;



        }
    }
}
