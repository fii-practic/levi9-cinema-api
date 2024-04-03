using Amazon.S3;
using Levi9.Cinema.Api;
using Levi9.Cinema.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();

switch (builder.Configuration["DatabaseProvider"])
{
    case "InMemory":
        builder.Services.AddDbContext<MoviesDbContext, InMemoryDbContext>();
        break;
    case "PostgreSql":
        builder.Services.AddDbContext<MoviesDbContext, PostgresDbContext>();
        break;
}

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IAwsS3Service, AwsS3Service>();
builder.Services.AddAWSService<IAmazonS3>();

builder.Services.Configure<AwsS3Options>(
    builder.Configuration.GetSection(AwsS3Options.S3Bucket));

builder.Services.AddCors(options =>
    options.AddPolicy(name: "levi9cinema", builder =>
    {
        builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
    })
);

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

// migrate any database changes on startup (includes initial db creation)
using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetService<PostgresDbContext>();
    if (dataContext is not null)
        dataContext.Database.Migrate();
}

// global error handler
app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseCors("levi9cinema");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();