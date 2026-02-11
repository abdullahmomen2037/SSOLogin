var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication()    
.AddGoogle(options =>
{
    options.ClientId = "77149603508-q299m1v1q93hkbev1o0q88q7sf58deds.apps.googleusercontent.com";
    options.ClientSecret = "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";
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();   // ✅ MUST BE HERE
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
