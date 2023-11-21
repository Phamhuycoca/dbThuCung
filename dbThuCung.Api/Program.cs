using CloudinaryDotNet;
using dbThuCung.Api.Controllers.GioHang;
using dbThuCung.Model.Context;
using dbThuCung.Model.Entities;
using dbThuCung.Model.Mapper;
using dbThuCung.Repository.IRepository;
using dbThuCung.Repository.Repository;
using dbThuCung.Service.IService;
using dbThuCung.Service.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ThuCungContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("Myconn")));



//Repository
builder.Services.AddScoped<IDanhMucRepo,DanhMucRepo>();
builder.Services.AddScoped<ISanPhamRepo,SanPhamRepo>();
builder.Services.AddScoped<IThuNuoiRepo,ThuNuoiRepo>();
builder.Services.AddScoped<INguoiDungRepo, NguoiDungRepo>();
builder.Services.AddScoped<ICartRepo,CartRepo>();


//Serivce
builder.Services.AddScoped<IDanhMucService,DanhMucService>();
builder.Services.AddScoped<ISanPhamService,SanPhamService>();
builder.Services.AddScoped<IThuNuoiService,ThuNuoiService>();
builder.Services.AddScoped<IEmailService,EmailService>();
builder.Services.AddScoped<INguoiDungService,NguoiDungService>();
//builder.Services.AddSingleton<List<CartItem>>();
builder.Services.AddScoped<ICartService, CartService>();
//builder.Services.AddScoped<GioHangController>();
//Mapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

//JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        // yêu cầu tgian hết hạn
        RequireExpirationTime = true,
        ValidateLifetime = true,
        //lấy ra khóa bí mật
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"])),
        RequireSignedTokens = true
    };
});
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

    // Cấu hình bảo mật Swagger UI
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [Space] then your token"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[]{}
            }
        });
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
    options.AddPolicy("Khách hàng", policy => policy.RequireRole("Khách hàng"));
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("VueApp",
        builder =>
        {
            builder.WithOrigins("http://localhost:2002")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});
//Cloudinary
IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

var cloudinaryAccount = new Account(
    configuration["Cloudinary:CloudName"],
    configuration["Cloudinary:ApiKey"],
    configuration["Cloudinary:ApiSecret"]
);
builder.Services.AddControllersWithViews();
var cloudinary = new Cloudinary(cloudinaryAccount);
builder.Services.AddSingleton(cloudinary);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("VueApp");

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
