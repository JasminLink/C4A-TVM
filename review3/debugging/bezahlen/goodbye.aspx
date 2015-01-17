<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="goodbye.aspx.cs" Inherits="C4A_demo_2.goodbye" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Good Bye</title>
    
    
<link rel="stylesheet" type="text/css" media="all" href="style.css" />
<link rel="stylesheet" type="text/css" media="all" href="C4A_styles.css"/>

<script type="text/javascript" src="helper.js"></script>
<script type="text/javascript" src="../js/jquery-1.10.2.js"></script>
<script type="text/javascript" src="../js/jquery-ui.js"></script>

</head>

<body onload="window.setTimeout('ZeitAnzeigen(\'fr\')', 1000)">
<form id="form2" runat="server">
<asp:Panel id="display" CssClass="startseite_C4A" style="width: 1024px; height:768px;" runat="server">

    <div id="headline">
    	<div id="headcontainer">
		    <div id="zeiticon" runat="server" class="zeiticon"></div> 
			<div id="Uhr" class="time" runat="server">&nbsp;</div>

            <div id="statuszeile" runat="server" style="font-size: 9px" visible="false">&nbsp;</div>
    	</div>
    </div>

    <div id="container">

   
      	<asp:ScriptManager ID="sm" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
       <asp:Timer runat="server" ID="timeout_ticker" Interval="5000" 
    ontick="timeout_ticker_Tick"></asp:Timer>
        
    
    <asp:Label id="goodbyemessage" CssClass="area_header" Text="Palim Palim" runat="server"></asp:Label>
    <br />
    <br />
    <br />
    <asp:Label id="goodbyemessage2" CssClass="area_header" Text="Palim Palim" runat="server"></asp:Label>
    
</div>
    
   
</asp:Panel>
</form> 
</body>
</html>

