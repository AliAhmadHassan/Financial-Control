<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Despesa.aspx.cs" Inherits="ControleFinanceiro.UI.Presentation.Pages.Logados.Financeiro.Despesa" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register src="../../../WebControl/MensagemOK.ascx" tagname="MensagemOK" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <asp:HiddenField ID="hdfIdSegmento" runat="server" />
        <asp:HiddenField ID="hdfIdCarteira" runat="server" />
        <asp:HiddenField ID="hdfMesReferencia" runat="server" />
        <asp:GridView ID="GdvDespesa" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="GdvDespesa_PageIndexChanging"
            OnRowCommand="GdvDespesa_RowCommand" 
            OnRowDataBound="GdvDespesa_RowDataBound" Font-Size="Small">
            <Columns>
                <asp:ButtonField ButtonType="Image" CommandName="Alterar" HeaderText="#" ImageUrl="~/Imagens/Ico/grid_atualizar.png"
                    Text="Alterar" />
                <asp:ButtonField ButtonType="Image" CommandName="Excluir" HeaderText="#" ImageUrl="~/Imagens/Ico/grid_deletar.png"
                    Text="Excluir">
                    <ControlStyle Width="16px" />
                    <ItemStyle Height="16px" Width="16px" />
                </asp:ButtonField>
                <asp:BoundField DataField="DataCadastro" HeaderText="Cadastro" DataFormatString="{0:dd/MM/yyyy}" NullDisplayText = "" />
                <asp:BoundField DataField="Emissao" HeaderText="Emissão" DataFormatString="{0:dd/MM/yyyy}" NullDisplayText = "" />
                <asp:BoundField DataField="Vencimento" HeaderText="Vencimento" DataFormatString="{0:dd/MM/yyyy}" NullDisplayText = "" />
                <asp:BoundField DataField="DtPgto" HeaderText="Dt. Pgto" DataFormatString="{0:dd/MM/yyyy}" NullDisplayText = "" />
                <asp:BoundField DataField="Descricao" HeaderText="Descrição" DataFormatString="{0:dd/MM/yyyy}" NullDisplayText = "" />
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
                <asp:ButtonField ButtonType="Image" HeaderText="Nota" 
                    ImageUrl="~/Imagens/search-icon.png" CommandName="ExibirNota">
                    <ControlStyle Width="16px" />
                    <ItemStyle Height="16px" Width="16px" HorizontalAlign="Center" />
                </asp:ButtonField>
                <asp:ButtonField ButtonType="Image" HeaderText="Boleto" 
                    ImageUrl="~/Imagens/search-icon.png" CommandName="ExibirBoleto">
                    <ControlStyle Width="16px" />
                    <ItemStyle Height="16px" Width="16px" HorizontalAlign="Center" />
                </asp:ButtonField>
                <asp:ButtonField ButtonType="Image" HeaderText="Comprovante" 
                    ImageUrl="~/Imagens/search-icon.png" CommandName="ExibirComprovante">
                    <ControlStyle Width="16px" />
                    <ItemStyle Height="16px" Width="16px" HorizontalAlign="Center" />
                </asp:ButtonField>
            </Columns>
        </asp:GridView>
        <asp:ModalPopupExtender ID="Panel_Cadastro_ModalPopupExtender" runat="server" TargetControlID="BtnNovo"
            CancelControlID="btCadastrar_Nao" BackgroundCssClass="modalBackground" Enabled="True"
            PopupControlID="Panel_Cadastro">
        </asp:ModalPopupExtender>
        <asp:Button ID="BtnNovo" runat="server" CssClass="ButtonNovo"/>
        <asp:Panel runat="server" ID="Panel_Cadastro" Visible="true" CssClass="modalPopup">
            <table>
                <tr>
                    <td>
                        Descrição</td>
                    <td>
                        <asp:TextBox ID="txtDescricao" runat="server" Height="40px" TextMode="MultiLine" 
                            Width="394px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Emissão
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmissao" runat="server"></asp:TextBox>
                        </td>
                </tr>
                <tr>
                    <td>
                        Vencimento
                    </td>
                    <td>
                        <asp:TextBox ID="txtVencimento" runat="server"></asp:TextBox> Meses: 
                        <asp:DropDownList ID="ddlMeses" runat="server">
                            <asp:ListItem Selected="True">1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>11</asp:ListItem>
                            <asp:ListItem>12</asp:ListItem>
                            <asp:ListItem>13</asp:ListItem>
                            <asp:ListItem>14</asp:ListItem>
                            <asp:ListItem>15</asp:ListItem>
                            <asp:ListItem>16</asp:ListItem>
                            <asp:ListItem>17</asp:ListItem>
                            <asp:ListItem>18</asp:ListItem>
                            <asp:ListItem>19</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>21</asp:ListItem>
                            <asp:ListItem>22</asp:ListItem>
                            <asp:ListItem>23</asp:ListItem>
                            <asp:ListItem>24</asp:ListItem>
                            <asp:ListItem>25</asp:ListItem>
                            <asp:ListItem>26</asp:ListItem>
                            <asp:ListItem>27</asp:ListItem>
                            <asp:ListItem>28</asp:ListItem>
                            <asp:ListItem>29</asp:ListItem>
                            <asp:ListItem>30</asp:ListItem>
                            <asp:ListItem>31</asp:ListItem>
                            <asp:ListItem>32</asp:ListItem>
                            <asp:ListItem>33</asp:ListItem>
                            <asp:ListItem>34</asp:ListItem>
                            <asp:ListItem>35</asp:ListItem>
                            <asp:ListItem>36</asp:ListItem>
                            <asp:ListItem>37</asp:ListItem>
                            <asp:ListItem>38</asp:ListItem>
                            <asp:ListItem>39</asp:ListItem>
                            <asp:ListItem>40</asp:ListItem>
                            <asp:ListItem>41</asp:ListItem>
                            <asp:ListItem>42</asp:ListItem>
                            <asp:ListItem>43</asp:ListItem>
                            <asp:ListItem>44</asp:ListItem>
                            <asp:ListItem>45</asp:ListItem>
                            <asp:ListItem>46</asp:ListItem>
                            <asp:ListItem>47</asp:ListItem>
                            <asp:ListItem>48</asp:ListItem>
                            <asp:ListItem>49</asp:ListItem>
                            <asp:ListItem>50</asp:ListItem>
                            <asp:ListItem>51</asp:ListItem>
                            <asp:ListItem>52</asp:ListItem>
                            <asp:ListItem>53</asp:ListItem>
                            <asp:ListItem>54</asp:ListItem>
                            <asp:ListItem>55</asp:ListItem>
                            <asp:ListItem>56</asp:ListItem>
                            <asp:ListItem>57</asp:ListItem>
                            <asp:ListItem>58</asp:ListItem>
                            <asp:ListItem>59</asp:ListItem>
                            <asp:ListItem>60</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                </tr>
                <tr>
                    <td>
                        Valor</td>
                    <td>
                        <asp:TextBox ID="txtValor" runat="server"></asp:TextBox>
                        </td>
                </tr>
                <tr>
                    <td>
                        Numero Documento
                    </td>
                    <td>
                        <asp:TextBox ID="txtNumeroDocumento" runat="server"></asp:TextBox>
                        </td>
                </tr>
                <tr>
                    <td>
                        IRPJ
                    </td>
                    <td>
                        <asp:TextBox ID="txtIRPJ" runat="server"></asp:TextBox>
                        </td>
                </tr>
                <tr>
                    <td>
                        Cofins
                    </td>
                    <td>
                        <asp:TextBox ID="txtCofins" runat="server"></asp:TextBox>
                        </td>
                </tr>
                <tr>
                    <td>
                        CSLL
                    </td>
                    <td>
                        <asp:TextBox ID="txtCSLL" runat="server"></asp:TextBox>
                        </td>
                </tr>
                <tr>
                    <td>
                        PIS
                    </td>
                    <td>
                        <asp:TextBox ID="txtPIS" runat="server"></asp:TextBox>
                        </td>
                </tr>
                <tr>
                    <td>
                        ISS
                    </td>
                    <td>
                        <asp:TextBox ID="txtISS" runat="server"></asp:TextBox>
                        </td>
                </tr>
                <tr>
                    <td>
                        NOTA
                    </td>
                    <td>
                        <asp:FileUpload ID="FUpNota" runat="server" Width="400px" />
                        </td>
                </tr>
                <tr>
                    <td>
                        Boleto
                    </td>
                    <td>
                        <asp:FileUpload ID="FUpBoleto" runat="server" Width="400px" />
                        </td>
                </tr>
                <tr>
                    <td>
                        Comprovante
                    </td>
                    <td>
                        <asp:FileUpload ID="FUpComprovante" runat="server" Width="400px" />
                        </td>
                </tr>
                <tr>
                    <td>
                        Data Pgto.</td>
                    <td>
                        <asp:TextBox ID="txtDtPgto" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Fornecedor</td>
                    <td>
                        <asp:ListBox ID="lstFornecedor" runat="server" Width="400px"></asp:ListBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Dados Bancario
                    </td>
                    <td>
                        <asp:ListBox ID="lstDadosBancario" runat="server" Width="400px"></asp:ListBox>
                        </td>
                </tr>
                <tr>
                    <td>
                        Dedutivel
                    </td>
                    <td>
                        <asp:CheckBox ID="cbDedutivel" runat="server"></asp:CheckBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="BtnCadastroSim" runat="server" CssClass="ButtonSalvar" Text="" Width="79px"
                            OnClick="BtnCadastroSim_Click" />
                        <asp:Button ID="btCadastrar_Nao" runat="server" CssClass="ButtonCancelar" Text=""
                            ValidationGroup="Cancelar" Width="79px" OnClick="btCadastrar_Nao_Click" />
                        <asp:HiddenField ID="hdfIdDespesa" runat="server" Value="-1" />
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    
    <uc1:MensagemOK ID="MensagemOK" runat="server" />
    </form>
</body>
</html>
