<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="monthly_ticket_spec.aspx.cs" Inherits="C4A_demo_2.monthly_ticket_spec" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    
    <asp:ScriptManager ID="sm" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
    <asp:Timer runat="server" ID="timeout_ticker" Interval="3000" 
    ontick="timeout_ticker_Tick"></asp:Timer>
    
    </div>
    </form>
</body>
</html>
