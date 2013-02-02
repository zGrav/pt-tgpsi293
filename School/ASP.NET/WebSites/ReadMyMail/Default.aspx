<%@ Page Title="Read My Mail - Main Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Login (only working with Gmail POP at the moment.)</h2>
<p>
        <asp:Label ID="emailLabel" runat="server" Text="Email:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="emailTxt" runat="server"></asp:TextBox>
</p>
<p>
        <asp:Label ID="pwdLabel" runat="server" Text="Password:"></asp:Label>
&nbsp;<asp:TextBox ID="pwdTxt" runat="server" TextMode="Password"></asp:TextBox>
</p>
    <p>
        <asp:Button ID="loginBtn" runat="server" OnClick="loginBtn_Click" Text="Login" />
</p>
    <p>
        <asp:Button ID="expBtn" runat="server" OnClick="expBtn_Click" Text="Expand for more options" />
</p>
    <asp:Panel ID="Panel1" runat="server" Visible="False">
        <asp:Label ID="typeLbl" runat="server" Text="Server type:"></asp:Label>
        &nbsp;<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem>POP</asp:ListItem>
            <asp:ListItem>IMAP</asp:ListItem>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="popsvLbl" runat="server" Text="Server:"></asp:Label>
        &nbsp;<asp:TextBox ID="popsvTxt" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="popportLbl" runat="server" Text="Port:"></asp:Label>
        &nbsp;<asp:TextBox ID="popportTxt" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="smtpserverLbl" runat="server" Text="SMTP Server:"></asp:Label>
        &nbsp;<asp:TextBox ID="smtpsvTxt" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="smtpportLbl" runat="server" Text="SMTP Port:"></asp:Label>
        &nbsp;<asp:TextBox ID="smtpportTxt" runat="server"></asp:TextBox>
    </asp:Panel>
    <p>
    </p>
</asp:Content>
