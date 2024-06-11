using HippoRecipeApi.Models;
using HippoRecipeApi.Services;
using HippoRecipeApi.Services.RecipeServices;
using HippoRecipeApi.Services.TagServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson(
    options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    }
    );
builder.Services.AddCors(options => 
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                        policy => 
                        {
                            policy.WithOrigins("http://localhost:5037", 
                            "http://localhost:3000").AllowAnyHeader().AllowAnyMethod();
                        });
});
builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddScoped<IIngredientService, IngredientService>();
builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);

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