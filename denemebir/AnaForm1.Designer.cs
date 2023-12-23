namespace denemebir
{
    partial class AnaForm1
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
            lblWaiterCount = new Label();
            fieldWaiterCount = new NumericUpDown();
            fieldChefCount = new NumericUpDown();
            lblChefCount = new Label();
            lblTableCount = new Label();
            fieldTableCount = new NumericUpDown();
            konsol = new TextBox();
            label1 = new Label();
            fieldCustomerCount = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)fieldWaiterCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fieldChefCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fieldTableCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fieldCustomerCount).BeginInit();
            SuspendLayout();
            // 
            // lblWaiterCount
            // 
            lblWaiterCount.AutoSize = true;
            lblWaiterCount.Location = new Point(1496, 76);
            lblWaiterCount.Name = "lblWaiterCount";
            lblWaiterCount.Size = new Size(76, 15);
            lblWaiterCount.TabIndex = 0;
            lblWaiterCount.Text = "Garson Sayısı";
            // 
            // fieldWaiterCount
            // 
            fieldWaiterCount.Location = new Point(1496, 94);
            fieldWaiterCount.Name = "fieldWaiterCount";
            fieldWaiterCount.Size = new Size(38, 23);
            fieldWaiterCount.TabIndex = 1;
            fieldWaiterCount.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // fieldChefCount
            // 
            fieldChefCount.Location = new Point(1496, 150);
            fieldChefCount.Name = "fieldChefCount";
            fieldChefCount.Size = new Size(38, 23);
            fieldChefCount.TabIndex = 2;
            fieldChefCount.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // lblChefCount
            // 
            lblChefCount.AutoSize = true;
            lblChefCount.Location = new Point(1496, 132);
            lblChefCount.Name = "lblChefCount";
            lblChefCount.Size = new Size(61, 15);
            lblChefCount.TabIndex = 3;
            lblChefCount.Text = "Aşçı Sayısı";
            lblChefCount.Click += label1_Click;
            // 
            // lblTableCount
            // 
            lblTableCount.AutoSize = true;
            lblTableCount.Location = new Point(1496, 187);
            lblTableCount.Name = "lblTableCount";
            lblTableCount.Size = new Size(67, 15);
            lblTableCount.TabIndex = 4;
            lblTableCount.Text = "Masa Sayısı";
            // 
            // fieldTableCount
            // 
            fieldTableCount.Location = new Point(1496, 214);
            fieldTableCount.Name = "fieldTableCount";
            fieldTableCount.Size = new Size(38, 23);
            fieldTableCount.TabIndex = 5;
            fieldTableCount.Value = new decimal(new int[] { 6, 0, 0, 0 });
            // 
            // konsol
            // 
            konsol.Location = new Point(1496, 281);
            konsol.Multiline = true;
            konsol.Name = "konsol";
            konsol.Size = new Size(376, 668);
            konsol.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1622, 76);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 7;
            label1.Text = "Müşteri Sayısı";
            // 
            // fieldCustomerCount
            // 
            fieldCustomerCount.Location = new Point(1622, 94);
            fieldCustomerCount.Name = "fieldCustomerCount";
            fieldCustomerCount.Size = new Size(38, 23);
            fieldCustomerCount.TabIndex = 8;
            fieldCustomerCount.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // AnaForm1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1884, 961);
            Controls.Add(fieldCustomerCount);
            Controls.Add(label1);
            Controls.Add(konsol);
            Controls.Add(fieldTableCount);
            Controls.Add(lblTableCount);
            Controls.Add(lblChefCount);
            Controls.Add(fieldChefCount);
            Controls.Add(fieldWaiterCount);
            Controls.Add(lblWaiterCount);
            Name = "AnaForm1";
            Text = "AnaForm1";
            ((System.ComponentModel.ISupportInitialize)fieldWaiterCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)fieldChefCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)fieldTableCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)fieldCustomerCount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label lblWaiterCount;
        private Label lblChefCount;
        private Label lblTableCount;
        private Label label1;
        public static NumericUpDown fieldCustomerCount;
        public static NumericUpDown fieldTableCount;
        public static NumericUpDown fieldWaiterCount;
        public static NumericUpDown fieldChefCount;
        public static TextBox konsol;
    }
}