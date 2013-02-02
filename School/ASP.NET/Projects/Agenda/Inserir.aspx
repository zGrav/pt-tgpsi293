<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Inserir.aspx.cs" Inherits="Inserir" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
    .style1
    {
        width: 100%;
    }
    .style2
    {
        width: 59px;
    }
    .style3
    {
        width: 59px;
        height: 26px;
    }
    .style4
    {
        height: 26px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table class="style1">
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            <asp:Label ID="nomeLbl" runat="server" Text="Nome"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="nomeTxt" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            <asp:Label ID="emailLbl" runat="server" Text="Email"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="emailTxt" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:ListBox ID="pBox" runat="server" Width="182px"></asp:ListBox>
        </td>
        <td>
            <asp:Label ID="countLabel" runat="server" Text="Count: "></asp:Label>
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style3">
            <asp:Label ID="telLbl" runat="server" Text="Telefone"></asp:Label>
        </td>
        <td class="style4">
            <asp:TextBox ID="telTxt" runat="server"></asp:TextBox>
        </td>
        <td class="style4">
            </td>
        <td class="style4">
            </td>
        <td class="style4">
            </td>
        <td class="style4">
            </td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            <asp:Button ID="listBtn" runat="server" onclick="listBtn_Click" Text="Listar" />
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            <asp:TextBox ID="pesTxt" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            <asp:Button ID="btnApagar" runat="server" onclick="btnApagar_Click" 
                Text="Apagar" />
        </td>
        <td>
            <asp:Button ID="pesBtn" runat="server" onclick="pesBtn_Click" 
                Text="Pesquisar" />
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            <asp:Button ID="editBtn" runat="server" onclick="editBtn_Click" Text="Editar" />
        </td>
        <td>
            <asp:Label ID="pesLabel" runat="server"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            <asp:Button ID="insBtn" runat="server" Text="Inserir" onclick="insBtn_Click" />
        </td>
        <td>
            &nbsp;</td>
        <td>
            <asp:Button ID="saveBtn" runat="server" onclick="saveBtn_Click" 
                Text="Guardar editar" />
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            <asp:Button ID="ordBtn" runat="server" onclick="ordBtn_Click" Text="Ordenar" />
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>

