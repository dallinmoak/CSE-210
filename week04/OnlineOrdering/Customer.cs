class Customer
{
  private string _name;
  private Address _address;
  public Customer(string name, Address address)
  {
    this._name = name;
    this._address = address;
  }

  public string DetailsToString()
  {
    string NameData = $"Name: {this._name}";
    string AddressData = $"Address:\n{this._address.DetailsToString()}";
    return $"{NameData}\n  {AddressData}";
  }

  public bool isDomestic()
  {
    return this._address.GetCountry() == "USA";
  }
}