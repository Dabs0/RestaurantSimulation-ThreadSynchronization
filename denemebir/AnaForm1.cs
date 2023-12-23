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
        public static List<Masa> masalar = new List<Masa>();
        public static List<Button> masalarButton = new List<Button>();
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
                butonEtiketi.Size = new System.Drawing.Size(100, 20);
                butonEtiketi.Location = new System.Drawing.Point(masaButton.Location.X + 50, masaButton.Location.Y + 70);
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





            for (int i = 0; i < waiters.Count; i++)
            {

                Button chefButon = new Button();
                chefButon.Name = chefs[i].Name;
                chefButon.BackColor = Color.DarkSeaGreen;
                chefButon.Text = chefs[i].Name;
                chefButon.Width = 300;
                chefButon.Height = 100;
                chefButon.Location = new Point(asciPanel.Size.Width / 3, i * (asciPanel.Size.Height / (chefs.Count + 1)));

                Label butonEtiketi = new Label();
                butonEtiketi.Name = chefs[i].Name;
                butonEtiketi.BackColor = Color.White;
                butonEtiketi.Size = new System.Drawing.Size(200, 20);
                butonEtiketi.Location = new System.Drawing.Point(chefButon.Location.X + 50, chefButon.Location.Y + 70);
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
                waiterButon.BackColor = Color.DarkSeaGreen;
                waiterButon.Text = waiters[i].Name;
                waiterButon.Width = 300;
                waiterButon.Height = 100;
                waiterButon.Location = new Point(garsonPanel.Size.Width / 5, i * (garsonPanel.Size.Height / (waiters.Count + 1)));

                Label butonEtiketi = new Label();
                butonEtiketi.Name = waiters[i].Name;
                butonEtiketi.BackColor = Color.White;
                butonEtiketi.Size = new System.Drawing.Size(200, 20);
                butonEtiketi.Location = new System.Drawing.Point(waiterButon.Location.X + 50, waiterButon.Location.Y + 70);
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
            asciPanel.Size = new Size(400, 1000);
            asciPanel.BorderStyle = BorderStyle.FixedSingle;
            mainPanel.Controls.Add(asciPanel);
            garsonPanel = new Panel();
            garsonPanel.Location = new Point(400, 0);
            garsonPanel.Size = new Size(400, 1000);
            garsonPanel.BorderStyle = BorderStyle.FixedSingle;
            mainPanel.Controls.Add(garsonPanel);
            masalarPanel = new Panel();
            masalarPanel.Location = new Point(800, 0);
            masalarPanel.Size = new Size(400, 1000);
            masalarPanel.BorderStyle = BorderStyle.FixedSingle;
            mainPanel.Controls.Add(masalarPanel);
            Button baslaButton = new Button();
            baslaButton.Text = "BAŞLA";

            baslaButton.Location = new Point(masalarPanel.Size.Width / 2, masalarPanel.Size.Height - 100);
            baslaButton.Click += BaslaButton_Click;
            masalarPanel.Controls.Add(baslaButton);





        }

        private static void BaslaButton_Click(object sender, EventArgs e)
        {
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
                    masalarButton.ElementAt(i).BackColor = Color.DarkSeaGreen;
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
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }



}


