using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.DTO
{
    public class ControleAcesso:Base
    {
        public ControleAcesso()
        {
            Id = -1;
        }

        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUControleAcesso"
            , ProcedureInserir = "SPIControleAcesso"
            , ProcedureRemover = "SPDControleAcesso"
            , ProcedureListarTodos = "SPSControleAcesso"
            , ProcedureSelecionar = "SPSControleAcessoPelaPK")]
        public int Id { get; set; }
        public int IdCarteira { get; set; }
        public string Nome { get; set; }
    }
}
