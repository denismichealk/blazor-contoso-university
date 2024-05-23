using BlazorContosoUniversity.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace BlazorContosoUniversity.Client;

public class Program
{
    static async Task Main(string[] args)
    {
        
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.Services.AddSingleton<StudentsServiceClient>();
        builder.Services.AddSingleton<DepartmentsServiceClient>();
        builder.Services.AddSingleton<CoursesServiceClient>();
        builder.Services.AddSingleton<InstructorsServiceClient>();
        builder.Services.AddSingleton<StatisticsServiceClient>();

        await builder.Build().RunAsync();
    }
}
