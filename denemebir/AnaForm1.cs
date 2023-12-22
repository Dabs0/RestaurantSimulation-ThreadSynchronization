using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        public static List<Button> chefButton =  new List<Button>();
        public static List<Label> asciButonLabel = new List<Label>();
        static TabControl tab;
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
            for(int i = 0; i < main1.chefCount; i++)
            {
                Chef chef = new Chef(id, isimler.ElementAt(random.Next(0, isimler.Count)));
                chefs.Add(chef);
                
                id++;
            }


        }
        public static void MasaAnimasyonPaneliEkle()
        {
            TabPage tabPage = new TabPage("Masalar"); // Yeni bir TabPage oluşturun

            Panel panel = new Panel();
            panel.Dock = DockStyle.Fill; // Paneli TabPage'in tamamına yayın
            tabPage.Controls.Add(panel); // Paneli TabPage'e ekle

            for (int i = 0; i < main1.tableCount; i++)
            {
                Masa masa = new Masa();
                masalar.Add(masa);
            }

            int xPos = 220;
            int yPos = 80;

            foreach (var masa in masalar)
            {
                Button masaButton = new Button();
                masaButton.Text = "Masa " + masa.id;
                masaButton.Width = 200;
                masaButton.Height = 100;
                masaButton.Location = new Point(xPos, yPos);

                Label butonEtiketi = new Label();
                butonEtiketi.BackColor = Color.White;
                butonEtiketi.Size = new System.Drawing.Size(100, 20);
                butonEtiketi.Location = new System.Drawing.Point(masaButton.Location.X + 50, masaButton.Location.Y + 70);
                butonLabelleri.Add(butonEtiketi);
                panel.Controls.Add(butonEtiketi); // Panel'e Label'i ekle
                panel.Controls.Add(masaButton); // Panel'e Button'u ekle
                masalarButton.Add(masaButton);

                if (masa.id == 3)
                {
                    xPos = 220;
                    yPos = 200;
                }
                else
                {
                    xPos += 400;
                }
            }

            masalariBoya();


            Button baslaButton = new Button();
            baslaButton.Text = "BAŞLA";

            baslaButton.Location = new Point(700, 400);
            baslaButton.Click += BaslaButton_Click;
            panel.Controls.Add(baslaButton);

            tab.TabPages.Add(tabPage); // TabPage'i TabControl'e ekle
        }

        public static void AsciAnimasyonPaneliEkle()
        {
            TabPage tabPage = new TabPage("Aşçılar"); // Yeni bir TabPage oluşturun

            Panel panel = new Panel();
            panel.Dock = DockStyle.Fill; // Paneli TabPage'in tamamına yayın
            tabPage.Controls.Add(panel); // Paneli TabPage'e ekle

           

            int xPos = 220;
            int yPos = 80;

           foreach(var chef in chefs)
            {

                Button chefButon = new Button();
                chefButon.Name = chef.Name;
                chefButon.BackColor = Color.DarkSeaGreen;
                chefButon.Text = chef.Name;
                chefButon.Width = 300;
                chefButon.Height = 200;
                chefButon.Location = new Point(xPos, yPos);

                Label butonEtiketi = new Label();
                butonEtiketi.Name = chef.Name;
                butonEtiketi.BackColor = Color.White;
                butonEtiketi.Size = new System.Drawing.Size(200, 20);
                butonEtiketi.Location = new System.Drawing.Point(chefButon.Location.X + 70, chefButon.Location.Y + 120);
                asciButonLabel.Add(butonEtiketi);
                panel.Controls.Add(butonEtiketi); // Panel'e Label'i ekle
                panel.Controls.Add(chefButon); // Panel'e Button'u ekle
                chefButton.Add(chefButon);


                xPos += 400;
            }


            tab.TabPages.Add(tabPage); // TabPage'i TabControl'e ekle




        }
        private void AnaForm_Load(object sender, EventArgs e)
        {
            tab = new TabControl();
            tab.Dock = DockStyle.Fill; // TabControl'ü formun tamamına yayın
            this.Controls.Add(tab);
           
            MasaAnimasyonPaneliEkle();
            
           
           
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

    }



}


