using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;
using Services.C.Core.Enums;
using Services.C.Core.Events;
using Services.C.Core.Handlers;
using Services.C.Core.Helpers;
using Services.C.Core.Interfaces;
using Services.C.Core.Models;
using Services.C.Shared;

var builder = WebApplication.CreateBuilder(args);

#region *** ConfigureServices
var appSettings = builder.Configuration.GetSection(nameof(AppSettings));
builder.Services.Configure<AppSettings>(appSettings);

var jwtSettings = builder.Configuration.GetSection(nameof(JwtSettings)).ToJWTSettings();
builder.Services.ConfigureJwtSettings(jwtSettings);
builder.Services.AddJWTAuthentication(jwtSettings);

builder.Services.ConfigureRepositories();
builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Service C", Version = "v1" });
});

builder.Services.AddHttpClient();
#endregion

var app = builder.Build();

#region *** Configure
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Service C v1"));
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

var eventBus = app.Services.GetRequiredService<IEventBus>();
eventBus.Subscribe<ServiceCDEvent, ServiceCDEventHandler>(ExchangeTypes.Fanout);
#endregion

app.Run();
