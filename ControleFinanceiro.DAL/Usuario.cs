using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ControleFinanceiro.DAL
{
    public class Usuario:Base<DTO.Usuario>
    {
        public virtual List<DTO.Usuario> SelectPelaCarteira(int Id)
        {
            List<DTO.Usuario> LUsuario = new List<DTO.Usuario>();

            using (SqlConnection Conn = new SqlConnection(Conexao.strConn))
            {
                using (SqlCommand cmd = new SqlCommand("SPSUsuarioPeloPerfil", Conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("IdPerfil", Id);

                        Conn.Open();
                        using (SqlDataReader Dr = cmd.ExecuteReader())
                        {
                            while (Dr.Read())
                                LUsuario.Add(Auxiliar.RetornaDadosEntidade<DTO.Usuario>(Dr));
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

            return LUsuario;
        }
        public virtual DTO.Usuario Logar(string Login, string Senha)
        {
            DTO.Usuario usuario = new DTO.Usuario();

            using (SqlConnection Conn = new SqlConnection(Conexao.strConn))
            {
                using (SqlCommand cmd = new SqlCommand("SPSUsuarioLogar", Conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Login", Login);
                        cmd.Parameters.AddWithValue("@Senha", Senha);

                        Conn.Open();
                        using (SqlDataReader Dr = cmd.ExecuteReader())
                        {
                            if (Dr.Read())
                                usuario = Auxiliar.RetornaDadosEntidade<DTO.Usuario>(Dr);
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

            return usuario;
        }
    }
}
