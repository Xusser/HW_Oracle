namespace HW_Oracle
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel_Bottom = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel_Buttons = new System.Windows.Forms.TableLayoutPanel();
            this.button_insert = new System.Windows.Forms.Button();
            this.button_rf_dgv = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox_DATABASE = new System.Windows.Forms.TextBox();
            this.textBox_TABLE = new System.Windows.Forms.TextBox();
            this.statuslabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel_Bottom.SuspendLayout();
            this.tableLayoutPanel_Buttons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_Bottom
            // 
            this.tableLayoutPanel_Bottom.ColumnCount = 1;
            this.tableLayoutPanel_Bottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel_Bottom.Controls.Add(this.tableLayoutPanel_Buttons, 0, 1);
            this.tableLayoutPanel_Bottom.Controls.Add(this.dataGridView, 0, 0);
            this.tableLayoutPanel_Bottom.Controls.Add(this.tableLayoutPanel1, 0, 2);
            this.tableLayoutPanel_Bottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Bottom.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_Bottom.Name = "tableLayoutPanel_Bottom";
            this.tableLayoutPanel_Bottom.Padding = new System.Windows.Forms.Padding(8);
            this.tableLayoutPanel_Bottom.RowCount = 3;
            this.tableLayoutPanel_Bottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel_Bottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.tableLayoutPanel_Bottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel_Bottom.Size = new System.Drawing.Size(844, 481);
            this.tableLayoutPanel_Bottom.TabIndex = 0;
            // 
            // tableLayoutPanel_Buttons
            // 
            this.tableLayoutPanel_Buttons.ColumnCount = 4;
            this.tableLayoutPanel_Buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel_Buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel_Buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel_Buttons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel_Buttons.Controls.Add(this.button_insert, 0, 0);
            this.tableLayoutPanel_Buttons.Controls.Add(this.button_rf_dgv, 3, 0);
            this.tableLayoutPanel_Buttons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Buttons.Location = new System.Drawing.Point(16, 318);
            this.tableLayoutPanel_Buttons.Margin = new System.Windows.Forms.Padding(8);
            this.tableLayoutPanel_Buttons.Name = "tableLayoutPanel_Buttons";
            this.tableLayoutPanel_Buttons.RowCount = 1;
            this.tableLayoutPanel_Buttons.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel_Buttons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel_Buttons.Size = new System.Drawing.Size(812, 90);
            this.tableLayoutPanel_Buttons.TabIndex = 0;
            // 
            // button_insert
            // 
            this.button_insert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_insert.Font = new System.Drawing.Font("Arial", 15.75F);
            this.button_insert.Location = new System.Drawing.Point(8, 8);
            this.button_insert.Margin = new System.Windows.Forms.Padding(8);
            this.button_insert.Name = "button_insert";
            this.button_insert.Size = new System.Drawing.Size(187, 74);
            this.button_insert.TabIndex = 0;
            this.button_insert.Text = "INSERT";
            this.button_insert.UseVisualStyleBackColor = true;
            this.button_insert.Click += new System.EventHandler(this.Button_insert_Click);
            // 
            // button_rf_dgv
            // 
            this.button_rf_dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_rf_dgv.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_rf_dgv.Location = new System.Drawing.Point(617, 8);
            this.button_rf_dgv.Margin = new System.Windows.Forms.Padding(8);
            this.button_rf_dgv.Name = "button_rf_dgv";
            this.button_rf_dgv.Size = new System.Drawing.Size(187, 74);
            this.button_rf_dgv.TabIndex = 3;
            this.button_rf_dgv.Text = "REFRESH\r\nDATAGRIDVIEW";
            this.button_rf_dgv.UseVisualStyleBackColor = true;
            this.button_rf_dgv.Click += new System.EventHandler(this.Button_Re_DataGridView_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.Location = new System.Drawing.Point(16, 16);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(8);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.Size = new System.Drawing.Size(812, 286);
            this.dataGridView.TabIndex = 1;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.textBox_DATABASE, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_TABLE, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.statuslabel, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(16, 424);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(8);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(812, 41);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // textBox_DATABASE
            // 
            this.textBox_DATABASE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_DATABASE.Location = new System.Drawing.Point(8, 8);
            this.textBox_DATABASE.Margin = new System.Windows.Forms.Padding(8);
            this.textBox_DATABASE.Name = "textBox_DATABASE";
            this.textBox_DATABASE.Size = new System.Drawing.Size(254, 21);
            this.textBox_DATABASE.TabIndex = 0;
            this.textBox_DATABASE.Text = " SYSTEM";
            // 
            // textBox_TABLE
            // 
            this.textBox_TABLE.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_TABLE.Location = new System.Drawing.Point(278, 8);
            this.textBox_TABLE.Margin = new System.Windows.Forms.Padding(8);
            this.textBox_TABLE.Name = "textBox_TABLE";
            this.textBox_TABLE.Size = new System.Drawing.Size(254, 21);
            this.textBox_TABLE.TabIndex = 1;
            this.textBox_TABLE.Text = "STUDENT";
            // 
            // statuslabel
            // 
            this.statuslabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statuslabel.Font = new System.Drawing.Font("Arial", 15.75F);
            this.statuslabel.Location = new System.Drawing.Point(548, 8);
            this.statuslabel.Margin = new System.Windows.Forms.Padding(8);
            this.statuslabel.Name = "statuslabel";
            this.statuslabel.Size = new System.Drawing.Size(256, 25);
            this.statuslabel.TabIndex = 2;
            this.statuslabel.Text = "STATUS:";
            this.statuslabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 481);
            this.Controls.Add(this.tableLayoutPanel_Bottom);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.tableLayoutPanel_Bottom.ResumeLayout(false);
            this.tableLayoutPanel_Buttons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Bottom;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Buttons;
        private System.Windows.Forms.Button button_insert;
        private System.Windows.Forms.Button button_rf_dgv;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBox_DATABASE;
        private System.Windows.Forms.TextBox textBox_TABLE;
        private System.Windows.Forms.Label statuslabel;
    }
}

