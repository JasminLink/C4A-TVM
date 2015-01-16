<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="C4A_demo_2._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>C4A TVM</title>  

<link rel="stylesheet" type="text/css" media="all" href="style.css" />
<link rel="stylesheet" type="text/css" media="all" href="C4A_styles.css"/>

<script type="text/javascript" src="helper.js"></script>
<script type="text/javascript" src="../js/jquery-1.10.2.js"></script>
<script type="text/javascript" src="../js/jquery-ui.js"></script>



<script type="text/javascript">
        function myFunction(fontfamily) 
        {
            document.getElementById('label_21').style.fontFamily = fontfamily;
            document.getElementById('label_22').style.fontFamily = fontfamily;
            document.getElementById('label_23').style.fontFamily = fontfamily;
            document.getElementById('label_5').style.fontFamily = fontfamily;
            document.getElementById('label_6').style.fontFamily = fontfamily;
            document.getElementById('label_7').style.fontFamily = fontfamily;
            // document.getElementById('label_8').style.fontFamily = fontfamily;
            document.getElementById('label_11').style.fontFamily = fontfamily;  
            document.getElementById('label_12').style.fontFamily = fontfamily;
            document.getElementById('Uhr').style.fontFamily = fontfamily;

            document.getElementById('label_1').style.fontFamily = fontfamily;
            document.getElementById('label_3').style.fontFamily = fontfamily;
            document.getElementById('label_4').style.fontFamily = fontfamily;

            document.getElementById('service_label').style.fontFamily = fontfamily;
            document.getElementById('label_25').style.fontFamily = fontfamily;
            document.getElementById('touristlabel').style.fontFamily = fontfamily;
            document.getElementById('label_27').style.fontFamily = fontfamily;

            document.getElementById('dest_choice').style.fontFamily = fontfamily; 
            
            
                          
        }
    </script>



</head>
<body onload="window.setTimeout('ZeitAnzeigen(\'fr\')', 1000)">
    <form id="form1" runat="server">

    <asp:ScriptManager ID="sm" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
<asp:Timer runat="server" ID="timeout_ticker" Interval="3000" 
    ontick="timeout_ticker_Tick"></asp:Timer>
    



