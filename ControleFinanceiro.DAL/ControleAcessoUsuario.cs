using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ControleFinanceiro.DAL
{
    public class ControleAcessoUsuario
    {
        public virtual List<DTO.ControleAcessoUsuario> Select()
        {
            List<DTO.ControleAcessoUsuario> LControleAcessoUsuario = new List<DTO.ControleAcessoUsuario>();

            using (SqlConnection Conn = new SqlConnection(Conexao.strConnControleAcesso))
            {
                using (SqlCommand cmd = new SqlCommand("SPSUsuarios", Conn))
                {
                    try
                    {
                        Conn.Open();
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        using (SqlDataReader Dr = cmd.ExecuteReader())
                        {
                            while (Dr.Read())
                                LControleAcessoUsuario.Add(Auxiliar.RetornaDadosEntidade<DTO.ControleAcessoUsuario>(Dr));
                        }
                    }
                    catch (Exception Erro)
                    {
                        throw new Exception("Erro ao consultar");
                    }
                    finally
                    {

                    }
                }
            }

            return LControleAcessoUsuario;
        }

        public virtual decimal SelectProporcao(int IdCarteira, string Referencia)
        {
            using (SqlConnection Conn = new SqlConnection(Conexao.strConnControleAcesso))
            {
                using (SqlCommand cmd = new SqlCommand("SPSUsuariosProporcao", Conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("IdCarteira", IdCarteira);
                        cmd.Parameters.AddWithValue("IdReferencias", Referencia);

                        Conn.Open();
                        using (SqlDataReader Dr = cmd.ExecuteReader())
                        {
                            if (Dr.Read())
                                return decimal.Parse(Dr[0].ToString());
                        }
                    }
                    catch (Exception Erro)
                    {
                        throw new Exception("Erro ao consultar");
                    }
                    finally
                    {

                    }
                }
            }

            return 0;
        }
    }
}
