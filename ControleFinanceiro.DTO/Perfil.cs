using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.DTO
{
    public class Perfil:Base
    {
        public Perfil()
        {
            Id = -1;
        }

        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUPerfil"
            , ProcedureInserir = "SPIPerfil"
            , ProcedureRemover = "SPDPerfil"
            , ProcedureListarTodos = "SPSPerfil"
            , ProcedureSelecionar = "SPSPerfilPelaPK")]
        public int Id { get; set; }
        public bool Ativo { get; set; }
        public string Descricao { get; set; }
        public string Observacao { get; set; }
    }
}
