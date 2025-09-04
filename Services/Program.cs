using PersonSender.Kafka;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var updateCount = 0;
        await TopicCreator.Create();
        var consumer = new PersonConsumer();
        var producer = new Producer();

        Action<Person> dbUpdate = personReceived =>
        {
            QueryRunner.Run("Address", EntryBuilder.Build(personReceived.Address));
            QueryRunner.Run("Person",
                EntryBuilder.Build(personReceived, "Address", personReceived.Address.Id.Value));

            Console.WriteLine($"DB updated sucessfully (x{++updateCount})");
        };

        Task.Run(() => consumer.Start(dbUpdate));

        Console.WriteLine("[Press any key to create person]");
        while (true)
        {
            Console.ReadKey();
            var person = PersonGenerator.Run();
            producer.Send(KafkaConfig.TopicConfig.Name, "person: " + person.Id!.Value.ToString().Substring(0, 10),
                person);
        }
    }
}