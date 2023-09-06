using DataExtractionAWSData;
using DataExtractionRepository;
using DataExtractionService.Srvc;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
var corsBuilder = new CorsPolicyBuilder();
// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
                    builder => builder.WithOrigins("http://localhost:4200", "https://testing")
                                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                                        .SetIsOriginAllowed((host) => true)
                                        .AllowAnyHeader()
                                        .AllowAnyMethod()
                                        .AllowCredentials());
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddMvc();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
ServiceRegistration.RegisterServices(builder.Services);

RepositoryRegistration.RegisterServices(builder.Services);

ContextRegistration.ContextServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("CorsPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
