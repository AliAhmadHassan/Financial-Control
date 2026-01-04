using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ControleFinanceiro.DAL
{
    public class UsuarioMenu
    {

        public virtual void Remover(int IdUsuario)
        {
            using (SqlConnection Conn = new SqlConnection(Conexao.strConn))
            {
                using (SqlCommand cmd = new SqlCommand("SPDUsuarioMenu", Conn))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        
                        Conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception erro)
                    {
                        throw new Exception("Erro ao deletar o registro");
                    }
                    finally
                    {
                    }
                }
            }
        }

        public void Inserir(DTO.UsuarioMenu Entidade)
        {
            using (SqlConnection Conn = new SqlConnection(Conexao.strConn))
            {
                using (SqlCommand cmd = new SqlCommand("SPIUsuarioMenu", Conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        foreach (SqlParameter Param in Auxiliar.GeraParametros<DTO.UsuarioMenu>(Entidade))
                            cmd.Parameters.Add(Param);

                        Conn.Open();
                        cmd.ExecuteNonQuery();                        
                    }
                    catch (Exception Erro)
                    {
                        throw new Exception("Erro ao inserir registro.");
                    }
                    finally
                    {
                    }
                }
            }
        }
    }
}
