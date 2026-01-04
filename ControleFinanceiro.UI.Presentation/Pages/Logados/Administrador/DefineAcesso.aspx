<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DefineAcesso.aspx.cs" Inherits="ControleFinanceiro.UI.Presentation.Pages.Logados.Administrador.DefineAcesso" %>

<%@ Register src="../../../WebControl/MensagemOK.ascx" tagname="MensagemOK" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="background-color: White">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <h1 style="color: Black;">
            Define Acesso</h1>
        <hr />
        <asp:GridView ID="gdvAcesso" runat="server" AutoGenerateColumns="False" 
            onrowdatabound="gdvAcesso_RowDataBound" PageSize="1000" CellPadding="4" 
            EnableTheming="False" ForeColor="#333333" GridLines="None" Width="500px">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                
                <asp:TemplateField HeaderText="Acesso">
                    <ItemTemplate>
                        <asp:CheckBox ID="CbAcesso" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Imagem" HeaderText="">
                    <ControlStyle Width="50px" />
                    <ItemStyle Height="50px" Width="50px" />
                </asp:BoundField>                
                <asp:BoundField DataField="Descricao" HeaderText="Descricao"/>

                <asp:BoundField DataField="Id" HeaderText="Cod."/>
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        <hr />
        <asp:Button ID="Salvar" Text="Salvar" runat="server" OnClick="Salvar_Click"></asp:Button>
        <uc1:MensagemOK ID="MensagemOK1" runat="server" />
    </div>
    </form>
</body>
</html>
