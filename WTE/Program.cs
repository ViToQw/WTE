var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.Run();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//        name: "default",
//        pattern: "{controller=Home}/{action=Index}/{id?}");
//    endpoints.MapControllerRoute(
//        name: "recipe",
//        pattern: "RecipeCards/Index",  // Это маршрут для RecipeCards/Index
//        defaults: new { controller = "RecipeCards", action = "Index" });
//    endpoints.MapControllerRoute(
//        name: "account",
//        pattern: "Account/Profile",  // Это маршрут для Account/Profile
//        defaults: new { controller = "Account", action = "Profile" });
//});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(
        name: "recipe",
        pattern: "RecipeCards/Index",  // Это маршрут для RecipeCards/Index
        defaults: new { controller = "RecipeCards", action = "Index" });
    endpoints.MapControllerRoute(
        name: "account",
        pattern: "Account/Profile",  // Это маршрут для Account/Profile
        defaults: new { controller = "Account", action = "Profile" });
});


