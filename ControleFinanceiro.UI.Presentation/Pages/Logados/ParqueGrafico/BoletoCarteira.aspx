<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Logados/MasterPageMenu.Master"
    AutoEventWireup="true" CodeBehind="BoletoCarteira.aspx.cs" Inherits="ControleFinanceiro.UI.Presentation.Pages.Logados.ParqueGrafico.BoletoCarteira" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ MasterType VirtualPath="~/Pages/Logados/MasterPageMenu.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <table width="100%" class="TabelaContent">
        <tr>
            <td>
                Selecione uma Carteira
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
                Alterar Carteira Boleto
                <hr />
                    <table width="600px">
                        <tr>
                            <td>
                                Carteira:
                            </td>
                            <td>
                                <asp:Label ID="lblCarteira" runat="server" align="left"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Credor:<br />
                                <asp:LinkButton ID="lkbDesSelecionarCredor" Text="Anular a Seleção" runat="server"
                                    OnClick="lkbDesSelecionarCredor_Click" ForeColor="LightGray" Font-Size="X-Small"></asp:LinkButton>
                            </td>
                            <td>
                                <asp:ListBox ID="lstCredor" runat="server" Width="450px" AutoPostBack="True" OnSelectedIndexChanged="lstCredor_SelectedIndexChanged"
                                    SelectionMode="Multiple" Height="138px"></asp:ListBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Segmento:<br />
                                <asp:LinkButton ID="lkbDesSelecionarSegmento" Text="Anular a Seleção" 
                                    runat="server" onclick="lkbDesSelecionarSegmento_Click" ForeColor="LightGray" Font-Size="X-Small"></asp:LinkButton>
                            </td>
                            <td>
                                <asp:ListBox ID="lstSegmento" runat="server" Width="450px" OnSelectedIndexChanged="lstSegmento_SelectedIndexChanged"
                                    SelectionMode="Multiple" AutoPostBack="True" Height="138px"></asp:ListBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Produto:<br />
                                <asp:LinkButton ID="lkbDesSelecionarProduto" Text="Anular a Seleção" 
                                    runat="server" onclick="lkbDesSelecionarProduto_Click" ForeColor="LightGray" Font-Size="X-Small"></asp:LinkButton>
                            </td>
                            <td>
                                <asp:ListBox ID="lstProduto" runat="server" Width="450px" SelectionMode="Multiple"
                                    Height="138px"></asp:ListBox>
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
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
