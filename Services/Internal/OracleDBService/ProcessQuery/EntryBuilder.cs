using System.Data.Common;
using Oracle.ManagedDataAccess.Client;

public static class EntryBuilder
{
    public static DBentry Build(object entity, string relationName = "", Guid id = default)
    {
        var entry = new DBentry();
        var properties = entity.GetType().GetProperties();

        foreach (var prop in properties)
        {
            string name = prop.Name;
            object value = prop.GetValue(entity) ?? DBNull.Value;
            Type type = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;

            if (prop.Name == relationName)
            {
                name += "Id";
                value = id;
                type = typeof(Guid);
            }

            var (parsedValue, dbType) = ParameterParser.Parse(type, value);

            entry.Columns.Add(name);
            entry.ParameterNames.Add(":" + name);
            entry.Parameters.Add(new OracleParameter(":" + name, dbType) { Value = parsedValue });
        }

        return entry;
    }
}
