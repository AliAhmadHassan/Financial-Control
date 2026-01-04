<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Logados/MasterPageMenu.Master"
    AutoEventWireup="true" CodeBehind="CadastroDespesasReceitas.aspx.cs" Inherits="ControleFinanceiro.UI.Presentation.Pages.Logados.Financeiro.CadastroDespesasReceitas" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
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
    <div class="TabelaContent">
        <asp:DropDownList ID="ddlReferencia" runat="server">
        </asp:DropDownList>
        <asp:Accordion ID="Accordion" runat="server" HeaderCssClass="accordionHeader" HeaderSelectedCssClass="accordionHeaderSelected"
            ContentCssClass="accordionContent" AutoSize="None" FadeTransitions="true" TransitionDuration="250"
            FramesPerSecond="40" RequireOpenedPane="false" SuppressHeaderPostbacks="true">
            <Panes>
                <asp:AccordionPane ID="aplSegmento" runat="Server">
                    <Header>
                        Selecione uma Segmento <asp:Label ID="lblSegmento" runat="server"></asp:Label>
                        <hr />
                    </Header>
                    <Content>
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
                    </Content>
                </asp:AccordionPane>
                <asp:AccordionPane ID="aplCarteira" runat="server">
                    <Header>
                        Selecione uma Carteira <asp:Label ID="lblCarteira" runat="server"></asp:Label>
                        <asp:HiddenField ID="hdfIdSegmento"
                            Value="-1" runat="server" />
                        <hr />
                    </Header>
                    <Content>
                        <asp:TreeView ID="trwCarteira" runat="server" ForeColor="White" ImageSet="Arrows"
                            OnSelectedNodeChanged="trwCarteira_SelectedNodeChanged" Width="100%">
                            <HoverNodeStyle Font-Underline="True" ForeColor="#CCCCCC" />
                            <LeafNodeStyle ForeColor="#CCCCCC" />
                            <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="White" HorizontalPadding="5px"
                                NodeSpacing="0px" VerticalPadding="0px" />
                            <ParentNodeStyle Font-Bold="False" ForeColor="White" />
                            <RootNodeStyle ForeColor="White" />
                            <SelectedNodeStyle Font-Underline="True" ForeColor="#0ef5d1" HorizontalPadding="0px"
                                VerticalPadding="0px" />
                        </asp:TreeView>
                        <asp:HiddenField ID="hdfIdCarteira" runat="server" Value="-1" />
                    </Content>
                </asp:AccordionPane>
                <asp:AccordionPane ID="aplCadastro" runat="server">
                    <Header>
                        Cadastro
                        <hr />
                    </Header>
                    <Content>
                        <asp:GridView ID="GdvDespesaReceita" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="GdvDespesaReceita_PageIndexChanging"
                            OnRowCommand="GdvDespesaReceita_RowCommand" OnRowDataBound="GdvDespesaReceita_RowDataBound">
                            <Columns>
                                <asp:ButtonField ButtonType="Image" CommandName="Alterar" HeaderText="#" ImageUrl="~/Imagens/Ico/grid_atualizar.png"
                                    Text="Alterar" />
                                <asp:ButtonField ButtonType="Image" CommandName="Excluir" HeaderText="#" ImageUrl="~/Imagens/Ico/grid_deletar.png"
                                    Text="Excluir">
                                    <ControlStyle Width="16px" />
                                    <ItemStyle Height="16px" Width="16px" />
                                </asp:ButtonField>
                                <asp:BoundField DataField="Data" HeaderText="Data" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField DataField="Valor" HeaderText="Valor" DataFormatString="{0:C2}">
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="IdUsuario" HeaderText="Usuario">
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Id" HeaderText="Cod.">
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                            </Columns>
                        </asp:GridView>
                    </Content>
                </asp:AccordionPane>
            </Panes>
        </asp:Accordion>
        <asp:HiddenField ID="hdfIdReceitaDespesa" runat="server" Value="-1" />
        <asp:HiddenField ID="BtnNovo" runat="server" />
        <asp:ModalPopupExtender ID="Panel_Cadastro_ModalPopupExtender" runat="server" TargetControlID="BtnNovo"
            CancelControlID="btCadastrar_Nao" BackgroundCssClass="modalBackground" Enabled="True"
            PopupControlID="Panel_Cadastro">
        </asp:ModalPopupExtender>
        <asp:Panel runat="server" ID="Panel_Cadastro" Visible="true" CssClass="modalPopup">
            <table>
                <tr>
                    <td>
                        Valor
                    </td>
                    <td>
                        <asp:TextBox ID="txtValor" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="BtnCadastroSim" runat="server" CssClass="ButtonSalvar" Text="" Width="79px"
                            OnClick="BtnCadastroSim_Click" />
                        <asp:Button ID="btCadastrar_Nao" runat="server" CssClass="ButtonCancelar" Text=""
                            ValidationGroup="Cancelar" Width="79px" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
</asp:Content>
