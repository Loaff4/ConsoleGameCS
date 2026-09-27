using ConsoleGame.Entities.Data;
using System.Text.Json;
namespace ConsoleGame.Utilities;
public class JsonUtil
{

    private static JsonSerializerOptions options = new JsonSerializerOptions
    {
        PropertyNamingPolicy = JsonNamingPolicy.KebabCaseLower
    };
    
    public static string ReadJson(string url)
    {
        try
        {
            string jsonString = File.ReadAllText(url);
            return jsonString;

        } catch (DirectoryNotFoundException)
        {
            Console.WriteLine($"[ERROR] Failed to read json. Directory does not exist for url: '{url}");
        } catch (FileNotFoundException)
        {
            Console.WriteLine($"[ERROR] Failed to read json. File does not exist for url: '{url}");
        } catch (Exception ex)
        {
            Console.WriteLine($"[ERROR] Failed to read json at {url}. {ex.Message}");
        } 
        return "";
    }

    public static EntityData JsonToEntityData(string jsonString)
    {

        if (string.IsNullOrEmpty(jsonString))
        {
            Console.WriteLine("[ERROR] Cannot serialize empty or null string.");
            return EntityData.Empty;
        }
        
        EntityData? data = JsonSerializer.Deserialize<EntityData>(jsonString, options);
        if (data != null) return (EntityData)data;
        
        return EntityData.Empty;
    }

    public static DamageData JsonToDamageData(string jsonString)
    {
        if (string.IsNullOrEmpty(jsonString))
        {
            Console.WriteLine("[ERROR] Cannot serialize empty or null string.");
            return DamageData.Empty;
        }
        
        
        DamageData? data = JsonSerializer.Deserialize<DamageData>(jsonString, options);
        if (data != null) return (DamageData)data;

        return DamageData.Empty;    
    }
}