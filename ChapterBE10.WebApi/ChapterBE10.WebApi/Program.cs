using Chapter.WebApi.Contexts;
using ChapterBE10.WebApi.Interfaces;
using ChapterBE10.WebApi.Repositories;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ChapterContext, ChapterContext>();
builder.Services.AddTransient<ILivroRepository, LivroRepository>();  
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddControllers();

// adicionado servico de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => 
    {
        builder.WithOrigins("http://localhosto:3000")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

// adicionado servico de jwt bearer = forma de autenticacao
builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
})
// define os parametros de validacao do token
.AddJwtBearer("JwtBearer", options =>
 {
     options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
     {
         //valida quem esta solicitando
         ValidateIssuer = true,
         //valida quem esta recebendo
         ValidateAudience = true,
         //define se o tempo de expirassao sera validado
         ValidateLifetime = true,
         //forma de criptografia e ainda valida a chave de autenticacao
         IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("chapterbe10-key-authenticator")),
         //valida o tempo de expirassao do token
         ClockSkew = TimeSpan.FromMinutes(20),
         //nome do Issuer, de onde esta vindo
         ValidIssuer = "ChapterBE10.WebApi",
         //nome do audience, para onde esta indo
         ValidAudience = "ChapterBE10.WebApi"

     };
 });

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

app.UseCors("CorsPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
