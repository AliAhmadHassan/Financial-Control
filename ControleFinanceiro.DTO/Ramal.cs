using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.DTO
{
    public class Ramal:Base
    {
        public Ramal()
        {
            Numero = -1;
        }

        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPURamal"
            , ProcedureInserir = "SPIRamal"
            , ProcedureRemover = "SPDRamal"
            , ProcedureListarTodos = "SPSRamal"
            , ProcedureSelecionar = "SPSRamalPelaPK")]
        public int Numero { get; set; }
        public int IdControleAcesso { get; set; }

    }
}
