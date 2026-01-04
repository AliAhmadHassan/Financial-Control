<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Logados/MasterPageMenu.Master" 
    AutoEventWireup="true" CodeBehind="FechamentoFiltros.aspx.cs" Inherits="ControleFinanceiro.UI.Presentation.Pages.Logados.Relatorios.FechamentoFiltros" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ MasterType VirtualPath="~/Pages/Logados/MasterPageMenu.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script type="text/javascript">
            function abrir_popup(url, title, w, h) {
                var left = (screen.width / 2) - (w / 2);
                var top = (screen.height / 2) - (h / 2);
                return window.open(url, title, 'toolbar=no, location=no, directories=no, status=yes, menubar=yes, scrollbars=yes, resizable=yes, copyhistory=no, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);
            }

            function mensagem_teste(cpf) {
                alert('Atendo o cliente de cpf ' + cpf);
            }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Panel ID="Conteudo" runat="server">
        <table width="100%" class="TabelaContent">
            <tr>
                <td style="vertical-align: top;">Selecione Mês para relatorio:
                    <asp:DropDownList ID="ddlReferencia" runat="server" Width="190px">
                    </asp:DropDownList>
                    &nbsp;<hr />
                    <br />
                    <asp:Button ID="btnGerarRelatorio" runat="server" Text="Gerar Relatorio" OnClick="btnGerarRelatorio_Click" />
                    <hr />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
