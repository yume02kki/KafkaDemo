using System.Text.Json;
using Confluent.Kafka;
using PersonSender.Kafka;

public class PersonConsumer
{
    public void Start(Action<Person> eventHook)
    {
        using (var consumer = new ConsumerBuilder<Ignore, string>(KafkaConfig.ConsumerConfig).Build())
        {
            consumer.Subscribe(KafkaConfig.TopicConfig.Name);

            var consumerTokenSource = new CancellationTokenSource();
            Console.CancelKeyPress += (_, e) =>
            {
                e.Cancel = true;
                consumerTokenSource.Cancel();
            };
            try
            {
                while (true)
                {
                    var consumeResult = consumer.Consume(consumerTokenSource.Token);
                    eventHook(JsonSerializer.Deserialize<Person>(consumeResult.Message.Value));
                    consumer.Commit(consumeResult);
                }
            }
            catch (OperationCanceledException)
            {
                consumer.Close();
            }
        }
    }
}