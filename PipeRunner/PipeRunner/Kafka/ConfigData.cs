using Confluent.Kafka;

namespace PersonSender.Kafka;

public static class ConfigData
{
    private static readonly string Host = "localhost:9092";

    public static string ConnectionStr { get; private set; } =
        "Data Source=localhost:1521/XEPDB1;User Id=PROJECT;Password=1;";

    public static string topic { get; private set; } = "person-topic";

    public static ConsumerConfig ConsumerConfig { get; private set; } = new ConsumerConfig
    {
        BootstrapServers = Host,
        GroupId = "cs-consumer-group",
    };

    public static ProducerConfig ProducerConfig { get; private set; } = new ProducerConfig
    {
        BootstrapServers = Host,
        ClientId = "cs-producer-client"
    };
}