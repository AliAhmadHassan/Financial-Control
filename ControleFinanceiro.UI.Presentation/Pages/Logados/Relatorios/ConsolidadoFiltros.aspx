<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Logados/MasterPageMenu.Master"
    AutoEventWireup="true" CodeBehind="ConsolidadoFiltros.aspx.cs" Inherits="ControleFinanceiro.UI.Presentation.Pages.Logados.Relatorios.Consolidado.ConsolidadoFiltros" %>

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
                <td style="vertical-align: top;">Selecione uma Carteira
                    <hr />
                    <asp:TreeView ID="trwCarteira" runat="server" ForeColor="White" ImageSet="Arrows"
                        OnSelectedNodeChanged="trwCarteira_SelectedNodeChanged" OnTreeNodeDataBound="trwCarteira_TreeNodeDataBound">
                        <HoverNodeStyle Font-Underline="True" ForeColor="#CCCCCC" />
                        <LeafNodeStyle ForeColor="#CCCCCC" />
                        <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="White" HorizontalPadding="5px"
                            NodeSpacing="0px" VerticalPadding="0px" />
                        <ParentNodeStyle Font-Bold="False" ForeColor="White" />
                        <RootNodeStyle ForeColor="White" />
                        <SelectedNodeStyle Font-Underline="True" ForeColor="#0ef5d1" HorizontalPadding="0px"
                            VerticalPadding="0px" />
                    </asp:TreeView>
                </td>
                <td style="vertical-align: top;">Selecione os Mêses para Consulta
                    <hr />
                    De:
                    <asp:TextBox ID="TbDe" runat="server"></asp:TextBox>
                    Ate:
                    <asp:TextBox ID="TbAte" runat="server"></asp:TextBox>
                    <hr />
                    Receita Por:
                    <hr />
                    <asp:ListBox ID="lstReceita" runat="server">
                        <asp:ListItem Value="0" Selected="True">Emissão</asp:ListItem>
                        <asp:ListItem Value="1">Vencimento</asp:ListItem>
                        <asp:ListItem Value="2">Pagamento</asp:ListItem>
                    </asp:ListBox>
                    <hr />
                    Despesa Por:
                    <hr />
                    <asp:ListBox ID="lstDespesa" runat="server">
                        <asp:ListItem Value="0" Selected="True">Emissão</asp:ListItem>
                        <asp:ListItem Value="1">Vencimento</asp:ListItem>
                        <asp:ListItem Value="2">Pagamento</asp:ListItem>
                    </asp:ListBox>
                    <hr />
                    Dedutivel
                    <hr />
                    <asp:ListBox ID="lstDedutivel" runat="server">
                        <asp:ListItem Value="-1" Selected="True">Indiferente</asp:ListItem>
                        <asp:ListItem Value="0">Não</asp:ListItem>
                        <asp:ListItem Value="1">Sim</asp:ListItem>
                    </asp:ListBox>
                    <hr />
                    Dados Bancario
                    <hr />
                    <asp:ListBox ID="lstDadosBancario" runat="server" Width="400px" SelectionMode="Multiple" Height="211px"></asp:ListBox>
                    <hr />
                    <asp:HiddenField ID="hdfCarteira" runat="server" />
                    <asp:Button ID="btnGerarRelatorio" Text="Gerar Relatorio" runat="server" OnClick="btnGerarRelatorio_Click" />
                    <hr />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
