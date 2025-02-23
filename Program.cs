using Microsoft.EntityFrameworkCore;
using ProjectManagerM_LGroupAB.Data;
using ProjectManagerM_LGroupAB.Repositories;
using ProjectManagerM_LGroupAB.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
//Kopierat från AI
builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IProjectService, ProjectService>();

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowFrontend",
		policy =>
		{
			policy.WithOrigins("http://localhost:3000") // React-appen körs här
				  .AllowAnyMethod()
				  .AllowAnyHeader();
		});
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


app.UseSwagger();
app.UseSwaggerUI();

app.UseHsts();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.UseCors("AllowFrontend");
app.Run();
