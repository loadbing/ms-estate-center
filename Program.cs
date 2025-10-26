using MongoDB.Driver;
using ms_estate_center.Adapter.Out.Mongodb.Properties;
using ms_estate_center.Adapter.Out.Mongodb.Users;
using ms_estate_center.Application.UseCases.Properties;
using ms_estate_center.Application.UseCases.Users;
using ms_estate_center.Settings;
using ms_estate_center.Adapter.Middlewares;
using Microsoft.IdentityModel.Tokens;
using ms_estate_center.Infrastructure.Settings;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<PropertiesRepository>();
builder.Services.AddScoped<UsersRepository>();
builder.Services.AddScoped<CreatePropertiesUseCase>();
builder.Services.AddScoped<GetAllPropertiesUseCase>();
builder.Services.AddScoped<GetPropertyByIdUseCase>();
builder.Services.AddScoped<UpdatePropertyUseCase>();
builder.Services.AddScoped<DeletePropertyUseCase>();
builder.Services.AddScoped<ValidatePropertyExistenceUseCase>();
builder.Services.AddScoped<ValidateUserUseCase>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<AESSettings>(options =>
{
    options.Key = Environment.GetEnvironmentVariable("AES_SETTINGS_KEY") ?? builder.Configuration["AESSettings:Key"] ?? "";
    options.IV = Environment.GetEnvironmentVariable("AES_SETTINGS_IV") ?? builder.Configuration["AESSettings:IV"] ?? "";
});

Console.WriteLine("AES_SETTINGS_KEY = " + Environment.GetEnvironmentVariable("AES_SETTINGS_KEY"));
Console.WriteLine("AES_SETTINGS_IV = " + Environment.GetEnvironmentVariable("AES_SETTINGS_IV"));



var mongoConnection = Environment.GetEnvironmentVariable("MONGO_DB_CONNECTION_STRING") 
                      ?? builder.Configuration["MongoDB:ConnectionString"] ?? "";

var mongoDatabaseName = Environment.GetEnvironmentVariable("MONGO_DB_DATABASE_NAME")
                        ?? builder.Configuration["MongoDB:DatabaseName"] ?? "";

Console.WriteLine("MONGO_DB_CONNECTION_STRING = " + Environment.GetEnvironmentVariable("MONGO_DB_CONNECTION_STRING"));
Console.WriteLine("MONGO_DB_DATABASE_NAME = " + Environment.GetEnvironmentVariable("MONGO_DB_DATABASE_NAME"));

Console.WriteLine(mongoConnection);
Console.WriteLine(mongoDatabaseName);


builder.Services.AddSingleton<IMongoClient>(_ => new MongoClient(mongoConnection));

builder.Services.AddScoped(sp =>
{
    var client = sp.GetRequiredService<IMongoClient>();
    return client.GetDatabase(mongoDatabaseName);
});

var jwtKey = Environment.GetEnvironmentVariable("JWT_KEY")
             ?? builder.Configuration["Jwt:Key"] ?? "";
             
Console.WriteLine("JWT_KEY = " + Environment.GetEnvironmentVariable("JWT_KEY"));
Console.WriteLine(jwtKey);

builder.Services.AddAuthentication("Bearer").AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
        ClockSkew = TimeSpan.Zero
    };
});


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
