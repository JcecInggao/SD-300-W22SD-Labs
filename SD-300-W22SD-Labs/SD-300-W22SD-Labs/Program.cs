using System.Text;
Product kitkat = new Product("KitKat", 1, "A1");
VendingMachine.StockItem(kitkat, 5);
VendingMachine.StockFloat(10, 5);

static class VendingMachine
{
    // Properties
    public static int SerialNumber { get; set; } = 1;
    private static Dictionary<int, int> _moneyFloat { get; set; }
    private static Dictionary<Product, int> _inventory { get; set; }
    private static readonly string? _barcode;
    
    // Constructor
    static VendingMachine()
    {
        SerialNumber++;
        _barcode = "";
    }


    // Methods
    public static string StockItem(Product product, int quantity)
    {
        _inventory.Add(product, quantity);
        return product.Name;
    }

    public static string StockFloat(int moneyDenomination, int quantity)
    {
        _moneyFloat.Add(moneyDenomination, quantity);
        string floatString = "";
        foreach (KeyValuePair<int,int> mf in _moneyFloat)
        {
            Console.WriteLine("${0} coins: {1}", mf.Key, mf.Value);
        }

        return floatString;
    }
}

public class Product
{
    public string Name { get; set; }
    public int Price { get; set; }
    public string Code { get; set; }
    
    public Product(string name, int price, string code)
    {
        Name = name;
        Price = price;
        Code = code;
    }
}