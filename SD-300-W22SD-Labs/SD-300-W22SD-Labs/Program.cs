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
        if (_barcode == null)
        {
            throw new Exception("Barcode cannot be null");
        }
        _barcode = _barcode;
    }

    // Methods
    public static string StockItem(Product product, int quantity)
    {
        if (quantity < 0)
        {
            throw new Exception("quantity cannot be negative");
        }

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

        public static void CalculateCoins(Dictionary<int, int> machine, int totalChange)
    {
        int change = totalChange;

        foreach (KeyValuePair<int, int> coin in machine)
        {
            int usersCoins = 0;
            int coinKey = coin.Key;
            int coinsLeft = coin.Value;

            // if the change is greater than the coin type, it will take a coin
            if (coinKey <= change)
            {
                // will take away a coin until the coin is to big for the current change
                // aka: while change is greater than coin type
                if (coinsLeft > 0)
                {
                    while (change >= coinKey)
                    {
                        if (coinsLeft > 0)
                        {
                            change = change - coinKey;
                            coinsLeft = coinsLeft - 1;
                            usersCoins++;
                        }
                    }
                    // grammatical fixing; pieces and piece when appropriate
                    Console.WriteLine($"${coinKey}: {usersCoins} {(usersCoins > 1 ? "pieces" : "piece")}");
                }
            }
        }
    }

    public static string VendItem(Dictionary<int, int> machine, int unitPrice, int userPayment)
    {
        if (userPayment > unitPrice)
        {
            // user pays more than price
            // user receives change

            // find total change
            int change = userPayment - unitPrice;
            CalculateCoins(machine, change);

            return $"Total change: ${change}";
        }
        else if (userPayment == unitPrice)
        {
            // user gets no change
            throw new Exception("No change");
        }
        else
        {
            // user does not get item
            return new Exception("Insufficient payment");
        }
    }
}

public class Product
{
    public string Name { get; set; }
    public int Price { get; set; }
    public string Code { get; set; }
    
    public Product(string name, int price, string code)
    {
        if (name == null)
        {
            throw new Exception("Error: product name is null");
        } 
        else if (price < 0)
        {
            throw new Exception("Error: product price is invalid; negative value");
        }
        else if (code == null)
        {
            throw new Exception("Error: product code is null");
        }

        Name = name;
        Price = price;
        Code = code;
    }
}