using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ControleFinanceiro.DAL
{
    public class Segmento:Base<DTO.Segmento>
    {
        public virtual List<DTO.Segmento> SelectPeloIdPai(int Id)
        {
            List<DTO.Segmento> LSegmento = new List<DTO.Segmento>();

            using (SqlConnection Conn = new SqlConnection(Conexao.strConn))
            {
                using (SqlCommand cmd = new SqlCommand("SPSSegmentoPeloIdPai", Conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("IdPai", Id);

                        Conn.Open();
                        using (SqlDataReader Dr = cmd.ExecuteReader())
                        {
                            while (Dr.Read())
                                LSegmento.Add(Auxiliar.RetornaDadosEntidade<DTO.Segmento>(Dr));
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

            return LSegmento;
        }

        public virtual List<DTO.Segmento> SelectPeloTipo(int Id)
        {
            List<DTO.Segmento> LSegmento = new List<DTO.Segmento>();

            using (SqlConnection Conn = new SqlConnection(Conexao.strConn))
            {
                using (SqlCommand cmd = new SqlCommand("SPSSegmentoPeloTipo", Conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("IdTipo", Id);

                        Conn.Open();
                        using (SqlDataReader Dr = cmd.ExecuteReader())
                        {
                            while (Dr.Read())
                                LSegmento.Add(Auxiliar.RetornaDadosEntidade<DTO.Segmento>(Dr));
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

            return LSegmento;
        }

        public virtual List<DTO.Segmento> SelectIdentado()
        {
            List<DTO.Segmento> LSegmento = new List<DTO.Segmento>();

            using (SqlConnection Conn = new SqlConnection(Conexao.strConn))
            {
                using (SqlCommand cmd = new SqlCommand(@"Select TbSegmento.Id as Id,REPLICATE('    ',dbo.QtdLinhasSegmento(TbSegmento.IdPai)) + TbSegmento.Descricao as Descricao, TbSegmento.IdPai as IdPai, Data, IdTipoSegmento from TbSegmento", Conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        Conn.Open();
                        using (SqlDataReader Dr = cmd.ExecuteReader())
                        {
                            while (Dr.Read())
                                LSegmento.Add(Auxiliar.RetornaDadosEntidade<DTO.Segmento>(Dr));
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

            return LSegmento;
        }
    }
}
