using Waitlist.Entity.Aws;
using Waitlist.Helpers;
using Waitlist.Services;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var env = builder.Environment;

//SERVICES
{
    // add DB contexts depending on QA or Prod
    if (env.IsDevelopment())
    {       
        services.AddDbContext<DataContext>();
    }
    else
    {
        services.AddDbContext<DataContextPROD, DataContext>();
    }

    services.AddCors();
    services.AddControllers();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    // add mapper
    services.AddAutoMapper(typeof(Program));

    // configure appsettings object
    services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
    services.Configure<AppSettings>(builder.Configuration.GetSection("ConnectionStrings"));

    // configure Dependency Injection for app services
    services.AddScoped<IPassengerService, PassengerService>();

    //configure DI for AWS Secrets Manager
    services.AddScoped<IAmazonSecretsManager>(a =>
        new AmazonSecretsManagerClient(RegionEndpoint.USEast1)
    );
    // configure DI API aws creds
    services.Configure<AwsCredentials>(builder.Configuration);
    services.AddAWSService<IAmazonS3>();

}

// APP
var app = builder.Build();

{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    // global error handler
    app.UseMiddleware<ErrorHandlerMiddleware>();  

    app.UseRouting();

    // Enable CORS
    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

    app.UseAuthorization();

    app.MapControllers();
}

app.Run();
