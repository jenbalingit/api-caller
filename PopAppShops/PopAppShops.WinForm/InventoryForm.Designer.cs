namespace PopAppShops.WinForm
{
    partial class InventoryForm
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
            this.BtnGenerateTransactions = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.txttransCount = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.txtSerial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtbasestocks = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.SKU = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Current = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button5 = new System.Windows.Forms.Button();
            this.lblN = new System.Windows.Forms.Label();
            this.lblout = new System.Windows.Forms.Label();
            this.lblsell = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.txtsku = new System.Windows.Forms.TextBox();
            this.Expected = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // BtnGenerateTransactions
            // 
            this.BtnGenerateTransactions.Location = new System.Drawing.Point(877, 5);
            this.BtnGenerateTransactions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnGenerateTransactions.Name = "BtnGenerateTransactions";
            this.BtnGenerateTransactions.Size = new System.Drawing.Size(177, 37);
            this.BtnGenerateTransactions.TabIndex = 2;
            this.BtnGenerateTransactions.Text = "Generate Transactions";
            this.BtnGenerateTransactions.UseVisualStyleBackColor = true;
            this.BtnGenerateTransactions.Click += new System.EventHandler(this.BtnGenerateTransactions_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader2,
            this.columnHeader6});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(513, 56);
            this.listView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(541, 474);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Action";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "SKU";
            this.columnHeader3.Width = 250;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "SerialNumber";
            this.columnHeader2.Width = 800;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Message";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(513, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 29);
            this.label1.TabIndex = 6;
            this.label1.Text = "# Of Transactions : ";
            // 
            // txttransCount
            // 
            this.txttransCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttransCount.Location = new System.Drawing.Point(804, 5);
            this.txttransCount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txttransCount.Name = "txttransCount";
            this.txttransCount.Size = new System.Drawing.Size(67, 34);
            this.txttransCount.TabIndex = 5;
            this.txttransCount.Text = "5";
            this.txttransCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(186, 533);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 37);
            this.button1.TabIndex = 8;
            this.button1.Text = "Single In";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(282, 533);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 37);
            this.button2.TabIndex = 9;
            this.button2.Text = "Single Out";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(187, 574);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(91, 37);
            this.button4.TabIndex = 10;
            this.button4.Text = "Single Sell";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtSerial
            // 
            this.txtSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerial.Location = new System.Drawing.Point(10, 533);
            this.txtSerial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Size = new System.Drawing.Size(171, 34);
            this.txtSerial.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(115, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 29);
            this.label2.TabIndex = 15;
            this.label2.Text = "Base Stock : ";
            // 
            // txtbasestocks
            // 
            this.txtbasestocks.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbasestocks.Location = new System.Drawing.Point(257, 6);
            this.txtbasestocks.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtbasestocks.Name = "txtbasestocks";
            this.txtbasestocks.Size = new System.Drawing.Size(93, 34);
            this.txtbasestocks.TabIndex = 16;
            this.txtbasestocks.Text = "50";
            this.txtbasestocks.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(364, 3);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(113, 37);
            this.button6.TabIndex = 19;
            this.button6.Text = "Reset Stock";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SKU,
            this.Current,
            this.Expected});
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            this.listView2.Location = new System.Drawing.Point(9, 56);
            this.listView2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(472, 473);
            this.listView2.TabIndex = 20;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // SKU
            // 
            this.SKU.Text = "SKU";
            this.SKU.Width = 200;
            // 
            // Current
            // 
            this.Current.Text = "Current Stocks";
            this.Current.Width = 100;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(877, 536);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(177, 37);
            this.button5.TabIndex = 21;
            this.button5.Text = "Execute Transactions";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // lblN
            // 
            this.lblN.AutoSize = true;
            this.lblN.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblN.Location = new System.Drawing.Point(513, 544);
            this.lblN.Name = "lblN";
            this.lblN.Size = new System.Drawing.Size(63, 29);
            this.lblN.TabIndex = 22;
            this.lblN.Text = "In : 0";
            // 
            // lblout
            // 
            this.lblout.AutoSize = true;
            this.lblout.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblout.Location = new System.Drawing.Point(605, 544);
            this.lblout.Name = "lblout";
            this.lblout.Size = new System.Drawing.Size(82, 29);
            this.lblout.TabIndex = 23;
            this.lblout.Text = "Out : 0";
            // 
            // lblsell
            // 
            this.lblsell.AutoSize = true;
            this.lblsell.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsell.Location = new System.Drawing.Point(719, 544);
            this.lblsell.Name = "lblsell";
            this.lblsell.Size = new System.Drawing.Size(86, 29);
            this.lblsell.TabIndex = 24;
            this.lblsell.Text = "Sell : 0";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 8);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(97, 37);
            this.button3.TabIndex = 25;
            this.button3.Text = "Load Serials";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // txtsku
            // 
            this.txtsku.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsku.Location = new System.Drawing.Point(10, 571);
            this.txtsku.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtsku.Name = "txtsku";
            this.txtsku.Size = new System.Drawing.Size(171, 34);
            this.txtsku.TabIndex = 26;
            this.txtsku.Text = "WMGN66DL-CPN00-L";
            this.txtsku.TextChanged += new System.EventHandler(this.txtsku_TextChanged);
            // 
            // Expected
            // 
            this.Expected.Text = "Expected";
            this.Expected.Width = 100;
            // 
            // InventoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 718);
            this.Controls.Add(this.txtsku);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.lblsell);
            this.Controls.Add(this.lblout);
            this.Controls.Add(this.lblN);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.txtbasestocks);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSerial);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txttransCount);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.BtnGenerateTransactions);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "InventoryForm";
            this.Text = "InventoryForm";
            this.Load += new System.EventHandler(this.InventoryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnGenerateTransactions;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txttransCount;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtSerial;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtbasestocks;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader SKU;
        private System.Windows.Forms.ColumnHeader Current;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Label lblN;
        private System.Windows.Forms.Label lblout;
        private System.Windows.Forms.Label lblsell;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtsku;
        private System.Windows.Forms.ColumnHeader Expected;
    }
}