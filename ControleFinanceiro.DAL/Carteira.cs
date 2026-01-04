using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ControleFinanceiro.DAL
{
    public class Carteira:Base<DTO.Carteira>
    {
        public virtual List<DTO.Carteira> SelectPeloIdPai(int Id)
        {
            List<DTO.Carteira> LCarteira = new List<DTO.Carteira>();

            using (SqlConnection Conn = new SqlConnection(Conexao.strConn))
            {
                using (SqlCommand cmd = new SqlCommand("SPSCarteiraPelaIdPai", Conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("IdPai", Id);

                        Conn.Open();
                        using (SqlDataReader Dr = cmd.ExecuteReader())
                        {
                            while (Dr.Read())
                                LCarteira.Add(Auxiliar.RetornaDadosEntidade<DTO.Carteira>(Dr));
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

            return LCarteira;
        }

        public virtual List<DTO.Carteira> SelectIdentado()
        {
            List<DTO.Carteira> LCarteira = new List<DTO.Carteira>();

            using (SqlConnection Conn = new SqlConnection(Conexao.strConn))
            {
                using (SqlCommand cmd = new SqlCommand(@"Select TbCarteira.Id as Id,REPLICATE('    ',dbo.QtdLinhasCarteira(TbCarteira.IdPai)) + TbCarteira.Descricao as Descricao, TbCarteira.IdPai as IdPai from TbCarteira", Conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        Conn.Open();
                        using (SqlDataReader Dr = cmd.ExecuteReader())
                        {
                            while (Dr.Read())
                                LCarteira.Add(Auxiliar.RetornaDadosEntidade<DTO.Carteira>(Dr));
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

            return LCarteira;
        }

        public virtual List<DTO.Carteira> SelectPeloPredio(int Predio)
        {
            List<DTO.Carteira> LCarteira = new List<DTO.Carteira>();

            using (SqlConnection Conn = new SqlConnection(Conexao.strConn))
            {
                using (SqlCommand cmd = new SqlCommand("SPSCarteiraPeloPredio", Conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Predio", Predio);

                        Conn.Open();
                        using (SqlDataReader Dr = cmd.ExecuteReader())
                        {
                            while (Dr.Read())
                                LCarteira.Add(Auxiliar.RetornaDadosEntidade<DTO.Carteira>(Dr));
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

            return LCarteira;
        }

        public virtual List<DTO.Carteira> SelectPeloPessoas_Operacional()
        {
            List<DTO.Carteira> LCarteira = new List<DTO.Carteira>();

            using (SqlConnection Conn = new SqlConnection(Conexao.strConn))
            {
                using (SqlCommand cmd = new SqlCommand("SPSCarteiraPeloPessoas_Operacional", Conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        Conn.Open();
                        using (SqlDataReader Dr = cmd.ExecuteReader())
                        {
                            while (Dr.Read())
                                LCarteira.Add(Auxiliar.RetornaDadosEntidade<DTO.Carteira>(Dr));
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

            return LCarteira;
        }
    }
}
