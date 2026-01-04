using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ControleFinanceiro.UI.Presentation.App_Code;


namespace ControleFinanceiro.UI.Presentation.Pages.Logados.Relatorios.SegmentoCarteira
{
    public partial class SegmentoCarteira : System.Web.UI.Page
    {
        List<DTO.Carteira> Carteiras = new List<DTO.Carteira>();
        List<DTO.Segmento> Segmentos = new List<DTO.Segmento>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Carteiras = new BLL.Carteira().Select();
                Segmentos = new BLL.Segmento().Select();

                DateTime De = Session["De"].ToString().ToDateTime();
                DateTime Ate = Session["Ate"].ToString().ToDateTime();
                int TipoReceita = Session["TipoReceita"].ToString().ToInt();
                int TipoDespesa = Session["TipoDespesa"].ToString().ToInt();

                if (Session["IdSegmento"] != null)
                {
                    int IdSegmento = Session["IdSegmento"].ToString().ToInt();

                    switch (TipoReceita)
                    {
                        case 0:
                            gdvReceitas.DataSource = new BLL.Receita().SelectPeloSegmento(IdSegmento).Where(c => c.Emissao >= De && c.Emissao <= Ate).ToList();
                            break;
                        case 1:
                            gdvReceitas.DataSource = new BLL.Receita().SelectPeloSegmento(IdSegmento).Where(c => c.Vencimento >= De && c.Vencimento <= Ate).ToList();
                            break;
                        case 2:
                            gdvReceitas.DataSource = new BLL.Receita().SelectPeloSegmento(IdSegmento).Where(c => c.DtPgto >= De && c.DtPgto <= Ate).ToList();
                            break;
                    }

                    switch (TipoDespesa)
                    {
                        case 0:
                            gdvDespesas.DataSource = new BLL.Despesa().SelectPeloSegmento(IdSegmento).Where(c => c.Emissao >= De && c.Emissao <= Ate).ToList();
                            gdvDespesasRateio.DataSource = new BLL.DespesaRateio().SelectPeloSegmento(IdSegmento).Where(c => c.Emissao >= De && c.Emissao <= Ate).ToList();
                            break;
                        case 1:
                            gdvDespesas.DataSource = new BLL.Despesa().SelectPeloSegmento(IdSegmento).Where(c => c.Vencimento >= De && c.Vencimento <= Ate).ToList();
                            gdvDespesasRateio.DataSource = new BLL.DespesaRateio().SelectPeloSegmento(IdSegmento).Where(c => c.Vencimento >= De && c.Vencimento <= Ate).ToList();
                            break;
                        case 2:
                            gdvDespesas.DataSource = new BLL.Despesa().SelectPeloSegmento(IdSegmento).Where(c => c.DtPgto >= De && c.DtPgto <= Ate).ToList();
                            gdvDespesasRateio.DataSource = new BLL.DespesaRateio().SelectPeloSegmento(IdSegmento).Where(c => c.DtPgto >= De && c.DtPgto <= Ate).ToList();
                            break;
                    }


                }
                if (Session["IdCarteira"] != null)
                {
                    int IdCarteira = Session["IdCarteira"].ToString().ToInt();

                    switch (TipoReceita)
                    {
                        case 0:
                            gdvReceitas.DataSource = new BLL.Receita().SelectPelaCarteira(IdCarteira).Where(c => c.Emissao >= De && c.Emissao <= Ate).ToList();
                            break;
                        case 1:
                            gdvReceitas.DataSource = new BLL.Receita().SelectPelaCarteira(IdCarteira).Where(c => c.Vencimento >= De && c.Vencimento <= Ate).ToList();
                            break;
                        case 2:
                            gdvReceitas.DataSource = new BLL.Receita().SelectPelaCarteira(IdCarteira).Where(c => c.DtPgto >= De && c.DtPgto <= Ate).ToList();
                            break;
                    }

                    switch (TipoDespesa)
                    {
                        case 0:
                            gdvDespesas.DataSource = new BLL.Despesa().SelectPelaCarteira(IdCarteira).Where(c => c.Emissao >= De && c.Emissao <= Ate).ToList();
                            gdvDespesasRateio.DataSource = new BLL.DespesaRateio().SelectPelaCarteira(IdCarteira).Where(c => c.Emissao >= De && c.Emissao <= Ate).ToList();
                            break;
                        case 1:
                            gdvDespesas.DataSource = new BLL.Despesa().SelectPelaCarteira(IdCarteira).Where(c => c.Vencimento >= De && c.Vencimento <= Ate).ToList();
                            gdvDespesasRateio.DataSource = new BLL.DespesaRateio().SelectPelaCarteira(IdCarteira).Where(c => c.Vencimento >= De && c.Vencimento <= Ate).ToList();
                            break;
                        case 2:
                            gdvDespesas.DataSource = new BLL.Despesa().SelectPelaCarteira(IdCarteira).Where(c => c.DtPgto >= De && c.DtPgto <= Ate).ToList();
                            gdvDespesasRateio.DataSource = new BLL.DespesaRateio().SelectPelaCarteira(IdCarteira).Where(c => c.DtPgto >= De && c.DtPgto <= Ate).ToList();
                            break;
                    }
                }



                gdvReceitas.DataBind();
                gdvDespesas.DataBind();
                gdvDespesasRateio.DataBind();

            }
        }


        protected void gdvReceitas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            RowDataBound(e);
        }


        protected void gdvDespesas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            RowDataBound(e);
        }

        protected void gdvDespesasRateio_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            RowDataBound(e);
        }

        private void RowDataBound(GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[3].Text = Segmentos.Where(c => c.Id.Equals(e.Row.Cells[3].Text.ToInt())).FirstOrDefault().Descricao;
                e.Row.Cells[4].Text = Carteiras.Where(c => c.Id.Equals(e.Row.Cells[4].Text.ToInt())).FirstOrDefault().Descricao;
            }
        }
    }
}