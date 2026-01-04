<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Logados/MasterPageMenu.Master"
    AutoEventWireup="true" CodeBehind="Carteira.aspx.cs" Inherits="ControleFinanceiro.UI.Presentation.Pages.Logados.Administrador.Carteira" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ MasterType VirtualPath="~/Pages/Logados/MasterPageMenu.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <table width="100%" class="TabelaContent">
        <tr>
            <td>
               Selecione um Grupo
                <hr />
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
            <td>
                <asp:Panel ID="PanelAlterar" runat="server" Visible="false" CssClass="PanelAlteracao">
                    Alterar Grupo
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
                                Obs.:
                            </td>
                            <td>
                                <asp:TextBox ID="txtObs" runat="server" align="left" TextMode="MultiLine" 
                                    Width="275px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Predio:
                            </td>
                            <td>
                                <asp:ListBox ID="lstPredio" runat="server" Height="38px" Width="272px">
                                    <asp:ListItem Value="19">Predio 19</asp:ListItem>
                                    <asp:ListItem Value="190">Predio 190</asp:ListItem>
                                </asp:ListBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Rateia?</td>
                            <td>
                                <asp:CheckBox ID="CbParticipaRateio" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>Tipo</td>
                            <td>
                                <asp:RadioButtonList ID="RBLTipo" runat="server">
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="btnSalvarAlteracao" runat="server" CssClass="ButtonSalvar" Width="48px"
                                    ToolTip="Salvar" OnClick="btnSalvarAlteracao_Click" />
                                <asp:HiddenField ID="hdfIdCarteira" runat="server" />
                            </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <br />
                    <br />
                    Cadastro SubGrupo
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
                                Obs.:
                            </td>
                            <td>
                                <asp:TextBox ID="txtSubObs" runat="server" align="left" TextMode="MultiLine" 
                                    Width="275px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Predio:
                            </td>
                            <td>
                                <asp:ListBox ID="lstSubPredio" runat="server" Height="38px" Width="272px">
                                    <asp:ListItem Value="19">Predio 19</asp:ListItem>
                                    <asp:ListItem Value="190">Predio 190</asp:ListItem>
                                </asp:ListBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Rateia?</td>
                            <td>
                                <asp:CheckBox ID="CbSubParticipaRateio" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Tipo</td>
                            <td>
                                <asp:RadioButtonList ID="RBLSubTipo" runat="server">
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="btnSalvar" runat="server" CssClass="ButtonSalvar" Width="48px" 
                                    ToolTip="Salvar" onclick="btnSalvar_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
