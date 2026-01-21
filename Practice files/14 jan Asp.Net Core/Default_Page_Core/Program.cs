using Microsoft.Extensions.FileProviders;

namespace Default_Page_Core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            //1. setting default files options to customize startup html file
            //1.1 DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
            //clear any default if exists
            //1.2 defaultFilesOptions.DefaultFileNames.Clear();
            //add our deafult file to the options
            //1.3 defaultFilesOptions.DefaultFileNames.Add("htmlpage1.html");

            //2.app.UseDirectoryBrowser();  //now set the options to the middleware

            //1.4 app.UseDefaultFiles(defaultFilesOptions); // for defualt files

            //0.app.UseStaticFiles(); // here we add static files means it will search in wwwroot file

            //3. filesserver middleware which encompasses all the above 3 middleware
            //var fileserveroptions = new FileServerOptions
            //{
            //    EnableDirectoryBrowsing = true,
            //    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"))
            //};
            //fileserveroptions.DefaultFilesOptions.DefaultFileNames.Clear();
            //app.UseFileServer(fileserveroptions);

            //4. Devlopmentexcetion page
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.MapGet("/", async context =>
            {
                int num1 = 10, num2 = 0;
                int res = num1 / num2;
                await context.Response.WriteAsync($"Result : {res}");
            });

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Handled request and responding..");
            //});

            app.Run();
        }
    }
}
