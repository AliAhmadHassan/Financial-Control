using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.DTO
{
    public class TipoPostagem:Base
    {
        public TipoPostagem()
        {
            Id = -1;
        }

        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUTipoPostagem"
            , ProcedureInserir = "SPITipoPostagem"
            , ProcedureRemover = "SPDTipoPostagem"
            , ProcedureListarTodos = "SPSTipoPostagem"
            , ProcedureSelecionar = "SPSTipoPostagemPelaPK")]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal ValorUnitario { get; set; }

    }
}
