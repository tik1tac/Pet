using Application.Behaviours;

using Contract;

using FluentValidation;

using MediatR;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

using PetProjectMarket.Shared.Helpers;

using Repository;

using System.Text;

public static class Extensions
{
    public static void ConfigureValidation(this IServiceCollection service)
    {
        service.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        service.AddValidatorsFromAssembly(typeof(Application.AssemblyReference).Assembly);
    }

    public static void ConfigureLogger(this IServiceCollection service)
    {
        service.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
    }

    public static void ConfigureException(this IServiceCollection service)
    {
        service.AddTransient<ExceptionHandling>();
    }

    public static void ConfigureComparison(this IServiceCollection service)
    {
        service.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        service.AddScoped<ISortHelpers<UserEntity>, SortHelpers<UserEntity>>();
        service.AddScoped<ISortHelpers<ProductsEntity>, SortHelpers<ProductsEntity>>();
        service.AddScoped<IServiceEmail, ServiceEmail>();
        service.AddScoped<IUserClaimsPrincipalFactory<UserEntity>, CustomClaimsFactory>();
    }

    public static void ConfigureMediatR(this IServiceCollection service)
    {
        service.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Application.AssemblyReference).Assembly));
    }

    public static void ConfigureCors(this IServiceCollection service)
    {
        service.AddCors(opt =>
        {
            opt.AddPolicy(name: "MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()
                .WithExposedHeaders("Pagination");
            });
        });
    }

    public static void ConfigureDataBase(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddDbContext<AplicationContext>(option =>
            option.UseNpgsql(connectionString: configuration["MyConnection:ConnectionString"]));
    }

    public static void ConfigureIdentity(this IServiceCollection service)
    {
        service.AddIdentity<UserEntity, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireUppercase = true;
                options.User.RequireUniqueEmail = true;
                options.Tokens.EmailConfirmationTokenProvider = "emailconfirmation";

                //Locked
                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
                options.Lockout.MaxFailedAccessAttempts = 3;
            })
            .AddEntityFrameworkStores<AplicationContext>()
            .AddDefaultTokenProviders()
            .AddTokenProvider<EmailConfirmationTokenProvider<UserEntity>>("emailconfirmation");
        //CustomCheckerPasword
        //Twillio

        service.Configure<DataProtectionTokenProviderOptions>(opt =>
        opt.TokenLifespan = TimeSpan.FromHours(2));

        service.Configure<EmailConfirmationTokenProviderOptions>(opt =>
        opt.TokenLifespan = TimeSpan.FromDays(3));
    }

    public static void ConfigurationAutoMapper(this IServiceCollection service)
    {
        service.AddAutoMapper(typeof(Program));
    }

    public static void ConfigurationEmailService(this IServiceCollection service, IConfiguration config)
    {
        var emailConfig = config.GetSection("EmailSettings");
        //
        var FromEmail = emailConfig["DefaultFromEmail"];
        var Host = emailConfig["SMTPSettings:Host"];
        var Port = emailConfig.GetValue<int>("SMTPSettings:Port");
        var Username = emailConfig["SMTPSettings:UserName"];
        var Passwd = emailConfig["SMTPSettings:Password"];

        service.AddFluentEmail(FromEmail).AddSmtpSender(Host, Port, Username, Passwd);
    }
    public static void ConfigureSwagger(this IServiceCollection service)
    {
        service.AddSwaggerGen(opt =>
        {
            opt.SwaggerDoc("MySwagger", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "MyApi", Version = "vers1" });
            opt.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
        });

    }
    public static void ConfigureProtection(this IServiceCollection service)
    {
        service.AddDataProtection()
            .PersistKeysToFileSystem(new DirectoryInfo(@"bin\debug\configuration"))
            .SetDefaultKeyLifetime(TimeSpan.FromDays(10));
    }
    public static void ConfigureJWT(this IServiceCollection service)
    {
        service.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(option =>
            {
                option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "http://localhost:5116",
                    ValidAudience = "http://localhost:5116",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuperSecretKey"))
                };
            });
    }
}