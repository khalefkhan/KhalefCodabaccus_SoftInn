using System.Threading.Tasks;

namespace TechnicalAssesmentBackendDeveloper;

class Booking
{
    public string Guestname { get; private set; } =string.Empty;
    public string RoomNumber{ get; private set; } =string.Empty;
    public DateTime CheckinDate {get; private set;}
    public DateTime CheckoutDate {get; private set;}
    public int TotalDays{get; private set;}
    public double RatePerDay{get; private set;}
    public double Discount{get; private set;}
    public double TotalAmount{get; private set;}

    public async Task BookRoom(string name, string room, DateTime checkin, DateTime checkout, double rate, double discountRate)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name is required.", nameof(name));
        if (string.IsNullOrWhiteSpace(room)) throw new ArgumentException("Room is required.", nameof(room));
        if (checkout < checkin) throw new ArgumentException("Check-out must be after check-in.");
        if (rate < 0) throw new ArgumentOutOfRangeException(nameof(rate));
        if (discountRate < 0) throw new ArgumentOutOfRangeException(nameof(discountRate));

        Guestname = name;
        RoomNumber = room;
        CheckinDate = checkin;
        CheckoutDate = checkout;
        RatePerDay = rate;
        Discount = discountRate;

        TotalDays = (checkout - checkin).Days;
        TotalAmount = TotalDays * RatePerDay;
        TotalAmount = TotalAmount - (TotalAmount * Discount / 100);

        await LogBookingDetailsAsync();

        Console.WriteLine("Room Booked for " + Guestname);
        Console.WriteLine("Room No: " + RoomNumber);
        Console.WriteLine("Check-In: " + CheckinDate.ToString());
        Console.WriteLine("Check-Out: " + CheckoutDate.ToString());
        Console.WriteLine("Total Days: " + TotalDays);
        Console.WriteLine("Amount: " + TotalAmount);
    } 

    public async Task LogBookingDetailsAsync()
    {
        // Simulate writing to a log file or remote system
        await Task.Delay(1000);
        Console.WriteLine("Booking log saved.");
    }

    public void Cancel()
    {
        Guestname = string.Empty;
        RoomNumber = string.Empty;
        CheckinDate = DateTime.MinValue;
        CheckoutDate = DateTime.MinValue;
        RatePerDay = 0;
        Discount = 0;
        TotalDays = 0;
        TotalAmount = 0;

        Console.WriteLine("Booking cancelled");
    }
}

public static class AppHost
{
    static async Task Run(string[] args)
    {
        Booking b = new Booking();
        await b.BookRoom("Alice", "101", DateTime.Now, DateTime.Now.AddDays(3), 150.5, 10);
        b.Cancel();
    }
}