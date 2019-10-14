using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW_Oracle
{
    class OracleHelper
    {
        private static string connectionStr = "Data Source=(DESCRIPTION =(ADDRESS_LIST =(ADDRESS = (PROTOCOL = TCP)(HOST = 10.79.3.17)(PORT = 1521)))(CONNECT_DATA =(SID = ORCL)(SERVER = DEDICATED)));User Id=System;Password=123456;";
        private static string prevSelectSQL = null;

        /// <summary>
        /// 执行SQL语句，返回影响记录数
        /// </summary>
        /// <param name="SQL">SQL语句</param>
        /// <returns>影响记录数</returns>
        public static int ExecuteSQL(string SQL)
        {
            using (OracleConnection conn = new OracleConnection(connectionStr))
            {
                using (OracleCommand cmd = new OracleCommand(SQL, conn))
                {
                    try
                    {
                        conn.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (OracleException e)
                    {
                        conn.Close();
                        MessageBox.Show("执行SQL语句错误!\n\n" + e.ToString(), "Error-ExecuteSQL(SQL)");
                        return -1;
                    }
                }
            }
        }

        /// <summary>
        /// 执行多条SQL语句,返回成功(1)或失败(0)
        /// </summary>
        /// <param name="SQLList"></param>
        /// <returns></returns>
        public static int ExecuteSQL_Tran(ArrayList SQLList)
        {
            using (OracleConnection conn = new OracleConnection(connectionStr))
            {
                conn.Open();
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.Connection = conn;
                    using (OracleTransaction ot = conn.BeginTransaction())
                    {
                        cmd.Transaction = ot;

                        try
                        {
                            for (int i = 0; i < SQLList.Count; i++)
                            {
                                string SQL = SQLList[i].ToString();
                                if (String.IsNullOrEmpty(SQL.Trim()))
                                {
                                    cmd.CommandText = SQL;
                                    cmd.ExecuteNonQuery();
                                }
                            }
                            ot.Commit();
                            return 1;
                        }
                        catch (OracleException e)
                        {
                            ot.Rollback();
                            conn.Close();
                            MessageBox.Show("执行SQL语句错误!\n已回滚\n\n" + e.ToString(), "Error-ExecuteSQL_Trans(SQLList)");
                            return 0;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 执行查询语句，返回DataTable
        /// </summary>
        /// <param name="SQL">SQL语句</param>
        /// <returns>对应DataTable或者null(失败)</returns>
        public static DataTable ExecuteSQL_DataTable(string SQL)
        {
            using (OracleConnection conn = new OracleConnection(connectionStr))
            {
                using (OracleCommand cmd = new OracleCommand(SQL, conn))
                {
                    try
                    {
                        conn.Open();
                        using (OracleDataReader dr = cmd.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(dr);
                            dr.Close();
                            prevSelectSQL = SQL;
                            return dt;
                        }
                    }
                    catch (OracleException e)
                    {
                        conn.Close();
                        MessageBox.Show("执行SQL语句错误!\n\n" + e.ToString(), "Error-ExecuteReader(SQL)");
                        return null;
                    }
                }
            }
        }
    }
}
