using System.ComponentModel;
using System.Text.Json;
using Confluent.Kafka;
using PersonSender.Kafka;

public class PersonConsumer
{
    private ConsumerBuilder<string, string> consumerBuilder;
    public PersonConsumer()
    {
        this.consumerBuilder = new ConsumerBuilder<string, string>(KafkaConfig.ConsumerConfig);
    }

    public Person? Start(string topicName)
    {
        using var consumer = consumerBuilder.Build();
        consumer.Subscribe(topicName);
        try
        {
            var result = consumer.Consume();
            if (result?.Message?.Value != null)
            {
                return JsonSerializer.Deserialize<Person>(result.Message.Value);
            }
        }
        catch (ConsumeException)
        {
        }
        return null;
    }
}