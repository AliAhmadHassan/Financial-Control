using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.BLL
{
    public class ControleAcessoUsuario
    {
        public List<DTO.ControleAcessoUsuario> Select()
        {
            return new DAL.ControleAcessoUsuario().Select();
        }
        public decimal SelectProporcao(int IdCarteira, string Referencia)
        {
            return new DAL.ControleAcessoUsuario().SelectProporcao(IdCarteira, Referencia);
        }
    }
}
