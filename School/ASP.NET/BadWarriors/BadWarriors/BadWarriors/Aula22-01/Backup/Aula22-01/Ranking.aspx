<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Ranking.aspx.cs" Inherits="Aula22_01.Ranking" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
        AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="username" HeaderText="username" 
                SortExpression="username" />
            <asp:BoundField DataField="hp" HeaderText="hp" SortExpression="hp" />
            <asp:BoundField DataField="money" HeaderText="money" SortExpression="money" />
            <asp:BoundField DataField="attack" HeaderText="attack" 
                SortExpression="attack" />
            <asp:BoundField DataField="defense" HeaderText="defense" 
                SortExpression="defense" />
            <asp:BoundField DataField="wins" HeaderText="wins" SortExpression="wins" />
            <asp:BoundField DataField="losses" HeaderText="losses" 
                SortExpression="losses" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        SelectCommand="SELECT [username], [hp], [money], [attack], [defense], [wins], [losses] FROM [users]">
    </asp:SqlDataSource>
    <br />
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Return" />
</asp:Content>
