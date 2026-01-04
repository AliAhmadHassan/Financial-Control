using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControleFinanceiro.UI.Presentation.App_Code;
using System.Net;
using System.Text;

namespace ControleFinanceiro.UI.Presentation.Pages.Logados.Financeiro
{
    public partial class DespesaRateio : System.Web.UI.Page
    {
        List<DTO.DespesaRateioCarteira> AuxdespesaRateioCarteiras = null;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hdfIdSegmento.Value = Request.QueryString.Get("IdSegmento");
                hdfIdCarteira.Value = Request.QueryString.Get("IdCarteira");
                hdfMesReferencia.Value = Request.QueryString.Get("MesReferencia");

                MontaGrid();

                lstDadosBancario.DataSource = new BLL.DadosBancario().Select().OrderBy(c => c.Descricao).ToList();
                lstDadosBancario.DataTextField = "Descricao";
                lstDadosBancario.DataValueField = "Id";
                lstDadosBancario.DataBind();

                lstFornecedor.DataSource = new BLL.Fornecedor().Select().OrderBy(c => c.Nome).ToList();
                lstFornecedor.DataTextField = "Nome";
                lstFornecedor.DataValueField = "Id";
                lstFornecedor.DataBind();
            }
        }

        private void MontaTelaCarteira(string CarteirasReferencia)
        {
            ControleFinanceiro.UI.Presentation.App_Code.Common.Tree<DTO.Carteira> tree = new App_Code.Common.Tree<DTO.Carteira>();
            tree.DataSource = new BLL.Carteira().SelectIdentado();
            tree.Id = "Id";
            tree.Descricao = "Descricao";
            tree.IdPai = "IdPai";

            TreeNode treeNode = tree.DataBind();

            StringBuilder html = new StringBuilder();
            html.AppendLine(string.Format(@"<table width='{0}px'>", 600));
            #region Cabeçalho
            html.AppendLine(@"
<tr>
    <td style='border-bottom:1px dotted black; background-color:Black; color:White;'>
        <b>Grupo</b>
    </td>
    <td style='border-bottom:1px dotted black; text-align:center; background-color:Black; color:White;'>
        <b>%</b></td>
</tr>
");
            html.AppendLine("");
            #endregion

            #region Detail
            html.AppendLine(string.Format(@"
<tr>
    <td style='border-bottom:1px dotted black; background-color:#267597;'>
        {0}
    </td>
    <td style='border-bottom:1px dotted black; text-align:center; background-color:#267597;'>
        
    </td>
</tr>", treeNode.Text.Replace("    ", "&nbsp;&nbsp;&nbsp;&nbsp;")));

            Aux(html, treeNode, CarteirasReferencia);
            #endregion
            html.AppendLine(@"</table>");

            ltlCarteira.Text = html.ToString();
        }

        private void Aux(StringBuilder html, TreeNode treenode, string CarteirasReferencia)
        {

            foreach (TreeNode node in treenode.ChildNodes)
            {
                decimal Percentual = 0;
                if (AuxdespesaRateioCarteiras != null)
                {
                    DTO.DespesaRateioCarteira aux = AuxdespesaRateioCarteiras.Where(c => c.IdCarteira.Equals(node.Value.ToInt())).FirstOrDefault();
                    if (aux != null)
                        Percentual = aux.Percentual;
                    else
                    {
                        if (CarteirasReferencia.Split(',').Contains(node.Value))
                            Percentual = new BLL.ControleAcessoUsuario().SelectProporcao(node.Value.ToInt(), CarteirasReferencia);
                    }
                }
                else
                {
                    if (CarteirasReferencia.Split(',').Contains(node.Value))
                        Percentual = new BLL.ControleAcessoUsuario().SelectProporcao(node.Value.ToInt(), CarteirasReferencia);
                }


                html.AppendLine(string.Format(@"
<tr>
    <td style='border-bottom:1px dotted black; {2}'>
        {0}
    </td>
    <td style='border-bottom:1px dotted black; text-align:center; {2}'>
        {1}
    </td>
</tr>", node.Text.Replace("    ", "&nbsp;&nbsp;&nbsp;&nbsp;")
      , node.ChildNodes.Count == 0 ? string.Format("<input id='Tb{0}' name='Tb{0}' type='text' value='{1}' style='width:50px' />", node.Value, Percentual.ToString("0.00")) : ""
      , node.ChildNodes.Count > 0 ? "background-color:#267597;" : ""
      ));
                if (node.ChildNodes.Count > 0)
                    Aux(html, node, CarteirasReferencia);
            }
        }
        protected void MontaGrid()
        {
            if ((hdfIdSegmento.Value != string.Empty) && (hdfIdCarteira.Value != string.Empty))
            {
                List<DTO.DespesaRateio> Despesa = new BLL.DespesaRateio().SelectPeloSegmento(hdfIdSegmento.Value.ToInt());
                int Mes = hdfMesReferencia.Value.Split('/')[0].ToInt(), Ano = hdfMesReferencia.Value.Split('/')[1].ToInt();

                GdvDespesa.DataSource = Despesa.Where(c => c.IdCarteira.Equals(hdfIdCarteira.Value.ToInt()) && c.Vencimento.Month.Equals(Mes) && c.Vencimento.Year.Equals(Ano)).ToList();
                GdvDespesa.DataBind();
            }
        }

        protected void BtnCadastroSim_Click(object sender, EventArgs e)
        {
            PanelTipoRateio_ModalPopupExtender.Show();
        }

        protected void btnTipoRateioOk_Click(object sender, EventArgs e)
        {
            string TipoRateio = RbtnTipoRateio.SelectedValue;
            string CarteirasReferencia = ConsultaCarteira(TipoRateio);
            MontaTelaCarteira(CarteirasReferencia);
            Panel_Carteira_ModalPopupExtender.Show();
        }

        private string ConsultaCarteira(string TipoRateio)
        {
            StringBuilder SBretorno = new StringBuilder();
            switch (TipoRateio)
            {
                case "Predio19":
                    foreach (DTO.Carteira carteira in new BLL.Carteira().SelectPeloPredio(19))
                        SBretorno.Append(string.Format("{0},", carteira.Id));
                    break;

                case "Predio190":
                    foreach (DTO.Carteira carteira in new BLL.Carteira().SelectPeloPredio(190))
                        SBretorno.Append(string.Format("{0},", carteira.Id));
                    break;

                case "Pessoas_Operacional":
                    foreach (DTO.Carteira carteira in new BLL.Carteira().SelectPeloPessoas_Operacional())
                        SBretorno.Append(string.Format("{0},", carteira.Id));
                    break;

                case "Pessoas":
                    foreach (DTO.Carteira carteira in new BLL.Carteira().SelectPeloPredio(19))
                        SBretorno.Append(string.Format("{0},", carteira.Id));
                    foreach (DTO.Carteira carteira in new BLL.Carteira().SelectPeloPredio(190))
                        SBretorno.Append(string.Format("{0},", carteira.Id));
                    break;

                case "Salario":
                    MensagemOK.ShowMessage("Tipo de Rateio não implementado!");
                    break;

                case "Predio19_0":
                    foreach (DTO.Carteira carteira in new BLL.Carteira().SelectPeloPredio(19))
                        SBretorno.Append(string.Format("{0},", carteira.Id));
                    foreach (DTO.Carteira carteira in new BLL.Carteira().SelectPeloPredio(0))
                        SBretorno.Append(string.Format("{0},", carteira.Id));
                    break;

            }

            return SBretorno.ToString();
        }

        protected void btCadastrar_Nao_Click(object sender, EventArgs e)
        {

        }

        protected void GdvDespesa_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GdvDespesa.PageIndex = e.NewPageIndex;
            MontaGrid();
        }

        protected void GdvDespesa_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Alterar":
                    PopularCampos(int.Parse(GdvDespesa.Rows[int.Parse(e.CommandArgument.ToString())].Cells[9].Text.Replace("&nbsp;", string.Empty)));
                    break;

                case "Excluir":
                    Excluir(int.Parse(GdvDespesa.Rows[int.Parse(e.CommandArgument.ToString())].Cells[9].Text.Replace("&nbsp;", string.Empty)));
                    break;

                case "ExibirNota":
                    {
                        DTO.DespesaRateio Despesa = new BLL.DespesaRateio().SelectPelaPK(int.Parse(GdvDespesa.Rows[int.Parse(e.CommandArgument.ToString())].Cells[9].Text.Replace("&nbsp;", string.Empty)));
                        if (Despesa.Nota == null)
                        {
                            MensagemOK.ShowMessage("Nota Não Inclusa na Base de Dados.");
                            break;
                        }
                        ExibirArquivo(Despesa.Nota, Despesa.ExtensaoNota);
                    }
                    break;

                case "ExibirBoleto":
                    {
                        DTO.DespesaRateio despesa = new BLL.DespesaRateio().SelectPelaPK(int.Parse(GdvDespesa.Rows[int.Parse(e.CommandArgument.ToString())].Cells[9].Text.Replace("&nbsp;", string.Empty)));
                        if (despesa.Boleto == null)
                        {
                            MensagemOK.ShowMessage("Boleto Não Incluso na Base de Dados.");
                            break;
                        }
                        ExibirArquivo(despesa.Boleto, despesa.ExtensaoBoleto);
                    }
                    break;

                case "ExibirComprovante":
                    {
                        DTO.DespesaRateio despesa = new BLL.DespesaRateio().SelectPelaPK(int.Parse(GdvDespesa.Rows[int.Parse(e.CommandArgument.ToString())].Cells[9].Text.Replace("&nbsp;", string.Empty)));
                        if (despesa.Boleto == null)
                        {
                            MensagemOK.ShowMessage("Comprovante Não Incluso na Base de Dados.");
                            break;
                        }
                        ExibirArquivo(despesa.Comprovante, despesa.ExtensaoComprovante);
                    }
                    break;
            }
        }

        private void ExibirArquivo(Byte[] Arquivo, string Extensao)
        {

            WebClient req = new WebClient();
            HttpResponse response = HttpContext.Current.Response;
            response.Clear();
            response.ClearContent();
            response.ClearHeaders();
            response.Buffer = true;
            response.AddHeader("Content-Disposition", "attachment;filename=\"Document" + Extensao + "\"");
            response.BinaryWrite(Arquivo);
            response.End();
        }

        private void Excluir(int id)
        {
            DTO.DespesaRateio Despesa = new BLL.DespesaRateio().SelectPelaPK(id);
            new BLL.DespesaRateioCarteira().Remover(id);
            new BLL.DespesaRateio().Remover(Despesa);
            MontaGrid();
        }

        private void PopularCampos(int id)
        {
            AuxdespesaRateioCarteiras = new BLL.DespesaRateioCarteira().SelectPeloDespesasRatio(id);

            DTO.DespesaRateio Despesa = new BLL.DespesaRateio().SelectPelaPK(id);
            hdfIdDespesa.Value = Despesa.Id.ToString();
            txtCofins.Text = Despesa.Cofins.ToString();
            txtCSLL.Text = Despesa.CSLL.ToString();
            cbDedutivel.Checked = Despesa.Dedutivel;
            txtEmissao.Text = Despesa.Emissao.ToString("dd/MM/yyyy");
            lstDadosBancario.SelectedValue = Despesa.IdDadosBancario.ToString();

            if (Despesa.IdFornecedor != 0)
                lstFornecedor.SelectedValue = Despesa.IdFornecedor.ToString();

            txtIRPJ.Text = Despesa.IRPJ.ToString();
            txtISS.Text = Despesa.ISS.ToString();
            txtNumeroDocumento.Text = Despesa.NumeroDocumento.ToString();
            txtDtPgto.Text = Despesa.DtPgto.ToString();
            txtDescricao.Text = Despesa.Descricao;
            txtPIS.Text = Despesa.PIS.ToString();
            txtValor.Text = Despesa.Valor.ToString();
            txtVencimento.Text = Despesa.Vencimento.ToString("dd/MM/yyyy");
            

            Panel_Cadastro_ModalPopupExtender.Show();
        }

        protected void GdvDespesa_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[7].Text = new BLL.Usuario().SelectPelaPK(e.Row.Cells[8].Text.ToInt()).Nome;
                if (e.Row.Cells[2].Text == "01/01/0001")
                    e.Row.Cells[2].Text = string.Empty;
                if (e.Row.Cells[3].Text == "01/01/0001")
                    e.Row.Cells[3].Text = string.Empty;
                if (e.Row.Cells[4].Text == "01/01/0001")
                    e.Row.Cells[4].Text = string.Empty;
                if (e.Row.Cells[5].Text == "01/01/0001")
                    e.Row.Cells[5].Text = string.Empty;
            }
        }

        protected void btnCarteiraSalvar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ddlMeses.SelectedValue.ToInt(); i++)
            {
                List<DTO.Carteira> carteiras = new BLL.Carteira().Select();
                List<DTO.DespesaRateioCarteira> despesaRateioCarteiras = new List<DTO.DespesaRateioCarteira>();

                decimal Total = 0;
                foreach (DTO.Carteira carteira in carteiras)
                {
                    string tbaux = Request["Tb" + carteira.Id];
                    if ((!string.IsNullOrEmpty(tbaux)) && (tbaux != "0,00"))
                    {
                        Total += tbaux.ToDecimal();

                        DTO.DespesaRateioCarteira despesaRateioCarteira = new DTO.DespesaRateioCarteira();
                        despesaRateioCarteira.IdCarteira = carteira.Id;
                        despesaRateioCarteira.IdDespesasRateio = 0;
                        despesaRateioCarteira.Percentual = tbaux.ToDecimal();
                        despesaRateioCarteiras.Add(despesaRateioCarteira);
                    }
                }

                if (Total != 100)
                {
                    MensagemOK.ShowMessage(string.Format("Proprorção não totalizado em 100% (Somatoria {0}%)", Total));
                    return;
                }

                int Mes = hdfMesReferencia.Value.Split('/')[0].ToInt(), Ano = hdfMesReferencia.Value.Split('/')[0].ToInt();

                DTO.DespesaRateio Despesa = hdfIdDespesa.Value == "-1" ? new DTO.DespesaRateio() : new BLL.DespesaRateio().SelectPelaPK(hdfIdDespesa.Value.ToInt());
                if (FUpBoleto.HasFile)
                {
                    Despesa.ExtensaoBoleto = FUpBoleto.FileName.Substring(FUpBoleto.FileName.LastIndexOf('.'));
                    Despesa.Boleto = FUpBoleto.FileBytes;
                }
                if (FUpNota.HasFile)
                {
                    Despesa.ExtensaoNota = FUpNota.FileName.Substring(FUpNota.FileName.LastIndexOf('.'));
                    Despesa.Nota = FUpNota.FileBytes;
                }
                if (FUpComprovante.HasFile)
                {
                    Despesa.ExtensaoComprovante = FUpComprovante.FileName.Substring(FUpComprovante.FileName.LastIndexOf('.'));
                    Despesa.Comprovante = FUpComprovante.FileBytes;
                }
                Despesa.Cofins = txtCofins.Text.ToDecimal();
                Despesa.CSLL = txtCSLL.Text.ToDecimal();
                Despesa.Dedutivel = cbDedutivel.Checked;
                Despesa.Emissao = txtEmissao.Text.ToDateTime().AddMonths(i);
                Despesa.IdCarteira = hdfIdCarteira.Value.ToInt();
                Despesa.IdDadosBancario = lstDadosBancario.SelectedValue.ToInt();
                Despesa.IdSegmento = hdfIdSegmento.Value.ToInt();
                Despesa.IdUsuario = ((DTO.Usuario)Session["Usuario"]).Id;
                Despesa.IRPJ = txtIRPJ.Text.ToDecimal();
                Despesa.ISS = txtISS.Text.ToDecimal();
                Despesa.NumeroDocumento = txtNumeroDocumento.Text.ToInt();

                if (i == 0)
                {
                    if (!string.IsNullOrEmpty(txtDtPgto.Text))
                        Despesa.DtPgto = txtDtPgto.Text.ToDateTime();
                }

                Despesa.Descricao = txtDescricao.Text;
                Despesa.PIS = txtPIS.Text.ToDecimal();
                Despesa.Valor = txtValor.Text.ToDecimal();
                Despesa.Vencimento = txtVencimento.Text.ToDateTime().AddMonths(i);
                Despesa.IdFornecedor = lstFornecedor.SelectedValue.ToInt();
                try
                {
                    new BLL.DespesaRateio().Cadastro(Despesa, despesaRateioCarteiras);
                    MontaGrid();
                    MensagemOK.ShowMessage("Despesa Cadastrado com Sucesso!");
                }
                catch (Exception erro)
                {
                    MensagemOK.ShowMessage(erro.Message);
                }
            }
        }

        protected void btnTipoRateioCancel_Click(object sender, EventArgs e)
        {

        }

      
    }
}