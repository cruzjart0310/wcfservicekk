using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WcfServiceKKreme.Models;

namespace WcfServiceKKreme.DataAccess
{
    public class ClsDataBase
    {
        string connection = "Server=DESKTOP-F9LL8NE\\MSSQLSERVER2;Database=Test;Integrated Security=True";

        public DataTable GetData(string sp, EAction eAction, int param = 0)
        {
            var dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connection))
            {
                try
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(sp, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        if (eAction == EAction.SELECTBYID)
                        {
                            cmd.Parameters.Add("@piId", SqlDbType.Int).Value = param;
                        }

                        var da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (con != null)
                    {
                        con.Close();
                    }
                }
            }

            return dt;
        }

        public int Save(string sp, EAction action, Coupon coupon, int param = 0)
        {
            DateTime date;
            int retorno = 0;
            using (SqlConnection con = new SqlConnection(connection))
            {
                try
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(sp, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        if ((action == EAction.INSERT || action == EAction.UPDATE) && coupon != null)
                        {
                            cmd.Parameters.Add("@pcDuration", SqlDbType.DateTime, 100).Value = coupon.Duration;
                            cmd.Parameters.Add("@pcSerie", SqlDbType.VarChar, 20).Value = coupon.Serie;
                            cmd.Parameters.Add("@pcDescription", SqlDbType.VarChar, 200).Value = coupon.Description;
                            cmd.Parameters.Add("@piStatusId", SqlDbType.Int, 1).Value = coupon.Status.Id;
                            cmd.Parameters.Add("@piEstablishmentId", SqlDbType.Int, 1).Value = coupon.Establishment.Id;
                        }

                        if (action == EAction.DELETE || action == EAction.UPDATE)
                        {
                            cmd.Parameters.Add("@piId", SqlDbType.Int, 1).Value = param;
                        }

                        retorno = cmd.ExecuteNonQuery();

                       // var prueba = cmd.ExecuteScalar();
                        
                       //retorno = Convert.ToInt32(prueba);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (con != null)
                    {
                        con.Close();
                    }
                }
            }

            return retorno;
        }
    }
}