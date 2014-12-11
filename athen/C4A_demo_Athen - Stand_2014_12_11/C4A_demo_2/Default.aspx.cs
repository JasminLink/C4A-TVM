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
using Microsoft.PointOfService.Legacy;
using Microsoft.PointOfService.Management;
using Microsoft.PointOfService;
using System.Threading;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Threading;

namespace C4A_demo_2
{
    

    public partial class _Default : System.Web.UI.Page
    {

        public CTicket ticket;

        
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

        protected void HyperLinkB_Click(object sender, EventArgs e)
        {
            // runjQueryCode("$('.button_contrast').switchClass('button_contrast','button_crazy','slow');$('.button_crazy').switchClass('button_crazy','button_contrast','fast');");
            runjQueryCode("$('.startseite_C4A').switchClass('startseite_C4A','startseite_C4A_contrast','slow');");
            runjQueryCode("$('.zeiticon').switchClass('zeiticon','zeiticon_contrast','slow');");
            runjQueryCode("$('.time').switchClass('time','time_contrast','slow');");
            runjQueryCode("$('.button_normal').switchClass('button_normal','button_contrast','slow');");
            runjQueryCode("$('.button_eng_normal_eservice').switchClass('button_eng_normal_eservice','button_eng_contrast_eservice','slow');");
            runjQueryCode("$('.button_eng_normal').switchClass('button_eng_normal','button_eng_contrast','slow');");
            runjQueryCode("$('.button_hoch_normal').switchClass('button_hoch_normal','button_hoch_contrast','slow');");
            runjQueryCode("$('.button_hoch_normal_touristen').switchClass('button_hoch_normal_touristen','button_hoch_contrast_touristen','slow');");
            runjQueryCode("$('.area_header').switchClass('area_header','area_header_contrast','slow');");

        }


        protected void HyperLinkC_Click(object sender, EventArgs e)
        {
            // runjQueryCode("$('.button_contrast').switchClass('button_contrast','button_crazy','slow');$('.button_crazy').switchClass('button_crazy','button_contrast','fast');");
            runjQueryCode("$('.startseite_C4A').switchClass('startseite_C4A','startseite_C4A_contrast','slow');");
            runjQueryCode("$('.area_header').switchClass('area_header','area_header_contrast','slow');");
            runjQueryCode("$('.zeiticon').switchClass('zeiticon','zeiticon_contrast','slow');");
            runjQueryCode("$('.time').switchClass('time','time_contrast','slow');");
            runjQueryCode("$('.button_normal').switchClass('button_normal','button_contrast','slow');");
            runjQueryCode("$('.button_eng_normal_eservice').switchClass('button_eng_normal_eservice','button_eng_contrast_eservice','slow');");
            runjQueryCode("$('.button_eng_normal').switchClass('button_eng_normal','button_eng_contrast','slow');");
            runjQueryCode("$('.button_hoch_normal').switchClass('button_hoch_normal','button_hoch_contrast','slow');");
            runjQueryCode("$('.button_hoch_normal_touristen').switchClass('button_hoch_normal_touristen','button_hoch_contrast_touristen','slow');");
            
         }

        protected void startButton_Click(object sender, EventArgs e)
        {

            // Die Auskommentierten Zeilen müssen hinzugefügt werden, falls der Scanner daueraft scannen soll(leider noch nicht funktionionsfähig) . Andernfalls scannt der Scanner einmalig beim Klicken auf den Button.
            
            //new Thread((ThreadStart)delegate()
            //{
               // for (int i = 0; i < 5; i++)
               // {
                    IDScanner scanner = new IDScanner();
                    string Data = scanner.scan();

                    //this.BeginInvoke((ThreadStart)delegate()
                   // {
                        if (Data.Contains("la"))
                        {
                            //startButton.Visible = false;
                            this.runjQueryCode("$('.startseite_C4A').switchClass('startseite_C4A','startseite_C4A_contrast','slow');");
                            this.runjQueryCode("$('.zeiticon').switchClass('zeiticon','zeiticon_contrast','slow');");
                            this.runjQueryCode("$('.time').switchClass('time','time_contrast','slow');");
                            this.runjQueryCode("$('.button_normal').switchClass('button_normal','button_contrast','slow');");
                            this.runjQueryCode("$('.button_eng_normal_eservice').switchClass('button_eng_normal_eservice','button_eng_contrast_eservice','slow');");
                            this.runjQueryCode("$('.button_eng_normal').switchClass('button_eng_normal','button_eng_contrast','slow');");
                            this.runjQueryCode("$('.button_hoch_normal').switchClass('button_hoch_normal','button_hoch_contrast','slow');");
                            this.runjQueryCode("$('.button_hoch_normal_touristen').switchClass('button_hoch_normal_touristen','button_hoch_contrast_touristen','slow');");
                            this.runjQueryCode("$('.area_header').switchClass('area_header','area_header_contrast','slow');");
                        }

                        if (Data.Contains("lo"))
                        {
                            //startButton.Visible = false;
                            this.runjQueryCode("$('.startseite_C4A_contrast').switchClass('startseite_C4A_contrast','startseite_C4A','slow');");
                            this.runjQueryCode("$('.zeiticon_contrast').switchClass('zeiticon_contrast','zeiticon','slow');");
                            this.runjQueryCode("$('.time_contrast').switchClass('time_contrast','time','slow');");
                            this.runjQueryCode("$('.button_contrast').switchClass('button_contrast','button_normal','slow');");
                            this.runjQueryCode("$('.button_eng_contrast_eservice').switchClass('button_eng_contrast_eservice','button_eng_normal_eservice','slow');");
                            this.runjQueryCode("$('.button_eng_contrast').switchClass('button_eng_contrast','button_eng_normal','slow');");
                            this.runjQueryCode("$('.button_hoch_contrast').switchClass('button_hoch_contrast','button_hoch_normal','slow');");
                            this.runjQueryCode("$('.button_hoch_contrast_touristen').switchClass('button_hoch_contrast_touristen','button_hoch_normal_touristen','slow');");
                            this.runjQueryCode("$('.area_header_contrast').switchClass('area_header_contrast','area_header','slow');");

                        }


                    //});
               // }
           // }).Start();

        }



