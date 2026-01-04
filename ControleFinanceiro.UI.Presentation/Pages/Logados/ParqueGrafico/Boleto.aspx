<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Logados/MasterPageMenu.Master"
    AutoEventWireup="true" CodeBehind="Boleto.aspx.cs" Inherits="ControleFinanceiro.UI.Presentation.Pages.Logados.ParqueGrafico.Boleto" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ MasterType VirtualPath="~/Pages/Logados/MasterPageMenu.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="TabelaContent" style="min-height: 600px;">
        <b>Mês: </b>
        <asp:DropDownList ID="ddlMes" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMes_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:GridView ID="GdvBoleto" runat="server" AutoGenerateColumns="False" OnRowDataBound="GdvBoleto_RowDataBound"
            OnRowCommand="GdvBoleto_RowCommand" OnPageIndexChanging="GdvBoleto_PageIndexChanging">
            <Columns>
                <asp:ButtonField ButtonType="Image" CommandName="Alterar" HeaderText="#" ImageUrl="~/Imagens/Ico/grid_atualizar.png"
                    Text="Alterar" />
                <asp:ButtonField ButtonType="Image" CommandName="Excluir" HeaderText="#" ImageUrl="~/Imagens/Ico/grid_deletar.png"
                    Text="Excluir">
                    <ControlStyle Width="16px" />
                    <ItemStyle Height="16px" Width="16px" />
                </asp:ButtonField>
                <asp:BoundField DataField="IdCarteira" HeaderText="Carteira" />
                <asp:BoundField DataField="Quantidade" HeaderText="Quantidade" DataFormatString="{0:N0}">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="IdUsuario" HeaderText="Usuario">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="IdTipoPostagem" HeaderText="Tipo Postagem">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="Id" HeaderText="Cod.">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        <br />
        <asp:Button ID="BtnNovo" runat="server" CssClass="ButtonNovo" OnClick="BtnNovo_Click" />
        <asp:Button ID="BtnImportar" runat="server" CssClass="ButtonImportar" OnClick="BtnImportar_Click" />
        <asp:ModalPopupExtender ID="Panel_Importar_ModalPopupExtender" runat="server" TargetControlID="BtnImportar"
            CancelControlID="btCadastrar_Nao" BackgroundCssClass="modalBackground" Enabled="True"
            PopupControlID="Panel_Importar">
        </asp:ModalPopupExtender>
        <asp:ModalPopupExtender ID="Panel_Cadastro_ModalPopupExtender" runat="server" TargetControlID="BtnNovo"
            CancelControlID="btCadastrar_Nao" BackgroundCssClass="modalBackground" Enabled="True"
            PopupControlID="Panel_Cadastro">
        </asp:ModalPopupExtender>
        <asp:Panel runat="server" ID="Panel_Cadastro" Visible="true" CssClass="modalPopup">
            <table>
                <tr>
                    <td>
                        Carteira
                    </td>
                    <td>
                        <asp:ListBox ID="lstCarteira" runat="server" Width="500px"></asp:ListBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Carteira
                    </td>
                    <td>
                        <asp:TextBox ID="txtQuantidade" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="BtnCadastroSim" runat="server" CssClass="ButtonSalvar" Text="" 
                            Width="79px" onclick="BtnCadastroSim_Click" />
                        <asp:Button ID="BtnCadastroNão" runat="server" CssClass="ButtonCancelar" Text="" ValidationGroup="Cancelar" Width="79px" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel runat="server" ID="Panel_Importar" Visible="true" CssClass="modalPopup">
            <table>
                <tr>
                    <td colspan="4">
                        Franquia
                    </td>
                </tr>
                <tr>
                    <td>
                        De:
                    </td>
                    <td>
                        <asp:TextBox ID="txtFranquiaDe" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Ate:
                    </td>
                    <td>
                        <asp:TextBox ID="txtFranquiaAte" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        FAC
                    </td>
                </tr>
                <tr>
                    <td>
                        De:
                    </td>
                    <td>
                        <asp:TextBox ID="txtFacDe" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        Ate:
                    </td>
                    <td>
                        <asp:TextBox ID="txtFacAte" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="height: 5px;" colspan="3">
                        <asp:HiddenField ID="IdCadastrar" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="height: 5px;" colspan="3">
                        <asp:Button ID="btCadastrar_Sim" runat="server" CssClass="ButtonSalvar" OnClick="btCadastrar_Sim_Click"
                            Text="" Width="79px" />
                        <asp:Button ID="btCadastrar_Nao" runat="server" CssClass="ButtonCancelar" OnClick="btCadastrar_Nao_Click"
                            Text="" ValidationGroup="Cancelar" Width="79px" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
        
    </div>
</asp:Content>
