using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using DatabaseScriptRunner.Domain.Entities;
using Microsoft.AspNetCore.Http;
using DatabaseScriptRunner.Infraestructure.Data;
using DatabaseScriptRunner.Infraestructure.DataManager;
using DatabaseScriptRunner.Infraestructure.Repository;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using DatabaseScriptRunner.Api.Controllers;

namespace DatabaseScriptRunner
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));
            // conectar com o banco

            services.AddDbContext<DatabaseContext>(opt => opt.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\NathanSilvaCosta\\Documents\\BancoNew.mdf;Integrated Security=True;Connect Timeout=30"));
            services.AddScoped<IDataRepository<Database>, DatabaseManager>();
            services.AddScoped<IDataRepository<User>, UserManager>();
            services.AddScoped<IDataRepository<ActionUser>, ActionUserManager>();
            services.AddScoped<IDataRepository<UserDatabase>,UseDatabaseManager>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("http://localhost:3000");
                });
            });

            ////
            //var key = Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:JWT_Secret"].ToString());

            //services.AddAuthentication(x =>
            //{
            //    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(x =>
            //{
            //    x.RequireHttpsMetadata = false;
            //    x.SaveToken = false;
            //    x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(key),
            //        ValidateIssuer = false,
            //        ValidateAudience = false,
            //        ClockSkew = TimeSpan.Zero
            //    };
            //});



            // TOKEN
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            })
            .AddJwtBearer("JwtBearer", jwtOptions =>
            {
                jwtOptions.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = TokenController.SIGNING_KEY,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(20)
                };
            });
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            ////
            //app.UseCors(builder =>
            //builder.WithOrigins(Configuration["ApplicationSettings:Client_URL"].ToString())
            //.AllowAnyHeader()
            //.AllowAnyMethod()
            //);
            //  app.UseCors(options => options.WithOrigins("http://localhost:3000"));

            app.UseCors(corsPolicyBuilder => corsPolicyBuilder.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader());
            //    app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthentication();
            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
