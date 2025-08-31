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