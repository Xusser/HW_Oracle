using System;
using System.Collections;
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
    public partial class TransactionForm : Form
    {
        private static TransactionForm _transactionForm = null;

        public  static ArrayList arrayList = new ArrayList();

        public static bool isTransactionFormRunning()
        {
            if (_transactionForm == null)
                return false;
            else
                return true;
        }

        public void Ref_ListBox()
        {
            listBox1.Items.Clear();
            foreach(string sql in arrayList)
            {
                listBox1.Items.Add(sql);
            }
        }

        public static TransactionForm Instance()
        {
            if (_transactionForm == null)
                _transactionForm = new TransactionForm();
            return _transactionForm;
        }

        private TransactionForm()
        {
            InitializeComponent();
        }

        private void Cancel_button_Click(object sender, EventArgs e)
        {
            arrayList.Clear();
            this.Close();
        }

        private void TransactionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (arrayList.Count > 0)
                {
                    e.Cancel = true;
                    if (MessageBox.Show("你尚有事务未提交\n确认取消？", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        arrayList.Clear();
                        _transactionForm = null;
                        this.Close();
                    }
                }
                return;
            }
            else
            {
                arrayList.Clear();
                _transactionForm = null;
                this.Close();
            }
        }

        private void Commit_button_Click(object sender, EventArgs e)
        {
            if (OracleHelper.ExecuteSQL_Tran(arrayList) == 1)
            {
                MessageBox.Show("Success");
                arrayList.Clear();
                _transactionForm = null;
                this.Close();
            }
            else
            {
                MessageBox.Show("Fail");
            }
            
        }
    }
}
