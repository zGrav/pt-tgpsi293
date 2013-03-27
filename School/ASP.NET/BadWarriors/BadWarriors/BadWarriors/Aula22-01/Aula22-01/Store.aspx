<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Store.aspx.cs" Inherits="Aula22_01.Store" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="id" DataSourceID="SqlDataSource1" 
        onselectedindexchanged="GridView1_SelectedIndexChanged">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" 
                ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
            <asp:BoundField DataField="price" HeaderText="price" SortExpression="price" />
            <asp:BoundField DataField="attack" HeaderText="attack" 
                SortExpression="attack" />
            <asp:BoundField DataField="defense" HeaderText="defense" 
                SortExpression="defense" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
        SelectCommand="SELECT * FROM [store] WHERE ([id] &gt; @id)">
        <SelectParameters>
            <asp:Parameter DefaultValue="1" Name="id" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
    <asp:Label ID="Label1" runat="server" Text="Name:"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
    &nbsp;<br />
    <asp:Label ID="Label2" runat="server" Text="Attack:"></asp:Label>
    <asp:TextBox ID="TextBox2" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Defense:"></asp:Label>
    <asp:TextBox ID="TextBox3" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Price:"></asp:Label>
    <asp:TextBox ID="TextBox4" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
    <br />
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Buy" />
    <br />
    <br />
    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Return" />
    <br />
    <br />
    <asp:Label ID="Label5" runat="server" Text="Label" Visible="False"></asp:Label>
</asp:Content>
