using ConsoleGame.Data;
using ConsoleGame.Entities.Data;
using System.Text.Json;
namespace ConsoleGame.Utilities;
public class JsonUtil
{
    public static EntityData JsonToEntityData(string jsonString)
    {
        Console.WriteLine(jsonString);
        EntityData? data = JsonSerializer.Deserialize<EntityData>(jsonString);
        if (data != null) return (EntityData)data;
        
        return EntityData.empty;
    }
}