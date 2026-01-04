using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ControleFinanceiro.DAL
{
    public class ReceitaDespesa:Base<DTO.ReceitaDespesa>
    {
        public virtual List<DTO.ReceitaDespesa> SelectPelaCarteira(int Id)
        {
            List<DTO.ReceitaDespesa> LReceitaDespesa = new List<DTO.ReceitaDespesa>();

            using (SqlConnection Conn = new SqlConnection(Conexao.strConn))
            {
                using (SqlCommand cmd = new SqlCommand("SPSReceitaDespesaPelaCarteira", Conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("IdCarteira", Id);

                        Conn.Open();
                        using (SqlDataReader Dr = cmd.ExecuteReader())
                        {
                            while (Dr.Read())
                                LReceitaDespesa.Add(Auxiliar.RetornaDadosEntidade<DTO.ReceitaDespesa>(Dr));
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

            return LReceitaDespesa;
        }

        public virtual List<DTO.ReceitaDespesa> SelectPeloSegmento(int Id)
        {
            List<DTO.ReceitaDespesa> LReceitaDespesa = new List<DTO.ReceitaDespesa>();

            using (SqlConnection Conn = new SqlConnection(Conexao.strConn))
            {
                using (SqlCommand cmd = new SqlCommand("SPSReceitaDespesaPeloSegmento", Conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("IdSegmento", Id);

                        Conn.Open();
                        using (SqlDataReader Dr = cmd.ExecuteReader())
                        {
                            while (Dr.Read())
                                LReceitaDespesa.Add(Auxiliar.RetornaDadosEntidade<DTO.ReceitaDespesa>(Dr));
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

            return LReceitaDespesa;
        }

        public virtual List<DTO.ReceitaDespesa> SelectPelaUsuario(int Id)
        {
            List<DTO.ReceitaDespesa> LReceitaDespesa = new List<DTO.ReceitaDespesa>();

            using (SqlConnection Conn = new SqlConnection(Conexao.strConn))
            {
                using (SqlCommand cmd = new SqlCommand("SPSReceitaDespesaPeloUsuario", Conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("IdUsuario", Id);

                        Conn.Open();
                        using (SqlDataReader Dr = cmd.ExecuteReader())
                        {
                            while (Dr.Read())
                                LReceitaDespesa.Add(Auxiliar.RetornaDadosEntidade<DTO.ReceitaDespesa>(Dr));
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

            return LReceitaDespesa;
        }

        public virtual List<DTO.ReceitaDespesa> SelectPelaReferencia(int Mes, int Ano)
        {
            List<DTO.ReceitaDespesa> LReceitaDespesa = new List<DTO.ReceitaDespesa>();

            using (SqlConnection Conn = new SqlConnection(Conexao.strConn))
            {
                using (SqlCommand cmd = new SqlCommand("SPSReceitaDespesaPelaReferencia", Conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("Mes", Mes);
                        cmd.Parameters.AddWithValue("Ano", Ano);

                        Conn.Open();
                        using (SqlDataReader Dr = cmd.ExecuteReader())
                        {
                            while (Dr.Read())
                                LReceitaDespesa.Add(Auxiliar.RetornaDadosEntidade<DTO.ReceitaDespesa>(Dr));
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

            return LReceitaDespesa;
        }
    }
}
