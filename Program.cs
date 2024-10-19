using Backend.services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//builder.Services.AddSingleton<IPersonaServices, PersonaServices2>();

builder.Services.AddKeyedSingleton<IPersonaServices, PersonaServices>("personaservice");
builder.Services.AddKeyedSingleton<IPersonaServices, PersonaServices2>("personaservice2");

builder.Services.AddKeyedSingleton<IRamdonServices, RamdonServices>("randomSingleton");
builder.Services.AddKeyedSingleton<IRamdonServices, RamdonServices>("randomScope");
builder.Services.AddKeyedSingleton<IRamdonServices, RamdonServices>("randomTrasient");

builder.Services.AddSingleton<IPersonaServices, PersonaServices>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

