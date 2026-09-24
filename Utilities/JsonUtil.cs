using ConsoleGame.Data;
using ConsoleGame.Entities.Data;
using System.Data;
using System.Text.Json;
namespace ConsoleGame.Utilities;
public class JsonUtil
{
    public static EntityData JsonToEntityData(string jsonString)
    {
        
        EntityData? data = JsonSerializer.Deserialize<EntityData>(jsonString);
        if (data != null) return (EntityData)data;
        
        return EntityData.Empty;
    }

    public static DamageData JsonToDamageData(string jsonString)
    {
        DamageData? data = JsonSerializer.Deserialize<DamageData>(jsonString);
        if (data != null) return (DamageData)data;

        return DamageData.Empty;    
    }
}