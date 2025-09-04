using Oracle.ManagedDataAccess.Client;

public class QueryRunner
{
    private static readonly string ConnectionString = DBconfig.ConnectionStr;

    public static void Run(string table, DBentry entry)
    {
        var queryString = $"INSERT INTO {table} ({string.Join(", ", entry.Columns)}) " +
                          $"VALUES ({string.Join(", ", entry.ParameterNames)})";

        using (var connection = new OracleConnection(ConnectionString))
        {
            connection.Open();

            using (var command = new OracleCommand(queryString, connection))
            {
                command.Parameters.AddRange(entry.Parameters.ToArray());
                command.ExecuteNonQuery();
            }
        }
    }
}