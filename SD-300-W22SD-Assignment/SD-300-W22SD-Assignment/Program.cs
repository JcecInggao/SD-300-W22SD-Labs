using System.Text;
// Question 1

// the first int represents the value of a coin
// the second int represents the amount of coins available
Dictionary<int, int> vendingMachine = new Dictionary<int, int>();

// vending machine inventory
vendingMachine.Add(20, 0); // 1 $20 coins
vendingMachine.Add(10, 2); // 2 $10 coins
vendingMachine.Add(5, 0); // 3 $5 coins
vendingMachine.Add(2, 5); // 5 $2 coins
vendingMachine.Add(1, 8); // 8 $1 coins

/*
 * this function accepts a dictionary for coin values, an int representing a units price, and an int representing the users payment
 * this function then compares the unit price and user payment, to check for change
 * if the userPayment results in change, the function "CalculateCoins" will be called
 * CalculateCoins will accept the dictionary for coin types and coin amounts and will check the change\
 * after the coins are displayed from the CalculateCoins function, this function will also display the users total change
 * otherwise "No change" or "Insufficient payment" will be returned
 */
string Vending(Dictionary<int, int> machine, int unitPrice, int userPayment)
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
        return "No change";
    }
    else
    {
        // user does not get item
        return "Insufficient payment";
    }
}

/*
* this function is called when the userPayment exceeds the unitPrice
* this function will accept a dictionary from the vending machine being used, and the change from the Vending function
* a foreach loop is called to check every individual coin type in the called Dictionary
* the loop will display a message stating which coin type is "dispensed" and how many pieces are "dispensed"
*/
void CalculateCoins(Dictionary<int, int> machine, int totalChange)
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

VendingMachine machine1 = new VendingMachine();
Product kitKat = new Product("KitKat", 2, "A1");
Console.WriteLine(machine1.StockItem(kitKat, 12));
Console.WriteLine(machine1.StockFloat(1, 10));

public class VendingMachine
{
    public int SerialNumber { get; set; }
    public Dictionary<int, int> MoneyFloat { get; set; }
    public Dictionary<Product, int> Inventory { get; set; }

    public VendingMachine ()
	{

	}

    public void StockItem(Product product, int quantity)
    {
        Inventory.Add(product, quantity);
        foreach (Product items in product)
	    {
            Console.WriteLine($"Product:{items.Name} Code:{items.Code} Price: ${items.Price} Quantity:{quantity}");
	    }
    }

    public string StockFloat(int moneyDenomination, int quantity)
    {
        MoneyFloat.Add(moneyDenomination, quantity);
        foreach (Dictionary<int, int> items in MoneyFloat)
	    {
            Console.WriteLine($"${items.Name} Code:{items.Code} Price: ${items.Price} Quantity:{quantity}");
	    }
    }

    public void VendItem(string code, List<int> money)
    {

    }
}

public class Product
{
    public string Name { get; set; }
    public int Price { get; set; }
    public string Code { get; set; }

    public Product (string name, int price, string code)
	{
        Name = name;
        Price = price;
        Code = code;
	}
}
