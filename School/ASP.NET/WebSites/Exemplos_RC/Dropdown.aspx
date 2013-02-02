<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Dropdown.aspx.cs" Inherits="Dropdown" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
 <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>Calculadora</asp:ListItem>
            <asp:ListItem>Inicio</asp:ListItem>
            <asp:ListItem>Sobre</asp:ListItem>
            <asp:ListItem>Produtos</asp:ListItem>
        </asp:DropDownList>
        
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Goto" />
</asp:Content>

