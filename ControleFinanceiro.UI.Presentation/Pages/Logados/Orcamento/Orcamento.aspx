<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Orcamento.aspx.cs" Inherits="ControleFinanceiro.UI.Presentation.Pages.Logados.Orcamento.Orcamento" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../../Scripts/jquery-1.9.1.js"></script>
    <script src="../../../Scripts/jquery-1.9.1.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div id="Content">
            <asp:Literal ID="ltlSegmento" runat="server"></asp:Literal>
            <asp:Button ID="btnSalvar" Text="Salvar" runat="server" OnClick="btnSalvar_Click" />
        </div>
    </form>
</body>
</html>
