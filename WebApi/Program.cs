var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//BLOQUEO DE CONSULTAS EXTERNAS AL SERVIDOR API
//El * permite la consulta en cualquier dominio
builder.Services.AddCors(policyBuilder => policyBuilder.AddDefaultPolicy
                        (policy => policy.WithOrigins("*").AllowAnyHeader().AllowAnyMethod()));


//
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
