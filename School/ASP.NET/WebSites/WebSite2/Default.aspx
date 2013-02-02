<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pagina Inicial</title>
    <style type="text/css">
        .style1
        {
            height: 23px;
        }
        .style2
        {
            height: 23px;
            width: 415px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal">
            <Items>
                <asp:MenuItem NavigateUrl="Default.aspx" Text="Inicio" Value="Inicio">
                </asp:MenuItem>
                <asp:MenuItem NavigateUrl="Calculadora.aspx" Text="Calculadora" 
                    Value="Calculadora"></asp:MenuItem>
                <asp:MenuItem NavigateUrl="Produtos.aspx" Text="Produtos" Value="Produtos">
                    <asp:MenuItem Text="Processadores" Value="Processadores"></asp:MenuItem>
                    <asp:MenuItem Text="Discos" Value="Discos"></asp:MenuItem>
                    <asp:MenuItem Text="Memorias" Value="Memorias"></asp:MenuItem>
                </asp:MenuItem>
                <asp:MenuItem NavigateUrl="Sobre.aspx" Text="Sobre" Value="Sobre">
                </asp:MenuItem>
                <asp:MenuItem NavigateUrl="links.aspx" Text="Links" Value="Links">
                </asp:MenuItem>
            </Items>
            <StaticHoverStyle BackColor="Black" />
        </asp:Menu>
        <br />
    
        <table align="center" style="width:100%;">
            <tr>
                <td align="center" class="style1">
                    <a href="Default.aspx">Inicio</a></td>
                <td align="center">
                  <a href="Calculadora.aspx">Calculadora</a></td>
                <td align="center" class="style2">
                    <a href="Produtos.aspx">Produtos</a></td>
                <td align="center" class="style1">
                    <a href="Sobre.aspx">Sobre</a></td>
            </tr>
        </table>
    
    <h1 align="center">Inicio</h1>

    </div>
    </form>
</body>
</html>
