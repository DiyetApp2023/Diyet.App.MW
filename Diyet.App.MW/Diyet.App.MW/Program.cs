using Appusion.Core.Common.Implementation.Repositories;
using Appusion.Core.Common.Interface.Repositories;
using Appusion.Core.Common.Interface.Services;
using Appusion.Core.Common.IoC;
using Appusion.Core.Common.Middlewares.Jwt;
using Appusion.Core.Common.Utility;
using Appusion.Core.ServiceBase;
using Appusion.Core.Services.Base;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;
using Appusion.Core.Common.Mapping;
using Appusion.Core.Services.Mail;
using Appusion.Core.Services.User;
using Appusion.Core.Services.Jwt;
using Appusion.Core.Services.Meal;
using Appusion.Core.Services.Product;
using Appusion.Core.Services.DietPlan;
using Appusion.Core.Common.Base;

var builder = WebApplication.CreateBuilder(args);

var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.InstallJwtParameters(configuration);
builder.Services.InstallAppusionDietDbContext(configuration);
builder.Services.InstallMailSettings(configuration);
builder.Services.InstallUserParameters(configuration);
builder.Services.AddCors(p => p.AddPolicy("CorsPolicy", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyOrigin();
}));

builder.Services.AddScoped<IServiceCaller, ServiceCaller>();
builder.Services.AddScoped<IUserEntityRepository, UserEntityRepository>();
builder.Services.AddScoped<IUserOtpEntityRepository, UserOtpEntityRepository>();
builder.Services.AddScoped<IUserSessionRepository, UserSessionRepository>();
builder.Services.AddScoped<RestClient>();
builder.Services.AddScoped<HttpClient>();
builder.Services.AddScoped<RestHelper>();
builder.Services.AddAutoMapper(mapper =>
{
    mapper.AddProfile(new MappingProfile());
});
JsonConvert.DefaultSettings = () => new JsonSerializerSettings
{
    ContractResolver = new CamelCasePropertyNamesContractResolver()
};

builder.Services.AddScoped<IServiceCaller, ServiceCaller>();
builder.Services.AddScoped<IMailService, MailService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IMealService, MealService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IDietPlanService, DietPlanService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IDietPlanRepository, DietPlanRepository>();
builder.Services.AddScoped<IUserDietPlanMapRepository, UserDietPlanMapRepository>();
builder.Services.AddScoped<IJwtUtils, JwtUtils>();
builder.Services.AddScoped<IUserActivationEntityRepository, UserActivationEntityRepository>();
builder.Services.AddScoped<IMealEntityRepository, MealEntityRepository>();
builder.Services.AddScoped<IUserDietPlanDetailRepository,UserDietPlanDetailRepository>();
builder.Services.AddScoped<IUserDietPlanMealDetailProductMapEntityRepository, UserDietPlanMealDetailProductMapEntityRepository>();
builder.Services.AddScoped<IUserDailyActivityEntityRepository, UserDailyActivityEntityRepository>();
builder.Services.AddScoped<IUserSessionDetailEntityRepository, UserSessionDetailEntityRepository>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<RestHelper>();
builder.Services.AddScoped<RestClient>();
builder.Services.AddScoped<HttpClient>();
builder.Services.AddScoped<MailHelper>();
builder.Services.AddScoped<JwtHelper>();
builder.Services.AddScoped<UserComponent>();
builder.Services.AddScoped<MealComponent>();
builder.Services.AddScoped<ProductComponent>();
builder.Services.AddScoped<DietPlanComponent>();
//builder.Services.AddScoped<CurrentUser>((serviceProvider) =>
//{
//    var httpContext = (serviceProvider.GetService(typeof(IHttpContextAccessor)) as IHttpContextAccessor)
//    ?.HttpContext;
//    return (CurrentUser)httpContext.Items["User"];
//});

//builder.Services.AddScoped<CurrentUser>(async (serviceProvider) =>
//{
//    var currentUser =  new CurrentUser();
//    return await currentUser.Create(serviceProvider);
//});

builder.Services.AddScoped((serviceProvider) =>
{
    return CurrentUser.Create(serviceProvider);
});



builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
app.UseMiddleware<JwtMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
