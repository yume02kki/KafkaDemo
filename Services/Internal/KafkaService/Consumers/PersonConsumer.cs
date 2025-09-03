using System.Text.Json;
using Confluent.Kafka;
using PersonSender.Kafka;

public class PersonConsumer
{
    private readonly ConsumerBuilder<string, string> consumerBuilder;

    public PersonConsumer()
    {
        consumerBuilder = new ConsumerBuilder<string, string>(KafkaConfig.ConsumerConfig);
    }

    public void Start(string topicName, Action<Person> eventHook)
    {
        using var consumer = consumerBuilder.Build();
        consumer.Subscribe(topicName);
        while (true)
            try
            {
                var result = consumer.Consume();
                var person = JsonSerializer.Deserialize<Person>(result.Message.Value);
                eventHook(person);
            }

            catch (ConsumeException)
            {
            }
    }
}