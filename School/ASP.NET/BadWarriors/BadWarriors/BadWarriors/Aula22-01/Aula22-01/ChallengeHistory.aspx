<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ChallengeHistory.aspx.cs" Inherits="Aula22_01.ChallengeHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id_challenge" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True">
        <Columns>
            <asp:BoundField DataField="id_challenge" HeaderText="id_challenge" InsertVisible="False" ReadOnly="True" SortExpression="id_challenge" />
            <asp:BoundField DataField="id_challenger" HeaderText="id_challenger" SortExpression="id_challenger" />
            <asp:BoundField DataField="id_challenged" HeaderText="id_challenged" SortExpression="id_challenged" />
            <asp:BoundField DataField="time" HeaderText="time" SortExpression="time" />
            <asp:BoundField DataField="win" HeaderText="win" SortExpression="win" />
            <asp:BoundField DataField="loss" HeaderText="loss" SortExpression="loss" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [challenges] WHERE ([id_challenger] = @id_challenger)">
        <SelectParameters>
            <asp:SessionParameter Name="id_challenger" SessionField="ownID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Return" />
</asp:Content>
