<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Logados/MasterPageMenu.Master" AutoEventWireup="true" CodeBehind="Carteira.aspx.cs" Inherits="ControleFinanceiro.UI.Presentation.Pages.Logados.Orcamento.Carteira" %>

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
    Selecione uma Carteira
                    <hr />
    <asp:TreeView ID="trwCarteira" runat="server" ForeColor="White" ImageSet="Arrows"
        OnSelectedNodeChanged="trwCarteira_SelectedNodeChanged" OnTreeNodeDataBound="trwCarteira_TreeNodeDataBound">
        <HoverNodeStyle Font-Underline="True" ForeColor="#CCCCCC" />
        <LeafNodeStyle ForeColor="#CCCCCC" />
        <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="White" HorizontalPadding="5px"
            NodeSpacing="0px" VerticalPadding="0px" />
        <ParentNodeStyle Font-Bold="False" ForeColor="White" />
        <RootNodeStyle ForeColor="White" />
        <SelectedNodeStyle Font-Underline="True" ForeColor="#0ef5d1" HorizontalPadding="0px"
            VerticalPadding="0px" />
    </asp:TreeView>
</asp:Content>
