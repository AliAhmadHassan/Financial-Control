using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControleFinanceiro.UI.Presentation.App_Code;

namespace ControleFinanceiro.UI.Presentation.Pages.Logados.Administrador
{
    public partial class Fornecedor : BasePage
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
            GdvFornecedor.DataSource = new BLL.Fornecedor().Select();
            GdvFornecedor.DataBind();


            Master.NomeAplicacao = "Cadastro Fornecedor";
            Master.DescricaoAplicacao = "Tela para Cadastro e Manutenção de Fornecedores.";
        }

        protected void GdvFornecedor_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GdvFornecedor.PageIndex = e.NewPageIndex;
            MontaTela();
        }

        protected void GdvFornecedor_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Alterar":
                    PopularCampos(int.Parse(GdvFornecedor.Rows[int.Parse(e.CommandArgument.ToString())].Cells[4].Text.Replace("&nbsp;", string.Empty)));
                    break;

                case "Excluir":
                    Excluir(int.Parse(GdvFornecedor.Rows[int.Parse(e.CommandArgument.ToString())].Cells[4].Text.Replace("&nbsp;", string.Empty)));
                    break;

            }
        }

        private void Excluir(int p)
        {
            new BLL.Fornecedor().Remover(new BLL.Fornecedor().SelectPelaPK(p));
            MontaTela();
        }

        private void PopularCampos(int p)
        {
            DTO.Fornecedor fornecedor = new BLL.Fornecedor().SelectPelaPK(p);
            txtCNPJ.Text = fornecedor.CNPJ;
            txtNome.Text = fornecedor.Nome;
            IdCadastrar.Value = fornecedor.Id.ToString();
            Panel_Cadastrar_ModalPopupExtender.Show();
        }

        protected void GdvFornecedor_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void BtnNovo_Click(object sender, EventArgs e)
        {

        }

        protected void btCadastrar_Sim_Click(object sender, EventArgs e)
        {
            try
            {
                DTO.Fornecedor fornecedor = new DTO.Fornecedor();
                fornecedor.Id = IdCadastrar.Value.ToInt();
                fornecedor.Nome = txtNome.Text;
                fornecedor.CNPJ = txtCNPJ.Text;
                new BLL.Fornecedor().Cadastro(fornecedor);
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
    }
}