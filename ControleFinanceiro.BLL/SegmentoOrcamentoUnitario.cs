using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.BLL
{
    public class SegmentoOrcamentoUnitario
    {
        public List<DTO.SegmentoOrcamentoUnitario> Select()
        {
            return new DAL.SegmentoOrcamentoUnitario().Select();
        }

        public DTO.SegmentoOrcamentoUnitario SelectPelaPk(int Id)
        {
            return new DAL.SegmentoOrcamentoUnitario().SelectPelaPK(Id);
        }

        public List<DTO.SegmentoOrcamentoUnitario> SelectPeloSegmento(int Id)
        {
            return new DAL.SegmentoOrcamentoUnitario().SelectPeloSegmento(Id);
        }

        public void Remover(DTO.SegmentoOrcamentoUnitario segmentoOrcamentoUnitario)
        {
            new DAL.SegmentoOrcamentoUnitario().Remover(segmentoOrcamentoUnitario);

        }

        public void Cadastro(DTO.SegmentoOrcamentoUnitario segmentoOrcamentoUnitario)
        {
            new DAL.SegmentoOrcamentoUnitario().Cadastro(segmentoOrcamentoUnitario);
        }
    }
}
