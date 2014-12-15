using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Drawing;
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
            // hier wird gedruckt
            Printer printer = new Printer();
            Bitmap druckticket = Printer.generateTicket(Global.ticket.type, "", Global.ticket.destination, Global.ticket.price.ToString(), "", Global.ticket.tarif);
            printer.printTicket(druckticket);
        }

        protected void navigate_back_Click(object sender, EventArgs e)
        {

        }
    }
}
