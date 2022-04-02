var builder = WebApplication.CreateBuilder(args);


builder.Services.AddMvc(option => option.EnableEndpointRouting = false);




var app = builder.Build();

app.UseStaticFiles();
app.UseMvc(routes => routes.MapRoute("Default", "{controller=Home}/{action=Connexion}"));


app.Run();

