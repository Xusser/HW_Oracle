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


        private static bool usingTranas = false;
        private static OracleConnection conn = null;

        public static OracleConnection Conn()
        {
            if (conn == null)
            {
                conn = new OracleConnection(connectionStr);
                conn.Open();
            }
            return conn;
        }


        /// <summary>
        /// 执行SQL语句，返回影响记录数
        /// </summary>
        /// <param name="SQL">SQL语句</param>
        /// <returns>影响记录数</returns>
        public static int ExecuteSQL(string SQL)
        {
            using (OracleCommand cmd = new OracleCommand(SQL, Conn()))
            {
                try
                {
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (OracleException e)
                {
                    MessageBox.Show("执行SQL语句错误!\n\n" + e.ToString(), "Error-ExecuteSQL(SQL)");
                    return -1;
                }
            }

        }

        public static DataTable ExecuteSQL_DataTable_Tran_Preview(ArrayList SQLList)
        {
            using (OracleCommand cmd = new OracleCommand())
            {
                cmd.Connection = Conn();
                using (OracleTransaction ot = Conn().BeginTransaction())
                {
                    cmd.Transaction = ot;

                    try
                    {
                        for (int i = 0; i < SQLList.Count; i++)
                        {
                            string SQL = SQLList[i].ToString();
                            if (!String.IsNullOrEmpty(SQL.Trim()))
                            {
                                cmd.CommandText = SQL;
                                cmd.ExecuteNonQuery();
                            }
                        }
                        //ot.Commit();
                        
                    }
                    catch (OracleException e)
                    {
                        ot.Rollback();
                        MessageBox.Show("执行SQL语句错误!\n已回滚\n\n" + e.ToString(), "Error-ExecuteSQL_Trans(SQLList)");
                        return null;
                    }
                    cmd.CommandText = prevSelectSQL;
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        ot.Rollback();
                        return dt;
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
            //MessageBox.Show(SQLList.Count.ToString());
            using (OracleCommand cmd = new OracleCommand())
            {
                cmd.Connection = Conn();
                using (OracleTransaction ot = Conn().BeginTransaction())
                {
                    cmd.Transaction = ot;

                    try
                    {
                        for (int i = 0; i < SQLList.Count; i++)
                        {
                            string SQL = SQLList[i].ToString();
                            //MessageBox.Show(SQL);
                            if (!String.IsNullOrEmpty(SQL.Trim()))
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
                        MessageBox.Show("执行SQL语句错误!\n已回滚\n\n" + e.ToString(), "Error-ExecuteSQL_Trans(SQLList)");
                        return 0;
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
            using (OracleCommand cmd = new OracleCommand(SQL, Conn()))
            {
                try
                {
                    using (OracleDataReader dr = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(dr);
                        prevSelectSQL = SQL;
                        return dt;
                    }
                }
                catch (OracleException e)
                {
                    MessageBox.Show("执行SQL语句错误!\n\n" + e.ToString(), "Error-ExecuteReader(SQL)");
                    return null;
                }
            }
        }

    }
}
