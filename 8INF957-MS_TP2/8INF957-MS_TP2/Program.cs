using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddMvc(option => option.EnableEndpointRouting = false);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,
        options => builder.Configuration.Bind("JwtSettings", options))
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
        options => builder.Configuration.Bind("CookieSettings", options));


//CreateWebHostBuilder(args).Build().Run()

var app = builder.Build();

app.UseStaticFiles();
app.UseMvc(routes => routes.MapRoute("Default", "{controller=Home}/{action=Connexion}"));


app.Run();

