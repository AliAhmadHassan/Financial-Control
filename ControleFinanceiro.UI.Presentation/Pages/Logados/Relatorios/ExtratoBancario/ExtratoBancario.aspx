<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExtratoBancario.aspx.cs"
    Inherits="ControleFinanceiro.UI.Presentation.Pages.Logados.Relatorios.ExtratoBancario.ExtratoBancario" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color: White; color: Black;">
    <form id="form1" runat="server">
        <div>
            <table width='{0}px'>
                <tr>
                    <td width='33%'>
                        <img src='../../../../Imagens/Logo%20Orc.jpg' style='width: 200px' />
                    </td>
                    <td width='33%'>
                        <br />
                        <asp:Label ID="lblData" runat="server"></asp:Label></asp:AccessDataSource>
                    </td>
                    <td width='33%' style='text-align: right;'>
                        <b>Extrato Bancario</b><br />
                        Entre:
                    <asp:Label ID="lblReferencia" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <asp:GridView ID="gdvSaldoInicial" SkinID="GridSemPaginacao" AutoGenerateColumns="False"
                runat="server" Width="720px"
                OnRowDataBound="gdvSaldoInicial_RowDataBound"
                OnRowCommand="gdvSaldoInicial_RowCommand" ShowFooter="True">
                <Columns>
                    <asp:BoundField DataField="Data" HeaderText="Vencimento" DataFormatString="{0:dd/MM/yyyy}">
                        <HeaderStyle Width="10%" />
                        <ItemStyle Width="10%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Descricao" HeaderText="Descrição">
                        <HeaderStyle Width="40%" />
                        <ItemStyle Width="40%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Saldo" HeaderText="Saldo" DataFormatString="{0:C2}">
                        <HeaderStyle HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" />
                        <HeaderStyle Width="10%" />
                        <ItemStyle Width="10%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Conta" HeaderText="Dados Bancario">
                        <HeaderStyle Width="35%" />
                        <ItemStyle Width="35%" />
                    </asp:BoundField>
                    <asp:ButtonField ButtonType="Image" CommandName="Selecionado"
                        ImageUrl="~/Imagens/voltar-menu.png" Text="Button" />
                </Columns>

            </asp:GridView>
            <br />
            <asp:GridView ID="gdvReceitas" SkinID="GridSemPaginacao" AutoGenerateColumns="False"
                runat="server" Width="720px"
                OnRowCommand="gdvReceitas_RowCommand" ShowFooter="True" OnRowDataBound="gdvReceitas_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="Data" HeaderText="Vencimento" DataFormatString="{0:dd/MM/yyyy}">
                        <HeaderStyle Width="10%" />
                        <ItemStyle Width="10%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Descricao" HeaderText="Descrição">
                        <HeaderStyle Width="40%" />
                        <ItemStyle Width="40%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Credito" HeaderText="Credito" DataFormatString="{0:C2}">
                        <HeaderStyle HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" />
                        <HeaderStyle Width="10%" />
                        <ItemStyle Width="10%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Conta" HeaderText="Dados Bancario">
                        <HeaderStyle Width="35%" />
                        <ItemStyle Width="35%" />
                    </asp:BoundField>
                    <asp:ButtonField ButtonType="Image" CommandName="Selecionado"
                        ImageUrl="~/Imagens/voltar-menu.png" Text="Button" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:GridView ID="gdvDespesas" SkinID="GridSemPaginacao" AutoGenerateColumns="False"
                runat="server" Width="720px"
                OnRowCommand="gdvDespesas_RowCommand" ShowFooter="True" OnRowDataBound="gdvDespesas_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="Data" HeaderText="Vencimento" DataFormatString="{0:dd/MM/yyyy}">
                        <HeaderStyle Width="10%" />
                        <ItemStyle Width="10%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Descricao" HeaderText="Descrição">
                        <HeaderStyle Width="40%" />
                        <ItemStyle Width="40%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Debito" HeaderText="Debito" DataFormatString="{0:C2}">
                        <HeaderStyle HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" />
                        <HeaderStyle Width="10%" />
                        <ItemStyle Width="10%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Conta" HeaderText="Dados Bancario">
                        <HeaderStyle Width="35%" />
                        <ItemStyle Width="35%" />
                    </asp:BoundField>
                    <asp:ButtonField ButtonType="Image" CommandName="Selecionado"
                        ImageUrl="~/Imagens/voltar-menu.png" Text="Button" />
                </Columns>
            </asp:GridView>
            <hr />
            <table width="100%" style="padding-right:20px">
                <tr>
                    <td style="background-color:#3e85ba; color:White; font-weight:bold">Descrição: </td>
                    <td style="background-color:#3e85ba; color:White; font-weight:bold; text-align:right">
                        Totais</td>
                </tr>
                <tr>
                    <td><b>Saldo Inicial: </b></td>
                    <td style="text-align:right">
                        <asp:Label ID="lblSaldoInicial" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td><b>Receitas: </b></td>
                    <td style="text-align:right">
                        <asp:Label ID="lblReceitas" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td><b>Despesas: </b></td>
                    <td style="text-align:right">
                        <asp:Label ID="lblDespesas" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td style="background-color:#3e85ba; color:White; font-weight:bold">Total Geral: </td>
                    <td style="background-color:#3e85ba; color:White; font-weight:bold; text-align:right;">
                        <asp:Label ID="lblTotalGeral" runat="server"></asp:Label></td>
                </tr>
            </table>
            <asp:Panel ID="PanelDetalhes" runat="server"
                Style="position: absolute; top: 28px; left: 41px; width: 1125px; height: 400px; background-color: White; border: 1px solid black;"
                Visible="False">
                <asp:GridView ID="gdvDetalhes" SkinID="GridSemPaginacao" AutoGenerateColumns="False"
                    runat="server" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="Data" HeaderText="Vencimento"
                            DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="Descricao" HeaderText="Descrição" />
                        <asp:BoundField DataField="Credito" HeaderText="Credito"
                            DataFormatString="{0:C2}">
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Debito" HeaderText="Debito"
                            DataFormatString="{0:C2}">
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Saldo" HeaderText="Saldo"
                            DataFormatString="{0:C2}">
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Conta" HeaderText="Dados Bancario" />
                    </Columns>
                </asp:GridView>
                <asp:Button ID="btnFechar" runat="server" OnClick="btnFechar_Click"
                    Text="Fechar" />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
