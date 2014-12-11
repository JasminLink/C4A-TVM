<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tourist.aspx.cs" Inherits="C4A_demo_2.tourist" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>

<script>var SITE_URL = 'http://wowslider.com/';</script>
        
<link rel="stylesheet" type="text/css" media="all" href="style.css" />
<link rel="stylesheet" type="text/css" media="all" href="C4A_styles.css"/>

<script type="text/javascript" src="helper.js"></script>
<script type="text/javascript" src="../js/jquery-1.10.2.js"></script>
<script type="text/javascript" src="../js/jquery-ui.js"></script>
<script type="text/javascript" src="../js/wowslider.js"></script>


<link rel="stylesheet" type="text/css" href="wowstyles.css" />


</head>

<body onload="window.setTimeout('ZeitAnzeigen(\'fr\')', 1000)">

<div id="display" class="touristbg_C4A">
    <div id="headline">
    	<div id="headcontainer">
			<div class="zeiticon"></div> 
			<div id="Uhr" class="time">&nbsp;</div>

            <div id="statuszeile" runat="server" style="font-size: 9px" visible="false">&nbsp;</div>
    	</div>
    </div>
    <br/><br/><br/><br/>
      	<div id="headlineelement" style="position: absolute; top:182px; left:43px;"><asp:Label runat="server" ID="choice"></asp:Label></div>
      	<div id="headlineelement" style="position: absolute; top:182px; left:668px;"><asp:Label runat="server" ID="ttheader"></asp:Label></div>
      	
      	      	<div id="Div1" style="position: absolute; top:238px; left:668px; "><asp:Label  width="275px" runat="server" ID="tt_description_1" style="line-height:20px"></asp:Label></div>
      	      	<div id="Div2" style="position: absolute; top:382px; left:668px; "><asp:Label width="275px" runat="server" ID="tt_description_2"></asp:Label></div>
      

    <br />
 <br />
  <br />
   <br />
<!-- Start WOWSlider.com BODY section --> <!-- add to the <body> of your page -->
	<div id="wowslider-container1" style="position:absolute; top:238px; left:40px">
	<div class="ws_images" ><ul>
		<li><img src="/img/allianz_arena_s.jpg" alt="allianz_arena_s" title="Allianz Arena" id="wows1_0" onclick="return wows1_0_onclick()" /></li>
		<li><img src="/img/alpenpanorama_s.jpg" alt="alpenpanorama_s" title="Alpenpanorama" id="wows1_1"/></li>
		<li><img src="/img/hofbraeuhaus_s.jpg" alt="full screen slider" title="Hofbräuhaus" id="wows1_2"/></li>
		<li><img src="/img/marienplatz_s.jpg" alt="marienplatz_s" title="Marienplatz" id="wows1_3"/></li>
	</ul></div>
	<div class="ws_bullets"><div>
		<a href="#" title="allianz_arena_s"><img src="/img/tooltips/allianz_arena_s.jpg" alt="allianz_arena_s"/>1</a>
		<a href="#" title="alpenpanorama_s"><img src="/img/tooltips/alpenpanorama_s.jpg" alt="alpenpanorama_s"/>2</a>
		<a href="#" title="hofbraeuhaus_s"><img src="/img/tooltips/hofbraeuhaus_s.jpg" alt="hofbraeuhaus_s"/>3</a>
		<a href="#" title="marienplatz_s"><img src="/img/tooltips/marienplatz_s.jpg" alt="marienplatz_s"/>4</a>
	</div></div>
	<div class="ws_shadow"></div>
	</div>	

	
<form id="form2" runat="server">


    <div id="footer">
    
    
    <a href="Default.aspx" class="button_eng_normal"><asp:Label runat="server" ID="cancelbutton"></asp:Label></a>
    

    <!--<a href="#" class="button-size-two button-stylegreen button-text buttonpadding floatright"><div id="buttonfeld">Bezahlen</div></a>-->
    </div>
</form>

</div>
    
</body>
</html>
