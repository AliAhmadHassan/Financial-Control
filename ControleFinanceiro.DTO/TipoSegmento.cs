using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.DTO
{
    public class TipoSegmento:Base
    {
        public TipoSegmento()
        {
            Id = -1;
        }

        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUTipoSegmento"
            , ProcedureInserir = "SPITipoSegmento"
            , ProcedureRemover = "SPDTipoSegmento"
            , ProcedureListarTodos = "SPSTipoSegmento"
            , ProcedureSelecionar = "SPSTipoSegmentoPelaPK")]
        public int Id { get; set; }
        public string Tipo { get; set; }
    }
}
