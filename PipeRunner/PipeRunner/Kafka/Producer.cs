using System.Text.Json;
using Confluent.Kafka;
using PersonSender.Kafka;
using PersonSender.KafkaFunctions;

namespace PersonSender;

public class Producer<TValue> : KafkaObject
{
    public Producer(string topicName) : base(topicName)
    {
    }

    public void Send(string key, TValue payload)
    {
        using var producer = new ProducerBuilder<string, string>(ConfigData.ProducerConfig).Build();
        var message = new Message<string, string>
        {
            Key = key,
            Value = JsonSerializer.Serialize(payload)
        };
        producer.Produce(topicName, message);
        producer.Flush();
    }
}