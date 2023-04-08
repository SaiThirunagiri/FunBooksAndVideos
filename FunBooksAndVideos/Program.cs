using FunBooksAndVideos.Repositories;
using FunBooksAndVideos.Services;
using FunBooksAndVideos.Services.BusinessRules;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = true,
//            ValidateAudience = true,
//            ValidateLifetime = true,
//            ValidateIssuerSigningKey = true,
//            ValidIssuer = Configuration["Jwt:Issuer"],
//            ValidAudience = Configuration["Jwt:Audience"],
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
//        };
//    });

Log.Logger = new LoggerConfiguration()
      .MinimumLevel.Debug()
      .WriteTo.File("logs\\log.txt", rollingInterval: RollingInterval.Day)
      .CreateLogger();

// Add services to the container.
builder.Services.AddSingleton<ICustomerRepository, CustomerRepository>();
builder.Services.AddSingleton<ICustomerService, CustomerService>()
   .AddSingleton<IShippingService, ShippingService>()
   .AddSingleton<IPurchaseOrderProcessorService, PurchaseOrderProcessorService>();

builder.Services.AddSingleton<IList<IBusinessRules>>(sp => {
    var dependentCustomerService = sp.GetRequiredService<ICustomerService>();
    var dependentShippingService = sp.GetRequiredService<IShippingService>();
    return new List<IBusinessRules>() { new MembershipRule(dependentCustomerService), 
        new ShippingRule(dependentCustomerService,dependentShippingService) };
});


builder.Services.AddControllers();
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
