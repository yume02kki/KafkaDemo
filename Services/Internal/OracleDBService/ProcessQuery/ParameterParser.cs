using Oracle.ManagedDataAccess.Client;

public static class ParameterParser
{
    private static readonly Dictionary<Type, Func<object, (object value, OracleDbType dbType)>> Parsers = new();

    //default init
    static ParameterParser()
    {
        AddParser<Guid>(guid => (guid.ToByteArray(), OracleDbType.Raw));
        AddParser<DateTime>(dateTime => (dateTime, OracleDbType.Date));
        AddParser<Enum>(e => (Convert.ToInt32(e), OracleDbType.Int32));
    }

    public static void AddParser<T>(Func<T, (object value, OracleDbType dbType)> parser)
    {
        Parsers[typeof(T)] = obj => parser((T)obj);
    }

    public static (object value, OracleDbType dbType) Parse(Type type, object value)
    {
        if (type.IsEnum) type = typeof(Enum);

        if (Parsers.TryGetValue(type, out var parser)) return parser(value);

        return (value, OracleDbType.Varchar2);
    }
}