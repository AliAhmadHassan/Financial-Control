using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleFinanceiro.BLL
{
    public class XLSX
    {
        public List<T> RetornaEntidade<T>(string PathArquivo)
        {
            return new DAL.XLSX().RetornaEntidade<T>(PathArquivo);
        }
    }
}
