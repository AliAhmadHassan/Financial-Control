<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fechamento.aspx.cs" Inherits="ControleFinanceiro.UI.Presentation.Pages.Logados.Relatorios.Fechamento.Fechamento" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Processar" />
        <asp:GridView ID="gdvFechamento" SkinID="GridSemPaginacao" runat="server" AutoGenerateColumns="False" OnRowDataBound="gdvFechamento_RowDataBound">
            <Columns>
                <asp:BoundField DataField="Carteira" HeaderText="Carteira" />
                <asp:BoundField DataField="ReceitaBruta" HeaderText="Receita Bruta" DataFormatString="{0:C2}" />
                <asp:BoundField DataField="Imposto" HeaderText="Impostos" DataFormatString="{0:C2}" />
                <asp:BoundField DataField="ReceitaLiquida" HeaderText="Receita Liquida" DataFormatString="{0:C2}" />
                <asp:BoundField DataField="CustoFixoVariado" HeaderText="Gastos Operacionais" DataFormatString="{0:C2}" />
                <asp:BoundField DataField="DespesasOper_ReceitaBruta" HeaderText="Gastos Oper. / Receita Bruta" />
                <asp:BoundField DataField="MargemContribuicao" HeaderText="% Margem Contribuição" />
                <asp:BoundField DataField="NaoOperacional" HeaderText="Não Operacional" DataFormatString="{0:C2}" />
                <asp:BoundField DataField="DespesaNO_ReceitaBruta" HeaderText="Despesa N.O. / Receita Bruta" />
                <asp:BoundField DataField="LucroLiquido" HeaderText="Lucro Liquido" DataFormatString="{0:C2}" />
                <asp:BoundField DataField="L_P" HeaderText="% L / (P)" />
            </Columns>
            <HeaderStyle Font-Size="Small" />
            <RowStyle Font-Size="Small" />
        </asp:GridView>
    </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:Timer ID="tmrTempo" runat="server" Enabled="False" Interval="30000" OnTick="tmrTempo_Tick">
        </asp:Timer>
        <asp:Panel ID="Panel1" runat="server" BackColor="WhiteSmoke" BorderWidth="1px" Height="20px" Width="500px">
            <asp:Panel ID="pnlStatus" runat="server" BackColor="CornflowerBlue" Height="20px" Width="1px">
                <br />
                <asp:Label ID="lblTempo" runat="server" Font-Names="Arial" Font-Size="9pt" Width="500px"></asp:Label>
            </asp:Panel>
        </asp:Panel>
    </form>
</body>
</html>
