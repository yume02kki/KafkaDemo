using Oracle.ManagedDataAccess.Client;

public static class QueryRunner
{
    public static void run(string table, DBentry entry)
    {
        using var connection = new OracleConnection(DBconfig.ConnectionStr);
        connection.Open();
        string queryString = $"INSERT INTO {table} ({string.Join(", ", entry.Columns)}) " + $"VALUES ({string.Join(", ", entry.ParameterNames)})";
        var command = new OracleCommand(queryString, connection);
        command.Parameters.AddRange(entry.Parameters.ToArray());

        command.ExecuteNonQuery();
    }
}