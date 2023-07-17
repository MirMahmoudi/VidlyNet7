using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VidlyNet7.Presentation.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
	.AddEntityFrameworkStores<ApplicationDbContext>();

// AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllersWithViews();

// Swagger Config
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
	option.SwaggerDoc("v1",
		new Microsoft.OpenApi.Models.OpenApiInfo
		{
			Title = "v1",
			Description = "Swagger for Vidly Apis",
			Version = "v1"
		});
});

var app = builder.Build();

// Configure the HTTP request pipeline.   //// Swagger
if (app.Environment.IsDevelopment())
{
	app.UseMigrationsEndPoint();
	app.UseSwagger(option =>
	{
		option.RouteTemplate = "Vidly/{documentName}/swagger.json";

	});
	app.UseSwaggerUI(option =>
	{
		option.SwaggerEndpoint("/Vidly/v1/swagger.json", "Vidly");
		option.RoutePrefix = "Vidly";
	});
}
else
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
