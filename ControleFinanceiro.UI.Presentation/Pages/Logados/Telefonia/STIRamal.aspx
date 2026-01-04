<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Logados/MasterPageMenu.Master"
    AutoEventWireup="true" CodeBehind="STIRamal.aspx.cs" Inherits="ControleFinanceiro.UI.Presentation.Pages.Logados.Telefonia.STIRamal" %>

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
                <asp:HiddenField ID="hdfIdCarteira" runat="server" />
            </td>
            <td>
                            Ramais Relacionados
                <hr />
            <asp:GridView ID="GdvSTIRamal" runat="server" AutoGenerateColumns="False" 
                    onpageindexchanging="GdvSTIRamal_PageIndexChanging" 
                    onrowcommand="GdvSTIRamal_RowCommand" 
                    onrowdatabound="GdvSTIRamal_RowDataBound">
            <Columns>
                <asp:ButtonField ButtonType="Image" CommandName="Alterar" HeaderText="#" ImageUrl="~/Imagens/Ico/grid_atualizar.png"
                    Text="Alterar" />
                <asp:ButtonField ButtonType="Image" CommandName="Excluir" HeaderText="#" ImageUrl="~/Imagens/Ico/grid_deletar.png"
                    Text="Excluir">
                    <ControlStyle Width="16px" />
                    <ItemStyle Height="16px" Width="16px" />
                </asp:ButtonField>
                <asp:BoundField DataField="Central" HeaderText="Central" />
                <asp:BoundField DataField="Ramal" HeaderText="Ramal" />
                <asp:BoundField DataField="IdCarteira" HeaderText="Carteira"/>
                <asp:BoundField DataField="Id" HeaderText="Cod.">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
                <asp:Button ID="BtnNovo" runat="server" CssClass="ButtonNovo" OnClick="BtnNovo_Click"/>
                <asp:ModalPopupExtender ID="Panel_Cadastro_ModalPopupExtender" runat="server" TargetControlID="BtnNovo"
                    CancelControlID="btCadastrar_Nao" BackgroundCssClass="modalBackground" Enabled="True"
                    PopupControlID="PanelAlterar">
                </asp:ModalPopupExtender>
                <asp:Panel ID="PanelAlterar" runat="server" Visible="true" CssClass="modalPopup">
                    Alterar Carteira
                    <hr />
                    <table>
                        <tr>
                            <td>
                                Central:
                            </td>
                            <td>
                                <asp:TextBox ID="txtCentral" runat="server" align="left"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Ramal:
                            </td>
                            <td>
                                <asp:TextBox ID="txtRamal" runat="server" align="left"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Andar:
                            </td>
                            <td>
                                <asp:TextBox ID="txtAndar" runat="server" align="left"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Sala:
                            </td>
                            <td>
                                <asp:TextBox ID="txtSala" runat="server" align="left"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 5px;" colspan="3">
                                <asp:Button ID="btCadastrar_Sim" runat="server" CssClass="ButtonSalvar" OnClick="btCadastrar_Sim_Click"
                                    Text="" Width="79px" />
                                <asp:Button ID="btCadastrar_Nao" runat="server" CssClass="ButtonCancelar" OnClick="btCadastrar_Nao_Click"
                                    Text="" ValidationGroup="Cancelar" Width="79px" />
                                <asp:HiddenField ID="hdfIdCadastro" runat="server" Value="-1" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
