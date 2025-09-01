using PersonSender;
using PersonSender.Kafka;

class Program
{
    public static void Main(string[] args)
    {
        var person = new Person
        {
            Id = Guid.NewGuid(),
            FirstName = "Jlpi",
            LastName = "Clements",
            Email = "john.clements@example.com",
            Phone = "555-987-6543",
            BirthDateUtc = new DateTime(2000, 3, 14),
            Gender = Gender.Male,
            Address = new Address
            {
                Id = Guid.NewGuid(),
                Country = "USA",
                City = "Metropolis",
                Street = "Elm Street",
                HouseNumber = "456",
                PostalCode = "10001"
            },
            Status = PersonStatus.Insert
        };

        Producer<Person> producer = new(ConfigData.topic);
        var consumer = new Consumer(ConfigData.topic);

        producer.Send(person.Id.Value.ToString().Substring(0, 10), person);
        consumer.Start();
    }
}