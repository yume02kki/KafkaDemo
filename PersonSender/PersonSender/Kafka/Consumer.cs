using Confluent.Kafka;
using PersonSender;

public class Consumer
{
    public void get()
    {
        using var consumer = new ConsumerBuilder<string, string>(ConfigData.Config).Build();
        consumer.Subscribe("person-topic");

        while (true)
        {
            var result = consumer.Consume();
            Console.WriteLine($"Key: {result.Message.Key}, Value: {result.Message.Value}");
        }
    }
}