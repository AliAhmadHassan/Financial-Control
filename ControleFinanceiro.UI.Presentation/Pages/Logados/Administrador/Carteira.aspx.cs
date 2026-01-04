using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControleFinanceiro.UI.Presentation.App_Code;

namespace ControleFinanceiro.UI.Presentation.Pages.Logados.Administrador
{
    public partial class Carteira : BasePage
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
            Master.NomeAplicacao = "Cadastro Grupo";
            Master.DescricaoAplicacao = "Tela para Cadastro e Manutenção de Grupo.";

            ControleFinanceiro.UI.Presentation.App_Code.Common.Tree<DTO.Carteira> tree = new App_Code.Common.Tree<DTO.Carteira>();
            tree.DataSource = new BLL.Carteira().Select();
            tree.Id = "Id";
            tree.Descricao = "Descricao";
            tree.IdPai = "IdPai";

            trwCarteira.Nodes.Clear();
            trwCarteira.Nodes.Add(tree.DataBind());
            trwCarteira.DataBind();

            RBLTipo.DataSource = new BLL.CarteiraTipo().Select();
            RBLTipo.DataTextField = "Descricao";
            RBLTipo.DataValueField = "Id";
            RBLTipo.DataBind();

            RBLSubTipo.DataSource = new BLL.CarteiraTipo().Select();
            RBLSubTipo.DataTextField = "Descricao";
            RBLSubTipo.DataValueField = "Id";
            RBLSubTipo.DataBind();
        }

        protected void btNovo_Click(object sender, EventArgs e)
        {

        }

        protected void trwCarteira_SelectedNodeChanged(object sender, EventArgs e)
        {
            DTO.Carteira carteira = new BLL.Carteira().SelectPelaPK(trwCarteira.SelectedValue.ToInt());

            txtDescricao.Text = carteira.Descricao;
            txtObs.Text = carteira.Observacao;
            if (carteira.Predio != 0)
                lstPredio.SelectedValue = carteira.Predio.ToString();
            else
                lstPredio.SelectedIndex = -1;
            CbParticipaRateio.Checked = carteira.ParticipaRateio;
            PanelAlterar.Visible = true;
            hdfIdCarteira.Value = trwCarteira.SelectedValue;
            RBLTipo.SelectedValue = carteira.Tipo.ToString();
        }

        protected void btnSalvarAlteracao_Click(object sender, EventArgs e)
        {
            try
            {
                DTO.Carteira carteira = new BLL.Carteira().SelectPelaPK(hdfIdCarteira.Value.ToInt());
                carteira.Descricao = txtDescricao.Text;
                carteira.Observacao = txtObs.Text;
                carteira.Predio = lstPredio.SelectedValue.ToInt();
                carteira.ParticipaRateio = CbParticipaRateio.Checked;
                carteira.Tipo = RBLTipo.SelectedValue.ToInt();
                new BLL.Carteira().Cadastro(carteira);
                MontaTela();
                Master.ShowMessage("Alterado com Sucesso!");
            }
            catch (Exception Erro)
            {
                Master.ShowMessage(Erro.Message);
            }
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSubDescricao.Text))
            {
                Master.ShowMessage("Favor Preencher uma descrição!");
                return;
            }

            try
            {
                DTO.Carteira carteira = new DTO.Carteira();
                carteira.Descricao = txtSubDescricao.Text;
                carteira.Observacao = txtSubObs.Text;
                carteira.Predio = lstSubPredio.SelectedValue.ToInt();
                carteira.IdPai = hdfIdCarteira.Value.ToInt();
                carteira.ParticipaRateio = CbSubParticipaRateio.Checked;
                carteira.Tipo = RBLSubTipo.SelectedValue.ToInt();
                new BLL.Carteira().Cadastro(carteira);
                MontaTela();
                Master.ShowMessage("Cadastrado com Sucesso!");
            }
            catch (Exception Erro)
            {
                Master.ShowMessage(Erro.Message);
            }
        }
    }
}