using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.DTO
{
    public class STI:Base
    {
        public STI()
        {
            Id = -1;
        }

        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUSTI"
            , ProcedureInserir = "SPISTI"
            , ProcedureRemover = "SPDSTI"
            , ProcedureListarTodos = "SPSSTI"
            , ProcedureSelecionar = "SPSSTIPelaPK")]
        public int Id { get; set; }
        public int Central { get; set; }
        public int Duracao { get; set; }
        public decimal Valor { get; set; }
        public int IdRamal { get; set; }
    }
}
