<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Logados/MasterPageMenu.Master" AutoEventWireup="true" CodeBehind="SegmentoCarteiraFiltros.aspx.cs" Inherits="ControleFinanceiro.UI.Presentation.Pages.Logados.Relatorios.SegmentoCarteiraFiltros" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ MasterType VirtualPath="~/Pages/Logados/MasterPageMenu.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function abrir_popup(url, title, w, h) {
            var left = (screen.width / 2) - (w / 2);
            var top = (screen.height / 2) - (h / 2);
            return window.open(url, title, 'toolbar=no, location=no, directories=no, status=yes, menubar=yes, scrollbars=yes, resizable=yes, copyhistory=no, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);
        }

        function mensagem_teste() {
            alert('Atendo o cliente de cpf');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    De:
                    <asp:TextBox ID="TbDe" runat="server"></asp:TextBox>
    Ate:
                    <asp:TextBox ID="TbAte" runat="server"></asp:TextBox>
    <hr />
    <table>
        <tr>
            <td>Receita Por:</td>
            <td>Despesa Por:</td>
        </tr>
        <tr>
            <td>    <asp:ListBox ID="lstReceita" runat="server">
        <asp:ListItem Value="0" Selected="True">Emissão</asp:ListItem>
        <asp:ListItem Value="1">Vencimento</asp:ListItem>
        <asp:ListItem Value="2">Pagamento</asp:ListItem>
    </asp:ListBox></td>
            <td>    <asp:ListBox ID="lstDespesa" runat="server">
        <asp:ListItem Value="0" Selected="True">Emissão</asp:ListItem>
        <asp:ListItem Value="1">Vencimento</asp:ListItem>
        <asp:ListItem Value="2">Pagamento</asp:ListItem>
    </asp:ListBox></td>
        </tr>
    </table>
    <hr />
    <table width="100%">
        <tr>
            <th>Segmento</th>
            <th>Carteira</th>
        </tr>
        <tr>
            <td>
                <asp:TreeView ID="trwSegmento" runat="server" ForeColor="White" ImageSet="Arrows"
                    OnSelectedNodeChanged="trwSegmento_SelectedNodeChanged" Width="100%">
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
            <td>
                <asp:TreeView ID="trwCarteira" runat="server" ForeColor="White" ImageSet="Arrows"
                    OnSelectedNodeChanged="trwCarteira_SelectedNodeChanged">
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
        </tr>
    </table>
</asp:Content>
