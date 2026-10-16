using ConsoleGame.Items;
namespace ConsoleGame.Utilities;

public class CollectionUtil
{
    
    public static bool ValueExistsInCollection<T>(T value, ICollection<T> collection)
    {
        if (value == null) return false;
        foreach(T element in collection)
        {
            if (value.Equals(element))
            {
                return true;
            }
        }
        return false;
    }

    public static void PrintItemList(List<Item> itemList)
    {
        Console.WriteLine("--");
        if (itemList.Count == 0)
        {
            Console.WriteLine("Empty!");
            Console.WriteLine("--\n");
            return;
        }

        int number = 1;
        
        foreach(Item item in itemList)
        {
            Console.WriteLine($"{number}. {item.Name}");
            number++;
        }
        
        Console.WriteLine("--\n");
    }
}