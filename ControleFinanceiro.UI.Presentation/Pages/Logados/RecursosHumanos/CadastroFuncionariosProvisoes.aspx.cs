using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControleFinanceiro.UI.Presentation.App_Code;

namespace ControleFinanceiro.UI.Presentation.Pages.Logados.RecursosHumanos
{
    public partial class CadastroFuncionariosProvisoes : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                MontaTela();
        }

        private void MontaTela()
        {
            Master.NomeAplicacao = "Cadastro Provisões com Funcionario";
            Master.DescricaoAplicacao = "Tela para Cadastro das provisões de mão de obra direta.";

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
                DTO.FuncionarioProvisoes aux = new BLL.FuncionarioProvisoes().SelectPelaIdControleAcesso(hdfIdControleAcesso.Value.ToInt());

                DTO.FuncionarioProvisoes FuncionarioProvisoes = new DTO.FuncionarioProvisoes();
                if (aux != null)
                    FuncionarioProvisoes.Id = aux.Id;
                FuncionarioProvisoes.DecimoTerceiro = txtDecimoTerceiro.Text.ToDecimal();
                FuncionarioProvisoes.Ferias = txtFerias.Text.ToDecimal();
                FuncionarioProvisoes.IdControleAcesso = hdfIdControleAcesso.Value.ToInt();
                FuncionarioProvisoes.INSSFerias = txtINSSFerias.Text.ToDecimal();
                FuncionarioProvisoes.FGTSFerias = txtFGTSFerias.Text.ToDecimal();
                FuncionarioProvisoes.INSS13Salario = txtINSSDecimoTerceiro.Text.ToDecimal();
                FuncionarioProvisoes.FGTS13Salario = txtFGTSDecimoTerceiro.Text.ToDecimal();
                FuncionarioProvisoes.ReclamacoesTrabalhistas = txtReclamacoesTrabalhistas.Text.ToDecimal();

                new BLL.FuncionarioProvisoes().Cadastro(FuncionarioProvisoes);

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

            DTO.FuncionarioProvisoes FuncionarioProvisoes = new BLL.FuncionarioProvisoes().SelectPelaIdControleAcesso(id);
            txtFerias.Text = FuncionarioProvisoes.Ferias.ToString();
            txtDecimoTerceiro.Text = FuncionarioProvisoes.DecimoTerceiro.ToString();
            txtINSSFerias.Text = FuncionarioProvisoes.INSSFerias.ToString();
            txtFGTSFerias.Text = FuncionarioProvisoes.FGTSFerias.ToString();
            txtINSSDecimoTerceiro.Text = FuncionarioProvisoes.INSS13Salario.ToString();
            txtFGTSDecimoTerceiro.Text = FuncionarioProvisoes.FGTS13Salario.ToString();
            txtReclamacoesTrabalhistas.Text = FuncionarioProvisoes.ReclamacoesTrabalhistas.ToString();


            Panel_Cadastrar_ModalPopupExtender.Show();
        }

        protected void GdvUsuario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GdvUsuario.PageIndex = e.NewPageIndex;
            MontaTela();
        }
    }
}