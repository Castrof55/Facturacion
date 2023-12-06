using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Presione una tecla para iniciar la aplicación...");
        Console.ReadKey();

        var host = CreateHostBuilder(args).Build();

        try
        {
            host.Run();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al ejecutar la aplicación: " + ex.ToString());
        }
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
}
