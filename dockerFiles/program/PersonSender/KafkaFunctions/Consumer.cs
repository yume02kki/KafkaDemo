using Confluent.Kafka;
using PersonSender.Kafka;
using PersonSender.KafkaFunctions;

namespace PersonSender;

public class Consumer : KafkaObject
{

    public Consumer(string topicName) : base(topicName)
    {
    }

    public void Start()
    {
        using var consumer = new ConsumerBuilder<string, string>(ConfigData.ConsumerConfig).Build();
        consumer.Subscribe(topicName);
        while (true)
        {
            var result = consumer.Consume(TimeSpan.FromSeconds(1));

            if (result != null)
            {
                Console.WriteLine($"Key: {result.Message.Key}, Value: {result.Message.Value}");
                consumer.Commit(result);
            }
        }
    }
}