using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControleFinanceiro.UI.Presentation.App_Code;

namespace ControleFinanceiro.UI.Presentation.Pages.Logados.ParqueGrafico
{
    public partial class BoletoCarteira : BasePage
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
            Master.NomeAplicacao = "Cadastro Boleto Carteira";
            Master.DescricaoAplicacao = "Tela para Cadastro e Manutenção de Boleto Carteiras.";

            ControleFinanceiro.UI.Presentation.App_Code.Common.Tree<DTO.Carteira> tree = new App_Code.Common.Tree<DTO.Carteira>();
            tree.DataSource = new BLL.Carteira().Select();
            tree.Id = "Id";
            tree.Descricao = "Descricao";
            tree.IdPai = "IdPai";

            trwCarteira.Nodes.Clear();
            trwCarteira.Nodes.Add(tree.DataBind());
            trwCarteira.DataBind();


            lstCredor.Items.Clear();
            lstCredor.DataSource = new BLL.CobNetCredor().Select();
            lstCredor.DataTextField = "Descricao";
            lstCredor.DataValueField = "IdCredor";
            lstCredor.DataBind();
        }

        protected void lstCredor_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<DTO.CobNetSegmento> segmentos = new List<DTO.CobNetSegmento>();
            foreach(ListItem item in lstCredor.Items)
            {
                if (item.Selected)
                {
                    segmentos.AddRange(new BLL.CobNetSegmento().SelectPeloCredId(item.Value.ToInt()));

                }
            }

            lstSegmento.Items.Clear();
            lstSegmento.DataSource = segmentos;
            lstSegmento.DataTextField = "Descricao";
            lstSegmento.DataValueField = "IdSegmento";
            lstSegmento.DataBind();
        }

        protected void btnSalvarAlteracao_Click(object sender, EventArgs e)
        {
            if (lstCredor.SelectedIndex == -1)
            {
                Master.ShowMessage("Favor Selecionar um Credor!");
                return;
            }

            new BLL.BoletoCarteira().RemovePelaIdCarteira(hdfIdCarteira.Value.ToInt());

            if ((lstProduto.SelectedIndex == -1) && (lstSegmento.SelectedIndex == -1))
                foreach (ListItem item in lstCredor.Items)
                {
                    if (item.Selected)
                    {

                        DTO.BoletoCarteira boletoCarteira = new BLL.BoletoCarteira().SelectPelaIdCarteira(hdfIdCarteira.Value.ToInt()).Where(c => c.Credor.Equals(item.Value.ToInt())).FirstOrDefault();

                        if (boletoCarteira == null)
                            boletoCarteira = new DTO.BoletoCarteira();

                        boletoCarteira.IdCarteira = hdfIdCarteira.Value.ToInt();
                        boletoCarteira.Credor = item.Value.ToInt();
                        new BLL.BoletoCarteira().Cadastro(boletoCarteira);
                    }
                }

            if (lstProduto.SelectedIndex == -1)
                foreach (ListItem item in lstSegmento.Items)
                {
                    if (item.Selected)
                    {
                        DTO.BoletoCarteira boletoCarteira = new BLL.BoletoCarteira().SelectPelaIdCarteira(hdfIdCarteira.Value.ToInt()).Where(c => c.Segmento.Equals(item.Value.ToInt())).FirstOrDefault();

                        if (boletoCarteira == null)
                            boletoCarteira = new DTO.BoletoCarteira();

                        boletoCarteira.IdCarteira = hdfIdCarteira.Value.ToInt();
                        boletoCarteira.Segmento = item.Value.ToInt();
                        new BLL.BoletoCarteira().Cadastro(boletoCarteira);
                    }
                }


            foreach (ListItem item in lstProduto.Items)
            {
                if (item.Selected)
                {
                    DTO.BoletoCarteira boletoCarteira = new BLL.BoletoCarteira().SelectPelaIdCarteira(hdfIdCarteira.Value.ToInt()).Where(c => c.Produto.Equals(item.Value.ToInt())).FirstOrDefault();

                    if (boletoCarteira == null)
                        boletoCarteira = new DTO.BoletoCarteira();

                    boletoCarteira.IdCarteira = hdfIdCarteira.Value.ToInt();
                    boletoCarteira.Produto = item.Value.ToInt();
                    new BLL.BoletoCarteira().Cadastro(boletoCarteira);
                }
            }

            Master.ShowMessage("Cadastrado Com Sucesso!");
            PanelAlterar.Visible = false;
            MontaTela();
        }

        protected void lstSegmento_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<DTO.CobNetProduto> produtos = new List<DTO.CobNetProduto>();
            foreach (ListItem item in lstSegmento.Items)
            {
                if (item.Selected)
                {
                    produtos.AddRange(new BLL.CobNetProduto().SelectPeloSegId(item.Value.ToInt()));

                }
            }
            lstProduto.Items.Clear();
            lstProduto.DataSource = produtos;
            lstProduto.DataTextField = "Descricao";
            lstProduto.DataValueField = "IdProduto";
            lstProduto.DataBind();
        }

        protected void trwCarteira_SelectedNodeChanged(object sender, EventArgs e)
        {
            lstCredor.ClearSelection();
            lstSegmento.ClearSelection();
            lstProduto.ClearSelection();

            string credores = string.Empty, segmentos = string.Empty, produtos = string.Empty;

            DTO.Carteira carteira = new BLL.Carteira().SelectPelaPK(trwCarteira.SelectedValue.ToInt());
            lblCarteira.Text = carteira.Descricao;
            hdfIdCarteira.Value = carteira.Id.ToString();

            List<DTO.BoletoCarteira> boletoCarteira = new BLL.BoletoCarteira().SelectPelaIdCarteira(carteira.Id);
            foreach (var x in boletoCarteira.GroupBy(c => c.Credor))
                credores += x.Key.ToString() + ", ";
            foreach (var x in boletoCarteira.GroupBy(c => c.Segmento))
                segmentos += x.Key.ToString() + ", ";
            foreach (var x in boletoCarteira.GroupBy(c => c.Produto))
                produtos += x.Key.ToString() + ", ";

            if (credores.Length > 0)
                credores = credores.Remove(credores.Length - 2);
            if (segmentos.Length > 0)
                segmentos = segmentos.Remove(segmentos.Length - 2);
            if (produtos.Length > 0)
                produtos = produtos.Remove(produtos.Length - 2);

            List<DTO.CobNetBoletoCarteira> cobNetBoletoCampanha = new BLL.CobNetBoletoCampanha().Select(credores, segmentos, produtos);

            foreach (var x in cobNetBoletoCampanha.GroupBy(c => c.Credor))
            {
                if (x.Key != 0)
                {
                    lstCredor.Items.FindByValue(x.Key.ToString()).Selected = true;
                }
            }
            lstCredor_SelectedIndexChanged(sender, e);

            foreach (var x in cobNetBoletoCampanha.GroupBy(c => c.Segmento))
            {
                if (x.Key != 0)
                {
                    lstSegmento.Items.FindByValue(x.Key.ToString()).Selected = true;
                }
            }
            lstSegmento_SelectedIndexChanged(sender, e);

            foreach (var x in cobNetBoletoCampanha.GroupBy(c => c.Produto))
            {
                if (x.Key != 0)
                {
                    lstProduto.Items.FindByValue(x.Key.ToString()).Selected = true;
                }
            }

            PanelAlterar.Visible = true;
        }

        protected void lkbDesSelecionarCredor_Click(object sender, EventArgs e)
        {
            lstCredor.ClearSelection();
            lstSegmento.ClearSelection();
            lstProduto.ClearSelection();
        }

        protected void lkbDesSelecionarSegmento_Click(object sender, EventArgs e)
        {
            lstSegmento.ClearSelection();
            lstProduto.ClearSelection();
        }

        protected void lkbDesSelecionarProduto_Click(object sender, EventArgs e)
        {
            lstProduto.ClearSelection();
        }            
    }
}