        protected void DesignSwitch_Click(object sender, EventArgs e)
        {
            
            String newstyle = "button_contrast";
            Switch_Design(newstyle);
            Switch_Design("area_header", "area_header_contrast");
        }


        public void Switch_Design(String newstyle)
        {
            String oldstyle = special_3.CssClass;
            Switch_Design(oldstyle, newstyle);
        }


        public void Switch_Design(String oldstyle, String newstyle)
        {

            String arg = "";
            arg = arg + "$('.";
            arg = arg + oldstyle;
            arg = arg + "').switchClass('";
            arg = arg + oldstyle;
            
            arg = arg + "','" + newstyle;
            arg = arg + "','slow');";

            statuszeile.InnerHtml = arg;
            runjQueryCode(arg);
        }

        public void setfontsize(int size)
        {
            Style style = new Style();
            style.Font.Size = 36;
            
            
        }

        
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.UI.Page _tvm = this.Page;
            Global.tvm = _tvm;

            applyLanguage(Global.current_language);
            if(Global.current_language.Contains("de")) lang_button_de.CssClass = "language_button_de_pressed";
            if (Global.current_language.Contains("en")) lang_button_de.CssClass = "language_button_en_pressed";
            if (Global.current_language.Contains("fr")) lang_button_de.CssClass = "language_button_fr_pressed";
            if (Global.current_language.Contains("es")) lang_button_de.CssClass = "language_button_es_pressed";
            if (Global.current_language.Contains("it")) lang_button_de.CssClass = "language_button_it_pressed";
            if (Global.current_language.Contains("gr")) lang_button_de.CssClass = "language_button_gr_pressed";

        }

        public void applyLanguage(String lang)
        {
            Global.fillWordingTable(lang);

            
            label_1.Text = Global.wordingtable[1];
            label_3.Text = Global.wordingtable[3];
            label_4.Text = Global.wordingtable[4];
            label_5.Text = Global.wordingtable[5];
            label_6.Text = Global.wordingtable[6];
            label_7.Text = Global.wordingtable[7];
            label_8.Text = Global.wordingtable[8];
        }

        public void serverside_apply_style(String theme)
        {
            dest_choice.CssClass = "button_contrast";
            freq_1_button.CssClass = "button_contrast";
            freq_2_button.CssClass = "button_contrast";
            freq_3_button.CssClass = "button_contrast";
        }

        protected void touristbutton_Click(object sender, EventArgs e)
        {

            Response.Redirect("tourist.aspx");
        }

        protected void freq_1_button_Click(object sender, EventArgs e)
        {
            Global.ticket.destination = freq_1_button.Text;
            Global.ticket.basefare = 3.60;
            Global.ticket.tarif = Global.wordingtable[5];
            Response.Redirect("ticket_spec.aspx");
            
        }

        protected void freq_2_button_Click(object sender, EventArgs e)
        {
            Global.ticket.destination = freq_2_button.Text;
            Global.ticket.basefare = 2.00;
            Response.Redirect("ticket_spec.aspx");
        }

        protected void freq_3_button_Click(object sender, EventArgs e)
        {
            Global.ticket.destination = freq_3_button.Text;
            Global.ticket.basefare = 2.40;
            Response.Redirect("ticket_spec.aspx");
        }

