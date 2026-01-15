namespace ASP.NET_CORE_Middleware
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationOptions webApplicationOptions = new WebApplicationOptions
            {
                WebRootPath = "Mywebroot",
                Args = args,
                EnvironmentName="Production"
            };

            //var builder = WebApplication.CreateBuilder(args);
            var builder = WebApplication.CreateBuilder(webApplicationOptions);
            var app = builder.Build();

            // 8. adding static files middleware
            app.UseStaticFiles();

            //app.MapGet("/", () => "Hello World!"); 

            //1. understanding route patterns
            //app.MapGet("/greet", () => "hello from /greet endpoint");
            //app.MapGet("/greet/{name}", (string name) => $"Welcome,{name}!");

            //2. configure middleware and excute using run

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Getting Response from First Middleware");
            //});

            //3. calling a seperate defined middleware
            //app.Run(FirstMiddleWare);

            //4. how to add multiple  middleware        // we can not use run with every middleware instead of run we can write use
            //4.1 the below is 1st middleware
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Getting Response from First Middleware");
            //});


            //4.2 second middleware
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Getting Response from First Middleware");
            //});

            //5. after appling the use to solve the multiple middleware

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Started first middleware " + "<br>");
            //    await next();

            //    //context.Response.WriteAsync("Returing first from first Middleware");
            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Started Second middleware " + "<br>");
            //});

            //6. configure many chain middlewares and calling with use extension
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Response from 1st Middleware\n");
            //    await next();
            //});
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Response from 2nd Middleware\n");
            //    await next();
            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Response from 3rd Middleware");
            //});
            //app.Run();


            // for come back
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("1st Middleware request\n");
            //    await next();
            //    await context.Response.WriteAsync("1st Middleware\n");
            //});
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("2nd Middleware request\n");
            //    await next();
            //    await context.Response.WriteAsync("2nd Middleware response\n");
            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("3rd Middleware request and response\n");
            //});

            //7. webappliaction option class  for changinf any property values before create builder
            app.MapGet("/", () => $"EnviromentName {app.Environment.EnvironmentName} \n" +
            $"ApplicationName : {app.Environment.ApplicationName} \n" +
            $"WebRootPath : {app.Environment.WebRootPath} \n" +
            $"ContentRoorPath : {app.Environment.ContentRootPath}");
            // it work wehn we have wwwroot but if we change that name so it will not work
            //what we can do we can insert this in above
            //check that below code above
            //WebApplicationOptions webApplicationOptions = new WebApplicationOptions
            //{
            //    WebRootPath = "Mywebroot",
            //    Args = args,
            //    EnvironmentName = "Production"
            //};

            //var builder = WebApplication.CreateBuilder(webApplicationOptions);
            app.Run();
        }
        private static async Task FirstMiddleWare(HttpContext context)
        {
            await context.Response.WriteAsync("Getting Response from defined first middleware");
        }
    }
}
