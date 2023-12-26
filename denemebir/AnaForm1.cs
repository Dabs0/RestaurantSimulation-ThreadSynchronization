using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static denemebir.main1;



namespace denemebir
{
    public partial class AnaForm1 : Form
    {
        static Random random = new Random();
        static Button baslaButton = new Button();
        public static List<Masa> masalar = new List<Masa>();
        public static List<Button> masalarButton = new List<Button>();
        public static List<Button> siraButton = new List<Button>();

        Random rand = new Random();
        public static List<Label> butonLabelleri = new List<Label>();
        public static List<Button> chefButton = new List<Button>();
        public static List<Button> garsonButton = new List<Button>();
        public static List<Label> asciButonLabel = new List<Label>();
        public static List<Label> garsonButonLabel = new List<Label>();
        static TabControl tab;
        static Panel asciPanel;
        static Panel garsonPanel;
        static Panel masalarPanel;
        static Panel siraPanel;
        static Panel mainPanel;

        public static int customerEarned = 0;
        public static int totalIncome = 0;
        public static int customerLeftQueue = 0;
        public AnaForm1()
        {
            InitializeComponent();
            this.Load += AnaForm_Load;
            //  garsonOlustur();
        }
        public static void asciOlustur()
        {
            List<string> isimler = new List<string>
{
    "Ahmet",
    "Mehmet",
    "Ayşe",
    "Fatma",
    "Mustafa",
};
            int id = 1;
            for (int i = 0; i < main1.chefCount; i++)
            {
                Chef chef = new Chef(id, isimler.ElementAt(random.Next(0, isimler.Count)));
                chefs.Add(chef);

                id++;
            }


        }
        public static void MasaAnimasyonPaneliEkle()
        {
            //TabPage tabPage = new TabPage("Masalar"); // Yeni bir TabPage oluşturun



            // Paneli TabPage'in tamamına yayın
            //tabPage.Controls.Add(masalarPanel); // Paneli TabPage'e ekle

            for (int i = 0; i < main1.tableCount; i++)
            {
                Masa masa = new Masa();
                masalar.Add(masa);
            }



            for (int i = 0; i < masalar.Count; i++)
            {
                Button masaButton = new Button();
                masaButton.Text = "Masa " + masalar[i].id;
                masaButton.Width = 200;
                masaButton.Height = 100;
                masaButton.Location = new Point(masalarPanel.Size.Width / 3, i * (masalarPanel.Size.Height / (masalar.Count + 1)));

                Label butonEtiketi = new Label();
                butonEtiketi.BackColor = Color.White;
                butonEtiketi.Size = new System.Drawing.Size(150, 20);
                butonEtiketi.Location = new System.Drawing.Point(masaButton.Location.X + 25, masaButton.Location.Y + 70);
                butonLabelleri.Add(butonEtiketi);
                masalarPanel.Controls.Add(butonEtiketi); // Panel'e Label'i ekle
                masalarPanel.Controls.Add(masaButton); // Panel'e Button'u ekle
                masalarButton.Add(masaButton);


            }

            masalariBoya();




            //tab.TabPages.Add(tabPage); // TabPage'i TabControl'e ekle
        }

