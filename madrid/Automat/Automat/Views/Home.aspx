﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <link href="../StyleSheet8.css" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Startseite</title>
</head>
<body class="colorYellowBlack bigFontSize">
   <form id="form1" runat="server">
       
       <div>
           <p>
               Bitte scannen Sie Ihren Code ein!
           </p>

           <asp:Button ID="ButtonScan"
               runat="server"
               onclick="ButtonScan_Click"
               Text="Scan" 
               class="bigButton">
           </asp:Button>

       </div>
       
       <div>
           <p> Ihr Code lautet:</p>
           <asp:Label ID="Label2"
               runat="server" Text="">
           </asp:Label>
       </div>

   </form>
</body>
</html>
