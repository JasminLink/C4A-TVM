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
