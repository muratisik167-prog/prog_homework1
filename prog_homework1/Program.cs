class Program
{
    static void Main(string[] args)
    {
    List<Product> menu = new List<Product> {
         new Food("Kuzu Ciğer", 150, 15),
         new Drink("Ayran",40, 2),
         new Dessert("Sütlaç", 50, 5),
         new Food("Mezeler", 0, 3)
    };  

        IOrder myOrder = new Order();
        bool isOrdering = true;
        Console.WriteLine("******* SUBU RESTORAN'A HOŞ GELDİNİZ *******");

        while (isOrdering) {
            Console.WriteLine("\n ******* MENU ******");
            Console.WriteLine("Lütfen Yapmak İstediğiniz İşlemi Seçin (1 - 2 - 3):");
            Console.WriteLine("1 - Ürün Ekle");
            Console.WriteLine("2 - Ürün Çıkar");
            Console.WriteLine("3 - Siparişi Tamamla Ve Fişi Yazdır");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("\n***** ÜRÜNLER ******* ");

                for (int i = 0; i < menu.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {menu[i].Name} - {menu[i].Price:C} - Hazırlık Süresi: {menu[i].PreparationTime} dakika");
                }
                Console.WriteLine("Eklemek istediğiniz ürünün numarasını giriniz ");

                // TryParse ile kullanıcının harf veya sembol girerse programın çökmesini engelliyoruz
                if (int.TryParse(Console.ReadLine(), out int addIndex) && addIndex > 0 && addIndex <= menu.Count)
                {
                    myOrder.AddProduct(menu[addIndex - 1]); // kullanıcı 1 girerse 0. indexteki ürün eklenir
                }
                else
                {
                    Console.WriteLine("Geçersiz ürün numarası. Lütfen tekrar deneyin.");
                }
            }
            else if (choice == "2") {
                Console.WriteLine("\n***** ÜRÜNLER ******* ");

                for (int i = 0; i < menu.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {menu[i].Name} - {menu[i].Price:C} - Hazırlık Süresi: {menu[i].PreparationTime} dakika");
                }
                Console.WriteLine("Çıkarmak istediğiniz ürünün numarasını giriniz ");

                // TryParse ile kullanıcının harf veya sembol girerse programın çökmesini engelliyoruz
                if (int.TryParse(Console.ReadLine(), out int removeIndex) && removeIndex > 0 && removeIndex <= menu.Count)
                {
                    myOrder.RemoveProduct(menu[removeIndex - 1]); // kullanıcı 1 girerse 0. indexteki ürün eklenir
                }
                else
                {
                    Console.WriteLine("Geçersiz ürün numarası. Lütfen tekrar deneyin.");
                }
            } else if (choice == "3") {
                myOrder.PrintReceipt();
                isOrdering = false; // sipariş tamamlandıktan sonra döngüyü sonlandırıyoruz
            }
            else
            {
                Console.WriteLine("Geçersiz seçim. Lütfen 1, 2 veya 3'ü seçin.");

            }

            

        }

        Console.ReadLine();
    }


public abstract class Product {
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int PreparationTime { get; set; } // dakika olarak tutulacak

    public Product(string name, decimal price, int preparationtime) {
        Name = name;
        Price = price;
        PreparationTime = preparationtime;
    }

    public abstract decimal CalculatePrice();
    public abstract int CalculatePreparationTime();
}

public class Food : Product {
    public Food(string name, decimal price, int preparationTime) : base(name, price, preparationTime) { }

    public override decimal CalculatePrice()
    {
        return Price;
    }
    public override int CalculatePreparationTime()
    {
        return PreparationTime + 2; // extra 2 dakika yemek hazırlanma süresi
    }
}

public class Drink : Product
{
    public Drink(string name, decimal price, int preparationTime) : base(name, price, preparationTime) { }

    public override decimal CalculatePrice()
    {
        return Price;
    }
    public override int CalculatePreparationTime()
    {
        return PreparationTime; 
    }
}

public class Dessert : Product
{
    public Dessert(string name, decimal price, int preparationTime) : base(name, price, preparationTime) { }

    public override decimal CalculatePrice()
    {
        return Price;
    }
    public override int CalculatePreparationTime()
    {
        return PreparationTime + 1; // extra 1 dakika yemek hazırlanma süresi
     
    }
}

public interface IOrder // zorunlu sipariş işlemleri
{
    void AddProduct(Product product);
    void RemoveProduct(Product product);
    decimal CalculateTotalPrice();
    int CalculateTotalPreparationTime();
    void PrintReceipt();
}

    public class Order : IOrder
    {
        private List<Product> _products;

        public Order()
        {
            _products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            if (product != null)
            {
                _products.Add(product);
                Console.WriteLine($"{product.Name} Sipariş'e eklendi");
            }
        }

        public void RemoveProduct(Product product)
        {
            if (_products.Contains(product))
            {
                _products.Remove(product);
                Console.WriteLine($"{product.Name} Sipariş'ten çıkarıldı");
            }
            else
            {
                Console.WriteLine($"{product.Name} Sipariş'te bulunamadı");
            }
        }

        public decimal CalculateTotalPrice()
        {
            decimal total = 0;
            foreach (var product in _products)
            {
                total += product.CalculatePrice();
            }
            return total;
        }
        public int CalculateTotalPreparationTime()
        {
            int totalTime = 0;
            foreach (var product in _products)
            {
                totalTime += product.CalculatePreparationTime();
            }
            return totalTime;

        }
        public void PrintReceipt()
        {
            Console.WriteLine("************ Sipariş Fişi ************");

            foreach (var product in _products)
            {
                Console.WriteLine($"{product.Name} - {product.CalculatePrice():C} - Hazırlık Süresi: {product.CalculatePreparationTime()} dakika");
            }
            Console.WriteLine("\n**************************************");
            Console.WriteLine($"Toplam Sipariş Tutarı : {CalculateTotalPrice()} Tl");
            Console.WriteLine($"Tahmini Hazırlık süresi {CalculateTotalPreparationTime()} Dakika");
            Console.WriteLine("**************************************\n");
        }
    }
}