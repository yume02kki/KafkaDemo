using System;
using System.Threading.Tasks;
using Confluent.Kafka;
using PersonSender;


class Program
{
    static void Main()
    {
        var johnClements = new Person
        {
            Id = Guid.NewGuid(),
            FirstName = "John",
            LastName = "Clements",
            Email = "john.clements@example.com",
            Phone = "+1-555-987-6543",
            BirthDateUtc = new DateTime(1985, 3, 14),
            Gender = Gender.Male,
            Status = PersonStatus.Insert,
            Address = new Address
            {
                Country = "USA",
                City = "Metropolis",
                Street = "Elm Street",
                HouseNumber = "456",
                PostalCode = "10001"
            }
        };
        const string topic = "person-topic";
        Console.Write("Produce : 1 | Consume: 2\n > ");
        switch (Console.ReadLine())
        {
            case "1":
                Producer<Person> producer = new(topic);
                producer.Send("p1", johnClements);
                break;
            case "2":
                Consumer consumer = new Consumer(topic);
                consumer.Start();
                break;
        }
    }
}