﻿using BLL.Utilities.Mailkit;
using DAL.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Utilities.Extensions.ServiceExtensions
{
	public static class ServiceExtensions
	{
		public static void ConfigureDbContext(this IServiceCollection services, IConfiguration Configuration)
		{

			services.AddDbContext<ApplicationDbContext>(options =>
			   options.UseSqlServer(
				   Configuration.GetConnectionString("DefaultConnection")));
			services.AddDbContext<BSynchroRJPDbContext>(options =>
			   options.UseSqlServer(
				   Configuration.GetConnectionString("DefaultConnection")));
			services.AddIdentity<ApplicationUser, IdentityRole>(options =>
			{
				options.SignIn.RequireConfirmedAccount = false;
				options.Password.RequireDigit = false;
				options.Password.RequiredLength = 4;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequireUppercase = false;
				options.Password.RequireLowercase = false;
			})
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddUserManager<CustomUserStore>()
				.AddDefaultTokenProviders();
			;
		}

		public static void ConfigureAuthentication(this IServiceCollection services)
		{
			services.AddAuthentication(o =>
			{
				o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(options =>
			{

				options.SaveToken = true;
				options.TokenValidationParameters = new TokenValidationParameters()
				{
					//Issuer is the API client 
					ValidateIssuer = true,
					ValidIssuer = "https://localhost:44310",

					//Audience is the client 
					ValidateAudience = true,
					ValidAudience = "https://localhost:44310",

					ValidateIssuerSigningKey = true,
					//Our Secret Key
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("fdjfhjehfjhfuehfbhvdbvjjoq8327483rgh")),

					//for delaying the expiry  date of the token
					ClockSkew = TimeSpan.FromMinutes(0)
				};
				//options.Events = new JwtBearerEvents
				//{
				//    OnMessageReceived = context =>
				//    {
				//        var accessToken = context.Request.Query["access_token"];

				//        var path = context.HttpContext.Request.Path;
				//        if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/hubs"))
				//        {
				//            context.Token = accessToken;
				//        }

				//        return Task.CompletedTask;
				//    }
				//};
				options.Events = new JwtBearerEvents
				{
					OnMessageReceived = context =>
					{
						if (context.Request.Path.Value.StartsWith("/hubs/notification") &&
							context.Request.Query.TryGetValue("token", out StringValues token)
						)
						{
							context.Token = token;
						}

						return Task.CompletedTask;
					},
					OnAuthenticationFailed = context =>
					{
						var te = context.Exception;
						return Task.CompletedTask;
					}
				};

			});
		}

		public static void ConfigureCookieAuthentication(this IServiceCollection services)
		{
			services.AddAuthentication().AddJwtBearer(options =>
			{

				options.SaveToken = true;
				options.TokenValidationParameters = new TokenValidationParameters()
				{
					//Issuer is the API client 
					ValidateIssuer = true,
					ValidIssuer = "https://localhost:44310",

					//Audience is the client 
					ValidateAudience = true,
					ValidAudience = "https://localhost:44310",

					ValidateIssuerSigningKey = true,
					//Our Secret Key
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("fdjfhjehfjhfuehfbhvdbvjjoq8327483rgh")),

					//for delaying the expiry  date of the token
					ClockSkew = TimeSpan.FromMinutes(0)
				};
				//options.Events = new JwtBearerEvents
				//{
				//    OnMessageReceived = context =>
				//    {
				//        var accessToken = context.Request.Query["access_token"];

				//        var path = context.HttpContext.Request.Path;
				//        if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/hubs"))
				//        {
				//            context.Token = accessToken;
				//        }

				//        return Task.CompletedTask;
				//    }
				//};
				options.Events = new JwtBearerEvents
				{
					OnMessageReceived = context =>
					{
						if (context.Request.Path.Value.StartsWith("/hubs/notification") &&
							context.Request.Query.TryGetValue("token", out StringValues token)
						)
						{
							context.Token = token;
						}

						return Task.CompletedTask;
					},
					OnAuthenticationFailed = context =>
					{
						var te = context.Exception;
						return Task.CompletedTask;
					}
				};

			});
		}


		public static void ConfigureAuthenticationMVC(this IServiceCollection services)
		{
			services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
					 .AddCookie(options =>
					 {
						 options.ExpireTimeSpan = TimeSpan.FromDays(30);
						 options.SlidingExpiration = true;
						 options.AccessDeniedPath = "/Forbidden/";
						 options.LoginPath = "/Account/Login";
						 //options.LogoutPath = "/Account/Logout";
						 options.LogoutPath = "/Home";
						 //options.AccessDeniedPath = "/Account/AccessDenied";

					 }).AddCookie("backend", options =>
					 {
						 options.ExpireTimeSpan = TimeSpan.FromDays(30);
						 options.SlidingExpiration = true;
						 options.LoginPath = new PathString("/admin/auth/signin");
						 options.LogoutPath = new PathString("/admin/auth/signin");
						 options.AccessDeniedPath = new PathString("/admin/System/error");

					 });


		}

		public static void ConfigureSwagger(this IServiceCollection services)
		{
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "BSynchroRJP", Version = "v1" });
				c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
				{
					Name = "Authorization",
					Type = SecuritySchemeType.ApiKey,
					Scheme = "Bearer",
					BearerFormat = "JWT",
					In = ParameterLocation.Header,
					Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
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
							new string[] {}

					}
				});
			});
		}

		public static void ConfigureMailKit(this IServiceCollection services, IConfiguration Configuration)
		{

			services.Configure<MailKitEmailSenderOptions>(options =>
			{
				options.Host_Address = Configuration["ExternalProviders:MailKit:SMTP:Address"];
				options.Host_Port = Convert.ToInt32(Configuration["ExternalProviders:MailKit:SMTP:Port"]);
				options.Host_Username = Configuration["ExternalProviders:MailKit:SMTP:Account"];
				options.Host_Password = Configuration["ExternalProviders:MailKit:SMTP:Password"];
				options.Sender_EMail = Configuration["ExternalProviders:MailKit:SMTP:SenderEmail"];
				options.Sender_Name = Configuration["ExternalProviders:MailKit:SMTP:SenderName"];
			});


		}


	}
}
