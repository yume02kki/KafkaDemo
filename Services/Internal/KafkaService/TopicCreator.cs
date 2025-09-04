using Confluent.Kafka;
using Confluent.Kafka.Admin;
using PersonSender.Kafka;

public class TopicCreator
{
    public static async Task Create()
    {
        try
        {
            using var admin = new AdminClientBuilder(new AdminClientConfig { BootstrapServers = KafkaConfig.Host })
                .Build();

            await admin.CreateTopicsAsync(new[] { KafkaConfig.TopicConfig });
        }
        catch (CreateTopicsException)
        {
        }
    }
}