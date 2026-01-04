<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Logados/MasterPageMenu.Master"
    AutoEventWireup="true" CodeBehind="ImportarSalarios.aspx.cs" Inherits="ControleFinanceiro.UI.Presentation.Pages.Logados.RecursosHumanos.ImportarSalarios" %>

<%@ MasterType VirtualPath="~/Pages/Logados/MasterPageMenu.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <table>
        <tr>
            <td>
                Arquivo xlsx:
            </td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" Width="100%" />
            </td>
        </tr>
        <tr>
            <td>
                Descrição
            </td>
            <td>
                <asp:TextBox ID="txtDescricao" runat="server" Height="40px" TextMode="MultiLine"
                    Width="394px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Emissão
            </td>
            <td>
                <asp:TextBox ID="txtEmissao" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Vencimento
            </td>
            <td>
                <asp:TextBox ID="txtVencimento" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Data Pgto.
            </td>
            <td>
                <asp:TextBox ID="txtDtPgto" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Fornecedor
            </td>
            <td>
                <asp:ListBox ID="lstFornecedor" runat="server" Width="400px"></asp:ListBox>
            </td>
        </tr>
        <tr>
            <td>
                Dados Bancario
            </td>
            <td>
                <asp:ListBox ID="lstDadosBancario" runat="server" Width="400px"></asp:ListBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Button ID="BtnCadastroSalvar" runat="server" CssClass="ButtonSalvar" Text=""
                    Width="79px" OnClick="BtnCadastroSalvar_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
