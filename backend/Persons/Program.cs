using Microsoft.OpenApi.Models;
using Persons.Services;

string corsKey = "_myCorsKey";
string swaggerVersion = "v1";
string swaggerTitle = "Persons";

var builder = WebApplication.CreateBuilder(args);

// -------------------------------------------- ConfigureServices
builder.Services.AddDbContext<PersonsContext>(options => options.UseSqlite("Data Source=Persons.sqlite"));

builder.Services.AddScoped<PersonsService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc(swaggerVersion, new OpenApiInfo
    {
        Title = swaggerTitle,
        Version = swaggerVersion
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(corsKey,
        x => x.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader()
      );
});

//string dataDirKey = "|DataDirectory|"; //if you use this: don't forget to set database file to "Copy if newer"
//string absoluteConnectionString = builder.Configuration.GetConnectionString("Persons");
//string? dataDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly()?.Location);
//if (absoluteConnectionString.Contains(dataDirKey)) absoluteConnectionString = absoluteConnectionString.Replace(dataDirKey, dataDirectory + Path.DirectorySeparatorChar);
//Console.WriteLine($"******** ConnectionString: {absoluteConnectionString}");
// absoluteConnectionString));
// -------------------------------------------- ConfigureServices END

var app = builder.Build();

// -------------------------------------------- Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    Console.WriteLine("******** Swagger enabled: http://localhost:5000/swagger (to set as default route: see launchsettings.json)");
    app.UseSwagger();
    app.UseSwaggerUI(x => x.SwaggerEndpoint($"/swagger/{swaggerVersion}/swagger.json", swaggerTitle));
}

app.UseCors(corsKey);

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
// -------------------------------------------- Middleware pipeline END

app.Run();
