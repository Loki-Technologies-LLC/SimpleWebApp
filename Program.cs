using Microsoft.Extensions.Configuration;
using Microsoft.Azure.AppConfiguration.AspNetCore;
using Azure.Identity;

const string AppConfigConnectionStringKey = "Endpoints:AppConfiguration";
const string SettingsPrefix = "MyApp:Settings";

var builder = WebApplication.CreateBuilder(args);

// Retrieve the endpoint
string endpoint = builder.Configuration.GetValue<string>(AppConfigConnectionStringKey)
    ?? throw new InvalidOperationException($"The setting `{AppConfigConnectionStringKey}` was not found.");

// Load configuration from Azure App Configuration (Azure CLI must be logged in for this to work and your ID must have access
// to the App Configuration instance.
// In production, the Managed Identity for the App Service will have this access, as you would need to configure that as well
builder.Configuration.AddAzureAppConfiguration(options =>
{
    options.ConfigureKeyVault(keyVaultOptions =>
    {
        keyVaultOptions.SetCredential(new DefaultAzureCredential());
    });
    
    options.Connect(new Uri(endpoint), new DefaultAzureCredential());
});

// Add services to the container.
builder.Services.AddRazorPages();

// Bind configuration "MyApp:Settings" section to the Settings object
builder.Services.Configure<SharpWebApp.Settings>(builder.Configuration.GetSection(SettingsPrefix));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
