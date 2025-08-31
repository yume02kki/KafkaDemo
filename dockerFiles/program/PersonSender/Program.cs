using System;
using System.Threading.Tasks;
using Confluent.Kafka;
using PersonSender;


class Program
{
    static void Main()
    {
        const string topic = "person-topic";
        Console.Write("Produce : 1 | Consume: 2\n > ");
        switch (Console.ReadLine())
        {
            case "1":
                Person person = new Person();
                person.FirstName = "John";
                person.LastName = "Clements";
                Producer<Person> producer = new(topic);
                producer.Send("p1", person);
                break;
            case "2":
                Consumer consumer = new Consumer(topic);
                consumer.Start();
                break;
        }
    }
}