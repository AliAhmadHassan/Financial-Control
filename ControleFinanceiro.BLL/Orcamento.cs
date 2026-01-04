using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.BLL
{
    public class Orcamento
    {
        public List<DTO.Orcamento> Select()
        {
            return new DAL.Orcamento().Select();
        }

        public DTO.Orcamento SelectPelaPK(int Id)
        {
            return new DAL.Orcamento().SelectPelaPK(Id);
        }

        public List<DTO.Orcamento> SelectPeloSegmento(int Id)
        {
            return new DAL.Orcamento().SelectPeloSegmento(Id);
        }

        public List<DTO.Orcamento> SelectPelaCarteira(int Id)
        {
            return new DAL.Orcamento().SelectPelaCarteira(Id);
        }

        public void Remover(DTO.Orcamento orcamento)
        {
            new DAL.Orcamento().Remover(orcamento);
        }

        public void Cadastro(DTO.Orcamento orcamento)
        {
            new DAL.Orcamento().Cadastro(orcamento);
        }
    }
}
