using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.DTO
{
    public class Usuario : Base
    {
        public Usuario()
        {
            this.Id = -1;
        }


        [AtributoBind(ChavePrimaria = true
            , ProcedureAlterar = "SPUUsuario"
            , ProcedureInserir = "SPIUsuario"
            , ProcedureRemover = "SPDUsuario"
            , ProcedureListarTodos = "SPSUsuario"
            , ProcedureSelecionar = "SPSUsuarioPelaPK")]
        public int Id { get; set; }
        public bool Ativo { get; set; }
        public string Nome { get; set; }
        public int IdPerfil { get; set; }
        public string Senha { get; set; }
        public string Login { get; set; }
    }
}
