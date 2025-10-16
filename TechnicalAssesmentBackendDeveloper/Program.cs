using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Item Manager!");

        ItemManager manager = new ItemManager();

        // Part One: Fix the NullReferenceException
        // This will throw a NullReferenceException
        manager.AddItem("Apple");
        manager.AddItem("Banana");

        manager.PrintAllItems();

        // Part Two: Implement the RemoveItem method
        manager.RemoveItem("Apple");
        manager.PrintAllItems();  //  Print remaining items after removal

        // Part Three: Introduce a Fruit class and use the ItemManager<Fruit> to add a few fruits and print them on the console.
        // TODO: Implement this part three.
        var fruitManager = new ItemManager<Fruit>();
        fruitManager.AddItem(new Fruit("Apple",  "Red"));
        fruitManager.AddItem(new Fruit("Banana", "Yellow"));
        fruitManager.AddItem(new Fruit("Grape",  "Purple"));

        Console.WriteLine("\nFruits:");
        fruitManager.PrintAllItems();


        // Part Four (Bonus): Implement an interface IItemManager and make ItemManager implement it.
        // TODO: Implement this part four.
    }
}

public class ItemManager
{
    private readonly List<string> items= new(); //fixed by initialising the list

    public void AddItem(string item)
    {
        items.Add(item);
    }

    public void PrintAllItems()
    {
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    // Part Two: Implement the RemoveItem method
    // TODO: Implement this method
    public void RemoveItem(string item) //Fixed Part 2: Implemented the RemoveItem Method
    {
        if (string.IsNullOrWhiteSpace(item))
        {
            Console.WriteLine("Invalid item name.");
            return;
        }
        if (items.Contains(item))
        {
            items.Remove(item);
            Console.WriteLine($"{item} removed successfully.");
        }
        else
        {
            Console.WriteLine($"{item} not found in the list.");
        }
        
    }

    public void ClearAllItems()
    {
        items.Clear();
    }
}

public class ItemManager<T>
{
    private readonly List<T> items = new();

    public void AddItem(T item)
    {
        items.Add(item);
    }

    public void PrintAllItems()
    {
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    public void ClearAllItems()
    {
        items.Clear();
    }
}
public sealed class Fruit
{
    public string Name { get; set; }
    public string Color { get; set; }

    public Fruit(string name, string color)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Color = color ?? throw new ArgumentNullException(nameof(color));
    }
    public override string ToString() => $"{Name} ({Color})";
}