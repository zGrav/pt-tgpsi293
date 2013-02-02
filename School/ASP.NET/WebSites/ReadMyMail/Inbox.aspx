<%@ Page Title="Read My Mail - Inbox" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Inbox.aspx.cs" Inherits="Inbox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <div>
		<asp:Table ID="mailTable" CssClass="mail-table" runat="server">
		<asp:TableHeaderRow>
			<asp:TableHeaderCell CssClass="mail-table-header"
				ColumnSpan="4">Listing mails 
			<asp:Literal ID="mailFrom" runat="server" />-
			<asp:Literal ID="mailTo" runat="server" /> of 
			<asp:Literal ID="mailTotal" runat="server" /> for 
			<asp:Literal ID="getownMail" runat="server" />
			</asp:TableHeaderCell></asp:TableHeaderRow><asp:TableRow>
			<asp:TableCell CssClass="mail-table-header-cell">
				#</asp:TableCell><asp:TableCell CssClass="mail-table-header-cell">
				From</asp:TableCell><asp:TableCell CssClass="mail-table-header-cell">
				Subject</asp:TableCell><asp:TableCell CssClass="mail-table-header-cell">
				Date &amp; Time</asp:TableCell></asp:TableRow><asp:TableFooterRow>
			<asp:TableCell CssClass="mail-table-footer" ColumnSpan="4">
			<asp:Table ID="FooterTable" Width="100%"
				BorderWidth="0" runat="server">
			<asp:TableRow>
			<asp:TableCell>
				<asp:Literal ID="previousPage" runat="server" />
			</asp:TableCell>
			<asp:TableCell HorizontalAlign="Right">
				<asp:Literal ID="nextPage" runat="server" />
			</asp:TableCell>
			</asp:TableRow>
			</asp:Table>
			</asp:TableCell></asp:TableFooterRow></asp:Table></div></asp:Content>