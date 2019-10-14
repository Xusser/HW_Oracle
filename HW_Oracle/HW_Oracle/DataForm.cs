using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW_Oracle
{
    public partial class DataForm : Form
    {
        private bool isEdit = false;
        private bool isInsert = false;
        private string DB_TABLE = null;

        private string old_sno, old_sname, old_ssex, old_sbirthday, old_tc;

        private void button_insert_200_Click(object sender, EventArgs e)
        {
            string SQL = null;

            string sno, sname, ssex, sbirthday, tc;
            Random ran = new Random();
            int SuccessCount = 0;
            while (SuccessCount < 200)
            {
                sno = ran.Next(100000, 999999).ToString();
                sname = "TEST" + SuccessCount.ToString();
                if (ran.Next(0, 1) == 0)
                {
                    ssex = "男";
                }
                else
                {
                    ssex = "女";
                }
                sbirthday = DateTime.Today.ToShortDateString().Trim();
                tc = ran.Next(0, 100).ToString();
                SQL = string.Format(@"INSERT INTO {0} (SNO,SNAME,SSEX,SBIRTHDAY,TC) values ('{1}','{2}','{3}',to_date('{4}','YYYY/MM/DD'),'{5}')", DB_TABLE, sno, sname, ssex, sbirthday, tc);
                if (OracleHelper.ExecuteSQL(SQL) > 0)
                {
                    SuccessCount++;
                }
            }

            MessageBox.Show("SQL insert 200 times done.");
            this.DialogResult = DialogResult.OK;
        }

        private void button_trans_insert_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textbox_sno.Text) || string.IsNullOrEmpty(textbox_sname.Text) || string.IsNullOrEmpty(combobox_ssex.Text))
            {
                MessageBox.Show("请检查填写");
                return;
            }

            Thread.CurrentThread.CurrentCulture = new CultureInfo("zh-cn");

            string sno = textbox_sno.Text.Trim();
            string sname = textbox_sname.Text.Trim();
            string ssex = combobox_ssex.Text.Trim();
            string sbirthday = dtpicker_sbirthday.Value.ToShortDateString().Trim();
            string tc = textbox_tc.Text.Trim();

            string SQL = null;

            if (isEdit)
            {
                if (string.IsNullOrEmpty(old_tc))
                {
                    SQL = string.Format(@"UPDATE {0} SET SNO='{1}',SNAME='{2}',SSEX='{3}',SBIRTHDAY=to_date('{4}','YYYY/MM/DD'),TC={5} WHERE SNO='{6}' AND SNAME='{7}' AND SSEX='{8}'",
                DB_TABLE, sno, sname, ssex, sbirthday, tc,
                old_sno, old_sname, old_ssex);
                }
                else
                {
                    SQL = string.Format(@"UPDATE {0} SET SNO='{1}',SNAME='{2}',SSEX='{3}',SBIRTHDAY=to_date('{4}','YYYY/MM/DD'),TC={5} WHERE SNO='{6}' AND SNAME='{7}' AND SSEX='{8}' AND TC='{9}'",
                DB_TABLE, sno, sname, ssex, sbirthday, tc,
                old_sno, old_sname, old_ssex, old_tc);
                }
            }
            if (isInsert)
            {
                if (string.IsNullOrEmpty(tc))
                {
                    SQL = string.Format(@"INSERT INTO {0} (SNO,SNAME,SSEX,SBIRTHDAY) values ('{1}','{2}','{3}',to_date('{4}','YYYY/MM/DD'))", DB_TABLE, sno, sname, ssex, sbirthday);
                }
                else
                {
                    SQL = string.Format(@"INSERT INTO {0} (SNO,SNAME,SSEX,SBIRTHDAY,TC) values ('{1}','{2}','{3}',to_date('{4}','YYYY/MM/DD'),'{5}')", DB_TABLE, sno, sname, ssex, sbirthday, tc);
                }
            }

            TransactionForm.arrayList.Add(SQL);

            Console.WriteLine(SQL);
            if (!TransactionForm.isTransactionFormRunning())
                TransactionForm.Instance().Show();
            UpdTransFormList();

            this.DialogResult = DialogResult.OK;

        }

        private void UpdTransFormList()
        {
            if (TransactionForm.isTransactionFormRunning())
            {
                //刷新对应窗体的选择
                Action ad = delegate ()
                {
                    TransactionForm.Instance().Ref_ListBox();
                };
                TransactionForm.Instance().Invoke(ad);
            }
        }

        /// <summary>
        /// 数据窗口
        /// </summary>
        /// <param name="sno"></param>
        /// <param name="sname"></param>
        /// <param name="ssex"></param>
        /// <param name="sbirthday"></param>
        /// <param name="tc"></param>
        /// <param name="mode">[0]数据插入[1]数据修改</param>
        public DataForm(string sno, string sname, string ssex, string sbirthday, string tc, string db_table, int mode)
        {
            InitializeComponent();

            DB_TABLE = db_table;

            if (mode == 0)
            {
                isInsert = true;
                this.Text = "DataForm - Insert Mode";
            }
            else if (mode == 1)
            {
                isEdit = true;
                this.Text = "DataForm - Edit Mode";
            }

            dtpicker_sbirthday.Value = DateTime.Now;
            combobox_ssex.Text = "男";

            if (isInsert)
            {
                button_insert_200.Enabled = true;
                // button_trans_insert.Enabled = true; no need for this.
            }

            if (isEdit)
            {
                button_confirm.Text = "UPDATE";
                old_sno = sno;
                old_sname = sname;
                old_ssex = ssex;
                old_sbirthday = sbirthday;
                old_tc = tc;

                textbox_sno.Text = sno;
                textbox_sname.Text = sname;
                combobox_ssex.Text = ssex;
                textbox_tc.Text = tc;

                try
                {
                    dtpicker_sbirthday.Value = DateTime.Parse(sbirthday);
                }
                catch (Exception e)
                {
                    MessageBox.Show("时间转换失败！\n\n" + e.ToString());
                }
            }

        }

        private void DataForm_Load(object sender, EventArgs e)
        {

        }

        private void Button_confirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textbox_sno.Text) || string.IsNullOrEmpty(textbox_sname.Text) || string.IsNullOrEmpty(combobox_ssex.Text))
            {
                MessageBox.Show("请检查填写");
                return;
            }

            Thread.CurrentThread.CurrentCulture = new CultureInfo("zh-cn");

            string sno = textbox_sno.Text.Trim();
            string sname = textbox_sname.Text.Trim();
            string ssex = combobox_ssex.Text.Trim();
            string sbirthday = dtpicker_sbirthday.Value.ToShortDateString().Trim();
            string tc = textbox_tc.Text.Trim();

            string SQL = null;

            if (isEdit)
            {
                if (string.IsNullOrEmpty(old_tc))
                {
                    SQL = string.Format(@"UPDATE {0} SET SNO='{1}',SNAME='{2}',SSEX='{3}',SBIRTHDAY=to_date('{4}','YYYY/MM/DD'),TC={5} WHERE SNO='{6}' AND SNAME='{7}' AND SSEX='{8}'",
                DB_TABLE, sno, sname, ssex, sbirthday, tc,
                old_sno, old_sname, old_ssex);
                }
                else
                {
                    SQL = string.Format(@"UPDATE {0} SET SNO='{1}',SNAME='{2}',SSEX='{3}',SBIRTHDAY=to_date('{4}','YYYY/MM/DD'),TC={5} WHERE SNO='{6}' AND SNAME='{7}' AND SSEX='{8}' AND TC='{9}'",
                DB_TABLE, sno, sname, ssex, sbirthday, tc,
                old_sno, old_sname, old_ssex, old_tc);
                }
            }
            if (isInsert)
            {
                if (string.IsNullOrEmpty(tc))
                {
                    SQL = string.Format(@"INSERT INTO {0} (SNO,SNAME,SSEX,SBIRTHDAY) values ('{1}','{2}','{3}',to_date('{4}','YYYY/MM/DD'))", DB_TABLE, sno, sname, ssex, sbirthday);
                }
                else
                {
                    SQL = string.Format(@"INSERT INTO {0} (SNO,SNAME,SSEX,SBIRTHDAY,TC) values ('{1}','{2}','{3}',to_date('{4}','YYYY/MM/DD'),'{5}')", DB_TABLE, sno, sname, ssex, sbirthday, tc);
                }
            }

            Console.WriteLine(SQL);
            MessageBox.Show("SQL:\n[" + SQL + "]", "DEBUG");

            if (OracleHelper.ExecuteSQL(SQL) > 0)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void Button_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
