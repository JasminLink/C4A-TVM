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
    public partial class goodbye : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            applyLanguage(Global.current_language);
            serverside_apply_style(Global.current_theme);
            // applyFontFace_clientside(Global.current_fontface);
            applyFontFace(Global.current_fontface);
            applyFontFace_clientside(Global.current_fontface);
            
            

        }



        public void applyFontFace(String family)
        {


            goodbyemessage.Attributes["style"] = "font-family: " + family;
            goodbyemessage2.Attributes["style"] = "font-family: " + family;

        }

        public void applyFontFace_clientside(String family)
        {
            String arg = "myFunction('" + family + "');";
            ScriptManager.RegisterStartupScript(this, GetType(), "myFunction", arg, true);
        }

        public void serverside_apply_style(String theme)
        {

            if (theme.Contains("normal"))
            {
                display.CssClass = "startseite_C4A";
                goodbyemessage.CssClass = "area_header";
                goodbyemessage2.CssClass = "area_header";
            }



            else if (theme.Contains("contrast"))
            {
                display.CssClass = "startseite_C4A_contrast";
                goodbyemessage.CssClass = "area_header_contrast";
                goodbyemessage2.CssClass = "area_header_contrast";
            }



        }

        public void applyLanguage(String lang)
        {
            Global.fillWordingTable(lang);

            goodbyemessage.Text = Global.wordingtable[41];
            goodbyemessage2.Text = Global.wordingtable[42];
      
        }



        protected void timeout_ticker_Tick(object sender, EventArgs e)
        {
            Global.current_language = "de";
            Global.current_fontface = "Calibri";
            Global.current_theme = "normal";
            Global.set_timeout("normal");

            Server.Transfer("Default.aspx");
        }
    }
}
