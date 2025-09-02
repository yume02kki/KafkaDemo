using Confluent.Kafka;

namespace PersonSender.Kafka;

public static class KafkaConfig
{
    private static readonly string Host = "localhost:9092";
    public static string Topic { get; private set; } = "person-topic";
    
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