        protected void lang_button_de_Click(object sender, EventArgs e)
        {
            Global.current_language = "de";
            applyLanguage(Global.current_language);
            lang_button_de.CssClass = "language_button_de_pressed";
            lang_button_en.CssClass = "language_button_en_normal";
            lang_button_fr.CssClass = "language_button_fr_normal";
            lang_button_it.CssClass = "language_button_it_normal";
            lang_button_gr.CssClass = "language_button_gr_normal"; 
            lang_button_es.CssClass = "language_button_es_normal";

        }

        protected void lang_button_fr_Click(object sender, EventArgs e)
        {
            Global.current_language = "fr";
            applyLanguage(Global.current_language);
            lang_button_fr.CssClass = "language_button_fr_pressed";
            lang_button_en.CssClass = "language_button_en_normal";
            lang_button_de.CssClass = "language_button_de_normal";
            lang_button_it.CssClass = "language_button_it_normal";
            lang_button_gr.CssClass = "language_button_gr_normal";
            lang_button_es.CssClass = "language_button_es_normal";
        }

        protected void lang_button_it_Click(object sender, EventArgs e)
        {
            Global.current_language = "it";
            applyLanguage(Global.current_language);
            lang_button_it.CssClass = "language_button_it_pressed";
            lang_button_en.CssClass = "language_button_en_normal";
            lang_button_fr.CssClass = "language_button_fr_normal";
            lang_button_de.CssClass = "language_button_de_normal";
            lang_button_gr.CssClass = "language_button_gr_normal";
            lang_button_es.CssClass = "language_button_es_normal";
        }

        protected void lang_button_es_Click(object sender, EventArgs e)
        {
            Global.current_language = "es";
            applyLanguage(Global.current_language);
            lang_button_es.CssClass = "language_button_es_pressed";
            lang_button_en.CssClass = "language_button_en_normal";
            lang_button_fr.CssClass = "language_button_fr_normal";
            lang_button_it.CssClass = "language_button_it_normal";
            lang_button_gr.CssClass = "language_button_gr_normal";
            lang_button_de.CssClass = "language_button_de_normal";
        }

        protected void lang_button_gr_Click(object sender, EventArgs e)
        {
            Global.current_language = "gr";
            applyLanguage(Global.current_language);
            lang_button_gr.CssClass = "language_button_gr_pressed";
            lang_button_en.CssClass = "language_button_en_normal";
            lang_button_fr.CssClass = "language_button_fr_normal";
            lang_button_it.CssClass = "language_button_it_normal";
            lang_button_es.CssClass = "language_button_es_normal";
            lang_button_de.CssClass = "language_button_de_normal";
        }


        protected void lang_button_en_Click(object sender, EventArgs e)
        {
            Global.current_language = "en";
            applyLanguage(Global.current_language);
            lang_button_en.CssClass = "language_button_en_pressed";
            lang_button_de.CssClass = "language_button_de_normal";
            lang_button_fr.CssClass = "language_button_fr_normal";
            lang_button_it.CssClass = "language_button_it_normal";
            lang_button_gr.CssClass = "language_button_gr_normal";
            lang_button_es.CssClass = "language_button_es_normal";
        }

        protected void dest_choice_Click(object sender, EventArgs e)
        {
            Response.Redirect("search_dest.aspx");
        }

        protected void special_1_Click(object sender, EventArgs e)
        {
            Response.Redirect("short.aspx");
        }

        protected void special_2_Click(object sender, EventArgs e)
        {
            Response.Redirect("day_ticket_spec.aspx");
        }

        protected void special_3_Click(object sender, EventArgs e)
        {
            Response.Redirect("weekly_ticket_spec.aspx");
        }

        protected void special_4_Click(object sender, EventArgs e)
        {
            Response.Redirect("monthly_ticket_spec.aspx");

        }

        protected void special_5_Click(object sender, EventArgs e)
        {
            Response.Redirect("group_ticket_spec.aspx");
        }

        // extralanger timeout
        // automatische Sprachadaption
        // Acessibility Standards
        // Klassenzimmer bei Stromausfall?
        // Nach Kauf: Hinweise, wie man zum Gleis kommt, wo Stufen sind, was Reisende mit schwerem Gepäck anstellen können usw.
        // Voice Reader: Ausweichen / ergänzen mit Voice Ausgabe
        // 
        // 1. CSS Schwarz / weiss , von vdv abweichen, c4a Logo rein
        // 2. Schriftgrösse
        // 3. Sprachauswahl
        // 4. Spracheausgabe
        // 5. Hinweise hinten dran
        // apply_style(NORMAL | CONTRAST | 70IES)
        // add_assistance(WHEELCHAIR | BLIND | SLOW)
        // set_language(GERMAN | ENGLISH | DUTCH)
        // set_area(MUNICH | JAKARTA | MADRID)

    }
}
