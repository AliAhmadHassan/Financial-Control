using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.BLL
{
    public class CobNetBoletos
    {
        public StringBuilder ProcessaBoleto(DateTime FacDe, DateTime FacAte, DateTime FranquiaDe, DateTime FranquiaAte, int MesReferencia, int AnoReferencia)
        {
            StringBuilder retorno = new StringBuilder();

            List<DTO.BoletoCarteira> boletosCarteiras = new DAL.BoletoCarteira().Select();

            List<DTO.CobNetBoletos> boletosFac = Select(true, FacDe, FacAte);
            List<DTO.CobNetBoletos> boletosFranquia = Select(false, FranquiaDe, FranquiaAte);

            foreach (DTO.BoletoCarteira carteira in boletosCarteiras)
            {
                Importa(MesReferencia, AnoReferencia, retorno, carteira, boletosFac, boletosFranquia);
            }

            if (boletosFac.Count > 0)
            {
                retorno.AppendLine("<table>");
                retorno.AppendLine("<tr>");
                retorno.AppendLine("<th>Credor</th>");
                retorno.AppendLine("<th>Segmento</th>");
                retorno.AppendLine("<th>Produto</th>");
                retorno.AppendLine("<th>Quantidade</th>");
                retorno.AppendLine("<th>Mensagem</th>");
                retorno.AppendLine("</tr>");
                foreach (DTO.CobNetBoletos Fac in boletosFac)
                {
                    retorno.AppendLine("<tr>");
                    retorno.AppendLine(string.Format("<td>FAC: {0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>Carteira Não Encontrado</td>", Fac.Cred_Id.ToString(), Fac.Seg_Id.ToString(), Fac.Prod_Id.ToString(), Fac.Qtd.ToString()));
                    retorno.AppendLine("</tr>");
                }
                retorno.AppendLine("</table>");
            }

            if (boletosFranquia.Count > 0)
            {
                retorno.AppendLine("<table>");
                retorno.AppendLine("<tr>");
                retorno.AppendLine("<th>Credor</th>");
                retorno.AppendLine("<th>Segmento</th>");
                retorno.AppendLine("<th>Produto</th>");
                retorno.AppendLine("<th>Quantidade</th>");
                retorno.AppendLine("<th>Mensagem</th>");
                retorno.AppendLine("</tr>");
                foreach (DTO.CobNetBoletos Franquia in boletosFranquia)
                {
                    retorno.AppendLine("<tr>");
                    retorno.AppendLine(string.Format("<td>Franquia: {0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>Carteira Não Encontrado</td>", Franquia.Cred_Id.ToString(), Franquia.Seg_Id.ToString(), Franquia.Prod_Id.ToString(), Franquia.Qtd.ToString()));
                    retorno.AppendLine("</tr>");
                }
                retorno.AppendLine("</table>");
            }

            return retorno;
        }

        private static void Importa(int MesReferencia, int AnoReferencia, StringBuilder retorno, DTO.BoletoCarteira boletoCarteira, List<DTO.CobNetBoletos> boletosFac, List<DTO.CobNetBoletos> boletosFranquia)
        {
            DTO.Boleto boleto = new DTO.Boleto();
            boleto.Data = DateTime.Now;
            boleto.IdCarteira = boletoCarteira.IdCarteira;            
            boleto.Mes = MesReferencia;
            boleto.Ano = AnoReferencia;
            boleto.IdUsuario = 1;

            if (boletoCarteira.Credor != 0)
            {

                int Qtds = 0;
                Qtds = boletosFac.Where(c => c.Cred_Id.Equals(boletoCarteira.Credor)).ToList().Sum(c => c.Qtd);
                boletosFac.RemoveAll(c => c.Cred_Id.Equals(boletoCarteira.Credor));
                Grava(boleto, 1, Qtds);

                Qtds = boletosFranquia.Where(c => c.Cred_Id.Equals(boletoCarteira.Credor)).ToList().Sum(c => c.Qtd);
                boletosFranquia.RemoveAll(c => c.Cred_Id.Equals(boletoCarteira.Credor));
                Grava(boleto, 2, Qtds);
            }
            else if (boletoCarteira.Segmento != 0)
            {
                int Qtds = 0;
                Qtds = boletosFac.Where(c => c.Seg_Id.Equals(boletoCarteira.Segmento)).ToList().Sum(c => c.Qtd);
                boletosFac.RemoveAll(c => c.Seg_Id.Equals(boletoCarteira.Segmento));
                Grava(boleto, 1, Qtds);
                Qtds = boletosFranquia.Where(c => c.Seg_Id.Equals(boletoCarteira.Segmento)).ToList().Sum(c => c.Qtd);
                boletosFranquia.RemoveAll(c => c.Seg_Id.Equals(boletoCarteira.Segmento));
                Grava(boleto, 2, Qtds);
            }
            else
            {
                int Qtds = 0;
                Qtds = boletosFac.Where(c => c.Prod_Id.Equals(boletoCarteira.Produto)).ToList().Sum(c => c.Qtd);
                boletosFac.RemoveAll(c => c.Prod_Id.Equals(boletoCarteira.Produto));
                Grava(boleto, 1, Qtds);
                Qtds = boletosFranquia.Where(c => c.Prod_Id.Equals(boletoCarteira.Produto)).ToList().Sum(c => c.Qtd);
                boletosFranquia.RemoveAll(c => c.Prod_Id.Equals(boletoCarteira.Produto));
                Grava(boleto, 2, Qtds);
            }
            


            //DTO.BoletoCarteira boletocarteira = boletosCarteiras.Where(c => c.Credor.Equals(boletoCobNet.Cred_Id)).FirstOrDefault();
            //if (boletocarteira == null)
            //{
            //    boletocarteira = boletosCarteiras.Where(c => c.Segmento.Equals(boletoCobNet.Seg_Id)).FirstOrDefault();
            //    if (boletocarteira == null)
            //        boletocarteira = boletosCarteiras.Where(c => c.Produto.Equals(boletoCobNet.Prod_Id)).FirstOrDefault();
            //}

            //if (boletocarteira != null)
            //{
            //    DTO.Boleto boleto = new DTO.Boleto();
            //    boleto.Data = DateTime.Now;
            //    boleto.IdCarteira = boletocarteira.IdCarteira;
            //    boleto.IdTipoPostagem = TipoPostagem;
            //    boleto.Quantidade = boletoCobNet.Qtd;
            //    boleto.Mes = MesReferencia;
            //    boleto.Ano = AnoReferencia;
            //    boleto.IdUsuario = 1;
            //    new BLL.Boleto().Cadastro(boleto);
            //}
            //else
                //retorno.AppendLine(string.Format("Credor: {0};Segmento: {1}; Produto: {2}; Quantidade: {3}; Carteira Não Encontrado", boletoCobNet.Cred_Id.ToString(), boletoCobNet.Seg_Id.ToString(), boletoCobNet.Prod_Id.ToString(), boletoCobNet.Qtd.ToString()));
        }

        private static void Grava(DTO.Boleto boleto, int IdTipoPostagem, int Qtds)
        {
            boleto.Id = -1;
            boleto.Quantidade = Qtds;
            boleto.IdTipoPostagem = IdTipoPostagem;
            if (Qtds > 0)
                new BLL.Boleto().Cadastro(boleto);
        }

        private List<DTO.CobNetBoletos> Select(bool Fac, DateTime De, DateTime Ate)
        {
            return new DAL.CobNetBoletos().Select(Fac, De, Ate);
        }
    }
}
