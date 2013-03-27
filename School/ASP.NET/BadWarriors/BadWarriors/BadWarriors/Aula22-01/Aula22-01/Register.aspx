<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Aula22_01.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Username:"></asp:Label>
&nbsp;<asp:TextBox ID="txtUsr" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsr" ErrorMessage="This field cannot be empty."></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label>
&nbsp;<asp:TextBox ID="txtPwd" runat="server" TextMode="Password"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPwd" ErrorMessage="This field cannot be empty."></asp:RequiredFieldValidator>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Email:"></asp:Label>
&nbsp;<asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail" ErrorMessage="This field cannot be empty."></asp:RequiredFieldValidator>
&nbsp;&nbsp;&nbsp;
    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Invalid e-mail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
    <br />
&nbsp;<br />
    <asp:Button ID="btnRegister" runat="server" onclick="btnRegister_Click" 
        Text="Register" />
    <br />
    <asp:Label ID="Label4" runat="server" Visible="False">Label</asp:Label>
</asp:Content>
