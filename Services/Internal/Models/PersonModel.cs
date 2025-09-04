public enum Gender
{
    Unknown = 0,
    Female = 1,
    Male = 2,
    Other = 3
}

public enum PersonStatus
{
    Insert = 0,
    Update = 1
}

public class Address
{
    public Guid? Id { get; set; }
    public string? Country { get; set; }
    public string? City { get; set; }
    public string? Street { get; set; }
    public string? HouseNumber { get; set; }
    public string? PostalCode { get; set; }
}

public class Person
{
    public Guid? Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public DateTime? BirthDateUtc { get; set; }
    public Gender? Gender { get; set; }
    public Address? Address { get; set; }
    public PersonStatus? Status { get; set; }
}

public static class PersonGenerator
{
    public static Person Run()
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