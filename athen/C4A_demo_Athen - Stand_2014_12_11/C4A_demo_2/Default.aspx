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
window.name = "Default1";
</script>



</head>
<body onload="window.setTimeout('ZeitAnzeigen(\'fr\')', 1000)">
    <form id="form1" runat="server">

    <asp:ScriptManager ID="sm" runat="server" EnablePartialRendering="true"></asp:ScriptManager>


<div id="display" class="startseite_C4A" style="width: 1024px; height:768px;">

    <div id="headline">
    	<div id="headcontainer">
			<div class="zeiticon"></div> 
			<div id="Uhr" class="time">&nbsp;</div>

            <div id="statuszeile" runat="server" style="font-size: 9px" visible="false">&nbsp;</div>
    	</div>
    </div>

    <div id="container">
        <div id="links" style="z-index:0;">
        
    
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <div id="textfeld_links"><asp:Label runat="server" id="label_1" CssClass="area_header"></asp:Label></div>
        </ContentTemplate> 
        </asp:UpdatePanel>
        
        <div style="height:105px; z-index: 2">
        <asp:LinkButton runat="server" id="dest_choice" NavigateUrl="#" 
                class="button_normal" onclick="dest_choice_Click"><div id="icon"><img src="../img/lupe.png" width="42" height="50" alt="lupe"/></div><div style="padding-left: 30px"><asp:Label runat="server" id="label_8"></asp:Label></div></asp:LinkButton>
        </div>
        <div id="Div1" style="z-index: 2"><div class="area_header" style="z-index: 2"><asp:Label runat="server" id="label_3"></asp:Label></div><br /></div>
		<asp:LinkButton runat="server" id="freq_1_button" NavigateUrl="#" 
                CssClass="button_normal" onclick="freq_1_button_Click">München Flughafen</asp:LinkButton>
		<asp:LinkButton runat="server" id="freq_2_button" NavigateUrl="#" 
                CssClass="button_normal" onclick="freq_2_button_Click">Olympiastadion</asp:LinkButton>
        <asp:LinkButton runat="server" id="freq_3_button" NavigateUrl="#" 
                CssClass="button_normal" onclick="freq_3_button_Click">Ostbahnhof</asp:LinkButton>
        
        
    
    
        
        <asp:HiddenField runat="server" ID="anker" />
 
        
        </div>
        <div id="leerspalte"></div>
        <div id="mitte">

        <div id="textfeld_mitte"><div class="area_header"><asp:Label runat="server" id="label_4"></asp:Label></div><br /></div>
        <asp:LinkButton runat="server" id="special_1" NavigateUrl="~/step1_MUC.aspx" 
                class="button_normal" onclick="special_1_Click"><asp:Label runat="server" id="label_5"></asp:Label></asp:LinkButton>
        
		<asp:LinkButton runat="server" id="special_2" NavigateUrl="#" 
                CssClass="button_normal" onclick="special_2_Click"><asp:Label runat="server" id="label_6"></asp:Label></asp:LinkButton>
        <asp:LinkButton runat="server" id="special_3" NavigateUrl="#" 
                CssClass="button_normal" onclick="special_3_Click">CityTourCard</asp:LinkButton>
        <asp:LinkButton runat="server" id="special_4" NavigateUrl="#" 
                CssClass="button_normal" onclick="special_4_Click">Regionalzug</asp:LinkButton>
        <br /><br />
        <asp:LinkButton runat="server" id="special_5" NavigateUrl="#" 
                CssClass="button_normal" onclick="special_5_Click"><asp:Label runat="server" id="label_7"></asp:Label></asp:LinkButton>
        </div>
 
        <div id="leerspalte"></div>
        
        
        <div id="rechts">
        <div id="textfeld_rechts"><div class="area_header">Service</div><br /></div>
       
        <asp:LinkButton runat="server" id="DesignSwitch" NavigateUrl="#" CssClass="button_eng_normal_eservice" 
                     OnClick="DesignSwitch_Click"><div style="padding-left: 35px; vertical-align:middle; ">Service</div></asp:LinkButton> 
                    
        <asp:LinkButton runat="server" id="HyperLinkC" NavigateUrl="#" 
                    CssClass="button_eng_normal" 
                    onclick="btnAsynchPostback_Click">Week-End </asp:LinkButton>   
        <asp:LinkButton runat="server" id="startButton" NavigateUrl="#" class="button_eng_normal"
                    onclick="startButton_Click"><div style="padding-left: 30px; vertical-align:middle; ">Start</div></asp:LinkButton> 
        
        <asp:LinkButton runat="server" id="touristbutton" NavigateUrl="#" 
                    CssClass="button_hoch_normal_touristen" 
                    onclick="touristbutton_Click"><div style="position: relative; top: 38px; left: 8px;">Tourist</div></asp:LinkButton>       
        
       
    
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



    </form>
</body>
</html>
