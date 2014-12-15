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
    public partial class reduction_spec : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Global.current_theme.Contains("contrast"))
            {
                display.Attributes["class"] = "stepbystep_C4A_contrast";
                normaltarif_button.CssClass = "button_contrast";
                kindertarif_button.CssClass = "button_contrast";
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
                normaltarif_button.CssClass = "button_normal";
                kindertarif_button.CssClass = "button_normal";


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
            
            
            
            yourticketheadline.Text = Global.wordingtable[15];
            to_label.Text = Global.wordingtable[16];
            ticket_dest.Text = Global.ticket.destination;
            ticket_type.Text = Global.ticket.type;
            choice.Text = Global.wordingtable[27];
            normaltarif.Text = Global.wordingtable[19];
            kindertarif.Text = Global.wordingtable[20];
            red_text.Text = Global.wordingtable[18];
            none_text.Text = Global.wordingtable[22];
            cancel_label.Text = Global.wordingtable[13];
        }

        protected void navigate_ahead_Click(object sender, EventArgs e)
        {

        }

        protected void navigate_back_Click(object sender, EventArgs e)
        {

        }


        protected void normaltarif_button_Click(object sender, EventArgs e)
        {
            Global.ticket.tarif = normaltarif.Text;
            Response.Redirect("specials_spec.aspx");
        }

        protected void kindertarif_button_Click(object sender, EventArgs e)
        {
            Global.ticket.tarif = kindertarif.Text;
            Global.ticket.price = 0.5 * Global.ticket.price;
            
            Response.Redirect("specials_spec.aspx");
        }
    }
}
