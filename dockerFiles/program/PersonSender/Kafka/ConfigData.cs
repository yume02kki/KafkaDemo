using Confluent.Kafka;

namespace PersonSender.Kafka;

public static class ConfigData
{
    private static string Host = "localhost:9092";
    
    public static ConsumerConfig ConsumerConfig { get; private set; } = new ConsumerConfig
    {
        BootstrapServers = Host,
        GroupId = "cs-consumer-grouper",
        EnableAutoCommit = false,
        AutoOffsetReset = AutoOffsetReset.Earliest 
    };

    public static ProducerConfig ProducerConfig { get; private set; } = new ProducerConfig
    {
        BootstrapServers = Host,
        ClientId = "cs-id",
    };
}