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

    public void query(Person person)
    {
        using var connection = new OracleConnection(connectionString);
        
        connection.Execute("INSERT INTO PERSON VALUES (@Id,@FirstName,@LastName,@Email,@Phone,@BirthDateUtc,@Gender,@Address,@Status)", person);
    }
}