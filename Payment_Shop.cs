using System;
using static System.Console;

namespace Project
{
    // Categories of articles (products)
    enum ArticleType
    {
        Electronics,
        Fashion,
        HomeGoods,
        Food,
        Other
    }

    // Structure for an Article (Product)
    struct Article
    {
        public string Code;
        public string Name;
        public decimal Price;
        public ArticleType Type;

        // Constructor
        public Article(string code, string name, decimal price, ArticleType type)
        {
            Code = code;
            Name = name;
            Price = price;
            Type = type;
        }

        // Display article information
        public void ShowInfo()
        {
            WriteLine($"Code: {Code}, Name: {Name}, Price: {Price}$, Type: {Type}");
        }
    }

    // Types of clients
    enum ClientType
    {
        Basic,
        Medium,
        VIP
    }

    // Structure for a Client
    struct Client
    {
        public string Code;
        public string Name;
        public string Address;
        public string Phone;
        public int OrderCount;
        public int TotalSpent;
        public ClientType Type;

        // Constructor
        public Client(string code, string name, string address, string phone, int orderCount, int totalSpent, ClientType type)
        {
            Code = code;
            Name = name;
            Address = address;
            Phone = phone;
            OrderCount = orderCount;
            TotalSpent = totalSpent;
            Type = type;
        }

        // Display client information
        public void ShowInfo()
        {
            WriteLine($"Code: {Code}, Name: {Name}, Address: {Address}, Phone: {Phone}, Orders: {OrderCount}, Total Spent: {TotalSpent}$, Type: {Type}");
        }
    }

    // Structure for an item in a request 
    struct RequestItem
    {
        public Article Article;
        public int Quantity;

        // Constructor
        public RequestItem(Article article, int quantity)
        {
            Article = article;
            Quantity = quantity;
        }

        // Display request item information
        public void ShowInfo()
        {
            WriteLine($"Article: {Article.Name}, Quantity: {Quantity}");
        }
    }

    // Payment methods
    enum PayType
    {
        Cash,
        Card,
        Online
    }

    // Structure for a Request
    struct Request
    {
        public string Code;
        public Client Client;
        public DateTime Date;
        public RequestItem[] Items;
        public PayType PaymentMethod;

        // Constructor
        public Request(string code, Client client, DateTime date, RequestItem[] items, PayType paymentMethod)
        {
            Code = code;
            Client = client;
            Date = date;
            Items = items;
            PaymentMethod = paymentMethod;
        }

        // Calculate total order cost
        public decimal GetTotalCost()
        {
            decimal total = 0;
            foreach (var item in Items)
            {
                total += item.Article.Price * item.Quantity;
            }
            return total;
        }

        // Display order information
        public void ShowInfo()
        {
            WriteLine($"Order Code: {Code}, Client: {Client.Name}, Date: {Date}, Payment: {PaymentMethod}");
            foreach (var item in Items)
            {
                item.ShowInfo();
            }
            WriteLine($"Total Cost: {GetTotalCost()}$");
        }
    }

    // Main class where the program starts
    class Program
    {
        static void Main()
        {
            // Create an article (product)
            Article article1 = new Article("Code15", "iPhone", 1500, ArticleType.Electronics);
            article1.ShowInfo();

            // Create a client
            Client client1 = new Client("C455", "John Doe", "123 Main St", "1234567890", 10, 1000, ClientType.Medium);
            client1.ShowInfo();

            // Create a request item (client orders 2 iPhones)
            RequestItem item1 = new RequestItem(article1, 2);
            item1.ShowInfo();

            // Create a request (order)
            Request request1 = new Request("R1", client1, DateTime.Now, new RequestItem[] { item1 }, PayType.Card);
            request1.ShowInfo();
        }
    }
}