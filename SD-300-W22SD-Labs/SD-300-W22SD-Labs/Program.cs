using System.Text;
try
{
    Product kitkat = new Product("KitKat", 1, "A1");
    VendingMachine.StockItem(kitkat, 5);
    VendingMachine.StockFloat(10, 5);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    throw;
}

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
        try
        {
            Name = name;
            Price = price;
            Code = code;
        }
        catch (Exception) when (name == null)
        {
            Console.WriteLine("Name is null");
            throw;
        }
        catch (Exception) when (price < 0)
        {
            Console.WriteLine("Price is invalid");
            throw;
        }
        catch (Exception) when (code == null)
        {
            Console.WriteLine("code is null");
            throw;
        }
    }
}