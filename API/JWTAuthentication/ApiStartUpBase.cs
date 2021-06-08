using FluentValidation.AspNetCore;
using JWTAuthentication.Core.Models;
using JWTAuthentication.Extensions;
using JWTAuthentication.Mapper;
using JWTAuthentication.Persistance;
using JWTAuthentication.Services.Mapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json.Serialization;

namespace JWTAuthentication
{
    public class ApiStartUpBase
    {
        public ApiStartUpBase(IConfiguration configuration, IWebHostEnvironment hostEnvironment)
        {
            Configuration = configuration;
            HostEnvironment = hostEnvironment;
        }

        protected IConfiguration Configuration { get; }

        protected IWebHostEnvironment HostEnvironment { get; }

        private const string jwtAuth = "JWT";

        public void RegisterDependencies(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: "CorsPolicy", builder =>
                {
                    builder.AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithOrigins("http://localhost:4200");   //AllowAnyOrigin()//;
                });
            });

            var mvcBuilder = services
                .AddControllers()
                 .AddJsonOptions(options =>
                   options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()))
                 .AddFluentValidation(Options =>
                 {
                     Options.RegisterValidatorsFromAssemblyContaining<Startup>();
                 });            

            services.AddIdentityServices(Configuration);

            services.AddAutoMapper(new Assembly[]
            {
               Assembly.GetAssembly(typeof(Startup)),
               Assembly.GetAssembly(typeof(ApiModelMappingProfile)),
               Assembly.GetAssembly(typeof(EntityMappingProfile)),
            });

            services.AddDBContextServices(Configuration);

            services.AddAplicationServices();

            services.Configure<JWT>(Configuration.GetSection(jwtAuth));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "JWTAuthentication", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter    'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: Bearer abcdef1234\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
            });
        }
    }
}
