<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Eventos.aspx.cs" Inherits="Eventos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;&nbsp;<br />
    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem>+</asp:ListItem>
        <asp:ListItem>-</asp:ListItem>
        <asp:ListItem>*</asp:ListItem>
        <asp:ListItem>/</asp:ListItem>
    </asp:DropDownList>
    <br />
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
&nbsp;<br />
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
        Text="Calcula" />
    <br />
    <br />
    <asp:TextBox ID="TextBox3" runat="server" ReadOnly="True"></asp:TextBox>
    </asp:Content>

