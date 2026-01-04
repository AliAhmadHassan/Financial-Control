using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.DTO
{
    public class Orcamento:Base
    {
        public Orcamento(){
            this.Id = -1;
        }

        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUOrcamento"
            , ProcedureInserir = "SPIOrcamento"
            , ProcedureRemover = "SPDOrcamento"
            , ProcedureListarTodos = "SPSOrcamento"
            , ProcedureSelecionar = "SPSOrcamentoPelaPK")]
        public int Id { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public int IdSegmento { get; set; }
        public int IdCarteira { get; set; }
        public decimal Valor { get; set; }
    }
}
