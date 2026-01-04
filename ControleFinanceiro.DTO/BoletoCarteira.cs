using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.DTO
{
    public class BoletoCarteira:Base
    {
        public BoletoCarteira()
        {
            Id = -1;
        }

        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUBoletoCarteira"
            , ProcedureInserir = "SPIBoletoCarteira"
            , ProcedureRemover = "SPDBoletoCarteira"
            , ProcedureListarTodos = "SPSBoletoCarteira"
            , ProcedureSelecionar = "SPSBoletoCarteiraPelaPK")]
        public int Id { get; set; }
        public int Credor { get; set; }
        public int Segmento { get; set; }
        public int Produto { get; set; }
        public int IdCarteira { get; set; }
    }
}
