using FastEndpoints;
using FastEndpoints.Swagger;
using CleanArchitecture.Application;
using CleanArchitecture.Infrastructure;
using CleanArchitecture.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddFastEndpoints();

builder.Services.SwaggerDocument(options =>
{
    options.DocumentSettings = settings =>
    {
        settings.Title = "Clean Architecture API";
        settings.Version = "v1";
        settings.Description = "Clean Architecture API Model.";
    };
    options.AutoTagPathSegmentIndex = 0;
});

builder.Services.AddLocalization(options =>
{
    options.ResourcesPath = "Resources";
});

var supportedCultures = new[] { "en-US", "pt-BR" };

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("pt-BR");
    options.SupportedCultures = supportedCultures.Select(c => new System.Globalization.CultureInfo(c)).ToList();
    options.SupportedUICultures = supportedCultures.Select(c => new System.Globalization.CultureInfo(c)).ToList();
});

builder.Services.Configuration(builder.Configuration.GetConnectionString("DefaultConnection")!);
builder.Services.AddRepositories();
builder.Services.AddApplicationServices();
builder.Services.AddReadGateways();
builder.Services.AddExceptionHandler<ExceptionMiddleware>();
builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseRequestLocalization();

app.UseExceptionHandler();
app.UseFastEndpoints();

app.UseOpenApi();
app.UseSwaggerUi();

app.Run();