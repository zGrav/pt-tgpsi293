<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Aula22_01.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Username:"></asp:Label>
&nbsp;<asp:TextBox ID="txtUsr" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label>
&nbsp;<asp:TextBox ID="txtPwd" runat="server" TextMode="Password"></asp:TextBox>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Email:"></asp:Label>
&nbsp;<asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
&nbsp;//todo validations<br />
&nbsp;<br />
    <asp:Button ID="btnRegister" runat="server" onclick="btnRegister_Click" 
        Text="Register" />
    <br />
    <asp:Label ID="Label4" runat="server" Visible="False"></asp:Label>
</asp:Content>
