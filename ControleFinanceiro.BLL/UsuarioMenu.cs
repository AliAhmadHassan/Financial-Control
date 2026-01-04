using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.BLL
{
    public class UsuarioMenu
    {
        public void Cadastro(List<DTO.UsuarioMenu> entidades)
        {
            new DAL.UsuarioMenu().Remover(entidades[0].IdUsuario);

            foreach (DTO.UsuarioMenu entidade in entidades)
                new DAL.UsuarioMenu().Inserir(entidade);
        }
    }
}
