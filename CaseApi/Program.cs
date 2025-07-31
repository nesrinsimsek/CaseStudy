
using CaseApi;
using CaseApi.Mapping;
using CaseBusiness.DependencyInjection;
using CaseDataAccess;
using CaseDataAccess.DependencyInjection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options => options.
    UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));
builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

DataAccessServiceRegistration.RegisterDataAccessServices(builder.Services);
BusinessServiceRegistration.RegisterBusinessServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Case API V1");
    });

}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();


app.MapControllers();

app.Run();
