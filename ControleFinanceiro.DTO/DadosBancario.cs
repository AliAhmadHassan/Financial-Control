using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.DTO
{
    public class DadosBancario: Base
    {
        public DadosBancario()
        {
            Id = -1;
        }

        [AtributoBind(ChavePrimaria = true
    , ProcedureAlterar = "SPUDadosBancario"
    , ProcedureInserir = "SPIDadosBancario"
    , ProcedureRemover = "SPDDadosBancario"
    , ProcedureListarTodos = "SPSDadosBancario"
    , ProcedureSelecionar = "SPSDadosBancarioPelaPK")]
        public int Id { get; set; }
        public string Banco { get; set; }
        public string Agencia { get; set; }
        public string ContaCorrente { get; set; }
        public string Descricao { get; set; }
        public string Empresa { get; set; }
    }
}
