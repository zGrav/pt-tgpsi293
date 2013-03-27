<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ShowFriends.aspx.cs" Inherits="Aula22_01.ShowFriends" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="id_request" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="id_request" HeaderText="id_request" InsertVisible="False" ReadOnly="True" SortExpression="id_request" />
            <asp:BoundField DataField="id_sender" HeaderText="id_sender" SortExpression="id_sender" />
            <asp:BoundField DataField="id_receiver" HeaderText="id_receiver" SortExpression="id_receiver" />
            <asp:BoundField DataField="time" HeaderText="time" SortExpression="time" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [friendlist] WHERE (([id_receiver] = @id_receiver) OR ([id_sender] = @id_sender))">
        <SelectParameters>
            <asp:SessionParameter Name="id_receiver" SessionField="ownID" Type="Int32" />
            <asp:SessionParameter Name="id_sender" SessionField="ownID" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="ID:"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Delete friend" />
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Return" />
</asp:Content>
