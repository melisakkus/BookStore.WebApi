using BookStore.BusinessLayer.Abstract;
using BookStore.BusinessLayer.Concrete;
using BookStore.DataAccessLayer.Abstract;
using BookStore.DataAccessLayer.Context;
using BookStore.DataAccessLayer.EntityFramework;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<BookStoreContext>();

builder.Services.AddScoped<ICategoryDal,EfCategoryDal>();
builder.Services.AddScoped<ICategoryService,CategoryManager>();

builder.Services.AddScoped<IProductDal, EfProductDal>();
builder.Services.AddScoped<IProductService,ProductManager>();

builder.Services.AddScoped<IQuoteDal,EfQuoteDal>();
builder.Services.AddScoped<IQuoteService,QuoteManager>();

builder.Services.AddScoped<IGeneralInfoDal,EfGeneralInfoDal>();
builder.Services.AddScoped<IGeneralInfoService,GeneralInfoManager>();

builder.Services.AddScoped<IUserEmailDal,EfUserEmailDal>();
builder.Services.AddScoped<IUserEmailService, UserEmailManager>();

builder.Services.AddScoped<IDashboardDal, EfDashboardDal>();
builder.Services.AddScoped<IDashboardService, DashboardManager>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