        public static void AsciAnimasyonPaneliEkle()
        {
            //TabPage tabPage = new TabPage("Aşçılar"); // Yeni bir TabPage oluşturun

            /*Panel panel = new Panel();
            panel.Dock = DockStyle.Fill; // Paneli TabPage'in tamamına yayın
            tabPage.Controls.Add(panel); // Paneli TabPage'e ekle*/





            for (int i = 0; i < chefs.Count; i++)
            {

                Button chefButon = new Button();
                chefButon.Name = chefs[i].Name;
                chefButon.BackColor = Color.Wheat;
                chefButon.Text = chefs[i].Name;
                chefButon.Width = 300;
                chefButon.Height = 100;
                chefButon.Location = new Point(asciPanel.Size.Width / 5, i * (asciPanel.Size.Height / (chefs.Count + 1)));

                Label butonEtiketi = new Label();
                butonEtiketi.Name = chefs[i].Name;
                butonEtiketi.BackColor = Color.White;
                butonEtiketi.Size = new System.Drawing.Size(250, 20);
                butonEtiketi.Location = new System.Drawing.Point(chefButon.Location.X + 25, chefButon.Location.Y + 70);
                asciButonLabel.Add(butonEtiketi);
                asciPanel.Controls.Add(butonEtiketi); // Panel'e Label'i ekle
                asciPanel.Controls.Add(chefButon); // Panel'e Button'u ekle
                chefButton.Add(chefButon);
            }


            //tab.TabPages.Add(tabPage); // TabPage'i TabControl'e ekle




        }
        public static void GarsonAnimasyonPaneliEkle()
        {
            //TabPage tabPage = new TabPage("Aşçılar"); // Yeni bir TabPage oluşturun

            /*Panel panel = new Panel();
            panel.Dock = DockStyle.Fill; // Paneli TabPage'in tamamına yayın
            tabPage.Controls.Add(panel); // Paneli TabPage'e ekle*/





            for (int i = 0; i < waiters.Count; i++)
            {

                Button waiterButon = new Button();
                waiterButon.Name = waiters[i].Name;
                waiterButon.BackColor = Color.Wheat;
                waiterButon.Text = waiters[i].Name;
                waiterButon.Width = 300;
                waiterButon.Height = 100;
                waiterButon.Location = new Point(garsonPanel.Size.Width / 5, i * (garsonPanel.Size.Height / (waiters.Count + 1)));

                Label butonEtiketi = new Label();
                butonEtiketi.Name = waiters[i].Name;
                butonEtiketi.BackColor = Color.White;
                butonEtiketi.Size = new System.Drawing.Size(250, 20);
                butonEtiketi.Location = new System.Drawing.Point(waiterButon.Location.X + 25, waiterButon.Location.Y + 70);
                garsonButonLabel.Add(butonEtiketi);
                garsonPanel.Controls.Add(butonEtiketi); // Panel'e Label'i ekle
                garsonPanel.Controls.Add(waiterButon); // Panel'e Button'u ekle
                garsonButton.Add(waiterButon);



            }


            //tab.TabPages.Add(tabPage); // TabPage'i TabControl'e ekle




        }
        private void AnaForm_Load(object sender, EventArgs e)
        {
            /*tab = new TabControl();
            tab.Dock = DockStyle.Fill; // TabControl'ü formun tamamına yayın
            this.Controls.Add(tab);*/
            mainPanel = new Panel();
            mainPanel.Dock = DockStyle.Fill;
            this.Controls.Add(mainPanel);
            asciPanel = new Panel();
            asciPanel.Location = new Point(0, 0);
            asciPanel.Size = new Size(400, 800);
            asciPanel.BorderStyle = BorderStyle.FixedSingle;
            mainPanel.Controls.Add(asciPanel);
            garsonPanel = new Panel();
            garsonPanel.Location = new Point(400, 0);
            garsonPanel.Size = new Size(400, 800);
            garsonPanel.BorderStyle = BorderStyle.FixedSingle;
            mainPanel.Controls.Add(garsonPanel);
            masalarPanel = new Panel();
            masalarPanel.Location = new Point(800, 0);
            masalarPanel.Size = new Size(400, 800);
            masalarPanel.BorderStyle = BorderStyle.FixedSingle;
            mainPanel.Controls.Add(masalarPanel);

            baslaButton.Text = "BAŞLA";

            baslaButton.Location = new Point(1720, 220);
            baslaButton.Click += BaslaButton_Click;
            mainPanel.Controls.Add(baslaButton);
            siraPanel = new Panel();
            siraPanel.Location = new Point(1200, 0);
            siraPanel.Size = new Size(400, 800);
            siraPanel.BorderStyle = BorderStyle.FixedSingle;

            mainPanel.Controls.Add(siraPanel);







        }

        private static void BaslaButton_Click(object sender, EventArgs e)
        {
            baslaButton.Enabled = false;
            fieldChefCount.Enabled = false;
            fieldCustomerCount.Enabled = false;
            fieldTableCount.Enabled = false;
            fieldWaiterCount.Enabled = false;
            main1 main = new main1();
            main1.Main();


        }

