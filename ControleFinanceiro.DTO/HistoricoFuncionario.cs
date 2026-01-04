using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.DTO
{
    public class HistoricoFuncionario : Base
    {
        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUHistoricoFuncionario"
            , ProcedureInserir = "SPIHistoricoFuncionario"
            , ProcedureRemover = "SPDHistoricoFuncionario"
            , ProcedureListarTodos = ""
            , ProcedureSelecionar = "SPSHistoricoFuncionarioPelaPK")]
        public int Id { get; set; }
        public int IdFuncionario { get; set; }
        public string Cargo { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public DateTime Adimissao { get; set; }
        public int IdCarteira { get; set; }
        public int Minutos { get; set; }
        public DateTime DataCadastro { get; set; }
        
    }
}
