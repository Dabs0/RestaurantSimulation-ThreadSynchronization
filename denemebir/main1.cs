using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace denemebir
{
    public class main1
    {
        public static SortedSet<Customer> customerQueue = new SortedSet<Customer>();
        public static int tableCount = (int)AnaForm1.fieldTableCount.Value;
        public static int waiterCount = (int)AnaForm1.fieldWaiterCount.Value;
        public static int chefCount = (int)AnaForm1.fieldChefCount.Value;
        private static int totalCustomerCount = 0;
        public static int currentCustomerCount = 0;
        public static int maxCustomerCount = (int)AnaForm1.fieldCustomerCount.Value; // Belirli bir sayıya ulaşana kadar müşteri üretecek
        static int[] tableStatus = new int[tableCount];//boşken -1 değilken müşterinin id'si
        static List<Customer> customers = new List<Customer>();
        public static List<Chef> chefs = new List<Chef>();
        public static List<Waiter> waiters = new List<Waiter>();
        public static int asciZamanKatsayisi = 3000;
        public static int garsonZamanKatsayisi = 2000;
        public static int musteriYemekZamanKatsayisi = 3000;
        public static int musteriUretmeZamanKatsayisi = 1000;
        public static int donguZamanKatsayisi = 1000;
        public static int simulasyonHiziZamanKatsayisi = 1;
        public static int siraBeklemeZamanKatsayisi = 20;
        public static int kasaZamanKatsayisi = 1000;



        public enum customerStatus
        {
            Waiting,
            Sitting,
            Ordering,
            Ordered,
            OrderInProcess,
            Eating,
            Ate,
            Paying,
            Leaving,
            Left
        };


        public class Masa
        {
            public int id;
            private static int nextId = 1;
            public bool BosMu { get; set; }
            public Customer Musteri { get; set; }


            public Masa()
            {

                id = nextId;
                BosMu = true; // Başlangıçta tüm masalar boş olacak
                Musteri = null; // Başlangıçta hiçbir müşteri olmayacak
                nextId++;
            }

            public void MusteriOturt(Customer musteri, Masa masa)
        {
                if (BosMu)
                {
                    Musteri = musteri;
                    BosMu = false;
                    Console.WriteLine($"{musteri.Name} masaya oturtuldu.");
                    AnaForm1.Log($"{musteri.Name} masaya oturtuldu.");
                    AnaForm1.LogCustomer($"{musteri.Name} masaya oturtuldu.");

                    int p = masa.id;
                    AnaForm1.masalarButton[p].BackColor = Color.Red;
                    Thread.Sleep(donguZamanKatsayisi*simulasyonHiziZamanKatsayisi);
                }
                else
                {
                    Console.WriteLine("Masa dolu, başka bir masayı deneyin.");
                    AnaForm1.Log("Masa dolu, başka bir masayı deneyin.");
                    AnaForm1.LogCustomer("Masa dolu, başka bir masayı deneyin.");
                }
            }

            public void MusteriAyril(Masa masa)
            {
                if (!BosMu)
                {
                    Console.WriteLine($"{Musteri.Name} masadan ayrıldı.");
                    AnaForm1.Log($"{Musteri.Name} masadan ayrıldı.");
                    AnaForm1.LogQueue($"{Musteri.Name} masadan ayrıldı.");
                    
                    Musteri = null;
                    masa.BosMu = true;
                }
                else
                {
                    Console.WriteLine("Masada zaten kimse yok.");
                    AnaForm1.Log("Masada zaten kimse yok.");
                    AnaForm1.LogCustomer("Masada zaten kimse yok.");

                }
            }
        
    }
    

    public class Waiter
        {
            int Id;
            public string Name;
            private Thread waiterThread;
            public bool shouldStop = false;
            public Waiter(int id, string name)
            {
                Id = id;
                Name = name;
                waiterThread = new Thread(SeekOrderLoop);
            }
            
            public void seekOrder()
            {
                Console.WriteLine($"Garson {Name} , sipariş arıyor...");
                AnaForm1.Log($"Garson {Name} , sipariş arıyor...");
                AnaForm1.LogWaiter($"Garson {Name} , sipariş arıyor...");
                for (int i = 0; i < tableCount; i++)
                {
                    Random random = new Random();
                    int table = random.Next(tableCount);
                    if (tableStatus[table] != -1 && customers.FirstOrDefault(c => c.Id == tableStatus[table]).status.Equals(customerStatus.Sitting))
                    {
                        takeOrder(table);
                        break;
                    }
                }
            }
            public void takeOrder(int tableID)
            {
                customers.FirstOrDefault(c => c.Id == tableStatus[tableID]).status = customerStatus.Ordering;
                Console.WriteLine($"Garson {Name} , {tableID}. Masadan sipariş alıyor...");
                AnaForm1.Log($"Garson {Name} , {tableID}. Masadan sipariş alıyor...");
                AnaForm1.LogWaiter($"Garson {Name} , {tableID}. Masadan sipariş alıyor...");
                Customer.SetLabelText(AnaForm1.butonLabelleri[tableID], customers.FirstOrDefault(c => c.Id == tableStatus[tableID]).Name +" "+ customers.FirstOrDefault(c => c.Id == tableStatus[tableID]).status);

                Button p = AnaForm1.garsonButton.FirstOrDefault(c => c.Name == this.Name);
                garsonuMesgulYap(p, tableID);
                Thread.Sleep(garsonZamanKatsayisi*simulasyonHiziZamanKatsayisi);
                customers.FirstOrDefault(c => c.Id == tableStatus[tableID]).status = customerStatus.Ordered;
                Console.WriteLine($"Garson {Name} , {tableID}. Masadan sipariş aldı...");
                AnaForm1.Log($"Garson {Name} , {tableID}. Masadan sipariş aldı...");
                AnaForm1.LogWaiter($"Garson {Name} , {tableID}. Masadan sipariş aldı...");
                Customer.SetLabelText(AnaForm1.butonLabelleri[tableID], customers.FirstOrDefault(c => c.Id == tableStatus[tableID]).Name +" "+ customers.FirstOrDefault(c => c.Id == tableStatus[tableID]).status);


                garsonuMesguldenCikar(p, tableID);
            }
            public void StartWorking()
            {
                waiterThread.Start();
            }

            public void StopWorking()
            {
                shouldStop = true;
                waiterThread.Join();
            }

            private void SeekOrderLoop()
            {
                while (!shouldStop)
                {
                    seekOrder();
                    Thread.Sleep(donguZamanKatsayisi*simulasyonHiziZamanKatsayisi);
                }
            }
            public void garsonuMesgulYap(Button p, int tableId)
            {
                foreach (var b in AnaForm1.garsonButton)
                {
                    if (b == p)
                    {
                        Random random = new Random();
                        b.BackColor = GenerateRandomBlueColor(random);
                        AnaForm1.masalarButton[tableId].BackColor=b.BackColor;
                        break;

                    }

                }
                foreach (var c in AnaForm1.garsonButonLabel)
                {

                    if (c.Name == p.Name)
                    {
                        string s = $"{tableId+1} numaralı masadan sipariş alınıyor";
                        Customer.SetLabelText(c, s);

                    }
                }


            }
            private Color GenerateRandomBlueColor(Random random)
            {
                // Rastgele bir RGB renk üret
                int red = random.Next(0, 50);
                int green = random.Next(0, 100);
                int blue = random.Next(100, 256); // Mavi tonları için minimum değeri ayarla (0-150 arası renkli tonlar)

                // Oluşturulan renk nesnesini döndür
                return Color.FromArgb(red, green, blue);
            }
            public void garsonuMesguldenCikar(Button p, int tableId)
            {
                foreach (var b in AnaForm1.garsonButton)
                {
                    if (b == p)
                    {
                        b.BackColor = Color.Wheat;
                        break;

                    }

                }
                foreach (var c in AnaForm1.garsonButonLabel)
                {

                    if (c.Name == p.Name)
                    {
                        string s = $"SİPARİŞ BEKLENİYOR";
                        Customer.SetLabelText(c, s);

                    }
                }


            }


        }
        public class Chef
        {
            public int Id;
            public string Name;
            private Thread chefThread;
            public bool shouldStop = false;
            public Chef(int id, string name)
            {
                Id = id;
                Name = name;
                chefThread = new Thread(CookOrderLoop);
            }

            public void StartWorking()
            {
                chefThread.Start();
            }

            public void StopWorking()
            {
                shouldStop = true;
                chefThread.Join();
            }

            private void CookOrderLoop()
            {
                while (!shouldStop)
                {
                    seekOrder();
                    Thread.Sleep(donguZamanKatsayisi * simulasyonHiziZamanKatsayisi);
                }
            }
            public void seekOrder()
            {
                Console.WriteLine($"Aşçı {Name} , sipariş arıyor...");
                AnaForm1.Log($"Aşçı {Name} , sipariş arıyor...");
                AnaForm1.LogChef($"Aşçı {Name} , sipariş arıyor...");

                for (int i = 0; i < tableCount; i++)
                {
                    if (tableStatus[i] != -1 && customers.FirstOrDefault(c => c.Id == tableStatus[i]).status.Equals(customerStatus.Ordered))
                    {
                        cookOrder(i);
                        break;
                    }
                }
            }
            public void asciyiMesgulYap(Button p,int tableId)
            {
                foreach(var b in AnaForm1.chefButton)
                {
                    if(b == p)
                    {
                        Random random = new Random();
                        b.BackColor = GenerateRandomGreenColor(random);
                        AnaForm1.masalarButton[tableId].BackColor = b.BackColor;
                        break;
                       
                    }

                }
                    foreach(var c in AnaForm1.asciButonLabel)
                {

                    if(c.Name == p.Name)
                    {
                        string s = $"{tableId+1} numaralı masanın siparişi hazırlanıyor";
                        Customer.SetLabelText(c, s);

                    }
                }


            }
            private Color GenerateRandomGreenColor(Random random)
            {
                // Rastgele bir RGB renk üret
                int red = random.Next(0, 50);
                int green = random.Next(100, 256); // Yeşil tonları için aralığı sınırla (50-200 arası renkli tonlar)
                int blue = random.Next(0, 50);

                // Oluşturulan renk nesnesini döndür
                return Color.FromArgb(red, green, blue);
            }

            public void asciyiMesguldenCikar(Button p, int tableId)
            {
                foreach (var b in AnaForm1.chefButton)
                {
                    if (b == p)
                    {
                        b.BackColor = Color.Wheat;
                        break;

                    }

                }
                foreach (var c in AnaForm1.asciButonLabel)
                {

                    if (c.Name == p.Name)
                    {
                        string s = $"SİPARİŞ BEKLENİYOR";
                        Customer.SetLabelText(c, s);

                    }
                }


            }

            public void cookOrder(int tableID)
            {
                customers.FirstOrDefault(c => c.Id == tableStatus[tableID]).status = customerStatus.OrderInProcess;
                Console.WriteLine($"Aşçı {Name} , {tableID}. Masanın siparişini pişiriyor...");
                AnaForm1.Log($"Aşçı {Name} , {tableID}. Masanın siparişini pişiriyor...");
                AnaForm1.LogChef($"Aşçı {Name} , {tableID}. Masanın siparişini pişiriyor...");

                Button p = AnaForm1.chefButton.FirstOrDefault(c => c.Name == this.Name);
                asciyiMesgulYap(p,tableID);
                Thread.Sleep(asciZamanKatsayisi*simulasyonHiziZamanKatsayisi);
                customers.FirstOrDefault(c => c.Id == tableStatus[tableID]).status = customerStatus.Eating;
                Console.WriteLine($"Aşçı {Name} , {tableID}. Masanın siparişini pişirdi...");
                AnaForm1.Log($"Aşçı {Name} , {tableID}. Masanın siparişini pişirdi...");
                AnaForm1.LogChef($"Aşçı {Name} , {tableID}. Masanın siparişini pişirdi...");
                AnaForm1.totalIncome++;
                AnaForm1.customerEarned++;
                AnaForm1.updateLabels();
                asciyiMesguldenCikar(p, tableID);
            }
            public void cookOrder(int OrderId, int OrderId2)
            {

            }
        }
        public class Customer : IComparable<Customer>
        {
            public int Id;
            public bool shouldStop = false;
            public int Priority;
            public string Name;
            public int TableNo;
            public customerStatus status;
            private Thread customerThread;
            public int beklemeSuresi=0;
            public int CompareTo(Customer other)
            {
                // Bu örnekte öncelik yüksek olan müşteriler önce gelir
                return other.Priority.CompareTo(this.Priority);
            }

            public Customer(int Id, int Priority, string Name)
            {
                this.Id = Id;

                this.Priority = Priority;
                this.Name = Name;
                this.status = customerStatus.Waiting;
                customerThread = new Thread(FindTableLoop);
            }
            public void StartWorking()
            {
                customerThread.Start();
            }

            public void StopWorking()
            {
                shouldStop = true;
                customerThread.Join();
            }

            private void FindTableLoop()
            {
                beklemeSuresi = 0;
                AnaForm1.LogQueue("findtableloop:" + this.Name);
                while (!shouldStop )
                {
                    
                    
                       

                        if (beklemeSuresi == 20)
                        {
                            customerQueue.Remove(this);
                            AnaForm1.updateQueue();
                            Console.WriteLine($"{this.Name} boş masa bulamadı. Ayrılıyor.");
                            AnaForm1.Log($"{this.Name} boş masa bulamadı. Ayrılıyor.");
                            AnaForm1.LogQueue($"{this.Name} boş masa bulamadı. Ayrılıyor.");
                            AnaForm1.customerLeftQueue++;
                            leave();
                            break;
                        }
                        findTable();
                        beklemeSuresi++;
                        Thread.Sleep(donguZamanKatsayisi * simulasyonHiziZamanKatsayisi);
                    
                        
                    
                    
                }
            }
            public void Eat(int masaId)
            {
                while (1 == 1)
                {
                    if (status == customerStatus.Eating)
                    {
                        Console.WriteLine($"{Name} {status}");
                        AnaForm1.Log($"{Name} {status}");
                        AnaForm1.LogCustomer($"{Name} {status}");
                        SetLabelText(AnaForm1.butonLabelleri[this.TableNo], this.Name +" "+ this.status);
                        Thread.Sleep(musteriYemekZamanKatsayisi*simulasyonHiziZamanKatsayisi);
                        status = customerStatus.Ate;
                        AnaForm1.masalarButton[masaId].BackColor = Color.Wheat;
                        SetLabelText(AnaForm1.butonLabelleri[masaId], "BOŞ");
                        leave();
                        
                        break;

                    }
                    else
                    {
                        Console.WriteLine($"{Name} {status}");
                        AnaForm1.Log($"{Name} {status}");
                        AnaForm1.LogCustomer($"{Name} {status}");
                        SetLabelText(AnaForm1.butonLabelleri[masaId], this.Name+" "+this.status);

                        Thread.Sleep(donguZamanKatsayisi * simulasyonHiziZamanKatsayisi);
                    }
                }
            }
            public static void SetLabelText(Label label ,string newText)
            {
                if (label.InvokeRequired)
                {
                    label.Invoke((MethodInvoker)delegate
                    {
                        label.Text = newText;
                    });
                }
                else
                {
                    label.Text = newText;
                }
            }

            public void findTable()
            {
                if (customerQueue.First().Equals(this))
                {
                    Console.WriteLine($"{Name} masa arıyor");
                    AnaForm1.Log($"{Name} masa arıyor");
                    AnaForm1.LogCustomer($"{Name} masa arıyor");
                    for (int i = 0; i < tableCount; i++)
                    {
                        if (tableStatus[i] == -1)
                        {

                            AnaForm1.masalarButton[i].BackColor = Color.Red;
                            tableStatus[i] = this.Id;
                            this.status = customerStatus.Sitting;
                            this.TableNo = i;
                            SetLabelText(AnaForm1.butonLabelleri[i], this.Name + " " + this.status);
                            Console.WriteLine("[{0}]", string.Join(", ", tableStatus));
                            customerQueue.Remove(this);
                            AnaForm1.updateQueue();
                            Eat(i);
                            break;
                        }
                    }
                }
                

            }
            public void leave()
            {
                Console.WriteLine($"{Name} ayrılıyor.");
                AnaForm1.Log($"{Name} ayrılıyor.");
                AnaForm1.LogQueue($"{Name} ayrılıyor.");
                if (!status.Equals(customerStatus.Waiting))
                {
                    tableStatus[TableNo] = -1;
                }
                status = customerStatus.Left;
                try
                {
                    StopWorking();
                    // Attempt to interrupt the thread
                    customerThread.Interrupt();
                    // Optionally, wait for the thread to finish gracefully
                    customerThread.Join();
                }
                catch (ThreadInterruptedException ex)
                {
                    // Handle the interruption gracefully (perform cleanup or logging)
                    Console.WriteLine($"ThreadInterruptedException: {ex.Message}");
                }
            }

        }
        public static void StartRandomCustomerGenerator()
        {
            Random random = new Random();

            while (currentCustomerCount < maxCustomerCount)
            {
                int randomInterval = random.Next(musteriUretmeZamanKatsayisi*simulasyonHiziZamanKatsayisi, 2*musteriUretmeZamanKatsayisi*simulasyonHiziZamanKatsayisi);
                Thread.Sleep(randomInterval);

                Customer newCustomer = GenerateRandomCustomer();

                lock (customerQueue)
                {
                    customers.Add(newCustomer);
                    customerQueue.Add(newCustomer);
                    AnaForm1.LogQueue("yeni eklendi:" + customerQueue.Count);
                    AnaForm1.updateQueue();
                }

                newCustomer.StartWorking();
                currentCustomerCount++;
                AnaForm1.updateLabels();
                totalCustomerCount++;
            }
        }

        public static Customer GenerateRandomCustomer()
        {
            Random random = new Random();
            int randomId = totalCustomerCount; // ID'yi toplam müşteri sayısına göre artır
            int randomPriority = random.Next(0, 100); // Rastgele bir öncelik seviyesi üret
            string randomName = "Customer" + totalCustomerCount; // Müşteri adını belirle
            Console.WriteLine($"{randomName} üretildi.");
            AnaForm1.Log($"{randomName} üretildi.");
            AnaForm1.LogQueue($"{randomName} üretildi.");
            return new Customer(randomId, randomPriority, randomName);
        }
        public static void Main()
        {
            
            for (int i = 0; i < tableCount; i++)
            {
                tableStatus[i] = -1;
            }
            

            for (int i = 0;i < waiterCount; i++)
            {
                Waiter garson = new Waiter(i, "Garson"+i);
                waiters.Add(garson);
                Thread garsonThread = new Thread(garson.StartWorking);
                garsonThread.Start();
                
            }

            for (int i = 0; i < chefCount; i++)
            {
                Chef sef = new Chef(i, "Aşçı"+i);
                chefs.Add(sef);
                Thread sef1Thread = new Thread(sef.StartWorking);
                sef1Thread.Start();
                
            }
            AnaForm1.MasaAnimasyonPaneliEkle();
            AnaForm1.AsciAnimasyonPaneliEkle();
            AnaForm1.GarsonAnimasyonPaneliEkle();
            Thread customerGenerator = new Thread(StartRandomCustomerGenerator);
            customerGenerator.Start();
            AnaForm1.totalIncome = 0 - tableCount - waiterCount - chefCount;




            




        }



    }
}
