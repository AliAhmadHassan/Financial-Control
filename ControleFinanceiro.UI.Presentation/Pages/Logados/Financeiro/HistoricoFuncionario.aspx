<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HistoricoFuncionario.aspx.cs" Inherits="ControleFinanceiro.UI.Presentation.Pages.Logados.Financeiro.HistoricoFuncionario" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .Invisivel{
            display:none;
        }
        .DDSemBorda{
            border:none;
            background-color:transparent;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" SkinID="GridPaginacao100" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" AllowSorting="True" PageSize="200" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="IdFuncionario" HeaderText="IdFuncionario" SortExpression="IdFuncionario" 
                    ItemStyle-CssClass="Invisivel"
                    HeaderStyle-CssClass="Invisivel"
                    ControlStyle-CssClass="Invisivel">
<ControlStyle CssClass="Invisivel"></ControlStyle>

<HeaderStyle CssClass="Invisivel"></HeaderStyle>

<ItemStyle CssClass="Invisivel"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Cargo" HeaderText="Cargo" SortExpression="Cargo" />
                <asp:BoundField DataField="Nome" HeaderText="Nome" SortExpression="Nome" />
                <asp:BoundField DataField="Matricula" HeaderText="Matricula" SortExpression="Matricula" />
                <asp:BoundField DataField="Adimissao" HeaderText="Adimissão" SortExpression="Adimissao" DataFormatString="{0:d}" />
                <asp:TemplateField HeaderText="Carteira" SortExpression="IdCarteira">
                    <EditItemTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSourceCarteira" DataTextField="Descricao" DataValueField="Id" Height="16px" SelectedValue='<%# Bind("IdCarteira") %>' Width="365px">
                        </asp:DropDownList>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="LbCarteira" runat="server" Text='<%# Bind("IdCarteira") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Minutos" HeaderText="Minutos" SortExpression="Minutos" 
                    ItemStyle-CssClass="Invisivel"
                    HeaderStyle-CssClass="Invisivel"
                    ControlStyle-CssClass="Invisivel">
<ControlStyle CssClass="Invisivel"></ControlStyle>

<HeaderStyle CssClass="Invisivel"></HeaderStyle>

<ItemStyle CssClass="Invisivel"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="DataCadastro" HeaderText="DataCadastro" SortExpression="DataCadastro" 
                    ItemStyle-CssClass="Invisivel"
                    HeaderStyle-CssClass="Invisivel"
                    ControlStyle-CssClass="Invisivel">
<ControlStyle CssClass="Invisivel"></ControlStyle>

<HeaderStyle CssClass="Invisivel"></HeaderStyle>

<ItemStyle CssClass="Invisivel"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" 
                    ItemStyle-CssClass="Invisivel"
                    HeaderStyle-CssClass="Invisivel"
                    ControlStyle-CssClass="Invisivel">
<ControlStyle CssClass="Invisivel"></ControlStyle>

<HeaderStyle CssClass="Invisivel"></HeaderStyle>

<ItemStyle CssClass="Invisivel"></ItemStyle>
                </asp:BoundField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringControleFinanceiro %>" SelectCommand="SELECT * FROM [TbHistoricoFuncionario] WHERE ([DataCadastro] = @DataCadastro)" DeleteCommand="SPDHistoricoFuncionario" DeleteCommandType="StoredProcedure" UpdateCommand="SPUHistoricoFuncionario" UpdateCommandType="StoredProcedure">
            <DeleteParameters>
                <asp:Parameter Direction="ReturnValue" Name="RETURN_VALUE" Type="Int32" />
                <asp:Parameter Name="Id" Type="Int32" />
            </DeleteParameters>
            <SelectParameters>
                <asp:QueryStringParameter DefaultValue="" Name="DataCadastro" QueryStringField="DataEmissao" Type="DateTime" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Direction="ReturnValue" Name="RETURN_VALUE" Type="Int32" />
                <asp:Parameter Name="IdFuncionario" Type="Int32" />
                <asp:Parameter Name="Cargo" Type="String" />
                <asp:Parameter Name="Nome" Type="String" />
                <asp:Parameter Name="Matricula" Type="String" />
                <asp:Parameter DbType="Date" Name="Adimissao" />
                <asp:Parameter Name="IdCarteira" Type="Int32" />
                <asp:Parameter Name="Minutos" Type="Int32" />
                <asp:Parameter Name="DataCadastro" Type="DateTime" />
                <asp:Parameter Name="Id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSourceCarteira" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringControleFinanceiro %>" SelectCommand="SELECT [Id]
	  ,	coalesce((Select top 1 coalesce(Descricao + '/', '' ) from tbcarteira cart2 where cart2.id = (Select top 1 coalesce(idPai, '' ) from tbcarteira cart where cart.id = [TbCarteira].IdPai)),'')  + 
		coalesce((Select top 1 coalesce(Descricao + '/', '' ) from tbcarteira cart where cart.id = [TbCarteira].IdPai), '') 
		+ coalesce(Descricao,'') as Descricao
FROM [TbCarteira]
order by 2"></asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
