using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW_Oracle
{
    public partial class MainForm : Form
    {
        private static DataTable dt = null;
        private DataGridViewButtonColumn btn_mod = null;
        private DataGridViewButtonColumn btn_del = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void SetStatus(string text, bool status)
        {
            Label sl = statuslabel;
            if (status)
            {
                sl.ForeColor = System.Drawing.Color.Blue;
            }
            else
            {
                sl.ForeColor = System.Drawing.Color.Red;
            }
            sl.Text = "STATUS:\t" + text.Trim();
        }

        private void re_dataGridView()
        {
            button_rf_dgv.Enabled = false;
            SetStatus("DOING", false);
            string SQL = string.Format(@"SELECT * FROM {0}.{1}", textBox_DATABASE.Text.Trim(), textBox_TABLE.Text.Trim());
            //MessageBox.Show("SQL:\n[" + SQL + "]", "DEBUG");
            if (dt != null)
            {
                dt.Clear();
            }
            dt = OracleHelper.ExecuteSQL_DataTable(SQL);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    dataGridView.DataSource = OracleHelper.ExecuteSQL_DataTable(SQL);

                    //追加修改按键
                    if (btn_mod != null)    //已经存在就删掉原来的按键
                    {
                        dataGridView.Columns.Remove(btn_mod);
                    }
                    btn_mod = new DataGridViewButtonColumn();
                    dataGridView.Columns.Add(btn_mod);
                    btn_mod.HeaderText = "MODIFY";
                    btn_mod.Name = "modify";
                    btn_mod.Text = "modify";
                    btn_mod.UseColumnTextForButtonValue = true;

                    //追加删除按键
                    if (btn_del != null)    //已经存在就删掉原来的按键
                    {
                        dataGridView.Columns.Remove(btn_del);
                    }
                    btn_del = new DataGridViewButtonColumn();
                    dataGridView.Columns.Add(btn_del);
                    btn_del.HeaderText = "DELETE";
                    btn_del.Name = "delete";
                    btn_del.Text = "delete";
                    btn_del.UseColumnTextForButtonValue = true;

                    SetStatus("SUCCESS", true);
                }
                else
                {
                    SetStatus("ERROR/NO DATA", false);
                }
            }
            else
            {
                SetStatus("ERROR", false);
            }
            button_rf_dgv.Enabled = true;
        }

        private void Button_Re_DataGridView_Click(object sender, EventArgs e)
        {
            re_dataGridView();
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("mod\nrow=" + e.RowIndex + "\ncol=" + e.ColumnIndex);
            if (e.ColumnIndex == 5)
            {
                //修改
                //MessageBox.Show("mod\nrow=" + e.RowIndex);

                string sno = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                string sname = dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                string ssex = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                string sbirthday = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                string tc = dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();

                SetStatus("DOING", false);

                DataForm df = new DataForm(sno, sname, ssex, sbirthday, tc, textBox_DATABASE.Text + '.' + textBox_TABLE.Text, 1);

                switch (df.ShowDialog(this))
                {
                    case DialogResult.OK:
                        SetStatus("SUCCESS", true);
                        re_dataGridView();
                        break;
                    case DialogResult.Cancel:
                        SetStatus("CANCELED", false);
                        break;
                    default:
                        SetStatus("ERROR", false);
                        break;
                }
            }
            if (e.ColumnIndex == 6)
            {
                //删除
                //MessageBox.Show("del\nrow="+e.RowIndex);

                string sno = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                string sname = dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                string ssex = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                string sbirthday = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();

                string SQL = string.Format(@"DELETE FROM {0}.{1} WHERE SNO='{2}' AND SNAME='{3}' AND SSEX='{4}'", textBox_DATABASE.Text.Trim(), textBox_TABLE.Text.Trim(), sno, sname, ssex);
                //MessageBox.Show("SQL:\n[" + SQL + "]", "DEBUG");
                SetStatus("DOING", false);
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("SQL:\n[" + SQL + "]\n\n请确认是否删除", "WARNING", MessageBoxButtons.YesNo);
                if (dr != DialogResult.Yes)
                {
                    MessageBox.Show("操作已取消");
                    SetStatus("CANCELED", false);
                    return;
                }
                if (OracleHelper.ExecuteSQL(SQL) > 0)
                {
                    SetStatus("SUCCESS", true);
                    re_dataGridView();
                }
                else
                {
                    SetStatus("ERROR/NOT FOUND", false);
                }
            }
        }

        private void Button_insert_Click(object sender, EventArgs e)
        {
            button_insert.Enabled = false;
            SetStatus("DOING", false);

            DataForm df = new DataForm(null, null, null, null, null, textBox_DATABASE.Text + '.' + textBox_TABLE.Text,0);

            switch (df.ShowDialog(this))
            {
                case DialogResult.OK:
                    SetStatus("SUCCESS", true);
                    break;
                case DialogResult.Cancel:
                    SetStatus("CANCELED", false);
                    break;
                default:
                    SetStatus("ERROR", false);
                    break;
            }
            button_insert.Enabled = true;
            re_dataGridView();
        }
    }
}
