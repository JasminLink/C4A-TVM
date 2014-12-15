<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="payment.aspx.cs" Inherits="C4A_demo_2.payment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    
    
<link rel="stylesheet" type="text/css" media="all" href="style.css" />
<link rel="stylesheet" type="text/css" media="all" href="C4A_styles.css"/>

<script type="text/javascript" src="helper.js"></script>
<script type="text/javascript" src="../js/jquery-1.10.2.js"></script>
<script type="text/javascript" src="../js/jquery-ui.js"></script>

</head>
<body onload="window.setTimeout('ZeitAnzeigen(\'fr\')', 1000)">
<form id="form2" runat="server">
<div id="display" class="payment_C4A">

    <div id="headline">
    	<div id="headcontainer">
			<div class="zeiticon"></div> 
			<div id="Uhr" class="time">&nbsp;</div>

            <div id="statuszeile" runat="server" style="font-size: 9px" visible="false">&nbsp;</div>
    	</div>
    </div>


    <div id="container">
      <div id="linksstepbystep">
      	<br/><br/><br/><br/>
      	<div id="headlineelement"><asp:Label runat="server" ID="choice"></asp:Label></div><br/>
      	       
      </div>
      <div id="leerspaltestepbystep">
      <br/><br/><br/>
      <br/><br/><br/>
      <br/><br/><br/>
       <br/><br/><br/>
      <div id="position"></div>
      </div>
      <div id="rechtsstepbystep">
      	<br/><br/><br/>
        <div id="fktextb" class="fktextbg"><asp:Label runat="server" ID="ticket_dest"></asp:Label></div>
        <div id="fktextb" class="fktextbg"><asp:Label runat="server" ID="ticket_type"></asp:Label></div>
        <div id="fktextb" class="fktextbg"><asp:Label runat="server" ID="ticket_tarif"></asp:Label></div>
        <div id="fktextb" class="fktextbg"><asp:Label runat="server" ID="add_service_value">jhghg</asp:Label></div>
        
        
        <br/><br/><br/><br/>
        <br/><br/><br/><br/>
        <div style="text-align:right;"><asp:Label runat="server" ID="total_price_label"></asp:Label></div>     
        <div style="text-align:right;"><asp:Label runat="server" ID="total_price"></asp:Label></div><div style="text-align:right; font-size:40px; padding-top:20px;"></div>
        <div style="text-align:right; font-size:40px; padding-top:20px;"><asp:Label runat="server" ID="price"></asp:Label></div>
      </div>
    </div>



    
    <div id="footer">
    
    
    <a href="Default.aspx" class="button_eng_normal"><asp:Label runat="server" ID="cancel_label"></asp:Label></a>
    
     <asp:Label runat="server" ID="yourticketheadline" CssClass="time" style="position:absolute; left:733px; top:-505px"></asp:Label>
     <asp:Label runat="server" ID="to_label" style="position:absolute; left:741px; top:-460px; color:#777777" >Nach</asp:Label>
    	
   	<asp:LinkButton runat="server" id="navigate_back" NavigateUrl="#" 
            CssClass="button_eng_normal" style="position:absolute; left:404px" 
            onclick="navigate_back_Click">zurück</asp:LinkButton>
   	<asp:LinkButton runat="server" id="navigate_ahead" NavigateUrl="#" 
            CssClass="button_eng_normal" style="position:absolute; left:548px" 
            onclick="navigate_ahead_Click">Ticket</asp:LinkButton>
   		

    <!--<a href="#" class="button-size-two button-stylegreen button-text buttonpadding floatright"><div id="buttonfeld">Bezahlen</div></a>-->
    </div>
    
   
</div>
</form> 
</body>
</html>
