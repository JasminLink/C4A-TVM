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
            choice.Text = Global.wordingtable[32];
            ttheader.Text = Global.wordingtable[33];
            tt_description_1.Text = "Entdecken Sie München und begeben Sie sich auf die Reise durch die bayerische Landeshauptstadt. Lassen Sie sich verzaubern und geniessen Sie alles mögliche. Langweilen Sie sich, besaufen Sie sich, machen Sie doch, was Sie wollen: München wird Sie verzaubern";
            tt_description_2.Text = "";
            // tt_adult_label.Text = Global.wordingtable[34];
            // tt_child_label.Text = Global.wordingtable[35];
            
        }

        protected void navigate_ahead_Click(object sender, EventArgs e)
        {

        }

        

        // protected void tt_adult_Click(object sender, EventArgs e)
        // {
        //     Response.Redirect("payment.aspx");
        // }

        protected void single_button_Click()
        {
        
        }

 



    }
}
