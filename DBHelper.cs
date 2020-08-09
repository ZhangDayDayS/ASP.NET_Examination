using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Shopping.DAL
{
    public class DBHelper
    {

        string constr = @"Data Source=ZhangDayS;Initial Catalog=Shopping;Integrated Security=True";
        //增删改(简单查询)
        public int Update(string sql)
        {
            int rows = 0;
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    rows = cmd.ExecuteNonQuery();
                }
                catch
                {

                }
            }
            return rows;
        }
        //增删改(参数化查询)
        public int Update(string sql, SqlParameter[] param, CommandType type)
        {
            int rows = 0;
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.CommandType = type;
                    cmd.Parameters.AddRange(param);
                    rows = cmd.ExecuteNonQuery();
                }
                catch
                {

                }
            }
            return rows;
        }
        //查询单个数据(简单查询)
        public object QueryOne(string sql)
        {
            object obj = null;
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    obj = cmd.ExecuteScalar();
                }
                catch
                {

                }
            }
            return obj;
        }
        //查询单个数据(参数化查询)
        public object QueryOne(string sql, SqlParameter[] param, CommandType type)
        {
            object obj = null;
            using (SqlConnection con = new SqlConnection(constr))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.CommandType = type;
                    cmd.Parameters.AddRange(param);
                    obj = cmd.ExecuteScalar();
                }
                catch
                {

                }
            }
            return obj;
        }
        //使用SqlDataReader查询多行多列数据(简单查询)
        public SqlDataReader QuerySet(string sql)
        {
            SqlDataReader reader = null;
            SqlConnection con = new SqlConnection(constr);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                reader = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                //throw ex;
                con.Close();
            }
            return reader;
        }
        //使用SqlDataReader查询多行多列数据(参数化查询)
        public SqlDataReader QuerySet(string sql, SqlParameter[] param, CommandType type)
        {
            SqlDataReader reader = null;
            SqlConnection con = new SqlConnection(constr);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = type;
                cmd.Parameters.AddRange(param);
                reader = cmd.ExecuteReader();
            }
            catch
            {
                con.Close();
            }
            return reader;
        }
        //使用DataSet查询多行多列数据(简单查询)
        public DataSet GetData(string sql)
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                sda.Fill(ds);
            }
            catch
            {

            }
            return ds;
        }
        //使用DataSet查询多行多列数据(参数化查询)
        public DataSet GetData(string sql, SqlParameter[] param, CommandType type)
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = type;
            cmd.Parameters.AddRange(param);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                sda.Fill(ds);
            }
            catch
            {

            }
            return ds;
        }
    }
}
