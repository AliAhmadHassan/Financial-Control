<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Logados/MasterPageMenu.Master" AutoEventWireup="true" CodeBehind="Fornecedor.aspx.cs" Inherits="ControleFinanceiro.UI.Presentation.Pages.Logados.Administrador.Fornecedor" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ MasterType VirtualPath="~/Pages/Logados/MasterPageMenu.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:GridView ID="GdvFornecedor" runat="server" AutoGenerateColumns="False" OnRowDataBound="GdvFornecedor_RowDataBound"
        OnRowCommand="GdvFornecedor_RowCommand" 
        onpageindexchanging="GdvFornecedor_PageIndexChanging">
        <Columns>
            <asp:ButtonField ButtonType="Image" CommandName="Alterar" HeaderText="#" ImageUrl="~/Imagens/Ico/grid_atualizar.png"
                Text="Alterar" />
            <asp:ButtonField ButtonType="Image" CommandName="Excluir" HeaderText="#" ImageUrl="~/Imagens/Ico/grid_deletar.png"
                Text="Excluir">
                <ControlStyle Width="16px" />
                <ItemStyle Height="16px" Width="16px" />
            </asp:ButtonField>
            <asp:BoundField DataField="Nome" HeaderText="Nome" />
            <asp:BoundField DataField="CNPJ" HeaderText="CNPJ" />
            <asp:BoundField DataField="Id" HeaderText="Cod." />
        </Columns>
    </asp:GridView>
    <br />
    <asp:Button ID="BtnNovo" runat="server" CssClass="ButtonNovo" OnClick="BtnNovo_Click" />
    <asp:ModalPopupExtender ID="Panel_Cadastrar_ModalPopupExtender" runat="server" TargetControlID="BtnNovo"
        CancelControlID="btCadastrar_Nao" BackgroundCssClass="modalBackground" Enabled="True"
        PopupControlID="Panel_Cadastrar">
    </asp:ModalPopupExtender>
    <asp:Panel runat="server" ID="Panel_Cadastrar" Visible="true" CssClass="modalPopup">
        <div class="header_popup">
            Cadastro de Usuario
        </div>
        <table width="100%" style>
            <tr>
                <td>
                    Nome:
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtNome" MaxLength="150" title="Informe o Nome do Usuario"
                        ToolTip="Informe o Nome do Usuario"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rvNome" runat="server" ControlToValidate="txtNome"
                        Display="Dynamic" ErrorMessage="*Favor preencher o Nome do Fornecedor" ForeColor="#CC3300"
                        Font-Bold="False" Font-Italic="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    CNPJ:
                </td>
                <td>
                    <asp:TextBox ID="txtCNPJ" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td style="height: 5px;">
                    <asp:HiddenField ID="IdCadastrar" runat="server" Value="-1" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;
                </td>
                <td style="height: 5px;">
                    <asp:Button ID="btCadastrar_Sim" runat="server" CssClass="ButtonSalvar" OnClick="btCadastrar_Sim_Click"
                        Text="" Width="79px" />
                    <asp:Button ID="btCadastrar_Nao" runat="server" CssClass="ButtonCancelar" OnClick="btCadastrar_Nao_Click"
                        Text="" ValidationGroup="Cancelar" Width="79px" />
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
