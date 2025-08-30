using System.Text.Json;
using System.Text.Json.Nodes;
using Confluent.Kafka;

namespace PersonSender;

public class Producer<Ttype>
{
    public string StrKey { get; set; }
    public Ttype Payload { get; private set; }

    public Producer(string strKey, Ttype payload)
    {
        this.StrKey = strKey;
        this.Payload = payload;
    }

    public void Send()
    {
        StrKey = this.StrKey;
        using var producer = new ProducerBuilder<string, string>(ConfigData.Config).Build();
        producer.Produce("person-topic", new Message<string, string>
        {
            Key = StrKey,
            Value = JsonEdit.Serialize(Payload)
        });

        producer.Flush();
    }
}