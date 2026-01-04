using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.DTO
{
    public class Segmento:Base
    {
        public Segmento()
        {
            Id = -1;
            Data = DateTime.Now;
        }

        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUSegmento"
            , ProcedureInserir = "SPISegmento"
            , ProcedureRemover = "SPDSegmento"
            , ProcedureListarTodos = "SPSSegmento"
            , ProcedureSelecionar = "SPSSegmentoPelaPK")]
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public int IdPai { get; set; }
        public int IdTipoSegmento { get; set; }
        public int IdTipoDespesas { get; set; }
    }
}
