using System;
using System.Net.Http;
using KraftKollen.Components;
using KraftKollen.Helpers;
using KraftKollen.Helpers.Interfaces;
using KraftKollen.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;



namespace KraftKollen;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();
        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri ("http://api.kolada.se/")});
        builder.Services.AddScoped<IApiService, ApiService>();
        builder.Services.AddScoped<IYearComparisonIndicator, YearComparisonIndicator>();
        builder.Services.AddScoped<ICalculateProcentage, CalculateProcentage>();
        builder.Services.AddScoped<ITrendCalculator, TrendCalculator>();
        builder.Services.AddScoped<ITopProduction, TopProduction>();
        builder.Services.AddScoped<IAverageProduction, AverageProduction>();
        builder.Services.AddAutoMapper(typeof(MappingProfile));
        builder.Services.AddScoped<ICalculateProductionDifference, CalculateProductionDifference>();
        builder.Services.AddScoped<ICalculateResultsInGwhAndTwh, CalculateResultsInGwhAndTwh>();

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
        app.UseAntiforgery();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.Run();
    }
}