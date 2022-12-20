using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using TechCareerShoppingList.Back.Application.Interfaces;
using TechCareerShoppingList.Back.Application.Mappings;
using TechCareerShoppingList.Back.Data.Context;
using TechCareerShoppingList.Back.Data.Repositories;
using TechCareerShoppingList.Back.Tools.JwtTools;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//MediatR servises
/*
 * cqrs te arabulucu. Eðer ben mediator kullanmasaydým tek tek  handle servis yazacaktým -->     
 * builder.Services.AddScoped<CreateProductCommandHandler>;
 */
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());


//DbContext ayarlarýmý (oluþturduðum DBContexte) verdiðim yer
builder.Services.AddDbContext<DBContext>(opt =>
{
    //connettion stringimi ayarladýðým yer//conStr app setting içinde tanýmladým
    opt.UseSqlServer(builder.Configuration.GetConnectionString("LocalDb"));
});


/*/Dependecy injection Repository için metodlarý
//1)AddTransient--bir request içinde 2 farklý transit isteði (ayrý ayrý iki nesne)
//2)AddSingleton(1 request içerisinde birden fazla scopped örneði varsa, her örnek için ayný nesne gelir.Farklý requestlerde nesne deðiþir ama her istek için aynýsý gelir yine
//3)AddScoped//kaç defa request atarsan at hep ayný nesne örneði 
Repository mizi Irepository aracýlýyla örneklediðimiz yer
*/
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


//Mapping Services //bizim yerimize otomatik mapping leme yapýyor
builder.Services.AddAutoMapper(opt =>
{
    opt.AddProfiles(new List<Profile>()
            {
                new ProductProfile(),
                new CategoryProfile(),
                new ShoppingListProfile(),
            });
});



/*Jwt service
 * 3 bölümden oluþur
 * 1)header:Algoritma þifreleme ve token type
 * 2)Payload : Data
 * 3)Verify signoture : imza(HMACSHA256 genelde kullanýlan)
 */
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false;//http ile çalýþtýðým için false yaptým.
    opt.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidAudience = JwtTokenSettings.Audience,//linleyici localde dinliyorum.jwttoken setting te gereki ayarý yaptým.
        ValidIssuer = JwtTokenSettings.Issuer,//Yayýnca // localde yayýn yapýyorum. yayýn deðiþince deðiþtirme gerekecek. 
        ClockSkew = TimeSpan.Zero,
        ValidateLifetime = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenSettings.Key)),//16 karekterden fazla ver.
        /*3 tür þifreleme var
          //akýn hocamýz 32 karekter yaptý.Faklý bir kullanýmý þekli ile 
         //google de bir örnekte de 16 karekte li diye gördüm Minumum mu ????. Araþtýr. Anlayamadým

        1)Symetrik: þifreyi yayýnlayanda, dinleyende ayný key ile çalýþýyor. Data kaybý yok
        2)Asimetrik
        3)Hash : Data bu yolla þifrelendiðinde artýk kaybolur. Daha çözemeyiz biz o datayý
         */


        ValidateIssuerSigningKey = true//þifreyi geçerli kýl
    };
});

var app = builder.Build();

//kimlik doðrulama
app.UseAuthentication();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//yetki
app.UseAuthorization();

app.MapControllers();

app.Run();



