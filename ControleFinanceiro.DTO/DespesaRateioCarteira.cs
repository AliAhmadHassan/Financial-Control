using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.DTO
{
    public class DespesaRateioCarteira : Base
    {
        public DespesaRateioCarteira()
        {
            Id = -1;
        }

        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUDespesasRateioCarteira"
            , ProcedureInserir = "SPIDespesasRateioCarteira"
            , ProcedureRemover = "SPDDespesasRateioCarteira"
            , ProcedureListarTodos = "SPSDespesasRateioCarteira"
            , ProcedureSelecionar = "SPSDespesasRateioCarteiraPelaPK")]
        public int Id { get; set; }
        public int IdDespesasRateio { get; set; }
        public int IdCarteira { get; set; }
        public decimal Percentual { get; set; }
    }
}
