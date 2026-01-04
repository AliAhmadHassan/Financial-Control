<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Receita.aspx.cs" Inherits="ControleFinanceiro.UI.Presentation.Pages.Logados.Financeiro.Receita" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="../../../WebControl/MensagemOK.ascx" TagName="MensagemOK" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        #Button1{
            display:none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <asp:HiddenField ID="hdfIdSegmento" runat="server" />
        <asp:HiddenField ID="hdfIdCarteira" runat="server" />
        <asp:HiddenField ID="hdfMesReferencia" runat="server" />
        <asp:GridView ID="GdvReceita" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="GdvReceita_PageIndexChanging"
            OnRowCommand="GdvReceita_RowCommand" OnRowDataBound="GdvReceita_RowDataBound"
            Font-Size="Small">
            <Columns>
                <asp:ButtonField ButtonType="Image" CommandName="Alterar" HeaderText="#" ImageUrl="~/Imagens/Ico/grid_atualizar.png"
                    Text="Alterar" />
                <asp:ButtonField ButtonType="Image" CommandName="Excluir" HeaderText="#" ImageUrl="~/Imagens/Ico/grid_deletar.png"
                    Text="Excluir">
                    <ControlStyle Width="16px" />
                    <ItemStyle Height="16px" Width="16px" />
                </asp:ButtonField>
                <asp:BoundField DataField="DataCadastro" HeaderText="Cadastro" DataFormatString="{0:dd/MM/yyyy}"
                    NullDisplayText="" />
                <asp:BoundField DataField="Emissao" HeaderText="Emissão" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="Vencimento" HeaderText="Vencimento" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="Valor" HeaderText="Valor" DataFormatString="{0:C2}">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="IdUsuario" HeaderText="Usuario">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:BoundField DataField="Id" HeaderText="Cod.">
                    <HeaderStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Right" />
                </asp:BoundField>
                <asp:ButtonField ButtonType="Image" HeaderText="Nota" ImageUrl="~/Imagens/search-icon.png"
                    CommandName="ExibirNota">
                    <ControlStyle Width="16px" />
                    <ItemStyle Height="16px" Width="16px" HorizontalAlign="Center" />
                </asp:ButtonField>
                <asp:ButtonField ButtonType="Image" HeaderText="Carta Correcao" ImageUrl="~/Imagens/search-icon.png"
                    CommandName="ExibirCartaCorrecao">
                    <ControlStyle Width="16px" />
                    <ItemStyle Height="16px" Width="16px" HorizontalAlign="Center" />
                </asp:ButtonField>
            </Columns>
        </asp:GridView>
        <asp:ModalPopupExtender ID="Panel_Cadastro_ModalPopupExtender" runat="server" TargetControlID="Button1"
            CancelControlID="btCadastrar_Nao" BackgroundCssClass="modalBackground" Enabled="True"
            PopupControlID="Panel_Cadastro">
        </asp:ModalPopupExtender>
        <asp:Button ID="Button1" runat="server"  CssClass="ButtonNovo" OnClick="BtnNovo_Click" />
                        
        <asp:Button ID="BtnNovo" runat="server" CssClass="ButtonNovo" OnClick="BtnNovo_Click" />
                        <asp:HiddenField ID="hdfIdReceita" runat="server" Value="-1" />
        <asp:Panel runat="server" ID="Panel_Cadastro" Visible="true" CssClass="modalPopup">
            <table>
                <tr>
                    <td>
                        NotaFiscal
                    </td>
                    <td>
                        <asp:CheckBox ID="CbNotaFiscal" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Emissão
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmissao" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Vencimento
                    </td>
                    <td>
                        <asp:TextBox ID="txtVencimento" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Data Pgto.
                    </td>
                    <td>
                        <asp:TextBox ID="txtDtPgto" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Numero Nota
                    </td>
                    <td>
                        <asp:TextBox ID="txtNumeroNota" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Valor
                    </td>
                    <td>
                        <asp:TextBox ID="txtValor" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        IRPJ
                    </td>
                    <td>
                        <asp:TextBox ID="txtIRPJ" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Cofins
                    </td>
                    <td>
                        <asp:TextBox ID="txtCofins" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        CSLL
                    </td>
                    <td>
                        <asp:TextBox ID="txtCSLL" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        PIS
                    </td>
                    <td>
                        <asp:TextBox ID="txtPIS" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        ISS
                    </td>
                    <td>
                        <asp:TextBox ID="txtISS" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        NOTA
                    </td>
                    <td>
                        <asp:FileUpload ID="FUpNota" runat="server" Width="400px" />
                    </td>
                </tr>
                <tr>
                    <td>
                        CartaCorrecao
                    </td>
                    <td>
                        <asp:FileUpload ID="FUpCartaCorrecao" runat="server" Width="400px" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Dados Bancario
                    </td>
                    <td>
                        <asp:ListBox ID="lstDadosBancario" runat="server" Width="400px"></asp:ListBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Obs
                    </td>
                    <td>
                        <asp:TextBox ID="txtObs" TextMode="MultiLine" Height="40px" Width="394px" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Dedutivel
                    </td>
                    <td>
                        <asp:CheckBox ID="cbDedutivel" runat="server"></asp:CheckBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="BtnCadastroSim" runat="server" CssClass="ButtonSalvar" Text="" Width="79px"
                            OnClick="BtnCadastroSim_Click" />
                        <asp:Button ID="btCadastrar_Nao" runat="server" CssClass="ButtonCancelar" Text=""
                            ValidationGroup="Cancelar" Width="79px" OnClick="btCadastrar_Nao_Click" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    <uc1:MensagemOK ID="MensagemOK" runat="server" />
    </form>
</body>
</html>
