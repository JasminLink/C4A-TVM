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
    public partial class tourist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack) //check if the webpage is loaded for the first time.
            {
                ViewState["PreviousPage"] =
                Request.UrlReferrer;//Saves the Previous page url in ViewState
            }
            
            timeout_ticker.Interval = Global.timeout;
            
            choice.Text = Global.wordingtable[32];
            ttheader.Text = Global.wordingtable[33];
            cancel_label.Text = Global.wordingtable[13];
            tt_description_1.Text = Global.wordingtable[36]; 
            // "Entdecken Sie München und begeben Sie sich auf die Reise durch die bayerische Landeshauptstadt. Lassen Sie sich verzaubern und geniessen Sie die Parks, Museen, Biergärten und das Nachtleben - und nutzen Sie dazu soviele MVG-Busse und Bahnen, wie Sie möchten. Volle drei Tage ab Kauf des Tickets! Zusätzlich liegt ein Stadtplan im MVG-Kundenzentrum für Sie bereit!";
            tt_description_2.Text = "";
            
            tt_adult_button.Text = Global.wordingtable[34];
            tt_children_button.Text = Global.wordingtable[35];
            




            if (Global.current_theme.Contains("contrast"))
            {
                display.Attributes["class"] = "touristbg_C4A_contrast";
                ccl.CssClass = "button_180_contrast";
                choice.CssClass = "area_header_contrast";
                tt_description_1.CssClass = "fliesstext_contrast";
                
                ttheader.CssClass = "area_header_contrast";
                tt_adult_button.CssClass = "button_contrast_small";
                tt_children_button.CssClass = "button_contrast_small";
            }

            if (Global.current_theme.Contains("normal"))
            {
                display.Attributes["class"] = "touristbg_C4A";
                ccl.CssClass = "button_eng_normal";
                choice.CssClass = "area_header";
                ttheader.CssClass = "area_header";
                tt_description_1.CssClass = "fliesstext";
                                
                tt_adult_button.CssClass = "button_normal";
                tt_children_button.CssClass = "button_normal";
            }





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

        

        // protected void tt_adult_Click(object sender, EventArgs e)
        // {
        //     Response.Redirect("payment.aspx");
        // }

        protected void tt_children_Click()
        {
         Global.ticket.destination = "Tourist Ticket";
         Global.ticket.type = Global.wordingtable[20];
         Global.ticket.special = "Enjoy Munich!";
         Global.ticket.price = 1 + 4 * Global.ticket.basefare;
         Response.Redirect("payment.aspx");
        }

        protected void tt_adult_Click(object sender, EventArgs e)
        {
            Global.ticket.destination = "Tourist Ticket";
            Global.ticket.type = Global.wordingtable[19];
            Global.ticket.special = "Enjoy Munich!";
            Global.ticket.price = 1.7 + 6 * Global.ticket.basefare;
            Response.Redirect("payment.aspx");
        }

        protected void tt_adult_button_Click(object sender, EventArgs e)
        {
            Global.ticket.destination = "Tourist Ticket";
            Global.ticket.type = Global.wordingtable[19];
            Global.ticket.special = "Enjoy Munich!";
            Global.ticket.price = 1.7 + 6 * Global.ticket.basefare;
            Response.Redirect("payment.aspx");

        }

        protected void tt_children_button_Click(object sender, EventArgs e)
        {
            Global.ticket.destination = "Tourist Ticket";
            Global.ticket.type = Global.wordingtable[20];
            Global.ticket.special = "Enjoy Munich!";
            Global.ticket.price = 1 + 4 * Global.ticket.basefare;
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
            cancel_label.Attributes["style"] = "font-family: " + family;
            tt_adult_button.Attributes["style"] = "position:absolute;  bottom:178px; left:668px; font-family: " + family;
            tt_children_button.Attributes["style"] = "position:absolute;  bottom:118px; left:668px; font-family: " + family;
            tt_description_1.Attributes["style"] = "font-family: " + family;
            ttheader.Attributes["style"] = "font-family: " + family;



        }

    }
}
