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
using Demo_GPII_Adapter;


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
            Global.current_theme = "contrast";
            // Global.current_fontface = "Comic Sans MS";
            // applyFontFace_clientside(Global.current_fontface);
            // serverside_apply_style(Global.current_theme);
            
            // runjQueryCode("$('.button_contrast').switchClass('button_contrast','button_crazy','slow');$('.button_crazy').switchClass('button_crazy','button_contrast','fast');");
            runjQueryCode("$('.startseite_C4A').switchClass('startseite_C4A','startseite_C4A_contrast','slow');");
            runjQueryCode("$('.time').switchClass('time','time_contrast','slow');");
            // HyperLink4.CssClass = "button_contrast";
            runjQueryCode("$('.area_header').switchClass('area_header','area_header_contrast','slow');");
            runjQueryCode("$('.zeiticon').switchClass('zeiticon','zeiticon_contrast','slow');");
            runjQueryCode("$('.button_normal').switchClass('button_normal','button_contrast','slow');");
            runjQueryCode("$('.button_eng_normal_eservice').switchClass('button_eng_normal_eservice','button_eng_contrast_eservice','slow');");
            runjQueryCode("$('.button_eng_normal').switchClass('button_eng_normal','button_eng_contrast','slow');");
            runjQueryCode("$('.button_hoch_normal').switchClass('button_hoch_normal','button_hoch_contrast','slow');");
            runjQueryCode("$('.button_eng_normal_c4a').switchClass('button_eng_normal_c4a','button_eng_contrast_c4a','slow');");
            runjQueryCode("$('.button_hoch_normal_touristen').switchClass('button_hoch_normal_touristen','button_hoch_contrast_touristen','slow');");
            
        }

        protected void HyperLinkB_Click(object sender, EventArgs e)
        {
            Global.current_theme = "contrast";
            // serverside_apply_style(Global.current_theme);
            
            // runjQueryCode("$('.button_contrast').switchClass('button_contrast','button_crazy','slow');$('.button_crazy').switchClass('button_crazy','button_contrast','fast');");
            runjQueryCode("$('.startseite_C4A').switchClass('startseite_C4A','startseite_C4A_contrast','slow');");
            runjQueryCode("$('.zeiticon').switchClass('zeiticon','zeiticon_contrast','slow');");
            runjQueryCode("$('.time').switchClass('time','time_contrast','slow');");
            runjQueryCode("$('.button_eng_normal_c4a').switchClass('button_eng_normal_c4a','button_eng_contrast_c4a','slow');");
            runjQueryCode("$('.button_normal').switchClass('button_normal','button_contrast','slow');");
            runjQueryCode("$('.button_eng_normal_eservice').switchClass('button_eng_normal_eservice','button_eng_contrast_eservice','slow');");
            runjQueryCode("$('.button_eng_normal').switchClass('button_eng_normal','button_eng_contrast','slow');");
            runjQueryCode("$('.button_hoch_normal').switchClass('button_hoch_normal','button_hoch_contrast','slow');");
            runjQueryCode("$('.button_hoch_normal_touristen').switchClass('button_hoch_normal_touristen','button_hoch_contrast_touristen','slow');");
            runjQueryCode("$('.area_header').switchClass('area_header','area_header_contrast','slow');");
        }


        protected void HyperLinkC_Click(object sender, EventArgs e)
        {
            textfeld_debug_label.Text = "HyperLinkC_Click";
            startButton_Click(sender, e);
            
            
            Global.current_theme = "contrast";
            Global.current_fontface = "Calibri";
            // applyFontFace_clientside(Global.current_fontface);
            // serverside_apply_style(Global.current_theme);


            ani_normal_to_contrast();
         }

        protected void ani_normal_to_contrast()
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
            runjQueryCode("$('.button_eng_normal_c4a').switchClass('button_eng_normal_c4a','button_eng_contrast_c4a','slow');");

        }

        protected void DesignSwitch_Click(object sender, EventArgs e)
        {
            textfeld_debug_label.Text = "DesignSwitch_Click";
            TVMSettings ts = TVM.listenForUser();
            String settings = "";
            settings = settings + "\"" + ts.TVMPreferences.userToken + "\" ";
            settings = settings + "\"" + ts.TVMPreferences.contrastTheme + "\" ";
            settings = settings + "\"" + ts.TVMPreferences.fontSize + "\" ";
            settings = settings + "\"" + ts.TVMPreferences.fontFace + "\" ";
            settings = settings + "\"" + ts.TVMPreferences.buttonSize + "\" ";
            settings = settings + "\"" + ts.TVMPreferences.timeOut + "\" ";
            settings = settings + "\"" + ts.TVMPreferences.language + "\" ";
            textfeld_debug_label.Text = settings;

            invoke_Settings(ts);

        }


        protected void startButton_Click(object sender, EventArgs e)
        {
            textfeld_debug_label.Text = "startButton_Click";
            TVMSettings ts = TVM.listenForUser();
            invoke_Settings(ts);
            
        }


        protected void invoke_Settings(TVMSettings ts)
        {

            //contrast theme
            if (ts.TVMPreferences.contrastTheme == "yellow-black"){
                Global.current_theme = "contrast";
            }
            else
            {
                Global.current_theme = "normal";
            }
            //serverside_apply_style(Global.current_theme);

            //font size
            if (ts.TVMPreferences.fontSize == "big" ){
                //
            }else{
                //
            }
            // apply fontsize... ?
            
            //font face
            if (ts.TVMPreferences.fontFace.Contains("omic")){
                Global.current_fontface = "Comic Sans MS";
            }else{
                Global.current_fontface = "Calibri";
            }

            //button siz not in use
            if (ts.TVMPreferences.buttonSize == "big")
            {
                //
            }
            else
            {
                //
            }
            // apply buttonSize... ?
            
            


            //timeout
            if (ts.TVMPreferences.timeOut == "long"){
                Global.timeout = 60000;
            }else{
                Global.timeout = 45000;
            }

            //language
            apply_language(ts.TVMPreferences.language);

            Response.Redirect("Default.aspx");
        }
        


        public void setfontsize(int size)
        {
            Style style = new Style();
            style.Font.Size = 36;
        }

        protected void apply_language(String language)
        {
            if (language.Contains("de"))
            {
                Global.current_language = "de";
            }

            if (language.Contains("en"))
            {
                Global.current_language = "en";
            }

            if (language.Contains("fr"))
            {
                Global.current_language = "fr";
            }

            if (language.Contains("es"))
            {
                Global.current_language = "es";
            }

            if (language.Contains("it"))
            {
                Global.current_language = "it";
            }

            if (language.Contains("el"))
            {
                Global.current_language = "gr";
            }

        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            timeout_ticker.Interval = Global.timeout;

            serverside_apply_style(Global.current_theme);
            // applyFontFace_clientside(Global.current_fontface);
            applyFontFace(Global.current_fontface);
            applyFontFace_clientside(Global.current_fontface);
            applyLanguage(Global.current_language);

            

            if (Global.current_language.Contains("de")) lang_button_de.CssClass = "language_button_de_pressed";
            if (Global.current_language.Contains("en")) lang_button_en.CssClass = "language_button_en_pressed";
            if (Global.current_language.Contains("fr")) lang_button_fr.CssClass = "language_button_fr_pressed";
            if (Global.current_language.Contains("es")) lang_button_es.CssClass = "language_button_es_pressed";
            if (Global.current_language.Contains("it")) lang_button_it.CssClass = "language_button_it_pressed";
            if (Global.current_language.Contains("gr")) lang_button_gr.CssClass = "language_button_gr_pressed";
        }

        protected void timeout_ticker_Tick(object sender, EventArgs e)
        {
            Global.current_language = "de";
            Global.current_theme = "normal";
            Global.set_timeout("normal");
            Global.current_fontface = "Calibri";
            Server.Transfer("Default.aspx");
        }

        public void applyLanguage(String lang)
        {
            Global.fillWordingTable(lang);

            service_label.Text = Global.wordingtable[40];
            // label_25.Text = Global.wordingtable[40];
            // label_26.Text = Global.wordingtable[39];
            
            label_1.Text = Global.wordingtable[1];
            label_3.Text = Global.wordingtable[3];
            label_4.Text = Global.wordingtable[4];
            label_5.Text = Global.wordingtable[5];
            label_6.Text = Global.wordingtable[6];
            label_7.Text = Global.wordingtable[7];
            label_8.Text = Global.wordingtable[8];
            label_11.Text = Global.wordingtable[26];
            label_12.Text = Global.wordingtable[24];

            // label_27.Text = Global.wordingtable[5];

            dest_choice.Text = Global.wordingtable[8];
        }

        public void applyFontFace(String family)
        {

            
            label_1.Attributes["style"] = "font-family: " + family;
            label_3.Attributes["style"] = "font-family: " + family;
            label_4.Attributes["style"] = "font-family: " + family;
            label_5.Attributes["style"] = "font-family: " + family;
            label_6.Attributes["style"] = "font-family: " + family;
            label_7.Attributes["style"] = "font-family: " + family;
            label_8.Attributes["style"] = "font-family: " + family;
            label_11.Attributes["style"] = "font-family: " + family;
            label_12.Attributes["style"] = "font-family: " + family;

            label_21.Attributes["style"] = "font-family: " + family;
            label_23.Attributes["style"] = "font-family: " + family;
            service_label.Attributes["style"] = "font-family: " + family;
            
            label_25.Attributes["style"] = "font-family: " + family;
            touristlabel.Attributes["style"] = "font-family: " + family;
            service_label.Attributes["style"] = "font-family: " + family;
            label_27.Attributes["style"] = "font-family: " + family;
            label_22.Attributes["style"] = "font-family: " + family;

            dest_choice.Attributes["style"] = "font-family: " + family;
            
        }

        public void applyFontFace_clientside(String family)
        {
            String arg = "myFunction('" + family + "');";
            ScriptManager.RegisterStartupScript(this, GetType(), "myFunction", arg, true);   
        }

        public void serverside_apply_style(String theme)
        {
            
            if(theme.Contains("normal"))
            {
            display.CssClass = "startseite_C4A";

            special_1.CssClass = "button_normal";
            special_2.CssClass = "button_normal";
            special_3.CssClass = "button_normal";
            special_4.CssClass = "button_normal";
            special_5.CssClass = "button_normal";

            dest_choice.CssClass = "button_normal";
            freq_1_button.CssClass = "button_normal";
            freq_2_button.CssClass = "button_normal";
            freq_3_button.CssClass = "button_normal";

            DesignSwitch.CssClass = "button_eng_normal";
            HyperLinkC.CssClass = "button_eng_normal_c4a";
            touristbutton.CssClass = "button_hoch_normal_touristen";

            zeiticon.CssClass = "zeiticon";
            
            Uhr.Attributes["style"] = "	font-style:bold; color:Black; font-size:18px; line-height: 25px; z-index: 2;";

            label_1.CssClass = "area_header";
            label_3.CssClass = "area_header";
            label_4.CssClass = "area_header";

            service_label.CssClass = "area_header";
            }



            else if(theme.Contains("contrast"))
            {
                ani_normal_to_contrast();

                display.CssClass = "startseite_C4A_contrast";

                special_1.CssClass = "button_contrast";
                special_2.CssClass = "button_contrast";
                special_3.CssClass = "button_contrast";
                special_4.CssClass = "button_contrast";
                special_5.CssClass = "button_contrast";
                
                dest_choice.CssClass = "button_contrast";
                freq_1_button.CssClass = "button_contrast";
                freq_2_button.CssClass = "button_contrast";
                freq_3_button.CssClass = "button_contrast";

                DesignSwitch.CssClass = "button_eng_contrast";
                HyperLinkC.CssClass = "button_eng_contrast_c4a";
                touristbutton.CssClass = "button_hoch_contrast_touristen";

                zeiticon.CssClass = "zeiticon_contrast";
                Uhr.Attributes["style"] = "font-style: bold; z-index: 2; color: #f4fc00; font-size:24px; ";

                label_1.CssClass = "area_header_contrast";
                label_3.CssClass = "area_header_contrast";
                label_4.CssClass = "area_header_contrast";

                service_label.CssClass = "area_header_contrast";

            }
            
            

        }

        protected void touristbutton_Click(object sender, EventArgs e)
        {

            Response.Redirect("tourist.aspx");
        }

        protected void freq_1_button_Click(object sender, EventArgs e)
        {
            // Global.ticket.destination = freq_1_button.Text;

            Global.ticket.destination = label_21.Text;
            Global.ticket.basefare = 3.60;
            Global.ticket.tarif = Global.wordingtable[5];
            Response.Redirect("ticket_spec.aspx");
            
        }

        protected void freq_2_button_Click(object sender, EventArgs e)
        {
            // Global.ticket.destination = freq_2_button.Text;

            Global.ticket.destination = label_22.Text;
            Global.ticket.basefare = 2.00;
            Response.Redirect("ticket_spec.aspx");
        }

        protected void freq_3_button_Click(object sender, EventArgs e)
        {
            // Global.ticket.destination = freq_3_button.Text;

            Global.ticket.destination = label_23.Text;
            Global.ticket.basefare = 2.40;
            Response.Redirect("ticket_spec.aspx");
        }

        protected void lang_button_de_Click(object sender, EventArgs e)
        {
            serverside_apply_style(Global.current_theme);
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
            serverside_apply_style(Global.current_theme);
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
            serverside_apply_style(Global.current_theme);
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

            serverside_apply_style(Global.current_theme);
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
            serverside_apply_style(Global.current_theme);
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

            serverside_apply_style(Global.current_theme);
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
