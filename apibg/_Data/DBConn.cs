using System;
using System.Data.SqlClient;
using System.Data;

namespace apibg
{
    public class DBConn
    {
        public static SqlConnection ConexionSQL()
        {
            SqlConnection ConectString = new SqlConnection(@"Data Source=SERVER; Initial Catalog=SAAIPRUEBA; User id=sa; Password=lsuc");
            return ConectString;
        }

        public static SqlDataReader Sp_fila(SqlCommand cmd)
        {
            cmd.Connection = ConexionSQL();
            cmd.Connection.Open();
            return cmd.ExecuteReader();
        }

        public static object Sp_valor(SqlCommand cmd)
        {
            Object valor = new Object();
            cmd.Connection = ConexionSQL();
            cmd.Connection.Open();
            valor = cmd.ExecuteScalar();
            cmd.Connection.Close();
            return valor;
        }

        public static bool Sp_abm(SqlCommand cmd)
        {
            cmd.Connection = ConexionSQL();
            cmd.Connection.Open();
            if (cmd.ExecuteNonQuery() == 0)
            {
                cmd.Connection.Close();
                return false;
            }
            else
            {
                cmd.Connection.Close();
                return true;
            }
        }

        public static DataTable Sp_dt(SqlCommand cmd) 
        {
            DataTable dt = new DataTable();
            cmd.Connection = ConexionSQL();
            cmd.Connection.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
            sqlda.Fill(dt);
            cmd.Connection.Close();
            return dt;
        }

        public static DataSet Sp_ds(SqlCommand cmd)
        {
            DataSet ds = new DataSet();
            cmd.Connection = ConexionSQL();
            cmd.Connection.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
            sqlda.Fill(ds);
            cmd.Connection.Close();
            return ds;
        }

        public static DataTable ConsultarDT(SqlCommand cmd)
        {
            DataSet ds = new DataSet();
            cmd.Connection = ConexionSQL();
            cmd.Connection.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
            sqlda.Fill(ds);
            cmd.Connection.Close();
            return ds.Tables[0];
        }

        public static object ConsultarValor(SqlCommand cmd)
        {
            cmd.Connection = ConexionSQL();
            cmd.Connection.Open();
            object valor = cmd.ExecuteScalar();
            cmd.Connection.Close();
            return valor;
        }
    }
}