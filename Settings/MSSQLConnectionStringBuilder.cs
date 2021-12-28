using System.Security.Cryptography.X509Certificates;

namespace ApproxWeatherAPI.Settings
{
  public class MSSQLConnectionStringBuilder : IConnectionStringBuilder
  {
    public string Datasource { get; init; }

    public string InitialCatalog { get; init; }

    public string User { get; init; }

    public string Password { get; init; }

    public string Params { get; init; }

    public string GetDSN() {
        return @$"Data Source={Datasource};Initial Catalog={InitialCatalog};
          User ID={User};Password={Password};{Params}";
    }
  }
}
