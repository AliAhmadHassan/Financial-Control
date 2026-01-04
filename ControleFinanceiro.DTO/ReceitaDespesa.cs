using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.DTO
{
    public class ReceitaDespesa:Base
    {
        public ReceitaDespesa()
        {
            Id = -1;
        }

        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUReceitaDespesa"
            , ProcedureInserir = "SPIReceitaDespesa"
            , ProcedureRemover = "SPDReceitaDespesa"
            , ProcedureListarTodos = "SPSReceitaDespesa"
            , ProcedureSelecionar = "SPSReceitaDespesaPelaPK")]
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public bool Finalizado { get; set; }
        public int IdCarteira { get; set; }
        public int IdSegmento { get; set; }
        public int IdUsuario { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
    }
}
