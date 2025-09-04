using Confluent.Kafka;
using Confluent.Kafka.Admin;

namespace PersonSender.Kafka;

public static class KafkaConfig
{
    public static readonly string Host = "localhost:9092";

    public static ConsumerConfig ConsumerConfig { get; private set; } = new()
    {
        AutoOffsetReset = AutoOffsetReset.Earliest,
        EnableAutoCommit = true,
        BootstrapServers = Host,
        GroupId = "consumer-group"
    };

    public static TopicSpecification TopicConfig { get; private set; } = new()
    {
        Name = "persons-topic",
        NumPartitions = 1,
        ReplicationFactor = 1
    };

    public static ProducerConfig ProducerConfig { get; private set; } = new()
    {
        BootstrapServers = Host,
        ClientId = "producer-client"
    };
}