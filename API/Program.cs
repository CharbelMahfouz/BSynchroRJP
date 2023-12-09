using BLL;

using BLL.Utilities.Extensions;
using BLL.Utilities.Extensions.ServiceExtensions;
using BLL.Utilities.Logging;
using LoggerService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using NLog;
using System.Configuration;
using System.IO;
var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<ApiBehaviorOptions>(options
  =>
{
    options.SuppressModelStateInvalidFilter = true;
});
builder.Services.AddCors();
IdentityModelEventSource.ShowPII = true;
builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureAuthentication();
builder.Services.ConfigureMailKit(builder.Configuration);
new ServiceInjector(builder.Services).RenderAPI();
builder.Services.AddSingleton<ILoggerManager, LoggerManager>();
builder.Services.AddRazorPages();
builder.Services.ConfigureSwagger();


var app = builder.Build();

app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader()
            .WithMethods("GET", "POST", "OPTIONS", "PUT", "DELETE")
            );
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BSynchro-RJP v1"));
}
app.ConfigureCustomExceptionMiddleware();
app.UseSwagger();
if (builder.Environment.IsProduction())
{
    app.UseSwaggerUI(c =>
    {
        //c.SwaggerEndpoint("/webapi/swagger/v1/swagger.json", "Template v1");
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "BSynchro-RJP v1");
        c.DisplayRequestDuration();
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
//logger Custom
//app.ConfigureCustomApiLoggingMiddleware();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});



