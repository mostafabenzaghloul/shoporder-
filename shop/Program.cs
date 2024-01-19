using Microsoft.EntityFrameworkCore;
using shop.Models;
using shop.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
var connectionstring = builder.Configuration.GetConnectionString("DefualtConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(connectionstring));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<ICategoriesServices,CategoriesServices>();
builder.Services.AddTransient<IAdminServices, AdminsServices>();
builder.Services.AddTransient<IProductsServices, PoductsServices>();
builder.Services.AddTransient<ICartService, CartService>();
builder.Services.AddTransient<IReviewRepository, ReviewRepository>();
builder.Services.AddTransient<IOrderDetailServices, OrderDetailService>();
builder.Services.AddTransient<IRepository<WishlistItem>, WishlistItemRepository>();
builder.Services.AddTransient<WishlistService>();
builder.Services.AddTransient<IRatingRepository, RatingRepository>();
builder.Services.AddTransient<RatingService>();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddCors();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();

app.Run();
