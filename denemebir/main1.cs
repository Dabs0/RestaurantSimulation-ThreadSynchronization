using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace denemebir
{
    public class main1
    {
        //SortedSet <Customer> customerQueue = new SortedSet<Customer>();
        public static int tableCount = 6;
        int waiterCount = 1;
        public static int chefCount = 2;
        private static int totalCustomerCount = 0;
        static int[] tableStatus = new int[tableCount];//boşken -1 değilken müşterinin id'si
        static List<Customer> customers = new List<Customer>();
        public static List<Chef> chefs = new List<Chef>();

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

                    int p = masa.id;
                    AnaForm1.masalarButton[p].BackColor = Color.Red;
                    Thread.Sleep(1000);
                }
                else
                {
                    Console.WriteLine("Masa dolu, başka bir masayı deneyin.");
                }
            }

            public void MusteriAyril(Masa masa)
            {
                if (!BosMu)
                {
                    Console.WriteLine($"{Musteri.Name} masadan ayrıldı.");
                    Musteri = null;
                    masa.BosMu = true;
                }
                else
                {
                    Console.WriteLine("Masada zaten kimse yok.");
                }
            }
        
    }
    

    public class Waiter
        {
            int Id;
            string Name;
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
                Thread.Sleep(5000);
                customers.FirstOrDefault(c => c.Id == tableStatus[tableID]).status = customerStatus.Ordered;
                Console.WriteLine($"Garson {Name} , {tableID}. Masadan sipariş aldı...");
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
                Button p = AnaForm1.chefButton.FirstOrDefault(c => c.Name == this.Name);
                asciyiMesgulYap(p,tableID);
                Thread.Sleep(5000);
                customers.FirstOrDefault(c => c.Id == tableStatus[tableID]).status = customerStatus.Eating;
                Console.WriteLine($"Aşçı {Name} , {tableID}. Masanın siparişini pişirdi...");
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
                while (!shouldStop)
                {
                    Console.WriteLine($"{Name} masa arıyor");
                    if (tryCount == 5)
                    {
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
            int maxCustomerCount = 50; // Belirli bir sayıya ulaşana kadar müşteri üretecek
            int currentCustomerCount = 0;

            while (currentCustomerCount < maxCustomerCount)
            {
                int randomInterval = random.Next(1000, 5000); // Rastgele bir süre aralığı (örneğin, 1 saniye ile 5 saniye arasında)
                Thread.Sleep(randomInterval);

                // Yeni müşteri üret
                Customer newCustomer = GenerateRandomCustomer();
                customers.Add(newCustomer);
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
            return new Customer(randomId, randomPriority, randomName);
        }
        public static void Main()
        {
            for (int i = 0; i < tableCount; i++)
            {
                tableStatus[i] = -1;
            }

            Thread customerGenerator = new Thread(StartRandomCustomerGenerator);
            customerGenerator.Start();

            Waiter garson1 = new Waiter(0, "Ali");
            Thread garson1Thread = new Thread(garson1.StartWorking);
            garson1Thread.Start();
            Thread.Sleep(1000);
            Waiter garson2 = new Waiter(1, "Kazım");
            Thread garson2Thread = new Thread(garson2.StartWorking);
            garson2Thread.Start();
            Thread.Sleep(1000);
            Chef sef1 = new Chef(0, "Mehmet");
            chefs.Add(sef1);
            Thread sef1Thread = new Thread(sef1.StartWorking);
            sef1Thread.Start();
            Thread.Sleep(1000);
            Chef sef2 = new Chef(1, "Akif");
            chefs.Add(sef2);
            Thread sef2Thread = new Thread(sef2.StartWorking);
            sef2Thread.Start();

            AnaForm1.AsciAnimasyonPaneliEkle();
            



        }



    }
}
