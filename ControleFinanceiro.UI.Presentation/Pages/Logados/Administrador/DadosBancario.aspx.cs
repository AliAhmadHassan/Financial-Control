using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControleFinanceiro.UI.Presentation.App_Code;

namespace ControleFinanceiro.UI.Presentation.Pages.Logados.Administrador
{
    public partial class DadosBancario : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MontaTela();
            }
        }

        private void MontaTela()
        {
            Master.NomeAplicacao = "Cadastro Dados Bancarios";
            Master.DescricaoAplicacao = "Tela para Cadastro e Manutenção das Contas Bancarias.";

            GdvDadosBancario.DataSource = new BLL.DadosBancario().Select();
            GdvDadosBancario.DataBind();

            IdCadastrar.Value = "-1";
        }

        protected void GdvDadosBancario_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }

        protected void BtnNovo_Click(object sender, EventArgs e)
        {
            txtAgencia.Text = string.Empty;
            txtBanco.Text = string.Empty;
            txtContaCorrente.Text = string.Empty;
            txtDescricao.Text = string.Empty;
        }

        protected void btCadastrar_Sim_Click(object sender, EventArgs e)
        {
            try
            {
                DTO.DadosBancario dadosBancario = new DTO.DadosBancario();
                dadosBancario.Agencia = txtAgencia.Text;
                dadosBancario.Banco = txtBanco.Text;
                dadosBancario.ContaCorrente = txtContaCorrente.Text;
                dadosBancario.Descricao = txtDescricao.Text;
                dadosBancario.Id = IdCadastrar.Value.ToInt();
                dadosBancario.Empresa = txtEmpresa.Text;
                new BLL.DadosBancario().Cadastro(dadosBancario);
                Master.ShowMessage("Cadastrado com Sucesso!");
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

        protected void GdvDadosBancario_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Alterar":
                    PopularCampos(int.Parse(GdvDadosBancario.Rows[int.Parse(e.CommandArgument.ToString())].Cells[5].Text.Replace("&nbsp;", string.Empty)));
                    break;
            }
        }

        private void PopularCampos(int id)
        {
            DTO.DadosBancario dadosBancario = new BLL.DadosBancario().SelectPelaPK(id);
            txtAgencia.Text = dadosBancario.Agencia;
            txtBanco.Text = dadosBancario.Banco;
            txtContaCorrente.Text = dadosBancario.ContaCorrente;
            txtDescricao.Text = dadosBancario.Descricao;
            txtEmpresa.Text = dadosBancario.Empresa;
            IdCadastrar.Value = dadosBancario.Id.ToString();
            Panel_Cadastrar_ModalPopupExtender.Show();
        }

        protected void GdvDadosBancario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GdvDadosBancario.PageIndex = e.NewPageIndex;
            MontaTela();
        }
    }
}