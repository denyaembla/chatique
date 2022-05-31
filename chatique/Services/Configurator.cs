using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace chatique.Services;

public static class Configurator
{
    private static readonly Lazy<IConfiguration> s_configuration;
    public static IConfiguration Configuration => s_configuration.Value;

    public static string Url => Configuration[nameof(Url)];
    public static string Username => Configuration.GetSection("Username").Value;
    public static string SomeValue2 => Configuration.GetSection("CheckoutInformation").GetSection("Firstname").Value;


    public static string BrowserType => Configuration.GetSection("ServiceConfig").GetSection("BrowserType").Value;

    public static int WaitTimeout =>
        int.Parse(Configuration.GetSection("ServiceConfig").GetSection("SeleniumWaitTimeout").Value);

    static Configurator()
    {
        s_configuration = new Lazy<IConfiguration>(BuildConfiguration);
    }

    private static IConfiguration BuildConfiguration()
    {
        var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var builder = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json");

        var appSettingFiles = Directory.EnumerateFiles(basePath, "appsettings.*.json");

        foreach (var appSettingFile in appSettingFiles) builder.AddJsonFile(appSettingFile);

        return builder.Build();
    }
}