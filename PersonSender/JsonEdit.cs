using System.Text.Json;

namespace PersonSender;

public static class JsonEdit
{
    public static string Serialize<T>(T obj) => JsonSerializer.Serialize(obj);
    public static T Deserialize<T>(string json) => JsonSerializer.Deserialize<T>(json)!;
}