<%@ Page Language="C#" AutoEventWireup="true" CodeFile="links.aspx.cs" Inherits="links" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>Calculadora</asp:ListItem>
            <asp:ListItem>Inicio</asp:ListItem>
            <asp:ListItem>Sobre</asp:ListItem>
            <asp:ListItem>Produtos</asp:ListItem>
        </asp:DropDownList>
    
    </div>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Goto" />
    </form>
</body>
</html>
