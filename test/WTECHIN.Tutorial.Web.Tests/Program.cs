using Microsoft.AspNetCore.Builder;
using WTECHIN.Tutorial;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
builder.Environment.ContentRootPath = GetWebProjectContentRootPathHelper.Get("WTECHIN.Tutorial.Web.csproj"); 
await builder.RunAbpModuleAsync<TutorialWebTestModule>(applicationName: "WTECHIN.Tutorial.Web");

public partial class Program
{
}
