class Product
{
  private string _name;
  private int _id;
  private double _unitPrice;
  public Product(string name, int id, double unitPrice)
  {
    this._name = name;
    this._id = id;
    this._unitPrice = unitPrice;
  }

  public string DetailsToString(int count = 1)
  {
    return $"{this._name} (ID: {this._id}) - ${this._unitPrice:0.00} x {count} = ${this.GetPrice(count: count):0.00}";
  }

  public double GetPrice(int count = 1)
  {
    return this._unitPrice * count;
  }
}