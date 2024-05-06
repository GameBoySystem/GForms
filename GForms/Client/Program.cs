global using GForms.Client.Services.TestService;
//global using GForms.Client.Services.QuestionService;
global using GForms.Shared;
using GForms.Client;
using GForms.Client.Services.AnswerService;
using GForms.Client.Services.AnswerVariantService;
using GForms.Client.Services.QuestionService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("GForms.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("GForms.ServerAPI"));
builder.Services.AddScoped<ITestService, TestService>();
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IAnswerVariantService, AnswerVariantService>();
builder.Services.AddScoped<IAnswerService, AnswerService>();

builder.Services.AddMudServices();
builder.Services.AddApiAuthorization();

await builder.Build().RunAsync();
