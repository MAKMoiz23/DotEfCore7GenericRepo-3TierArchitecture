using BAL.Services.IService;
using BAL.Services.Service;
using DAL.Data;
using DAL.DataRepositories.DataRepository;
using DAL.DataRepositories.IDataRepository;
using DAL.Models;
using DAL.Repository.GenericRepository;
using DAL.Repository.IGenericRepository;
using Pos_API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region AddServices
builder.Services.AddCors();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>();
builder.Services.AddScoped<IGenericRepository<Customer>, GenericRepository<Customer>>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
#endregion

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseHsts();
}

#region Swagger for Production and Development
app.UseSwagger();
app.UseSwaggerUI();
#endregion

app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
