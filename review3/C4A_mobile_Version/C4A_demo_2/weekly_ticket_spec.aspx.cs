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
    public partial class weekly_ticket_spec : System.Web.UI.Page
    {

        static string prevPage = String.Empty;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) //check if the webpage is loaded for the first time.
            {
                ViewState["PreviousPage"] =
                Request.UrlReferrer;//Saves the Previous page url in ViewState
            }
        }

        protected void timeout_ticker_Tick(object sender, EventArgs e)
        {
            Global.current_language = "de";
            Global.current_theme = "normal";
            Global.set_timeout("normal");
            
            Server.Transfer("Default.aspx");
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
    }
}
