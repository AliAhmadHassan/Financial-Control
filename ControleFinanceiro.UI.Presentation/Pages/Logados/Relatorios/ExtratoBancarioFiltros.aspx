<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Logados/MasterPageMenu.Master" AutoEventWireup="true" CodeBehind="ExtratoBancarioFiltros.aspx.cs" Inherits="ControleFinanceiro.UI.Presentation.Pages.Logados.Relatorios.ExtratoBancario.ExtratoBancarioFiltros" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ MasterType VirtualPath="~/Pages/Logados/MasterPageMenu.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function abrir_popup(url, title, w, h) {
            var left = (screen.width / 2) - (w / 2);
            var top = (screen.height / 2) - (h / 2);
            return window.open(url, title, 'toolbar=no, location=no, directories=no, status=yes, menubar=yes, scrollbars=yes, resizable=yes, copyhistory=no, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);
        }

        function mensagem_teste() {
            alert('Atendo o cliente de cpf');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Conteudo" runat="server">
        <table>
            <tr>
                <td>
                    De
                </td>
                <td>
                    Ate
                </td>
                <td>
                    Conta Bancaria
                </td>
                <td>
                    Tipo Data</td>
            </tr>
            <tr>
                <td>
                    <asp:Calendar ID="cldDe" runat="server" BackColor="White" BorderColor="Black" 
                        BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" 
                        ForeColor="Black" Height="250px" NextPrevFormat="ShortMonth" Width="330px">
                        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" 
                            Height="8pt" />
                        <DayStyle BackColor="#CCCCCC" />
                        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                        <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" 
                            Font-Size="12pt" ForeColor="White" Height="12pt" />
                        <TodayDayStyle BackColor="#999999" ForeColor="White" />
                    </asp:Calendar>
                </td>
                <td>
                    <asp:Calendar ID="cldAte" runat="server" BackColor="White" BorderColor="Black" 
                        BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" 
                        ForeColor="Black" Height="250px" NextPrevFormat="ShortMonth" Width="330px">
                        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" 
                            Height="8pt" />
                        <DayStyle BackColor="#CCCCCC" />
                        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                        <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" 
                            Font-Size="12pt" ForeColor="White" Height="12pt" />
                        <TodayDayStyle BackColor="#999999" ForeColor="White" />
                    </asp:Calendar>
                </td>
                <td>
                    <asp:ListBox ID="lstContaBancaria" runat="server" Height="246px" Width="289px" 
                        SelectionMode="Multiple">
                    </asp:ListBox>
                </td>
                <td>
                    <asp:ListBox ID="lstTipoData" runat="server" Height="246px" 
                        SelectionMode="Multiple" Width="289px">
                        <asp:ListItem Selected="True" Value="SPSExtratoBancarioV2">Vencimento</asp:ListItem>
                        <asp:ListItem Value="SPSExtratoBancarioDtPgto">Data Pagamento</asp:ListItem>
                        <asp:ListItem Value="SPSExtratoBancarioSemDtPgto">Vencimento Sem Data Pagamento</asp:ListItem>
                    </asp:ListBox>
                </td>
            </tr>
        </table>
        <asp:Button ID="Ok" Text="Visualizar na Web" runat="server" OnClick="Ok_Click" />
        &nbsp;<asp:Button ID="btnGerarDiario" runat="server" OnClick="btnGerarDiario_Click" Text="Gerar arquivo diario" />
        <asp:Timer ID="tmrTempo" runat="server" Enabled="False" Interval="30000" OnTick="tmrTempo_Tick">
        </asp:Timer>
        <asp:Panel ID="Panel1" runat="server" BackColor="WhiteSmoke" BorderWidth="1px" Height="20px" Width="500px" Visible="false">
            <asp:Panel ID="pnlStatus" runat="server" BackColor="CornflowerBlue" Height="20px" Width="1px">
                <br />
                <asp:Label ID="lblTempo" runat="server" Font-Names="Arial" Font-Size="9pt" Width="500px"></asp:Label>
            </asp:Panel>
        </asp:Panel>
        &nbsp;</asp:Panel>    
</asp:Content>
