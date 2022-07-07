 class Hotel
{
    public string Name { get; set; }
    public string Address { get; set; }
    public static List<Client> Clients { get; set; } = new List<Client>();
    public static List<Room> Rooms { get; set; } = new List<Room>();
    public static List<Reservation> Reservations { get; set; } = new List<Reservation>();
}

class Room
{
    public string Number { get; set; }
    public int Capacity { get; set; }
    public bool Occupied { get; set; }
    public List<Reservation> Reservations { get; set; }

    public Room(string number, int capacity)
    {
        Number = number;
        Capacity = capacity;
        Occupied = false;
        Reservations = new List<Reservation>();
    }
}

class Client
{
    public string Name { get; set; }
    public long CreditCard { get; set; }
    public List<Reservation> Reservations { get; set; }

    public Client()
    {
        Reservations = new List<Reservation>();
    }

    public Client(string name)
    {
        Name = name;
        Reservations = new List<Reservation>();
    }

    public Client(string name, int creditCard)
    {
        Name = name;
        CreditCard = creditCard;
        Reservations = new List<Reservation>();
    }
}

class Reservation
{
    public DateTime Date { get; set; }
    public int Occupants { get; set; }
    public bool IsCurrent { get; set; }
    public Client Client { get; set; }
    public Room Room { get; set; }

    public Reservation(DateTime date, int occupants, bool isCurrent, Client client, Room room)
    {
        Date = date;
        Occupants = occupants;
        IsCurrent = isCurrent;
        Client = client;
        Room = room;
    }
}

