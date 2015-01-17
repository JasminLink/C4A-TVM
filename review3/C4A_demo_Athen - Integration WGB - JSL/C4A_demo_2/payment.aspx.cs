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
    public partial class payment : System.Web.UI.Page
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
                display.Attributes["class"] = "payment_C4A_contrast";

                yourticketheadline.CssClass = "time_contrast";
                choice.CssClass = "time_contrast";
                Uhr.Attributes["class"] = "time_contrast";

                zeiticon.Attributes["class"] = "zeiticon_contrast";
                amount.Attributes["style"] = "color:Yellow; text-align:right; font-size:40px; padding-top:20px;";
                amount_label.Attributes["style"] = "color:Yellow; text-align:right; ";

                ccl.CssClass = "button_180_contrast";
                
                navigate_back.CssClass = "button_eng_contrast";

                navigate_back.Attributes["style"] = "position:absolute; left:394px";
                

            }

            if (Global.current_theme.Contains("normal"))
            {
                display.Attributes["class"] = "payment_C4A";


                yourticketheadline.CssClass = "time";
                choice.CssClass = "time";
                Uhr.Attributes["class"] = "time";

                zeiticon.Attributes["class"] = "zeiticon";


                ccl.CssClass = "button_eng_normal";
                
                navigate_back.CssClass = "button_eng_normal";

                navigate_back.Attributes["style"] = "position:absolute; left:404px";
                

            }
            
            cancel_label.Text = Global.wordingtable[13];
            ticket_tarif.Text = Global.ticket.tarif;
            to_label.Text = Global.wordingtable[16];
            ticket_dest.Text = Global.ticket.destination;
            ticket_type.Text = Global.ticket.type;
            add_service_value.Text = Global.ticket.special.ToString();
            price.Text = Math.Round(Global.ticket.price, 1).ToString("c");
            choice.Text = Global.wordingtable[25];
            total_price_label.Text = Global.wordingtable[17] + ":";
            
            back_label.Text = Global.wordingtable[38];
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


         protected void navigate_ahead_Click(object sender, EventArgs e)
         {
             
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


            choice.Attributes["style"] = "font-family: " + family;
 
            back_label.Attributes["style"] = "font-family: " + family;
            cancel_label.Attributes["style"] = "font-family: " + family;

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
