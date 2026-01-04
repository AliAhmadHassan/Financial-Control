using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.DTO
{
    public class SMS : Base
    {
        public SMS()
        {
            Id = -1;
        }

        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUSMS"
            , ProcedureInserir = "SPISMS"
            , ProcedureRemover = "SPDSMS"
            , ProcedureListarTodos = "SPSSMS"
            , ProcedureSelecionar = "SPSSMSPelaPK")]
        public int Id { get; set; }
        public int IdCarteira { get; set; }
        public DateTime Data { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public int IdUsuario { get; set; }
    }
}
