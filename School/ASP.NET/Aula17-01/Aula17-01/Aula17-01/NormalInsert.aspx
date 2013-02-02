<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NormalInsert.aspx.cs" Inherits="Aula17_01.NormalInsert" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Name:"></asp:Label>
<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
<br />
<asp:Label ID="Label2" runat="server" Text="Email:"></asp:Label>
<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
<br />
<asp:Label ID="Label3" runat="server" Text="User:"></asp:Label>
<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
<br />
<asp:Label ID="Label4" runat="server" Text="Pass:"></asp:Label>
<asp:TextBox ID="TextBox4" runat="server" TextMode="Password"></asp:TextBox>
<br />
<asp:Label ID="Label5" runat="server" 
    Text="Pic (please insert extension e.g .jpg):"></asp:Label>
<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
<br />
<br />
<asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Insert" />
<br />
</asp:Content>
