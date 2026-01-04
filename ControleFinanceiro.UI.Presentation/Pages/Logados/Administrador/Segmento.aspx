<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Logados/MasterPageMenu.Master"
    AutoEventWireup="true" CodeBehind="Segmento.aspx.cs" Inherits="ControleFinanceiro.UI.Presentation.Pages.Logados.Administrador.Segmento" %>

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
    <br />
    <table width="100%" class="TabelaContent">
        <tr>
            <td style="height: 100%; width:50%;">
                Selecione um Segmento
                <hr />
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
            <td style="height: 100%; width:50%;">
                <asp:Panel ID="PanelAlterar" runat="server" Visible="false" CssClass="PanelAlteracao">
                    Alterar Segmento
                    <hr />
                    <table width="300px">
                        <tr>
                            <td>
                                Descrição:
                            </td>
                            <td>
                                <asp:TextBox ID="txtDescricao" runat="server" align="left"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Tipo.:
                            </td>
                            <td>
                                <asp:ListBox ID="lstTipoSegmento" runat="server" Width="225px"></asp:ListBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Fechamento</td>
                            <td>
                                <asp:RadioButtonList ID="RBLTipoDespesa" runat="server">
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="btnSalvarAlteracao" runat="server" CssClass="ButtonSalvar" Width="48px"
                                    ToolTip="Salvar" OnClick="btnSalvarAlteracao_Click" />
                                <asp:Button ID="btnOrcamento" runat="server" OnClick="btnOrcamento_Click" Text="Orçamento" />
                                <asp:HiddenField ID="hdfIdsegmento" runat="server" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <br />
                    <br />
                    Cadastro SubSegmento
                    <hr />
                    <table width="300px">
                        <tr>
                            <td>
                                Descrição:
                            </td>
                            <td>
                                <asp:TextBox ID="txtSubDescricao" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Tipo.:
                            </td>
                            <td>
                                <asp:ListBox ID="lstSubTipoSegmento" runat="server" Width="225px"></asp:ListBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Fechamento</td>
                            <td>
                                <asp:RadioButtonList ID="RBLSubTipoDespesa" runat="server">
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="btnSalvar" runat="server" CssClass="ButtonSalvar" Width="48px" ToolTip="Salvar"
                                    OnClick="btnSalvar_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
