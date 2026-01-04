using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ControleFinanceiro.DAL
{
    public class STIRamal:Base<DTO.STIRamal>
    {
        public virtual List<DTO.STIRamal> SelectPeloRamal(int Id)
        {
            List<DTO.STIRamal> LSTIRamal = new List<DTO.STIRamal>();

            using (SqlConnection Conn = new SqlConnection(Conexao.strConn))
            {
                using (SqlCommand cmd = new SqlCommand("SPSSTIRamalPeloRamal", Conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("Ramal", Id);

                        Conn.Open();
                        using (SqlDataReader Dr = cmd.ExecuteReader())
                        {
                            while (Dr.Read())
                                LSTIRamal.Add(Auxiliar.RetornaDadosEntidade<DTO.STIRamal>(Dr));
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

            return LSTIRamal;
        }

        public virtual List<DTO.STIRamal> SelectPelaCarteira(int Id)
        {
            List<DTO.STIRamal> LSTIRamal = new List<DTO.STIRamal>();

            using (SqlConnection Conn = new SqlConnection(Conexao.strConn))
            {
                using (SqlCommand cmd = new SqlCommand("SPSSTIRamalPelaCarteira", Conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("IdCarteira", Id);

                        Conn.Open();
                        using (SqlDataReader Dr = cmd.ExecuteReader())
                        {
                            while (Dr.Read())
                                LSTIRamal.Add(Auxiliar.RetornaDadosEntidade<DTO.STIRamal>(Dr));
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

            return LSTIRamal;
        }
    }
}
