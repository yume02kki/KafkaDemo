using Confluent.Kafka;

namespace PersonSender.Kafka;

public static class KafkaConfig
{
    public static readonly string Host = "localhost:9092";
    public static string Topic { get; private set; } = "person-topic";

    public static ConsumerConfig ConsumerConfig { get; private set; } = new()
    {
        AutoOffsetReset = AutoOffsetReset.Earliest,
        EnableAutoCommit = true,
        BootstrapServers = Host,
        GroupId = "consumer-group"
    };

    public static ProducerConfig ProducerConfig { get; private set; } = new()
    {
        BootstrapServers = Host,
        ClientId = "producer-client"
    };
}