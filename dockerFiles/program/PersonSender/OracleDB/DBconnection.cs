using Dapper;
using Oracle.ManagedDataAccess.Client;

namespace PersonSender;


public class DBconnection
{
    private string connectionString;

    public DBconnection(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public void insert(Person person)
    {
        using var connection = new OracleConnection(connectionString);
        
        connection.Execute("INSERT INTO PROJECT_SCHEMA.Person VALUES (@Id,@FirstName,@LastName,@Email,@Phone,@BirthDateUtc,@Gender,-1,@Status)", person);
    }
}