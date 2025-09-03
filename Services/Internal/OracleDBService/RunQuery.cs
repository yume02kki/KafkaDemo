using Oracle.ManagedDataAccess.Client;

public static class QueryRunner
{
    private static readonly OracleConnection connection;

    static QueryRunner()
    {
        connection = new OracleConnection(DBconfig.ConnectionStr);
        connection.Open();
        Console.WriteLine("DB connected");
    }

    public static void run(string table, DBentry entry)
    {
        var queryString = $"INSERT INTO {table} ({string.Join(", ", entry.Columns)}) " +
                          $"VALUES ({string.Join(", ", entry.ParameterNames)})";
        var command = new OracleCommand(queryString, connection);
        command.Parameters.AddRange(entry.Parameters.ToArray());

        Console.WriteLine("ran");
        command.ExecuteNonQuery();
    }
}