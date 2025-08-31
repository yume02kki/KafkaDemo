using System.Text.Json;

namespace PersonSender;

public class JsonEdit
{
    public static string Serialize<T>(T obj)
    {
        return JsonSerializer.Serialize(obj);
    }

    public static T Deserialize<T>(string json)
    {
        return JsonSerializer.Deserialize<T>(json)!;
    }
}