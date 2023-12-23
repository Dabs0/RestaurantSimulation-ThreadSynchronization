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
        public static int maxCustomerCount = (int)AnaForm1.fieldCustomerCount.Value; // Belirli bir sayıya ulaşana kadar müşteri üretecek
        static int[] tableStatus = new int[tableCount];//boşken -1 değilken müşterinin id'si
        static List<Customer> customers = new List<Customer>();
        public static List<Chef> chefs = new List<Chef>();
        public static List<Waiter> waiters = new List<Waiter>();

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

                    int p = masa.id;
                    AnaForm1.masalarButton[p].BackColor = Color.Red;
                    Thread.Sleep(1000);
                }
                else
                {
                    Console.WriteLine("Masa dolu, başka bir masayı deneyin.");
                    AnaForm1.Log("Masa dolu, başka bir masayı deneyin.");
                }
            }

            public void MusteriAyril(Masa masa)
            {
                if (!BosMu)
                {
                    Console.WriteLine($"{Musteri.Name} masadan ayrıldı.");
                    AnaForm1.Log($"{Musteri.Name} masadan ayrıldı.");
                    Musteri = null;
                    masa.BosMu = true;
                }
                else
                {
                    Console.WriteLine("Masada zaten kimse yok.");
                    AnaForm1.Log("Masada zaten kimse yok.");

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

                Button p = AnaForm1.garsonButton.FirstOrDefault(c => c.Name == this.Name);
                garsonuMesgulYap(p, tableID);
                Thread.Sleep(5000);
                customers.FirstOrDefault(c => c.Id == tableStatus[tableID]).status = customerStatus.Ordered;
                Console.WriteLine($"Garson {Name} , {tableID}. Masadan sipariş aldı...");
                AnaForm1.Log($"Garson {Name} , {tableID}. Masadan sipariş aldı...");

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
                    Thread.Sleep(3000);
                }
            }
            public void garsonuMesgulYap(Button p, int tableId)
            {
                foreach (var b in AnaForm1.garsonButton)
                {
                    if (b == p)
                    {
                        b.BackColor = Color.Red;
                        break;

                    }

                }
                foreach (var c in AnaForm1.garsonButonLabel)
                {

                    if (c.Name == p.Name)
                    {
                        string s = $"{tableId} numaralı masadan sipariş alınıyor";
                        Customer.SetLabelText(c, s);

                    }
                }


            }
            public void garsonuMesguldenCikar(Button p, int tableId)
            {
                foreach (var b in AnaForm1.garsonButton)
                {
                    if (b == p)
                    {
                        b.BackColor = Color.DarkSeaGreen;
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
                    Thread.Sleep(3000);
                }
            }
            public void seekOrder()
            {
                Console.WriteLine($"Aşçı {Name} , sipariş arıyor...");
                AnaForm1.Log($"Aşçı {Name} , sipariş arıyor...");

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
                        b.BackColor = Color.Red;
                        break;
                       
                    }

                }
                    foreach(var c in AnaForm1.asciButonLabel)
                {

                    if(c.Name == p.Name)
                    {
                        string s = $"{tableId} numaralı sipariş hazırlanıyor";
                        Customer.SetLabelText(c, s);

                    }
                }


            }

            public void asciyiMesguldenCikar(Button p, int tableId)
            {
                foreach (var b in AnaForm1.chefButton)
                {
                    if (b == p)
                    {
                        b.BackColor = Color.DarkSeaGreen;
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

                Button p = AnaForm1.chefButton.FirstOrDefault(c => c.Name == this.Name);
                asciyiMesgulYap(p,tableID);
                Thread.Sleep(5000);
                customers.FirstOrDefault(c => c.Id == tableStatus[tableID]).status = customerStatus.Eating;
                Console.WriteLine($"Aşçı {Name} , {tableID}. Masanın siparişini pişirdi...");
                AnaForm1.Log($"Aşçı {Name} , {tableID}. Masanın siparişini pişirdi...");
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
                int tryCount = 0;
                while (!shouldStop && customerQueue.ElementAt(0).Equals(this))
                {
                    
                        Console.WriteLine($"{Name} masa arıyor");
                    AnaForm1.Log($"{Name} masa arıyor");

                    if (tryCount == 5)
                        {
                            customerQueue.Remove(this);
                            Console.WriteLine($"{this.Name} boş masa bulamadı. Ayrılıyor.");
                        AnaForm1.Log($"{this.Name} boş masa bulamadı. Ayrılıyor.");
                        leave();
                            break;
                        }
                        findTable();
                        tryCount++;
                        Thread.Sleep(3000);
                    
                    
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

                        Thread.Sleep(1000);
                        status = customerStatus.Ate;
                        AnaForm1.masalarButton[masaId].BackColor = Color.DarkSeaGreen;
                        SetLabelText(AnaForm1.butonLabelleri[masaId], "BOŞ");
                        leave();
                        
                        break;

                    }
                    else
                    {
                        Console.WriteLine($"{Name} {status}");
                        AnaForm1.Log($"{Name} {status}");
                        Thread.Sleep(1000);
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
                for (int i = 0; i < tableCount; i++)
                {
                    if (tableStatus[i] == -1)
                    {
                        customerQueue.Remove(this);
                        AnaForm1.masalarButton[i].BackColor = Color.Red;
                        tableStatus[i] = this.Id;
                        this.status = customerStatus.Sitting;
                        this.TableNo = i;
                        SetLabelText(AnaForm1.butonLabelleri[i], this.Name);
                        Console.WriteLine("[{0}]", string.Join(", ", tableStatus));
                        
                        Eat(i);
                        break;
                    }
                }

            }
            public void leave()
            {
                Console.WriteLine($"{Name} ayrılıyor.");
                AnaForm1.Log($"{Name} ayrılıyor.");
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
            
            int currentCustomerCount = 0;

            while (currentCustomerCount < maxCustomerCount)
            {
                int randomInterval = random.Next(1000, 5000); // Rastgele bir süre aralığı (örneğin, 1 saniye ile 5 saniye arasında)
                Thread.Sleep(randomInterval);

                // Yeni müşteri üret
                Customer newCustomer = GenerateRandomCustomer();
                customers.Add(newCustomer);
                customerQueue.Add(newCustomer);
                newCustomer.StartWorking();

                currentCustomerCount++;
                totalCustomerCount++;
            }
        }

        public static Customer GenerateRandomCustomer()
        {
            Random random = new Random();
            int randomId = totalCustomerCount; // ID'yi toplam müşteri sayısına göre artır
            int randomPriority = random.Next(1, 5); // Rastgele bir öncelik seviyesi üret
            string randomName = "Customer" + totalCustomerCount; // Müşteri adını belirle
            Console.WriteLine($"{randomName} üretildi.");
            AnaForm1.Log($"{randomName} üretildi.");
            return new Customer(randomId, randomPriority, randomName);
        }
        public static void Main()
        {
            for (int i = 0; i < tableCount; i++)
            {
                tableStatus[i] = -1;
            }

            
            for(int i = 0;i < waiterCount; i++)
            {
                Waiter garson = new Waiter(i, "Garson"+i);
                waiters.Add(garson);
                Thread garsonThread = new Thread(garson.StartWorking);
                garsonThread.Start();
                Thread.Sleep(1000);
            }

            for (int i = 0; i < chefCount; i++)
            {
                Chef sef = new Chef(i, "Aşçı"+i);
                chefs.Add(sef);
                Thread sef1Thread = new Thread(sef.StartWorking);
                sef1Thread.Start();
                Thread.Sleep(1000);
            }

            Thread customerGenerator = new Thread(StartRandomCustomerGenerator);
            customerGenerator.Start();





            AnaForm1.MasaAnimasyonPaneliEkle();
            AnaForm1.AsciAnimasyonPaneliEkle();
            AnaForm1.GarsonAnimasyonPaneliEkle();




        }



    }
}
