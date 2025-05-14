using Microsoft.EntityFrameworkCore;
using GenerateSVG.Data;
using GenerateSVG.Services.IServices;
using GenerateSVG.Services.Services; // DbContext burada olsun

var builder = WebApplication.CreateBuilder(args);

// Razor Pages veya MVC desteði
builder.Services.AddControllersWithViews();

// DbContext kaydý (örnek olarak SQLite)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=shapes.db"));

// Senin SVG servis kaydýn (interface ile)
builder.Services.AddScoped<ISvgBuilderService, SvgBuilderService>();

var app = builder.Build();

// Geliþtirme ortamý için hata sayfasý
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Temel middleware'ler
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Varsayýlan route ayarý (HomeController -> Index.cshtml gibi)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Shape}/{action=Create}/{id?}");

app.Run();
