using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.DTO
{
    public class SegmentoOrcamentoUnitario:Base
    {
        public SegmentoOrcamentoUnitario()
        {
            Id = -1;
        }

        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUSegmentoOrcamentoUnitario"
            , ProcedureInserir = "SPISegmentoOrcamentoUnitario"
            , ProcedureRemover = "SPDSegmentoOrcamentoUnitario"
            , ProcedureListarTodos = "SPSSegmentoOrcamentoUnitario"
            , ProcedureSelecionar = "SPSSegmentoOrcamentoUnitarioPelaPK")]
        public int Id { get; set; }
        public int IdSegmento { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }


    }
}
