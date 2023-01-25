using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using WayToDev.Application.Managers;
using WayToDev.Application.Services;
using WayToDev.Client.Hubs;
using WayToDev.Client.Mapping;
using WayToDev.Core.Configuration;
using WayToDev.Core.Interfaces.Infrastructure;
using WayToDev.Core.Interfaces.Managers;
using WayToDev.Core.Interfaces.Services;
using WayToDev.Db.Bridge;
using WayToDev.Db.EF;
using WayToDev.Infrastructure.Configurations;
using WayToDev.Infrastructure.MailSender;

var builder = WebApplication.CreateBuilder(args);

#region ConfigureServices

//binding configuration mail client
var mailConfig = new MailSenderConfiguration();
builder.Configuration.GetSection("MailClient").Bind(mailConfig);
builder.Services.AddSingleton(mailConfig);
//configuration urls
builder.Services.AddSingleton(new EmailTemplatePathModel { RootPath = builder.Environment.WebRootPath });
var appUrlsConfig = new ApplicationUrlsConfiguration();
builder.Configuration.GetSection("BaseUrls").Bind(appUrlsConfig);
builder.Services.AddSingleton(appUrlsConfig);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnString"),
        b => b.MigrationsAssembly("WayToDev.Db")));

builder.Services.AddAutoMapper(typeof(UserMapperProfile).GetTypeInfo().Assembly);
builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<INewsService, NewsService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddSignalR();
builder.Services.AddScoped<IAccountManager, AccountManager>();
builder.Services.AddTransient<IPasswordHelper, PasswordHelper>();
builder.Services.AddTransient<ISecurityContext, SecurityContextService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IVacancyService, VacancyService>();
builder.Services.AddScoped<IMailClient, MailClient>();
builder.Services.AddScoped<IMailService, MailService>();
builder.Services.AddSingleton<IPinGenerator, PinGenerator>();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
        
    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            var accessToken = context.Request.Query["access_token"];

            // If the request is for our hub...
            var path = context.HttpContext.Request.Path;
            if (!string.IsNullOrEmpty(accessToken) &&
                path.StartsWithSegments("/chatRoom"))
            {
                // Read the token out of the query string
                context.Token = accessToken;
            }

            return Task.CompletedTask;
        },
    };
});
builder.Services.AddAuthorization();
#endregion


var app = builder.Build();
app.UseSwaggerUI();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSwagger();
app.UseCors(x =>
{
    x.AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed(origin => true)
        .AllowCredentials();
});
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<ChatHub>("/chatHub");
    endpoints.MapControllerRoute("default", "{controller}/{action=Index}/{id?}");
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");
;

app.Run();