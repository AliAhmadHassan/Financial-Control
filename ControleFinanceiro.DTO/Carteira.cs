using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.DTO
{
    public class Carteira:Base
    {
        public Carteira()
        {
            Id = -1;
        }

        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUCarteira"
            , ProcedureInserir = "SPICarteira"
            , ProcedureRemover = "SPDCarteira"
            , ProcedureListarTodos = "SPSCarteira"
            , ProcedureSelecionar = "SPSCarteiraPelaPK")]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
        public int IdPai { get; set; }
        public int Predio { get; set; }
        public bool ParticipaRateio { get; set; }
        public int Tipo { get; set; }
    }
}
