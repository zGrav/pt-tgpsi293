<%@ Page Title="Read My Mail - Compose Mail" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Compose.aspx.cs" Inherits="Compose" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="style1">
        <tr>
            <td>
                <asp:Label ID="toLbl" runat="server" Text="To:"></asp:Label>
&nbsp;<asp:TextBox ID="toTxt" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="subLbl" runat="server" Text="Subject:"></asp:Label>
&nbsp;<asp:TextBox ID="subTxt" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="mesLbl" runat="server" Text="Message:"></asp:Label>
                <br />
                <asp:TextBox ID="mesTxt" runat="server" Height="100%" style="margin-left: 0px" 
                    TextMode="MultiLine" Width="100%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="sendBtn" runat="server" onclick="sendBtn_Click" Text="Send" UseSubmitBehavior="False" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="statusLbl" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

