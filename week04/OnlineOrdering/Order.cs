class Order
{
  private Customer _customer;
  private double _subtotal;
  private bool _isDomestic;
  private double _shippingCost;
  public record Item(Product product, int count);
  private List<Item> _items;

  public Order(Customer customer, List<Item> items)
  {
    this._customer = customer;
    this._items = items;
    double subtotal = 0;
    foreach (var item in this._items)
    {
      subtotal += item.product.GetPrice(count: item.count);
    }
    this._subtotal = subtotal;
    this._isDomestic = this._customer.isDomestic();
    if (this._isDomestic)
    {
      this._shippingCost = 5.0;
    }
    else
    {
      this._shippingCost = 35.0;
    }
  }

  private double _getTotal()
  {
    return this._subtotal + this._shippingCost;
  }

  private string _ItemDetailsToString()
  {
    string result = "";
    foreach (var item in this._items)
    {
      string ProductData = $"{item.product.DetailsToString(count: item.count)}";
      result += $"  {ProductData}\n";
    }
    result += $"  Subtotal: ${this._subtotal:0.00}";
    return result;
  }

  public string DetailsToString()
  {
    string CustomerData = $"Customer:\n  {this._customer.DetailsToString()}";
    string ItemsData = $"Items:\n{this._ItemDetailsToString()}";
    string ShippingData = $"{(this._isDomestic ? "Domestic" : "Foreign")} shipping: ${this._shippingCost:0.00}";
    string TotalData = $"Total: ${this._getTotal():0.00}";
    return $"Order summary:\n{CustomerData}\n{ItemsData}\n{ShippingData}\n{TotalData}";

  }
}