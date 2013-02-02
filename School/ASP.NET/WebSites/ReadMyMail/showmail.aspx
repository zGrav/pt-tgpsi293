<%@ Page Title="ReadMyMail - Currently reading a email" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="showmail.aspx.cs" Inherits="showmail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Literal ID="DebugLiteral" runat="server" />
    
    <table class="read-table">
    <tr>
		<td class="read-table-header" colspan="2">
		Email #<asp:Literal ID="mailIDL" runat="server" /></td>
    </tr>
    <tr>
		<td class="read-table-header-cell">Date &amp; Time</td>
		<td class="read-table-cell">
			<asp:Literal ID="Date" runat="server" /></td>
    </tr>
    <tr>
		<td class="read-table-header-cell">From</td>
		<td class="read-table-cell">
			<asp:Literal ID="From" runat="server" /></td>
    </tr>
    <tr>
		<td class="read-table-header-cell">Subject</td>
		<td class="read-table-cell">
			<asp:Literal ID="Subject" runat="server" /></td>
    </tr>
    <tr id="attachementSection" runat="server">
		<td class="read-table-header-cell">Attachments</td>
		<td class="read-table-cell">
			<asp:Literal ID="Attachments" runat="server" /></td>
    </tr>
     <tr>
		<td class="read-table-cell" colspan="2">
			<asp:Literal ID="Headers" runat="server" /></td>
    </tr>
    <tr>
		<td class="read-table-cell" colspan="2">
			<asp:Literal ID="Body" runat="server" /></td>
    </tr>
    </table>
</asp:Content>

