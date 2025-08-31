namespace PersonSender.KafkaFunctions;

public abstract class KafkaObject
{
    protected string topicName;

    protected KafkaObject(string topicName)
    {
        this.topicName = topicName;
    }
}