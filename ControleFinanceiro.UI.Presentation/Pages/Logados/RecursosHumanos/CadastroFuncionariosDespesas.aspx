<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Logados/MasterPageMenu.Master"
    AutoEventWireup="true" CodeBehind="CadastroFuncionariosDespesas.aspx.cs" Inherits="ControleFinanceiro.UI.Presentation.Pages.Logados.RecursosHumanos.CadastroFuncionariosDespesas" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ MasterType VirtualPath="~/Pages/Logados/MasterPageMenu.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="TabelaContent">
        <asp:GridView ID="GdvUsuario" runat="server" AutoGenerateColumns="False" OnRowDataBound="GdvUsuario_RowDataBound"
            OnRowCommand="GdvUsuario_RowCommand" 
            onpageindexchanging="GdvUsuario_PageIndexChanging">
            <Columns>
                <asp:ButtonField ButtonType="Image" CommandName="Alterar" HeaderText="#" ImageUrl="~/Imagens/Ico/grid_atualizar.png"
                    Text="Alterar" />
                <asp:BoundField DataField="Cargo" HeaderText="Cargo" />
                <asp:BoundField DataField="Nome" HeaderText="Nome" />
                <asp:BoundField DataField="Matricula" HeaderText="Matricula" />
                <asp:BoundField DataField="Adimissao" HeaderText="Adimissão" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="IdCarteira" HeaderText="Carteira" />
                <asp:BoundField DataField="Id" HeaderText="Cod." />
            </Columns>
        </asp:GridView>
        <asp:Button ID="BtnNovo" runat="server" CssClass="ButtonNovo" 
            OnClick="BtnNovo_Click" Enabled="False" />
        <asp:ModalPopupExtender ID="Panel_Cadastrar_ModalPopupExtender" runat="server" TargetControlID="BtnNovo"
            CancelControlID="btCadastrar_Nao" BackgroundCssClass="modalBackground" Enabled="True"
            PopupControlID="Panel_Cadastrar">
        </asp:ModalPopupExtender>
        <asp:Panel runat="server" ID="Panel_Cadastrar" Visible="true" CssClass="modalPopup">
            <div class="header_popup">
                Cadastro de Despesa
            </div>
            <table width="100%">
                <tr>
                    <td>
                        Salario:
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtSalario" title="Informe Salario do Funcionario"
                            ToolTip="Informe Salario do Funcionario"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        AjudaCusto:
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtAjudaCusto" title="Informe o Valor da Ajuda de Custo"
                            ToolTip="Informe o Valor da Ajuda de Custo"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Ferias:
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtFerias" title="Informe o Valor das Ferias" ToolTip="Informe o Valor das Ferias"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        13º Salario:
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtDecimoTerceiro" title="Informe o Valor de 13º" ToolTip="Informe o Valor de 13º"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        FGTS:
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtFGTS" title="Informe o Valor de FGTS" ToolTip="Informe o Valor de FGTS"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        INSS:
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtINSS" title="Informe o Valor de INSS" ToolTip="Informe o Valor de INSS"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td>
                        Multa Rescisorias:
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtMultaRescisorias" title="Informe o Valor de Multa Rescisorias" ToolTip="Informe o Valor de Multa Rescisorias"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td>
                        Indenizações:
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtIndenizacoes" title="Informe o Valor de Indenizações" ToolTip="Informe o Valor de Indenizações"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td>
                        Extra:
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtExtra" title="Informe o Valor Extra" ToolTip="Informe o Valor Extra"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td style="height: 5px;">
                        <asp:HiddenField ID="hdfIdControleAcesso" runat="server" Value="-1" />
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
    </div>
</asp:Content>
