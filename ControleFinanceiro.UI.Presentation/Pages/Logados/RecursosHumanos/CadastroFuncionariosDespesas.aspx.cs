using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControleFinanceiro.UI.Presentation.App_Code;


namespace ControleFinanceiro.UI.Presentation.Pages.Logados.RecursosHumanos
{
    public partial class CadastroFuncionariosDespesas : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                MontaTela();
        }

        private void MontaTela()
        {
            Master.NomeAplicacao = "Cadastro Despesas com Funcionario";
            Master.DescricaoAplicacao = "Tela para Cadastro das Despesas de mão de obra direta.";

            GdvUsuario.DataSource = new BLL.ControleAcessoUsuario().Select();
            GdvUsuario.DataBind();
        }
        protected void GdvUsuario_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[5].Text = new BLL.Carteira().SelectPelaPK(e.Row.Cells[5].Text.ToInt()).Descricao;
            }
        }

        protected void BtnNovo_Click(object sender, EventArgs e)
        {
        }

        protected void btCadastrar_Sim_Click(object sender, EventArgs e)
        {
            try
            {
                DTO.FuncionarioDespesas aux = new BLL.FuncionarioDespesas().SelectPelaIdControleAcesso(hdfIdControleAcesso.Value.ToInt());

                DTO.FuncionarioDespesas funcionarioDespesas = new DTO.FuncionarioDespesas();
                if (aux != null)
                    funcionarioDespesas.Id = aux.Id;
                funcionarioDespesas.AjudaCusto = txtAjudaCusto.Text.ToDecimal();
                funcionarioDespesas.DecimoTerceiro = txtDecimoTerceiro.Text.ToDecimal();
                funcionarioDespesas.Ferias = txtFerias.Text.ToDecimal();
                funcionarioDespesas.FGTS = txtFGTS.Text.ToDecimal();
                funcionarioDespesas.IdControleAcesso = hdfIdControleAcesso.Value.ToInt();
                funcionarioDespesas.Indenizacoes = txtIndenizacoes.Text.ToDecimal();
                funcionarioDespesas.INSS = txtINSS.Text.ToDecimal();
                funcionarioDespesas.MultaRescisorias = txtMultaRescisorias.Text.ToDecimal();
                funcionarioDespesas.Salario = txtSalario.Text.ToDecimal();
                funcionarioDespesas.Extra = txtExtra.Text.ToDecimal();

                new BLL.FuncionarioDespesas().Cadastro(funcionarioDespesas);

                Master.ShowMessage("Valores Definidos com Sucesso!");
                MontaTela();
            }
            catch (Exception erro)
            {
                Master.ShowMessage(erro.Message);
            }
        }
        protected void btCadastrar_Nao_Click(object sender, EventArgs e)
        {

        }

        protected void GdvUsuario_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            switch (e.CommandName)
            {
                case "Alterar":
                    PopularCampos(int.Parse(GdvUsuario.Rows[int.Parse(e.CommandArgument.ToString())].Cells[6].Text.Replace("&nbsp;", string.Empty)));
                    break;
            }
        }

        private void PopularCampos(int id)
        {
            hdfIdControleAcesso.Value = id.ToString();

            DTO.FuncionarioDespesas funcionarioDespesas = new BLL.FuncionarioDespesas().SelectPelaIdControleAcesso(id);
            txtSalario.Text = funcionarioDespesas.Salario.ToString();
            txtAjudaCusto.Text = funcionarioDespesas.AjudaCusto.ToString();
            txtFerias.Text = funcionarioDespesas.Ferias.ToString();
            txtDecimoTerceiro.Text = funcionarioDespesas.DecimoTerceiro.ToString();
            txtFGTS.Text = funcionarioDespesas.FGTS.ToString();
            txtINSS.Text = funcionarioDespesas.INSS.ToString();
            txtMultaRescisorias.Text = funcionarioDespesas.MultaRescisorias.ToString();
            txtIndenizacoes.Text = funcionarioDespesas.Indenizacoes.ToString();
            txtExtra.Text = funcionarioDespesas.Extra.ToString();

            Panel_Cadastrar_ModalPopupExtender.Show();
        }

        protected void GdvUsuario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GdvUsuario.PageIndex = e.NewPageIndex;
            MontaTela();
        }
    }
}