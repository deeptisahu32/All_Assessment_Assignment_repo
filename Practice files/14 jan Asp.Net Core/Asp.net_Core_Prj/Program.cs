namespace Asp.net_Core_Prj
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //creating the web Host and services
            var builder = WebApplication.CreateBuilder(args);

            //building the aplication
            var app = builder.Build();


            //setting up endpoints routing and middleware component 
            //1. //app.MapGet("/", () => "Hello World!" + System.Diagnostics.Process.GetCurrentProcess().ProcessName) ;

            // 2. read config info
            string? OurKeyvalue = builder.Configuration.GetValue<string>("OurNewKey", "default");

            //get the configuration value
            string? keyval = builder.Configuration["OurNewKey"];

            app.MapGet("/", () => $"{keyval}");

            app.Run();
        }
    }
}
