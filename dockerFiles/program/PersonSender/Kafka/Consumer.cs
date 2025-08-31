using System.Text.Json;
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
        const string connectionStr = "Data Source=localhost:1521/XE;User Id=PROJECT_SCHEMA;Password=1;";
        DBconnection db_connection = new DBconnection(connectionStr);
        using var consumer = new ConsumerBuilder<string, string>(ConfigData.ConsumerConfig).Build();
        consumer.Subscribe(topicName);
        while (true)
        {
            var result = consumer.Consume(TimeSpan.FromSeconds(1));

            if (result != null)
            {
                try
                {
                    Person personGot = JsonEdit.Deserialize<Person>(result.Message.Value);
                    Console.WriteLine("person: " + personGot.FirstName + " " + personGot.LastName);
                    db_connection.insert(personGot);
                    consumer.Commit(result);
                }
                catch (JsonException exception)
                {
                }
            }
        }
    }
}