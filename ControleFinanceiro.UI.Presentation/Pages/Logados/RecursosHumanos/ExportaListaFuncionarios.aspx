<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Logados/MasterPageMenu.Master" AutoEventWireup="true" CodeBehind="ExportaListaFuncionarios.aspx.cs" Inherits="ControleFinanceiro.UI.Presentation.Pages.Logados.RecursosHumanos.ExportaListaFuncionarios" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ MasterType VirtualPath="~/Pages/Logados/MasterPageMenu.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="TabelaContent">
        Clique no botão para gerar a planilha: <asp:Button ID="btnGeraListaFunc" runat="server" Text="Gerar Planilha" OnClick="btnGeraListaFunc_Click" />
    </div>
</asp:Content>
