var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);

var app = builder.Build();

app.UseStaticFiles();

app.UseMvc(routes => routes.MapRoute("Default", "{controller=Home}/{action=Informations}"));

app.Run();
