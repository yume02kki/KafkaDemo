using PersonSender.Kafka;

internal class Program
{
    private static void Main(string[] args)
    {
        var consumer = new PersonConsumer();
        var producer = new Producer();

        Action<Person> dbUpdate = personReceived =>
        {
            Console.WriteLine("ran once");
            QueryRunner.run("Address", EntryBuilder.Build(personReceived.Address));
            QueryRunner.run("Person", EntryBuilder.Build(personReceived, "Address", personReceived.Address.Id.Value));
            Console.WriteLine("db updated successfully");
        };

        Task.Run(() => consumer.Start(KafkaConfig.Topic, dbUpdate));

        while (true)
        {
            Console.WriteLine("Hit enter to send task...");
            Console.ReadLine();
            var person = PersonGenerator();

            producer.Send(KafkaConfig.Topic, person.Id.Value.ToString().Substring(0, 10), person);
            person.Id = Guid.NewGuid();
            person.Address.Id = Guid.NewGuid();
        }
    }


    private static Person PersonGenerator()
    {
        return new Person
        {
            Id = Guid.NewGuid(),
            FirstName = "John",
            LastName = "Egbert",
            Email = "ectobiologist@gmail.com",
            Phone = "052-987-6543",
            BirthDateUtc = new DateTime(1996, 4, 13),
            Gender = Gender.Female,
            Address = new Address
            {
                Id = Guid.NewGuid(),
                Country = "USA",
                City = "Washington",
                Street = "Maple Valley",
                HouseNumber = "1",
                PostalCode = "21605"
            },
            Status = PersonStatus.Insert
        };
    }
}