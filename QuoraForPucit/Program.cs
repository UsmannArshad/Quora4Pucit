using Microsoft.AspNetCore.Identity;
using QuoraForPucit;
using QuoraForPucit.Models;
using QuoraForPucit.Models.Interfaces;
using QuoraForPucit.Models.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IQuestionUpvoterRepository, QuestionUpvoterRepository>();
builder.Services.AddSingleton<IQuestionRepository, QuestionRepository>();
builder.Services.AddSingleton<IQuestionCommentsRepository, Q_Cmnts_Repo>();
builder.Services.AddSingleton<IAnswerRepository, AnswerRepostory>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<QuoraForPucit_DBContext>();
builder.Services.AddIdentity<UserwithIdentity, IdentityRole>().AddEntityFrameworkStores<QuoraForPucit_DBContext>();
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
app.UseAuthentication();
app.UseAuthorization();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
/*    pattern: "{controller=Login}/{action=SignIn}");*/
pattern: "{controller=Question}/{action=MainPage}/{id?}");
/* pattern: "{route=usermainpage}");*/

app.Run();
