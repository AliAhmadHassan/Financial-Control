using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.DTO
{
    public class Ura:Base
    {
        public Ura()
        {
            Id = -1;
        }
        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUUra"
            , ProcedureInserir = "SPIUra"
            , ProcedureRemover = "SPDUra"
            , ProcedureListarTodos = "SPSUra"
            , ProcedureSelecionar = "SPSUraPelaPK")]
        public int Id { get; set; }
        public int IdCarteira { get; set; }
        public DateTime Data { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public int IdUsuario { get; set; }
    }
}
