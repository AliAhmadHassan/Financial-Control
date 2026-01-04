<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ControleFinanceiro.UI.Presentation.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color: White; color: white;">
    <form id="form1" runat="server">
    <div id="div-login">
        <table>
            <tr>
                <td style="padding-left: 30px; padding-top: 5px">
                    <span style="font-size: x-large; font-weight: bold;">Seja bem-vindo </span>
                </td>
            </tr>
            <tr>
                <td style="padding-left: 30px; padding-top: 5px; padding-bottom: 5px; font-size: small">
                    Identifique-se por favor para utilizar o aplicativo.
                </td>
            </tr>
            <tr>
                <td style="padding-left: 30px">
                    Usuário
                </td>
            </tr>
            <tr>
                <td style="padding-left: 30px">
                    <asp:TextBox ID="tbUsuario" runat="server" Width="200px" title="Informe seu Ramal"
                        MaxLength="30"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rvUsuario" runat="server" ControlToValidate="tbUsuario"
                        ErrorMessage="* Favor preencher o Usuario" Font-Italic="True" ForeColor="yellow"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="padding-left: 30px">
                    Senha
                </td>
            </tr>
            <tr>
                <td style="padding-left: 30px">
                    <asp:TextBox ID="tbSenha" runat="server" Width="200px" TextMode="Password" title="Informe sua senha"
                        MaxLength="80"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rvSenha" runat="server" ControlToValidate="tbSenha"
                        ErrorMessage="* Favor preencher a senha" ForeColor="yellow" Font-Bold="False" Font-Italic="True"
                        Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="padding-left: 30px">
                    <asp:Label ID="lbMensagem" runat="server" Font-Italic="True" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="padding-left: 30px">
                    <asp:Button ID="btOkMensagem" runat="server" CssClass="botaoLogin" OnClick="btLogin_Click"
                        Text="" SkinID="btnLogin" ToolTip="Clique para entrar no sistema" />
                </td>
            </tr>
            <tr>
                <td style="padding-left: 30px">
                    <span style="display: none">Esqueceu sua senha? <strong><a href="#">Enviar Senha</a></strong></span>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
