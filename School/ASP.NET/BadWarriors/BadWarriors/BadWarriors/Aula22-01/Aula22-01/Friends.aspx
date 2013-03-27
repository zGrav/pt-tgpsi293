<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Friends.aspx.cs" Inherits="Aula22_01.Friends" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Enter user name to befriend:"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    &nbsp;<br />
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
        Text="Add" />
    &nbsp;&nbsp;<asp:Button ID="Button3" runat="server" Text="Show friends" OnClick="Button3_Click" />
    &nbsp;
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Return" />
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Label" Visible="False"></asp:Label>
    <br />
</asp:Content>
