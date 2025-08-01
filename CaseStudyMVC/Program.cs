using CaseStudyMVC.Mapping;
using CaseStudyMVC.Services.Abstract;
using CaseStudyMVC.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(MappingConfig));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<ITodoItemService, TodoItemService>();
builder.Services.AddScoped<ITodoItemService, TodoItemService>();
builder.Services.AddHttpClient<IUserService, UserService>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=TodoItem}/{action=Create}/{id?}");

app.Run();
