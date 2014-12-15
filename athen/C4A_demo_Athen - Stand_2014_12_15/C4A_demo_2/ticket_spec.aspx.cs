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
using System.Text;
using System.Drawing.Text;

namespace C4A_demo_2
{
    public partial class ticket_spec : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Global.fillWordingTable(Global.current_language);
            
            if (Global.current_theme.Contains("contrast"))
            {
                display.Attributes["class"] = "stepbystep_C4A_contrast";
                single_button.CssClass = "button_contrast";
                day_button.CssClass = "button_contrast";
                carnet_button.CssClass = "button_contrast";
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
                single_button.CssClass = "button_normal";
                day_button.CssClass = "button_normal";
                carnet_button.CssClass = "button_normal";
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

            ticket_dest.Text = Global.ticket.destination;
            choice.Text = Global.wordingtable[14];
            single_ticket.Text = Global.wordingtable[5];
            day_ticket.Text = Global.wordingtable[6];
            carnet.Text = Global.wordingtable[26];
            ticket_mode.Text = Global.wordingtable[29];
            total_price.Text = Global.wordingtable[17];
            cancel_label.Text = Global.wordingtable[13];
            yourticketheadline.Text = Global.wordingtable[15];
            to_label.Text = Global.wordingtable[16]; 
        }

        protected void single_button_Click(object sender, EventArgs e)
        {
            Global.ticket.type = Global.wordingtable[5];
            Global.ticket.price = Global.ticket.basefare;
            Response.Redirect("reduction_spec.aspx");
        }

        protected void day_button_Click(object sender, EventArgs e)
        {
            Global.ticket.type = Global.wordingtable[6];
            Global.ticket.price = 2.5*Global.ticket.basefare;
            Response.Redirect("reduction_spec.aspx");
        }

        protected void carnet_button_Click(object sender, EventArgs e)
        {
            Global.ticket.type = Global.wordingtable[26];
            Global.ticket.price = 7.5 * Global.ticket.basefare;
            Response.Redirect("reduction_spec.aspx");
        }

        protected void navigate_ahead_Click(object sender, EventArgs e)
        {

        }

        protected void navigate_back_Click(object sender, EventArgs e)
        {

        }

        protected void ImageMap1_Click(object sender, ImageMapEventArgs e)
        {
            runjQueryCode("$('#my_popup').popup();");
        }

        private string getjQueryCode(string jsCodetoRun)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("$(document).ready(function() {");
            sb.AppendLine(jsCodetoRun);
            sb.AppendLine(" });");

            return sb.ToString();
        }


        private void runjQueryCode(string jsCodetoRun)
        {

            ScriptManager requestSM = ScriptManager.GetCurrent(this);
            if (requestSM != null && requestSM.IsInAsyncPostBack)
            {
                ScriptManager.RegisterClientScriptBlock(this,
                                                        typeof(Page),
                                                        Guid.NewGuid().ToString(),
                                                        getjQueryCode(jsCodetoRun),
                                                        true);
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(typeof(Page),
                                                       Guid.NewGuid().ToString(),
                                                       getjQueryCode(jsCodetoRun),
                                                       true);
            }
        }



        protected void btnAsynchPostback_Click(object sender, EventArgs e)
        {
            // runjQueryCode("$('.button_contrast').switchClass('button_contrast','button_crazy','slow');$('.button_crazy').switchClass('button_crazy','button_contrast','fast');");
            runjQueryCode("$('.startseite_C4A').switchClass('startseite_C4A','startseite_C4A_contrast','slow');");
            runjQueryCode("$('.time').switchClass('time','time_contrast','slow');");
            // HyperLink4.CssClass = "button_contrast";
            runjQueryCode("$('.zeiticon').switchClass('zeiticon','zeiticon_contrast','slow');");
            runjQueryCode("$('.button_normal').switchClass('button_normal','button_contrast','slow');");
            runjQueryCode("$('.button_eng_normal_eservice').switchClass('button_eng_normal_eservice','button_eng_contrast_eservice','slow');");
            runjQueryCode("$('.button_eng_normal').switchClass('button_eng_normal','button_eng_contrast','slow');");
            runjQueryCode("$('.button_hoch_normal').switchClass('button_hoch_normal','button_hoch_contrast','slow');");
            runjQueryCode("$('.button_hoch_normal_touristen').switchClass('button_hoch_normal_touristen','button_hoch_contrast_touristen','slow');");

        }


    }
}
