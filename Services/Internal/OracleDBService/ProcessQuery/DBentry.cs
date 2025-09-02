using Oracle.ManagedDataAccess.Client;

public class DBentry
{
    public List<string> Columns { get; }
    public List<string> ParameterNames { get; }
    public List<OracleParameter> Parameters { get; }

    public DBentry(List<string>? columns = null, List<string>? parameterNames = null, List<OracleParameter>? parameters = null)
    {
        Columns = columns ?? new List<string>();
        ParameterNames = parameterNames ?? new List<string>();
        Parameters = parameters ?? new List<OracleParameter>();
    }
}
