class Program
{
    static void Main(string[] args)
    {
        const string topicName = "person-topic";

        var person = new Person
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

        Producer producer = new Producer();
        PersonConsumer consumer = new PersonConsumer();

        producer.Send(topicName, person.Id.Value.ToString().Substring(0, 10), person);

        //kafka => db
        {
            var packet = consumer.Start(topicName);
            if (packet is Person personGot && personGot.Address != null)
            {
                QueryRunner.run("ADDRESS", EntryBuilder.Build(personGot.Address));
                QueryRunner.run("PERSON", EntryBuilder.Build(personGot, "Address", person.Address.Id.Value));
            }
        }
    }
}