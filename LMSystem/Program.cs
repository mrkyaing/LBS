using LMSystem.DAO;
using LMSystem.Services;
using LMSystem.Services.ReportingServices;
using LMSystem.UnitOfWorks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
var config = builder.Configuration;
builder.Services.AddDbContext<LMSystemDbContext>(o =>
o.UseSqlServer(config.GetConnectionString("LMSystemConnectionstring")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IAuthorService, AuthorService>();
builder.Services.AddTransient<IPublisherService, PublisherService>();
builder.Services.AddTransient<IMemberService, MemberService>();
builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<IIssueBookService, IssueBookService>();
builder.Services.AddTransient<IOverDueBookService, OverDueBookService>();
builder.Services.AddTransient<IReturnBookService, ReturnBookService>();
builder.Services.AddRazorPages();
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<LMSystemDbContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
