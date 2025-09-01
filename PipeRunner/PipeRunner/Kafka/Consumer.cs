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
        
        var dbConnection = new DBconnection(ConfigData.ConnectionStr);
        using var consumer = new ConsumerBuilder<string, string>(ConfigData.ConsumerConfig).Build();

        consumer.Subscribe(topicName);
        while (true)
        {
            var result = consumer.Consume();
            if (result != null)
            {
                var personGot = JsonEdit.Deserialize<Person>(result.Message.Value);
                dbConnection.Insert(personGot.Address, "Address"); 
                dbConnection.Insert(personGot, "PERSON","Address",personGot.Address.Id.Value); 
            }
        }
    }
}