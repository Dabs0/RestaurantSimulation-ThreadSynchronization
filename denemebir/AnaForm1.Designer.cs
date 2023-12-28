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
            asciKonsol = new TextBox();
            garsonKonsol = new TextBox();
            masalarKonsol = new TextBox();
            siraKonsol = new TextBox();
            lblTotalCustomer = new Label();
            lblCustomerEarn = new Label();
            lblCustomerLeftQueue = new Label();
            lblTotalIncome = new Label();
            kasaKonsol = new TextBox();
            asciZamanNum = new NumericUpDown();
            label2 = new Label();
            garsonZamanNum = new NumericUpDown();
            label3 = new Label();
            kasaZamanNum = new NumericUpDown();
            label4 = new Label();
            masaZamanNum = new NumericUpDown();
            label5 = new Label();
            siraZamanNum = new NumericUpDown();
            label6 = new Label();
            donguZamanNum = new NumericUpDown();
            label7 = new Label();
            simulasyonZamanNum = new NumericUpDown();
            label8 = new Label();
            musteriUretmeNum = new NumericUpDown();
            label9 = new Label();
            label10 = new Label();
            ((System.ComponentModel.ISupportInitialize)fieldWaiterCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fieldChefCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fieldTableCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fieldCustomerCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)asciZamanNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)garsonZamanNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)kasaZamanNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)masaZamanNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)siraZamanNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)donguZamanNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)simulasyonZamanNum).BeginInit();
            ((System.ComponentModel.ISupportInitialize)musteriUretmeNum).BeginInit();
            SuspendLayout();
            // 
            // lblWaiterCount
            // 
            lblWaiterCount.AutoSize = true;
            lblWaiterCount.Location = new Point(1600, 67);
            lblWaiterCount.Name = "lblWaiterCount";
            lblWaiterCount.Size = new Size(76, 15);
            lblWaiterCount.TabIndex = 0;
            lblWaiterCount.Text = "Garson Sayısı";
            // 
            // fieldWaiterCount
            // 
            fieldWaiterCount.Location = new Point(1600, 85);
            fieldWaiterCount.Name = "fieldWaiterCount";
            fieldWaiterCount.Size = new Size(38, 23);
            fieldWaiterCount.TabIndex = 1;
            fieldWaiterCount.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // fieldChefCount
            // 
            fieldChefCount.Location = new Point(1600, 141);
            fieldChefCount.Name = "fieldChefCount";
            fieldChefCount.Size = new Size(38, 23);
            fieldChefCount.TabIndex = 2;
            fieldChefCount.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // lblChefCount
            // 
            lblChefCount.AutoSize = true;
            lblChefCount.Location = new Point(1600, 123);
            lblChefCount.Name = "lblChefCount";
            lblChefCount.Size = new Size(61, 15);
            lblChefCount.TabIndex = 3;
            lblChefCount.Text = "Aşçı Sayısı";
            lblChefCount.Click += label1_Click;
            // 
            // lblTableCount
            // 
            lblTableCount.AutoSize = true;
            lblTableCount.Location = new Point(1600, 178);
            lblTableCount.Name = "lblTableCount";
            lblTableCount.Size = new Size(67, 15);
            lblTableCount.TabIndex = 4;
            lblTableCount.Text = "Masa Sayısı";
            // 
            // fieldTableCount
            // 
            fieldTableCount.Location = new Point(1600, 205);
            fieldTableCount.Name = "fieldTableCount";
            fieldTableCount.Size = new Size(38, 23);
            fieldTableCount.TabIndex = 5;
            fieldTableCount.Value = new decimal(new int[] { 6, 0, 0, 0 });
            // 
            // konsol
            // 
            konsol.Location = new Point(1600, 281);
            konsol.Multiline = true;
            konsol.Name = "konsol";
            konsol.ScrollBars = ScrollBars.Vertical;
            konsol.Size = new Size(284, 513);
            konsol.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1726, 67);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 7;
            label1.Text = "Müşteri Sayısı";
            // 
            // fieldCustomerCount
            // 
            fieldCustomerCount.Location = new Point(1726, 85);
            fieldCustomerCount.Name = "fieldCustomerCount";
            fieldCustomerCount.Size = new Size(38, 23);
            fieldCustomerCount.TabIndex = 8;
            fieldCustomerCount.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // asciKonsol
            // 
            asciKonsol.Location = new Point(0, 800);
            asciKonsol.Multiline = true;
            asciKonsol.Name = "asciKonsol";
            asciKonsol.ScrollBars = ScrollBars.Vertical;
            asciKonsol.Size = new Size(320, 160);
            asciKonsol.TabIndex = 9;
            // 
            // garsonKonsol
            // 
            garsonKonsol.Location = new Point(320, 800);
            garsonKonsol.Multiline = true;
            garsonKonsol.Name = "garsonKonsol";
            garsonKonsol.ScrollBars = ScrollBars.Vertical;
            garsonKonsol.Size = new Size(320, 160);
            garsonKonsol.TabIndex = 10;
            // 
            // masalarKonsol
            // 
            masalarKonsol.Location = new Point(960, 800);
            masalarKonsol.Multiline = true;
            masalarKonsol.Name = "masalarKonsol";
            masalarKonsol.ScrollBars = ScrollBars.Vertical;
            masalarKonsol.Size = new Size(320, 160);
            masalarKonsol.TabIndex = 11;
            // 
            // siraKonsol
            // 
            siraKonsol.Location = new Point(1280, 800);
            siraKonsol.Multiline = true;
            siraKonsol.Name = "siraKonsol";
            siraKonsol.ScrollBars = ScrollBars.Vertical;
            siraKonsol.Size = new Size(320, 160);
            siraKonsol.TabIndex = 12;
            // 
            // lblTotalCustomer
            // 
            lblTotalCustomer.AutoSize = true;
            lblTotalCustomer.Location = new Point(1726, 123);
            lblTotalCustomer.Name = "lblTotalCustomer";
            lblTotalCustomer.Size = new Size(92, 15);
            lblTotalCustomer.TabIndex = 13;
            lblTotalCustomer.Text = "Gelen Müşteri: 0";
            // 
            // lblCustomerEarn
            // 
            lblCustomerEarn.AutoSize = true;
            lblCustomerEarn.Location = new Point(1726, 143);
            lblCustomerEarn.Name = "lblCustomerEarn";
            lblCustomerEarn.Size = new Size(112, 15);
            lblCustomerEarn.TabIndex = 14;
            lblCustomerEarn.Text = "Kazanılan Müşteri: 0";
            // 
            // lblCustomerLeftQueue
            // 
            lblCustomerLeftQueue.AutoSize = true;
            lblCustomerLeftQueue.Location = new Point(1726, 168);
            lblCustomerLeftQueue.Name = "lblCustomerLeftQueue";
            lblCustomerLeftQueue.Size = new Size(119, 15);
            lblCustomerLeftQueue.TabIndex = 15;
            lblCustomerLeftQueue.Text = "Giremeyen Müşteri: 0";
            // 
            // lblTotalIncome
            // 
            lblTotalIncome.AutoSize = true;
            lblTotalIncome.Location = new Point(1726, 192);
            lblTotalIncome.Name = "lblTotalIncome";
            lblTotalIncome.Size = new Size(98, 15);
            lblTotalIncome.TabIndex = 16;
            lblTotalIncome.Text = "Toplam Kazanç: 0";
            // 
            // kasaKonsol
            // 
            kasaKonsol.Location = new Point(640, 800);
            kasaKonsol.Multiline = true;
            kasaKonsol.Name = "kasaKonsol";
            kasaKonsol.ScrollBars = ScrollBars.Vertical;
            kasaKonsol.Size = new Size(320, 160);
            kasaKonsol.TabIndex = 17;
            // 
            // asciZamanNum
            // 
            asciZamanNum.DecimalPlaces = 1;
            asciZamanNum.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            asciZamanNum.Location = new Point(1606, 856);
            asciZamanNum.Name = "asciZamanNum";
            asciZamanNum.Size = new Size(38, 23);
            asciZamanNum.TabIndex = 19;
            asciZamanNum.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1606, 829);
            label2.Name = "label2";
            label2.Size = new Size(29, 15);
            label2.TabIndex = 18;
            label2.Text = "Aşçı";
            // 
            // garsonZamanNum
            // 
            garsonZamanNum.DecimalPlaces = 1;
            garsonZamanNum.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            garsonZamanNum.Location = new Point(1659, 856);
            garsonZamanNum.Name = "garsonZamanNum";
            garsonZamanNum.Size = new Size(38, 23);
            garsonZamanNum.TabIndex = 21;
            garsonZamanNum.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1659, 829);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 20;
            label3.Text = "Garson";
            // 
            // kasaZamanNum
            // 
            kasaZamanNum.DecimalPlaces = 1;
            kasaZamanNum.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            kasaZamanNum.Location = new Point(1715, 856);
            kasaZamanNum.Name = "kasaZamanNum";
            kasaZamanNum.Size = new Size(38, 23);
            kasaZamanNum.TabIndex = 23;
            kasaZamanNum.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(1715, 829);
            label4.Name = "label4";
            label4.Size = new Size(31, 15);
            label4.TabIndex = 22;
            label4.Text = "Kasa";
            // 
            // masaZamanNum
            // 
            masaZamanNum.DecimalPlaces = 1;
            masaZamanNum.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            masaZamanNum.Location = new Point(1767, 856);
            masaZamanNum.Name = "masaZamanNum";
            masaZamanNum.Size = new Size(38, 23);
            masaZamanNum.TabIndex = 25;
            masaZamanNum.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(1767, 829);
            label5.Name = "label5";
            label5.Size = new Size(35, 15);
            label5.TabIndex = 24;
            label5.Text = "Masa";
            label5.Click += label5_Click;
            // 
            // siraZamanNum
            // 
            siraZamanNum.Location = new Point(1821, 856);
            siraZamanNum.Name = "siraZamanNum";
            siraZamanNum.Size = new Size(41, 23);
            siraZamanNum.TabIndex = 27;
            siraZamanNum.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1821, 829);
            label6.Name = "label6";
            label6.Size = new Size(26, 15);
            label6.TabIndex = 26;
            label6.Text = "Sıra";
            // 
            // donguZamanNum
            // 
            donguZamanNum.DecimalPlaces = 1;
            donguZamanNum.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            donguZamanNum.Location = new Point(1606, 926);
            donguZamanNum.Name = "donguZamanNum";
            donguZamanNum.Size = new Size(38, 23);
            donguZamanNum.TabIndex = 29;
            donguZamanNum.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(1606, 899);
            label7.Name = "label7";
            label7.Size = new Size(43, 15);
            label7.TabIndex = 28;
            label7.Text = "Döngü";
            label7.Click += label7_Click;
            // 
            // simulasyonZamanNum
            // 
            simulasyonZamanNum.DecimalPlaces = 1;
            simulasyonZamanNum.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            simulasyonZamanNum.Location = new Point(1715, 926);
            simulasyonZamanNum.Name = "simulasyonZamanNum";
            simulasyonZamanNum.Size = new Size(68, 23);
            simulasyonZamanNum.TabIndex = 31;
            simulasyonZamanNum.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(1715, 899);
            label8.Name = "label8";
            label8.Size = new Size(68, 15);
            label8.TabIndex = 30;
            label8.Text = "Simülasyon";
            // 
            // musteriUretmeNum
            // 
            musteriUretmeNum.DecimalPlaces = 1;
            musteriUretmeNum.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            musteriUretmeNum.Location = new Point(1659, 926);
            musteriUretmeNum.Name = "musteriUretmeNum";
            musteriUretmeNum.Size = new Size(38, 23);
            musteriUretmeNum.TabIndex = 33;
            musteriUretmeNum.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(1659, 899);
            label9.Name = "label9";
            label9.Size = new Size(46, 15);
            label9.TabIndex = 32;
            label9.Text = "Üretme";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(1692, 803);
            label10.Name = "label10";
            label10.Size = new Size(100, 15);
            label10.TabIndex = 34;
            label10.Text = "Zaman Katsayıları";
            // 
            // AnaForm1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1884, 961);
            Controls.Add(label10);
            Controls.Add(musteriUretmeNum);
            Controls.Add(label9);
            Controls.Add(simulasyonZamanNum);
            Controls.Add(label8);
            Controls.Add(donguZamanNum);
            Controls.Add(label7);
            Controls.Add(siraZamanNum);
            Controls.Add(label6);
            Controls.Add(masaZamanNum);
            Controls.Add(label5);
            Controls.Add(kasaZamanNum);
            Controls.Add(label4);
            Controls.Add(garsonZamanNum);
            Controls.Add(label3);
            Controls.Add(asciZamanNum);
            Controls.Add(label2);
            Controls.Add(kasaKonsol);
            Controls.Add(lblTotalIncome);
            Controls.Add(lblCustomerLeftQueue);
            Controls.Add(lblCustomerEarn);
            Controls.Add(lblTotalCustomer);
            Controls.Add(siraKonsol);
            Controls.Add(masalarKonsol);
            Controls.Add(garsonKonsol);
            Controls.Add(asciKonsol);
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
            ((System.ComponentModel.ISupportInitialize)asciZamanNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)garsonZamanNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)kasaZamanNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)masaZamanNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)siraZamanNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)donguZamanNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)simulasyonZamanNum).EndInit();
            ((System.ComponentModel.ISupportInitialize)musteriUretmeNum).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label lblWaiterCount;
        private Label lblChefCount;
        private Label lblTableCount;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        public static NumericUpDown musteriUretmeNum;
        public static NumericUpDown asciZamanNum;
        public static TextBox kasaKonsol;
        public static Label lblTotalCustomer;
        public static TextBox asciKonsol;
        public static TextBox garsonKonsol;
        public static TextBox masalarKonsol;
        public static TextBox siraKonsol;
        public static NumericUpDown fieldCustomerCount;
        public static NumericUpDown fieldTableCount;
        public static NumericUpDown fieldWaiterCount;
        public static NumericUpDown fieldChefCount;
        public static TextBox konsol;
        public static Label lblCustomerEarn;
        public static Label lblCustomerLeftQueue;
        public static Label lblTotalIncome;
        public static NumericUpDown garsonZamanNum;
        public static NumericUpDown kasaZamanNum;
        public static NumericUpDown masaZamanNum;
        public static NumericUpDown siraZamanNum;
        public static NumericUpDown donguZamanNum;
        public static NumericUpDown simulasyonZamanNum;
    }
}