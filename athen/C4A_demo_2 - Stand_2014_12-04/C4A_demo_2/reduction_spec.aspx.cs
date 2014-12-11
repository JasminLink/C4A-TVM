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
            yourticketheadline.Text = Global.wordingtable[15];
            to_label.Text = Global.wordingtable[16];
            ticket_dest.Text = Global.ticket.destination;
            ticket_type.Text = Global.ticket.type;
            choice.Text = Global.wordingtable[27];
            normaltarif.Text = Global.wordingtable[19];
            kindertarif.Text = Global.wordingtable[20];
            red_text.Text = Global.wordingtable[18];
            none_text.Text = Global.wordingtable[22];
            cancelbutton.Text = Global.wordingtable[13];
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
