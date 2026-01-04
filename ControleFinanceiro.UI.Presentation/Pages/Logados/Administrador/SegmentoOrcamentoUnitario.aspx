<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SegmentoOrcamentoUnitario.aspx.cs" Inherits="ControleFinanceiro.UI.Presentation.Pages.Logados.Administrador.SegmentoOrcamentoUnitario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GdvOrcamento" runat="server" AutoGenerateColumns="False" OnRowCommand="GdvOrcamento_RowCommand">
                <Columns>
                    <asp:ButtonField ButtonType="Image" CommandName="Alterar" HeaderText="#" ImageUrl="~/Imagens/Ico/grid_atualizar.png"
                        Text="Alterar" />
                    <asp:ButtonField ButtonType="Image" CommandName="Excluir" HeaderText="#" ImageUrl="~/Imagens/Ico/grid_deletar.png"
                        Text="Excluir">
                        <ControlStyle Width="16px" />
                        <ItemStyle Height="16px" Width="16px" />
                    </asp:ButtonField>
                    <asp:BoundField DataField="Descricao" HeaderText="Descrição" />
                    <asp:BoundField DataField="Valor" HeaderText="Valor" />
                    <asp:BoundField DataField="Id" HeaderText="Cod." />
                </Columns>
            </asp:GridView>
            <br />
            <asp:Button ID="btnNovo" runat="server" Text="Novo" OnClick="btnNovo_Click" />
            <br />
            <br />
            <asp:Panel ID="PanelAlterar" runat="server" Visible="false">
                <table>
                    <tr>
                        <td>Descrição:</td>
                        <td>
                            <asp:TextBox ID="txtDescricao" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Valor:</td>
                        <td>
                            <asp:TextBox ID="txtValor" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" /><asp:HiddenField ID="hdfId" runat="server" Value="-1" /></td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
