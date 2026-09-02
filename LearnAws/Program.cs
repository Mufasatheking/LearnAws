using LearnAws.Repositories;

namespace LearnAws;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine(Environment.GetEnvironmentVariable("LEARNAWS_EXAMPLE_TOKEN"));
        Console.WriteLine(Environment.GetEnvironmentVariable("LEARNAWS_SECRET_TOKEN"));
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        builder.Services.AddControllers();
        builder.Services.AddScoped<IPeopleRepository, PeopleRepository>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();
        app.MapControllers();
        app.Run();
    }
}
