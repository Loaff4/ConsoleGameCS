using System.Collections.ObjectModel;

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
}