using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.DTO
{
    public class Boleto:Base
    {

        public Boleto()
        {
            Id = -1;
        }

        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUBoleto"
            , ProcedureInserir = "SPIBoleto"
            , ProcedureRemover = "SPDBoleto"
            , ProcedureListarTodos = "SPSBoleto"
            , ProcedureSelecionar = "SPSBoletoPelaPK")]
        public int Id { get; set; }

        public int IdCarteira { get; set; }
        
        public DateTime Data { get; set; }

        public int Quantidade { get; set; }

        public int IdUsuario { get; set; }

        public int IdTipoPostagem { get; set; }

        public int Mes { get; set; }

        public int Ano { get; set; }

    }
}
