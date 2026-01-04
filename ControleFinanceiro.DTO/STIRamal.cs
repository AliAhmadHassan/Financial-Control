using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.DTO
{
    public class STIRamal:Base
    {
        public STIRamal()
        {
            Id = -1;
        }

        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUSTIRamal"
            , ProcedureInserir = "SPISTIRamal"
            , ProcedureRemover = "SPDSTIRamal"
            , ProcedureListarTodos = "SPSSTIRamal"
            , ProcedureSelecionar = "SPSSTIRamalPelaPK")]
        public int Id { get; set; }
        public int Central { get; set; }
        public int Ramal { get; set; }
        public int IdCarteira { get; set; }
        public string Andar { get; set; }
        public string Sala { get; set; }
    }
}
