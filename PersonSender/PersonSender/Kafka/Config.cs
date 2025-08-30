using Confluent.Kafka;

namespace PersonSender;

public class ConfigData
{
    public static Config Config { get; private set; } = new ProducerConfig { BootstrapServers = "localhost:9092" };
}