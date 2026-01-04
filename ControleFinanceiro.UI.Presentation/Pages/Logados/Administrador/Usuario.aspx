<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Logados/MasterPageMenu.Master"
    AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="ControleFinanceiro.UI.Presentation.Pages.Logados.Administrador.Usuario" %>

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
    <asp:GridView ID="GdvUsuario" runat="server" AutoGenerateColumns="False" OnRowDataBound="GdvUsuario_RowDataBound"
        OnRowCommand="GdvUsuario_RowCommand" 
        onpageindexchanging="GdvUsuario_PageIndexChanging">
        <Columns>
            <asp:ButtonField ButtonType="Image" CommandName="Alterar" HeaderText="#" ImageUrl="~/Imagens/Ico/grid_atualizar.png"
                Text="Alterar" />
            <asp:ButtonField ButtonType="Image" CommandName="Excluir" HeaderText="#" ImageUrl="~/Imagens/Ico/grid_deletar.png"
                Text="Excluir">
                <ControlStyle Width="16px" />
                <ItemStyle Height="16px" Width="16px" />
            </asp:ButtonField>
            <asp:CheckBoxField DataField="Ativo" HeaderText="Ativo" />
            <asp:BoundField DataField="Nome" HeaderText="Nome" />
            <asp:BoundField DataField="IdPerfil" HeaderText="Perfil" />
            <asp:BoundField DataField="Id" HeaderText="Cod." />
                        <asp:ButtonField ButtonType="Image" CommandName="Acesso" HeaderText="Acesso" ImageUrl="~/Imagens/Menu.png"
                Text="Define Acesso">
                <ControlStyle Width="16px" />
                <ItemStyle Height="16px" Width="16px" />
            </asp:ButtonField>
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
                    Ativo:
                </td>
                <td>
                    <asp:CheckBox ID="cbxAtivo" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Nome:
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtNome" MaxLength="150" title="Informe o Nome do Usuario"
                        ToolTip="Informe o Nome do Usuario"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rvNome" runat="server" ControlToValidate="txtNome"
                        Display="Dynamic" ErrorMessage="* Favor preencher o Nome do Usuario" ForeColor="#CC3300"
                        Font-Bold="False" Font-Italic="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Perfil:
                </td>
                <td>
                    <asp:ListBox ID="lstPerfil" runat="server" Width="285px"></asp:ListBox>
                </td>
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
