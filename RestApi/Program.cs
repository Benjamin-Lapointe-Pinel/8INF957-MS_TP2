var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc(option => option.EnableEndpointRouting = false);
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseMvc();
app.UseSwagger();
app.UseSwaggerUI();
app.Run();