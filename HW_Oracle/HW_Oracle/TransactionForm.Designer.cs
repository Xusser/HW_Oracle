namespace HW_Oracle
{
    partial class TransactionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.Commit_button = new System.Windows.Forms.Button();
            this.Cancel_button = new System.Windows.Forms.Button();
            this.dbg_button = new System.Windows.Forms.Button();
            this.Preview_btn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.listBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(864, 555);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 18;
            this.listBox1.Location = new System.Drawing.Point(4, 4);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(856, 491);
            this.listBox1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.Commit_button, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.Cancel_button, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.dbg_button, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.Preview_btn, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 503);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(856, 48);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // Commit_button
            // 
            this.Commit_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Commit_button.Location = new System.Drawing.Point(646, 4);
            this.Commit_button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Commit_button.Name = "Commit_button";
            this.Commit_button.Size = new System.Drawing.Size(206, 40);
            this.Commit_button.TabIndex = 0;
            this.Commit_button.Text = "Commit";
            this.Commit_button.UseVisualStyleBackColor = true;
            this.Commit_button.Click += new System.EventHandler(this.Commit_button_Click);
            // 
            // Cancel_button
            // 
            this.Cancel_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cancel_button.Location = new System.Drawing.Point(432, 4);
            this.Cancel_button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Cancel_button.Name = "Cancel_button";
            this.Cancel_button.Size = new System.Drawing.Size(206, 40);
            this.Cancel_button.TabIndex = 1;
            this.Cancel_button.Text = "RollBack";
            this.Cancel_button.UseVisualStyleBackColor = true;
            this.Cancel_button.Click += new System.EventHandler(this.Cancel_button_Click);
            // 
            // dbg_button
            // 
            this.dbg_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbg_button.Enabled = false;
            this.dbg_button.Location = new System.Drawing.Point(3, 3);
            this.dbg_button.Name = "dbg_button";
            this.dbg_button.Size = new System.Drawing.Size(208, 42);
            this.dbg_button.TabIndex = 2;
            this.dbg_button.Text = "DEBUG";
            this.dbg_button.UseVisualStyleBackColor = true;
            // 
            // Preview_btn
            // 
            this.Preview_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Preview_btn.Location = new System.Drawing.Point(217, 3);
            this.Preview_btn.Name = "Preview_btn";
            this.Preview_btn.Size = new System.Drawing.Size(208, 42);
            this.Preview_btn.TabIndex = 3;
            this.Preview_btn.Text = "Preview";
            this.Preview_btn.UseVisualStyleBackColor = true;
            this.Preview_btn.Click += new System.EventHandler(this.Preview_btn_Click);
            // 
            // TransactionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 555);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(877, 586);
            this.Name = "TransactionForm";
            this.Text = "TransactionForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TransactionForm_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button Commit_button;
        private System.Windows.Forms.Button Cancel_button;
        private System.Windows.Forms.Button dbg_button;
        private System.Windows.Forms.Button Preview_btn;
    }
}