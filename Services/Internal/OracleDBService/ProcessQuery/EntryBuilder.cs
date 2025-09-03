using Oracle.ManagedDataAccess.Client;

public static class EntryBuilder
{
    public static DBentry Build(object entity, string? relationName = null, Guid? id = null)
    {
        var entry = new DBentry();
        var properties = entity.GetType().GetProperties();

        foreach (var prop in properties)
        {
            var name = prop.Name;
            var value = prop.GetValue(entity) ?? DBNull.Value;
            var underlyingType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;

            if (prop.Name == relationName)
            {
                name += "Id";
                value = id;
                underlyingType = typeof(Guid);
            }

            var (parsedValue, dbType) = ParameterParser.Parse(underlyingType, value);

            entry.Columns.Add(name);
            entry.ParameterNames.Add(":" + name);
            entry.Parameters.Add(new OracleParameter(":" + name, dbType) { Value = parsedValue });
        }

        return entry;
    }
}