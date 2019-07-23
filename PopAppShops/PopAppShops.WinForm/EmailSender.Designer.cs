namespace PopAppShops.WinForm
{
    partial class EmailSender
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
            this.txtrecepeint = new System.Windows.Forms.TextBox();
            this.txtBody = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtrecepeint
            // 
            this.txtrecepeint.Location = new System.Drawing.Point(99, 12);
            this.txtrecepeint.Name = "txtrecepeint";
            this.txtrecepeint.Size = new System.Drawing.Size(326, 22);
            this.txtrecepeint.TabIndex = 0;
            // 
            // txtBody
            // 
            this.txtBody.Location = new System.Drawing.Point(99, 40);
            this.txtBody.Multiline = true;
            this.txtBody.Name = "txtBody";
            this.txtBody.Size = new System.Drawing.Size(326, 211);
            this.txtBody.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(316, 257);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 26);
            this.button1.TabIndex = 2;
            this.button1.Text = "Send Email";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EmailSender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 300);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtBody);
            this.Controls.Add(this.txtrecepeint);
            this.Name = "EmailSender";
            this.Text = "EmailSender";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtrecepeint;
        private System.Windows.Forms.TextBox txtBody;
        private System.Windows.Forms.Button button1;
    }
}