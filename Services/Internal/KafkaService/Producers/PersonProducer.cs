using System.Text.Json;
using Confluent.Kafka;
using PersonSender.Kafka;

public class Producer
{
    private ProducerBuilder<string, string> producerBuilder;
    public Producer()
    {
        this.producerBuilder = new ProducerBuilder<string, string>(KafkaConfig.ProducerConfig);
    }

    public void Send(string topicName, string key, Person payload)
    {
        using var producer = producerBuilder.Build();
        try
        {
            var message = new Message<string, string>
            {
                Key = key,
                Value = JsonSerializer.Serialize(payload)
            };
            producer.Produce(topicName, message);
            producer.Flush();
        }
        catch (ProduceException<string, string>)
        {
        }

    }
}