        //public void garsonOlustur()
        //{
        //    for (int i = 0; i < 3; i++)
        //    {
        //        Garson garson = new Garson("Garson " + (i + 1), rand.Next(20, 35));
        //        garsonlar.Add(garson);

        //    }



        //}

        public static void masalariBoya()
        {
            for (int i = 0; i < masalar.Count; i++)
            {
                if (masalar[i].BosMu)
                {
                    masalarButton.ElementAt(i).BackColor = Color.Wheat;
                }

            }

        }
        public static void Log(string message)
        {
            if (konsol.InvokeRequired)
            {
                konsol.Invoke(new Action<string>(Log), message);
            }
            else
            {
                konsol.AppendText(message + Environment.NewLine);
            }
        }
        public static void LogCustomer(string message)
        {
            if (masalarKonsol.InvokeRequired)
            {
                masalarKonsol.Invoke(new Action<string>(LogCustomer), message);
            }
            else
            {
                masalarKonsol.AppendText(message + Environment.NewLine);
            }
        }
        public static void LogChef(string message)
        {
            if (asciKonsol.InvokeRequired)
            {
                asciKonsol.Invoke(new Action<string>(LogChef), message);
            }
            else
            {
                asciKonsol.AppendText(message + Environment.NewLine);
            }
        }
        public static void LogWaiter(string message)
        {
            if (garsonKonsol.InvokeRequired)
            {
                garsonKonsol.Invoke(new Action<string>(LogWaiter), message);
            }
            else
            {
                garsonKonsol.AppendText(message + Environment.NewLine);
            }
        }
        public static void LogQueue(string message)
        {
            if (siraKonsol.InvokeRequired)
            {
                siraKonsol.Invoke(new Action<string>(LogQueue), message);
            }
            else
            {
                siraKonsol.AppendText(message + Environment.NewLine);
            }
        }
        public static void updateQueue()
        {
            if (siraPanel.InvokeRequired)
            {
                siraPanel.Invoke(new MethodInvoker(updateQueue));
                return;
            }

            siraPanel.Controls.Clear();
            siraButton.Clear();
            int i = 0;

            foreach (var element in customerQueue)
            {
                LogQueue("customerqueuecount:"+customerQueue.Count);
                Button queueButton = new Button();
                queueButton.Name = element.Name;
                queueButton.BackColor = Color.Wheat;
                queueButton.Text = element.Name + " Öncelik:"+element.Priority;

                queueButton.Width = 300;
                queueButton.Height = 100;
                queueButton.Location = new Point(siraPanel.Size.Width / 5, i * (siraPanel.Size.Height / (customerQueue.Count + 1)));
                siraPanel.Controls.Add(queueButton);
                siraButton.Add(queueButton);

                i++;
            }
        }
        public static void updateLabels()
        {
            if (lblCustomerEarn.InvokeRequired)
            {
                lblCustomerEarn.Invoke(new MethodInvoker(() => updateLabels()));
            }
            else
            {
                lblCustomerEarn.Text = "Kazanılan Müşteri: " + customerEarned;
            }

            if (lblCustomerLeftQueue.InvokeRequired)
            {
                lblCustomerLeftQueue.Invoke(new MethodInvoker(() => updateLabels()));
            }
            else
            {
                lblCustomerLeftQueue.Text = "Kaybedilen Müşteri: " + customerLeftQueue;
            }

            if (lblTotalIncome.InvokeRequired)
            {
                lblTotalIncome.Invoke(new MethodInvoker(() => updateLabels()));
            }
            else
            {
                lblTotalIncome.Text = "Toplam Kazanç: " + totalIncome;
            }

            if (lblTotalCustomer.InvokeRequired)
            {
                lblTotalCustomer.Invoke(new MethodInvoker(() => updateLabels()));
            }
            else
            {
                lblTotalCustomer.Text = "Gelen Müşteri: " + main1.currentCustomerCount;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }



}


