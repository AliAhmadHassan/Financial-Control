<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SegmentoCarteira.aspx.cs" Inherits="ControleFinanceiro.UI.Presentation.Pages.Logados.Relatorios.SegmentoCarteira.SegmentoCarteira" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width='100%'>
                <tr>
                    <td width='33%'>
                        <img src='../../../../Imagens/Logo%20Orc.jpg' style='width: 200px' />
                    </td>
                    <td width='33%'>
                        <br />
                        <asp:Label ID="lblData" runat="server"></asp:Label>
                    </td>
                    <td width='33%' style='text-align: right;'>
                        <b>Segmento/Carteira</b>
                    </td>
                </tr>
            </table>
            <div style="width:100%; text-align:center; font-weight:bold;">Receitas</div>
            <asp:GridView ID="gdvReceitas" SkinID="GridSemPaginacao" AutoGenerateColumns="False"
                runat="server" Width="720px" ShowFooter="True" OnRowDataBound="gdvReceitas_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="Referencia" HeaderText="Referencia" DataFormatString="{0:MM/yyyy}">
                        <HeaderStyle Width="5%" />
                        <ItemStyle Width="5%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Vencimento" HeaderText="Vencimento" DataFormatString="{0:dd/MM/yyyy}">
                        <HeaderStyle Width="5%" />
                        <ItemStyle Width="5%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NumeroNota" HeaderText="Nota">
                        <HeaderStyle Width="5%" />
                        <ItemStyle Width="5%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="IdSegmento" HeaderText="Segmento">
                        <HeaderStyle Width="20%" />
                        <ItemStyle Width="20%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="IdCarteira" HeaderText="Carteira">
                        <HeaderStyle Width="20%" />
                        <ItemStyle Width="20%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Obs" HeaderText="Descrição">
                        <HeaderStyle Width="35%" />
                        <ItemStyle Width="35%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Valor" HeaderText="Valor" DataFormatString="{0:C2}">
                        <HeaderStyle HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" />
                        <HeaderStyle Width="10%" />
                        <ItemStyle Width="10%" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
            <br />
            <div style="width:100%; text-align:center; font-weight:bold;">Despesas</div>
            <asp:GridView ID="gdvDespesas" SkinID="GridSemPaginacao" AutoGenerateColumns="False"
                runat="server" Width="720px" ShowFooter="True" OnRowDataBound="gdvDespesas_RowDataBound">
                                <Columns>
                    <asp:BoundField DataField="Vencimento" HeaderText="Referencia" DataFormatString="{0:MM/yyyy}">
                        <HeaderStyle Width="5%" />
                        <ItemStyle Width="5%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Vencimento" HeaderText="Vencimento" DataFormatString="{0:dd/MM/yyyy}">
                        <HeaderStyle Width="5%" />
                        <ItemStyle Width="5%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NumeroDocumento" HeaderText="Documento">
                        <HeaderStyle Width="5%" />
                        <ItemStyle Width="5%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="IdSegmento" HeaderText="Segmento">
                        <HeaderStyle Width="20%" />
                        <ItemStyle Width="20%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="IdCarteira" HeaderText="Carteira">
                        <HeaderStyle Width="20%" />
                        <ItemStyle Width="20%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Descricao" HeaderText="Descrição">
                        <HeaderStyle Width="35%" />
                        <ItemStyle Width="35%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Valor" HeaderText="Valor" DataFormatString="{0:C2}">
                        <HeaderStyle HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" />
                        <HeaderStyle Width="10%" />
                        <ItemStyle Width="10%" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
            <br />
            <div style="width:100%; text-align:center; font-weight:bold;">Despesas Rateio</div>
            <asp:GridView ID="gdvDespesasRateio" SkinID="GridSemPaginacao" AutoGenerateColumns="False"
                runat="server" Width="720px" ShowFooter="True" OnRowDataBound="gdvDespesasRateio_RowDataBound">
                                <Columns>
                    <asp:BoundField DataField="Vencimento" HeaderText="Referencia" DataFormatString="{0:MM/yyyy}">
                        <HeaderStyle Width="5%" />
                        <ItemStyle Width="5%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Vencimento" HeaderText="Vencimento" DataFormatString="{0:dd/MM/yyyy}">
                        <HeaderStyle Width="5%" />
                        <ItemStyle Width="5%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NumeroDocumento" HeaderText="Documento">
                        <HeaderStyle Width="5%" />
                        <ItemStyle Width="5%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="IdSegmento" HeaderText="Segmento">
                        <HeaderStyle Width="20%" />
                        <ItemStyle Width="20%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="IdCarteira" HeaderText="Carteira">
                        <HeaderStyle Width="20%" />
                        <ItemStyle Width="20%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Descricao" HeaderText="Descrição">
                        <HeaderStyle Width="35%" />
                        <ItemStyle Width="35%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Valor" HeaderText="Valor" DataFormatString="{0:C2}">
                        <HeaderStyle HorizontalAlign="Right" />
                        <ItemStyle HorizontalAlign="Right" />
                        <HeaderStyle Width="10%" />
                        <ItemStyle Width="10%" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
