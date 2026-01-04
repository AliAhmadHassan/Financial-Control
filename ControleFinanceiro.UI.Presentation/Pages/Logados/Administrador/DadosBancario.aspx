<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Logados/MasterPageMenu.Master" AutoEventWireup="true" CodeBehind="DadosBancario.aspx.cs" Inherits="ControleFinanceiro.UI.Presentation.Pages.Logados.Administrador.DadosBancario" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ MasterType VirtualPath="~/Pages/Logados/MasterPageMenu.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <asp:GridView ID="GdvDadosBancario" runat="server" AutoGenerateColumns="False" OnRowDataBound="GdvDadosBancario_RowDataBound"
        OnRowCommand="GdvDadosBancario_RowCommand" 
        onpageindexchanging="GdvDadosBancario_PageIndexChanging">
        <Columns>
            <asp:ButtonField ButtonType="Image" CommandName="Alterar" HeaderText="#" ImageUrl="~/Imagens/Ico/grid_atualizar.png"
                Text="Alterar" />
            <asp:BoundField DataField="Descricao" HeaderText="Descrição" />
            <asp:BoundField DataField="Banco" HeaderText="Banco" />
            <asp:BoundField DataField="Agencia" HeaderText="Agencia" />
            <asp:BoundField DataField="ContaCorrente" HeaderText="Conta" />
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
            Cadastro de Dados Bancarios
        </div>
        <table width="100%">
            <tr>
                <td>
                    Banco:
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtBanco" MaxLength="5" title="Informe o numero do Banco"
                        ToolTip="Informe o numero do Banco"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Agencia:
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtAgencia" MaxLength="10" title="Informe o numero da Agencia"
                        ToolTip="Informe o numero da Agencia"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Conta:
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtContaCorrente" MaxLength="10" title="Informe o numero da Conta Corrente"
                        ToolTip="Informe o numero da Conta Corrente"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Descrição:
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtDescricao" MaxLength="150" title="Informe a descrição da conta"
                        ToolTip="Informe a descrição da conta"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Empresa</td>
                <td>
                    <asp:TextBox runat="server" ID="txtEmpresa" MaxLength="150" title="Informe a Empresa"
                        ToolTip="Informe a Empresa (Orcozol, Medina)"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                </td>
                <td style="height: 5px;">
                    <asp:HiddenField ID="IdCadastrar" runat="server" />
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
