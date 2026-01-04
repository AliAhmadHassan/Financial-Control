using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControleFinanceiro.UI.Presentation.App_Code;

namespace ControleFinanceiro.UI.Presentation.Pages.Logados.Financeiro
{
    public partial class CadastroDespesasReceitas : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MontaTela();

                ddlReferencia.Items.Clear();
                for (int i = -12; i < 17; i++)
                {
                    ListItem item = new ListItem();
                    item.Text = MesReferente(DateTime.Today.AddMonths(-i).Month) + "/" + DateTime.Today.AddMonths(-i).Year.ToString("0000");
                    item.Value = DateTime.Today.AddMonths(-i).Month.ToString("00") + "/" + DateTime.Today.AddMonths(-i).Year.ToString("0000");

                    if (i == 0)
                        item.Selected = true;
                    else
                        item.Selected = false;

                    ddlReferencia.Items.Add(item);
                }
            }
        }
        private void MontaTela()
        {
            Master.NomeAplicacao = "Cadastro Receitas\\Despesas";
            Master.DescricaoAplicacao = "Tela para Cadastro das Despesas e Receitas de cada Carteira.";

            TreeViewSegmento();
            TreeViewCarteira();


        }

        private void TreeViewSegmento()
        {
            ControleFinanceiro.UI.Presentation.App_Code.Common.Tree<DTO.Segmento> tree = new App_Code.Common.Tree<DTO.Segmento>();
            tree.DataSource = new BLL.Segmento().Select();
            tree.Id = "Id";
            tree.Descricao = "Descricao";
            tree.IdPai = "IdPai";

            trwSegmento.Nodes.Clear();
            trwSegmento.Nodes.Add(tree.DataBind());
            trwSegmento.DataBind();
        }

        private void TreeViewCarteira()
        {
            ControleFinanceiro.UI.Presentation.App_Code.Common.Tree<DTO.Carteira> tree = new App_Code.Common.Tree<DTO.Carteira>();
            tree.DataSource = new BLL.Carteira().Select();
            tree.Id = "Id";
            tree.Descricao = "Descricao";
            tree.IdPai = "IdPai";

            trwCarteira.Nodes.Clear();
            trwCarteira.Nodes.Add(tree.DataBind());
            trwCarteira.DataBind();
        }

        protected void trwSegmento_SelectedNodeChanged(object sender, EventArgs e)
        {
            if (new BLL.Segmento().SelectPeloIdPai(trwSegmento.SelectedValue.ToInt()).Count == 0)
            {
                Accordion.SelectedIndex = 1;
                lblSegmento.Text = " - " + new BLL.Segmento().SelectPelaPK(trwSegmento.SelectedValue.ToInt()).Descricao;
                hdfIdSegmento.Value = trwSegmento.SelectedValue;
                MontaGrid();
            }
        }

        protected void trwCarteira_SelectedNodeChanged(object sender, EventArgs e)
        {
            if (new BLL.Carteira().SelectPeloIdPai(trwCarteira.SelectedValue.ToInt()).Count == 0 || trwCarteira.SelectedValue.ToInt() == 24)
            {
                Accordion.SelectedIndex = 2;
                hdfIdCarteira.Value = trwCarteira.SelectedValue;
                lblCarteira.Text = " - " + new BLL.Carteira().SelectPelaPK(trwCarteira.SelectedValue.ToInt()).Descricao;
                MontaGrid();
            }
        }

        protected void MontaGrid()
        {
            if ((hdfIdSegmento.Value != "-1") && (hdfIdCarteira.Value != "-1"))
            {
                if ((new BLL.Segmento().SelectPeloIdPai(hdfIdSegmento.Value.ToInt()).Count == 0) && (new BLL.Carteira().SelectPeloIdPai(hdfIdCarteira.Value.ToInt()).Count == 0 || hdfIdCarteira.Value.ToInt() == 24))
                {
                    string script = string.Empty;
                    switch (new BLL.Segmento().SelectPelaPK(hdfIdSegmento.Value.ToInt()).IdTipoSegmento)
                    {
                        case 1: script = string.Format("abrir_popup('Receita.aspx?IdSegmento={0}&IdCarteira={1}&MesReferencia={2}','Receita',800,600)", hdfIdSegmento.Value, hdfIdCarteira.Value, ddlReferencia.SelectedValue);
                            break;
                        case 2: script = string.Format("abrir_popup('Despesa.aspx?IdSegmento={0}&IdCarteira={1}&MesReferencia={2}','Receita',800,600)", hdfIdSegmento.Value, hdfIdCarteira.Value, ddlReferencia.SelectedValue);
                            break;
                        case 4: script = string.Format("abrir_popup('DespesaRateio.aspx?IdSegmento={0}&IdCarteira={1}&MesReferencia={2}','Receita',800,600)", hdfIdSegmento.Value, hdfIdCarteira.Value, ddlReferencia.SelectedValue);
                            break;
                    }

                    ClientScript.RegisterClientScriptBlock(this.GetType(), Guid.NewGuid().ToString(), script, true);
                }
            }
        }

        protected void GdvDespesaReceita_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Cells[4].Text = new BLL.Usuario().SelectPelaPK(e.Row.Cells[4].Text.ToInt()).Nome;
        }

        protected void GdvDespesaReceita_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GdvDespesaReceita.PageIndex = e.NewPageIndex;
            MontaGrid();
        }

        protected void GdvDespesaReceita_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Alterar":
                    PopularCampos(int.Parse(GdvDespesaReceita.Rows[int.Parse(e.CommandArgument.ToString())].Cells[6].Text.Replace("&nbsp;", string.Empty)));
                    break;

                case "Excluir":
                    Excluir(int.Parse(GdvDespesaReceita.Rows[int.Parse(e.CommandArgument.ToString())].Cells[6].Text.Replace("&nbsp;", string.Empty)));
                    break;
            }
        }

        private void Excluir(int p)
        {
            DTO.ReceitaDespesa receitaDespesa = new BLL.ReceitaDespesa().SelectPelaPK(p);
            if (receitaDespesa.Finalizado == true)
            {
                Master.ShowMessage("Receita\\Despesa Finalizada não pode ser Removido!");
                return;
            }

            new BLL.ReceitaDespesa().Remover(receitaDespesa);
            Master.ShowMessage("Removido com Sucesso!");
            MontaGrid();
        }

        private void PopularCampos(int p)
        {
            DTO.ReceitaDespesa receitaDespesa = new BLL.ReceitaDespesa().SelectPelaPK(p);
            txtValor.Text = receitaDespesa.Valor.ToString();
            Panel_Cadastro_ModalPopupExtender.Show();
            hdfIdReceitaDespesa.Value = p.ToString();
        }

        protected void BtnCadastroSim_Click(object sender, EventArgs e)
        {
            if (hdfIdCarteira.Value == "-1")
                Master.ShowMessage("Favor Selecionar uma Carteira!");
            else if (hdfIdSegmento.Value == "-1")
                Master.ShowMessage("Favor Selecionar um Segmento!");
            else
            {
                if (hdfIdReceitaDespesa.Value == "-1")
                {
                    int Mes = ddlReferencia.SelectedValue.Split('/')[0].ToInt(), Ano = ddlReferencia.SelectedValue.Split('/')[0].ToInt();

                    DTO.ReceitaDespesa receitaDespesa = new DTO.ReceitaDespesa();
                    receitaDespesa.Ano = Ano;
                    receitaDespesa.Mes = Mes;
                    receitaDespesa.Data = DateTime.Now;
                    receitaDespesa.Finalizado = false;
                    receitaDespesa.IdCarteira = hdfIdCarteira.Value.ToInt();
                    receitaDespesa.IdSegmento = hdfIdSegmento.Value.ToInt();
                    receitaDespesa.IdUsuario = 1;
                    receitaDespesa.Valor = txtValor.Text.ToDecimal();
                    try
                    {
                        new BLL.ReceitaDespesa().Cadastro(receitaDespesa);
                        MontaGrid();
                        Master.ShowMessage("Receita\\Despesa Cadastrado com Sucesso!");

                    }
                    catch (Exception erro)
                    {
                        Master.ShowMessage(erro.Message);
                    }

                }
                else
                {
                    DTO.ReceitaDespesa receitaDespesa = new BLL.ReceitaDespesa().SelectPelaPK(hdfIdReceitaDespesa.Value.ToInt());
                    receitaDespesa.Valor = txtValor.Text.ToDecimal();
                    try
                    {
                        new BLL.ReceitaDespesa().Cadastro(receitaDespesa);
                        MontaGrid();
                        Master.ShowMessage("Receita\\Despesa Alterado com Sucesso!");
                    }
                    catch (Exception erro)
                    {
                        Master.ShowMessage(erro.Message);
                    }
                }

            }
        }

        protected void BtnNovo_Click(object sender, EventArgs e)
        {
            Panel_Cadastro_ModalPopupExtender.Show();
        }

    }
}