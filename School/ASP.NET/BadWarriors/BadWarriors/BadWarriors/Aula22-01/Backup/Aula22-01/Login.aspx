<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Aula22_01.Main" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<p>
    <asp:Label ID="Label1" runat="server" Text="Username:"></asp:Label>
&nbsp;<asp:TextBox ID="txtUsr" runat="server"></asp:TextBox>
</p>
<p>
    Password:
    <asp:TextBox ID="txtPwd" runat="server" TextMode="Password"></asp:TextBox>
</p>
<p>
    <asp:Button ID="btnLogin" runat="server" Text="Login" 
        onclick="btnLogin_Click" />
</p>
    <p>
        <asp:Label ID="Label2" runat="server"></asp:Label>
</p>
</asp:Content>
