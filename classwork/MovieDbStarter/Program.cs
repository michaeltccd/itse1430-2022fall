//Entry point code
var host = Host.CreateDefaultBuilder().Build();
s_configuration = host.Services.GetRequiredService<IConfiguration>();

public static string GetConnectionString ( string connectionStringName )
{
    var connString = s_configuration.GetConnectionString(connectionStringName);
    if (!String.IsNullOrEmpty(connString))
        return connString;

    throw new Exception($"Connection string '{connectionStringName}' not found. Ensure you are using the correct name and appsettings.json is available.");
}

private static IConfiguration s_configuration;