using System;
using System.Collections.Generic;
using System.Reflection;
using Oracle.ManagedDataAccess.Client;

public class DBconnection
{
    private string connectionString;

    public DBconnection(string connectionString)
    {
        this.connectionString = connectionString;
    }

    private Type GetUnderlyingType(PropertyInfo property) =>
        Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;

    private OracleCommand BuildSQL(object entity, string table, OracleConnection connection, string relationName,
        Guid id)
    {
        var properties = entity.GetType().GetProperties();
        var columns = new List<string>();
        var parameters = new List<string>();
        var sqlParams = new List<OracleParameter>();

        foreach (var property in properties)
        {
            var name = property.Name;
            var value = property.GetValue(entity) ?? DBNull.Value;
            OracleDbType dbType = OracleDbType.Varchar2; //default

            //guid to raw
            if (GetUnderlyingType(property) == typeof(Guid))
            {
                if (value != DBNull.Value)
                    value = ((Guid)value).ToByteArray();
                dbType = OracleDbType.Raw;
            }

            //relation
            if (!string.IsNullOrEmpty(relationName) && property.Name == relationName)
            {
                name += "Id";
                value = id.ToByteArray();
                dbType = OracleDbType.Raw;
            }

            //enum
            if (GetUnderlyingType(property).IsEnum && value != DBNull.Value)
            {
                value = (int)value;
                dbType = OracleDbType.Int32;
            }

            // time
            if (GetUnderlyingType(property) == typeof(DateTime) && value != DBNull.Value)
            {
                dbType = OracleDbType.Date;
            }

            columns.Add(name);
            parameters.Add(":" + name);

            var param = new OracleParameter(":" + name, dbType)
            {
                Value = value
            };
            sqlParams.Add(param);
        }

        var sql = $"INSERT INTO {table} ({string.Join(",", columns)}) VALUES ({string.Join(",", parameters)})";
        var cmd = new OracleCommand(sql, connection);
        cmd.Parameters.AddRange(sqlParams.ToArray());
        return cmd;
    }

    public void Insert(object entity, string table, string relationName = "", Guid id = default)
    {
        using var connection = new OracleConnection(connectionString);
        connection.Open();
        using var cmd = BuildSQL(entity, table, connection, relationName, id);
        cmd.ExecuteNonQuery();
    }
}