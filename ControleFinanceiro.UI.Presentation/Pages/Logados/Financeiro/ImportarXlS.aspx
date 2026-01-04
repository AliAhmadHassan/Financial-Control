<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Logados/MasterPageMenu.Master"
    AutoEventWireup="true" CodeBehind="ImportarXlS.aspx.cs" Inherits="ControleFinanceiro.UI.Presentation.Pages.Logados.Financeiro.ImportarXlS" %>

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
    <table>
        <tr>
            <td rowspan="8" style="vertical-align: top">
                <asp:TreeView ID="trwSegmento" runat="server" ForeColor="White" ImageSet="Arrows"
                    OnSelectedNodeChanged="trwSegmento_SelectedNodeChanged" Width="100%">
                    <HoverNodeStyle Font-Underline="True" ForeColor="#CCCCCC" />
                    <LeafNodeStyle ForeColor="#CCCCCC" />
                    <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="White" HorizontalPadding="5px"
                        NodeSpacing="0px" VerticalPadding="0px" />
                    <ParentNodeStyle Font-Bold="False" ForeColor="White" />
                    <RootNodeStyle ForeColor="White" />
                    <SelectedNodeStyle Font-Underline="True" ForeColor="#0ef5d1" HorizontalPadding="0px"
                        VerticalPadding="0px" />
                </asp:TreeView>
                <asp:HiddenField ID="hdfIdSegmento" Value="-1" runat="server" />
            </td>
            <td>
                <table>
                    <tr>
                        <td style="vertical-align: top; height:20px;">
                Arquivo xlsx:
            </td>
            <td style="vertical-align: top; height:20px;">
                <asp:FileUpload ID="FileUpload1" runat="server" Width="100%" style="margin-bottom: 0px" />
            </td>
                    </tr>

                    <tr>
            <td style="vertical-align: top; height:20px;">
                Descrição
            </td>
            <td style="vertical-align: top; height:20px;">
                <asp:TextBox ID="txtDescricao" runat="server" Height="40px" TextMode="MultiLine"
                    Width="394px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; height:20px;">
                Emissão
            </td>
            <td style="vertical-align: top; height:20px;">
                <asp:TextBox ID="txtEmissao" runat="server"></asp:TextBox>
            &nbsp;<asp:Button ID="btnManutencao" runat="server" OnClick="btnManutencao_Click" Text="Manutenção" />
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; height:20px;">
                Vencimento
            </td>
            <td style="vertical-align: top; height:20px;">
                <asp:TextBox ID="txtVencimento" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; height:20px;">
                Data Pgto.
            </td>
            <td style="vertical-align: top; height:20px;">
                <asp:TextBox ID="txtDtPgto" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; height:20px;">
                Fornecedor
            </td>
            <td style="vertical-align: top; height:20px;">
                <asp:ListBox ID="lstFornecedor" runat="server" Width="400px"></asp:ListBox>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top; height:20px;">
                &nbsp;
            </td>
            <td style="vertical-align: top; height:20px;">
                <asp:Button ID="BtnCadastroSalvar" runat="server" CssClass="ButtonSalvar" Text=""
                    Width="79px" OnClick="BtnCadastroSalvar_Click" />
            </td>
        </tr>
                </table>
            </td>
            
        </tr>
        
    </table>
</asp:Content>