<asp:Panel id="display" CssClass="startseite_C4A" style="width: 1024px; height:768px;" runat="server">

    <div id="headline">
    	<div id="headcontainer">
			<asp:Panel id = "zeiticon" CssClass="zeiticon" runat="server"></asp:Panel>
			<div id="Uhr" class="time" runat="server">&nbsp;</div>

    	</div>
    </div>

    <div id="container">
        <div id="links" style="z-index:0;">
        
    
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <div id="textfeld_links"><asp:Label runat="server" id="label_1" CssClass="area_header"></asp:Label></div>
        </ContentTemplate> 
        </asp:UpdatePanel>

        
        <asp:LinkButton runat="server" id="dest_choice" 
                CssClass="button_normal" onclick="dest_choice_Click"><asp:Label runat="server" ID="label_8">Zielhaltestelle</asp:Label></asp:LinkButton>
        
        <div id="Div1" style="z-index: 2"><div class="area_header" style="z-index: 2"><asp:Label runat="server" id="label_3"></asp:Label></div><br/></div>
		<asp:LinkButton runat="server" id="freq_1_button"  
                CssClass="button_normal" onclick="freq_1_button_Click"><asp:Label runat="server" id="label_21">München Flughafen</asp:Label></asp:LinkButton>
		<asp:LinkButton runat="server" id="freq_2_button"  
                CssClass="button_normal" onclick="freq_2_button_Click"><asp:Label runat="server" id="label_22">Olympiastadion</asp:Label></asp:LinkButton>
        <asp:LinkButton runat="server" id="freq_3_button"  
                CssClass="button_normal" onclick="freq_3_button_Click"><asp:Label runat="server" id="label_23">Ostbahnhof</asp:Label></asp:LinkButton>
        

        
        </div>
        <div id="leerspalte"></div>
        <div id="mitte">

        <div id="textfeld_mitte"><div class="area_header"><asp:Label runat="server" id="label_4"></asp:Label></div><br /></div>
        <asp:LinkButton runat="server" id="special_1" NavigateUrl="~/step1_MUC.aspx" 
                class="button_normal" onclick="special_1_Click"><asp:Label runat="server" id="label_5"></asp:Label></asp:LinkButton>
        
		<asp:LinkButton runat="server" id="special_2"  
                CssClass="button_normal" onclick="special_2_Click"><asp:Label runat="server" id="label_6"></asp:Label></asp:LinkButton>
        <asp:LinkButton runat="server" id="special_3"  
                CssClass="button_normal" onclick="special_3_Click"><asp:Label runat="server" id="label_11"></asp:Label></asp:LinkButton>
        <asp:LinkButton runat="server" id="special_4" 
                CssClass="button_normal" onclick="special_4_Click"><asp:Label runat="server" id="label_12"></asp:Label></asp:LinkButton>
        <br /><br />
        <asp:LinkButton runat="server" id="special_5"  
                CssClass="button_normal" onclick="special_5_Click"><asp:Label runat="server" id="label_7"></asp:Label></asp:LinkButton>
        </div>
 
        <div id="leerspalte"></div>
        
        <div id="rechts">
        <div id="textfeld_rechts" runat="server">
        <asp:Label runat="server" ID="service_label" CssClass="area_header">Service</asp:Label><br /></div>
       
        <asp:LinkButton runat="server" id="DesignSwitch"  CssClass="button_eng_normal_eservice" 
                     OnClick="DesignSwitch_Click"><div runat="server" id="label_25" style="position: relative; left:-8px;" >e-Service</div></asp:LinkButton> 
                    
        <asp:LinkButton runat="server" id="HyperLinkC"    CssClass="button_eng_normal_c4a" 
                    onclick="btnAsynchPostback_Click"><asp:Label runat="server" id="label_27" style="position: relative; left:-8px;">Cloud4All</asp:Label></asp:LinkButton>   
        
        <asp:LinkButton runat="server" id="touristbutton"  
                    CssClass="button_hoch_normal_touristen" 
                    onclick="touristbutton_Click"><div id="touristlabel" runat="server" style="position: relative; top: 38px; left: 8px;">Tourist</div></asp:LinkButton>       
        
       
    
</div>
 <div id="debug">
             <div id="textfeld_debug"><asp:Label runat="server" id="textfeld_debug_label" CssClass="area_header"></asp:Label></div>
            
 </div>

<div id="footer">


</div>



<asp:LinkButton runat="server" id="lang_button_de"  CssClass="language_button_de_normal" 
                    style="position:absolute; left:295px; top: 705px;" 
                    onclick="lang_button_de_Click"></asp:LinkButton>
<asp:LinkButton runat="server" id="lang_button_en"  CssClass="language_button_en_normal" 
                    style="position:absolute; left:365px; top: 705px;" 
                    onclick="lang_button_en_Click"></asp:LinkButton>
<asp:LinkButton runat="server" id="lang_button_fr" CssClass="language_button_fr_normal" 
                    style="position:absolute; left:435px; top: 705px;" 
                    onclick="lang_button_fr_Click"></asp:LinkButton>
<asp:LinkButton runat="server" id="lang_button_es" CssClass="language_button_es_normal" 
                    style="position:absolute; left:505px; top: 705px;" 
                    onclick="lang_button_es_Click"></asp:LinkButton>
<asp:LinkButton runat="server" id="lang_button_it" CssClass="language_button_it_normal" 
                    style="position:absolute; left:575px; top: 705px;" 
                    onclick="lang_button_it_Click"></asp:LinkButton>
<asp:LinkButton runat="server" id="lang_button_gr" CssClass="language_button_gr_normal" 
                    style="position:absolute; left:645px; top: 705px;" 
                    onclick="lang_button_gr_Click"></asp:LinkButton>

</div>
</asp:Panel>



    </form>
</body>
</html>
