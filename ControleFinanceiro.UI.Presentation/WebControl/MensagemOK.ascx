<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MensagemOK.ascx.cs"
    Inherits="ControleFinanceiro.UI.Presentation.WebControl.MensagemOK" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:ModalPopupExtender ID="Panel_MessageOk_ModalPopupExtender" runat="server" TargetControlID="btnOk"
    CancelControlID="btnOk" BackgroundCssClass="modalBackground" Enabled="True"
    PopupControlID="pnlMensagem">
</asp:ModalPopupExtender>
<asp:Panel ID="pnlMensagem" runat="server" Visible="false" CssClass="pnlMensagem">
    <div id="ConteudoAviso" class="Content">
        <div id="Titulo" class="Titulo">
            <asp:Label ID="lblTitulo" runat="server"></asp:Label>
        </div>
        <div id="Mensagem" class="Mensagem">
            <asp:Label ID="lblMensagem" runat="server"></asp:Label>
        </div>
        <div id="Botao" class="Botao">
            <asp:Button ID="btnOk" runat="server" Text="" onclick="btnOk_Click" CssClass="ButtonOK" Width="48px" Height="48px" />
        </div>
    </div>
</asp:Panel>
