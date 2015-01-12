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

                ccl.CssClass = "button_eng_contrast";
                navigate_ahead.CssClass = "button_eng_contrast";
                navigate_back.CssClass = "button_eng_contrast";

                navigate_back.Attributes["style"] = "position:absolute; left:394px";
                navigate_ahead.Attributes["style"] = "position:absolute; left:558px";

            }

            if (Global.current_theme.Contains("normal"))
            {
                display.Attributes["class"] = "payment_C4A";


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
            
            cancel_label.Text = Global.wordingtable[13];
            ticket_tarif.Text = Global.ticket.tarif;
            to_label.Text = Global.wordingtable[16];
            ticket_dest.Text = Global.ticket.destination;
            ticket_type.Text = Global.ticket.type;
            price.Text = Global.ticket.price.ToString("c");
            choice.Text = Global.wordingtable[25];
            total_price_label.Text = Global.wordingtable[17] + ":";
            add_service_value.Text = Global.ticket.special;

        }

        protected void navigate_ahead_Click(object sender, EventArgs e)
        {

        }

        protected void navigate_back_Click(object sender, EventArgs e)
        {

        }


        protected void timeout_ticker_Tick(object sender, EventArgs e)
        {
            Global.current_language = "de";
            Global.current_theme = "normal";
            Global.set_timeout("normal");

            Server.Transfer("Default.aspx");
        }
    }
}
