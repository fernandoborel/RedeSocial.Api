using RedeSocial.Api.Extensions;
using RedeSocial.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//caixa baixa nos endpoints
builder.Services.AddRouting(map => map.LowercaseUrls = true);

//extensions
builder.Services.AddSwaggerConfig();
builder.Services.AddJwtBearer(builder.Configuration);
builder.Services.AddMongoDB(builder.Configuration);
builder.Services.AddDependencyInjection();
builder.Services.AddCorsConfig();

var app = builder.Build(); //deploy

app.UseStaticFiles(); //habilita a wwwroot
app.UseMiddleware<ExceptionMiddleware>();
app.UseSwaggerConfig();
app.UseCorsConfig();
app.UseAuthorization();
app.MapControllers();

app.Run();//executa o projeto
