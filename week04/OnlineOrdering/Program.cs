using System;

class Program
{
  static void Main(string[] args)
  {
    List<Product> allProducts = new List<Product>
    {
      new Product("Apple", 0, 0.5),
      new Product("Banana", 1, 0.3),
      new Product("Orange", 2, 0.4),
      new Product("Grapes", 3, 2.0),
      new Product("Mango", 4, 1.5),
      new Product("Pineapple", 5, 3.0)
    };

    Customer c1 = new Customer(
      "John Doe",
      new Address(
        "123 Main St",
        "Springfield",
        "IL",
        "USA"
      )
    );
    Customer c2 = new Customer(
      "Jane Smith",
      new Address(
        "456 Elm St",
        "Springfield",
        "IL",
        "USA"
      )
    );
    Customer c3 = new Customer(
      "Bob Johnson",
      new Address(
        "Calle Garcia 123",
        "Ciudad de Mexico",
        "CDMX",
        "MX"
      )
    );

    List<Order> allOrders = new List<Order>();
    allOrders.Add(new Order(
      c1,
      new List<Order.Item>()
      {
        new Order.Item(allProducts[0], 2),
        new Order.Item(allProducts[1], 3),
        new Order.Item(allProducts[2], 1)
      }
    ));
    allOrders.Add(new Order(
      c2,
      new List<Order.Item>()
      {
        new Order.Item(allProducts[3], 1),
        new Order.Item(allProducts[4], 2)
      }
    ));
    allOrders.Add(new Order(
      c3,
      new List<Order.Item>()
      {
        new Order.Item(allProducts[5], 1),
        new Order.Item(allProducts[0], 5)
      }
    ));

    foreach (Order o in allOrders)
    {
      Console.Write($"{o.DetailsToString()}\n");
      Console.Write("-------------------\n");
    }
  }

}