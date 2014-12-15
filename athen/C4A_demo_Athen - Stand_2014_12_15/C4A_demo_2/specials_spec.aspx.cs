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

            if (Global.current_theme.Contains("contrast"))
            {
                display.Attributes["class"] = "stepbystep_C4A_contrast";
                no_plus_button.CssClass = "button_contrast";
                bike_plus_button.CssClass = "button_contrast";
                yourticketheadline.CssClass = "time_contrast";
                choice.CssClass = "time_contrast";
                Uhr.Attributes["class"] = "time_contrast";

                zeiticon.Attributes["class"] = "zeiticon_contrast";


                ccl.CssClass = "button_eng_contrast";
                navigate_ahead.CssClass = "button_eng_contrast";
                navigate_back.CssClass = "button_eng_contrast";

                navigate_back.Attributes["style"] = "position:absolute; left:394px";
                navigate_ahead.Attributes["style"] = "position:absolute; left:558px";

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

            }
            
            
            
            ticket_tarif.Text = Global.ticket.tarif;
            to_label.Text = Global.wordingtable[16];
            ticket_dest.Text = Global.ticket.destination;
            ticket_type.Text = Global.ticket.type;
            no_plus_label.Text = Global.wordingtable[23];
            bike_plus_label.Text = Global.wordingtable[24];
            choice.Text = Global.wordingtable[30];
            add_service_label.Text = Global.wordingtable[21];
            add_service_value.Text = Global.wordingtable[31];

        }



        protected void navigate_ahead_Click(object sender, EventArgs e)
        {

        }

        protected void navigate_back_Click(object sender, EventArgs e)
        {

        }

        protected void no_plus_button_Click(object sender, EventArgs e)
        {
            Global.ticket.special = Global.wordingtable[23];
            Response.Redirect("payment.aspx");
        }

        protected void bike_plus_button_Click(object sender, EventArgs e)
        {
            Global.ticket.special = bike_plus_button.Text;
            Global.ticket.price = Global.ticket.price + 0.25 * Global.ticket.price;
            Response.Redirect("payment.aspx");
        }
    }
}
