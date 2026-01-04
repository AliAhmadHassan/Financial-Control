using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ControleFinanceiro.DAL
{
    public class Boleto:Base<DTO.Boleto>
    {
        public virtual List<DTO.Boleto> SelectPelaCarteira(int Id)
        {
            List<DTO.Boleto> LBoleto = new List<DTO.Boleto>();

            using (SqlConnection Conn = new SqlConnection(Conexao.strConn))
            {
                using (SqlCommand cmd = new SqlCommand("SPSBoletoPelaCarteira", Conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("IdCarteira", Id);

                        Conn.Open();
                        using (SqlDataReader Dr = cmd.ExecuteReader())
                        {
                            while (Dr.Read())
                                LBoleto.Add(Auxiliar.RetornaDadosEntidade<DTO.Boleto>(Dr));
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

            return LBoleto;
        }

        public virtual List<DTO.Boleto> SelectPeloUsuario(int Id)
        {
            List<DTO.Boleto> LBoleto = new List<DTO.Boleto>();

            using (SqlConnection Conn = new SqlConnection(Conexao.strConn))
            {
                using (SqlCommand cmd = new SqlCommand("SPSBoletoPeloUsuario", Conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("IdUsuario", Id);

                        Conn.Open();
                        using (SqlDataReader Dr = cmd.ExecuteReader())
                        {
                            while (Dr.Read())
                                LBoleto.Add(Auxiliar.RetornaDadosEntidade<DTO.Boleto>(Dr));
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

            return LBoleto;
        }

        public virtual List<DTO.Boleto> SelectPeloTipoPostagem(int Id)
        {
            List<DTO.Boleto> LBoleto = new List<DTO.Boleto>();

            using (SqlConnection Conn = new SqlConnection(Conexao.strConn))
            {
                using (SqlCommand cmd = new SqlCommand("SPSBoletoPeloTipoPostagem", Conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("IdTipoPostagem", Id);

                        Conn.Open();
                        using (SqlDataReader Dr = cmd.ExecuteReader())
                        {
                            while (Dr.Read())
                                LBoleto.Add(Auxiliar.RetornaDadosEntidade<DTO.Boleto>(Dr));
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

            return LBoleto;
        }

        public virtual List<DTO.Boleto> SelectPelaReferencia(int Mes, int Ano)
        {
            List<DTO.Boleto> LBoleto = new List<DTO.Boleto>();

            using (SqlConnection Conn = new SqlConnection(Conexao.strConn))
            {
                using (SqlCommand cmd = new SqlCommand("SPSBoletoPelaReferencia", Conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Mes", Mes);
                        cmd.Parameters.AddWithValue("@Ano", Ano);

                        Conn.Open();
                        using (SqlDataReader Dr = cmd.ExecuteReader())
                        {
                            while (Dr.Read())
                                LBoleto.Add(Auxiliar.RetornaDadosEntidade<DTO.Boleto>(Dr));
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

            return LBoleto;
        }
    }
}
