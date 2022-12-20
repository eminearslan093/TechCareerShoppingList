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
 * cqrs te arabulucu. E�er ben mediator kullanmasayd�m tek tek  handle servis yazacakt�m -->     
 * builder.Services.AddScoped<CreateProductCommandHandler>;
 */
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());


//DbContext ayarlar�m� (olu�turdu�um DBContexte) verdi�im yer
builder.Services.AddDbContext<DBContext>(opt =>
{
    //connettion stringimi ayarlad���m yer//conStr app setting i�inde tan�mlad�m
    opt.UseSqlServer(builder.Configuration.GetConnectionString("LocalDb"));
});


/*/Dependecy injection Repository i�in metodlar�
//1)AddTransient--bir request i�inde 2 farkl� transit iste�i (ayr� ayr� iki nesne)
//2)AddSingleton(1 request i�erisinde birden fazla scopped �rne�i varsa, her �rnek i�in ayn� nesne gelir.Farkl� requestlerde nesne de�i�ir ama her istek i�in ayn�s� gelir yine
//3)AddScoped//ka� defa request atarsan at hep ayn� nesne �rne�i 
Repository mizi Irepository arac�l�yla �rnekledi�imiz yer
*/
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


//Mapping Services //bizim yerimize otomatik mapping leme yap�yor
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
 * 3 b�l�mden olu�ur
 * 1)header:Algoritma �ifreleme ve token type
 * 2)Payload : Data
 * 3)Verify signoture : imza(HMACSHA256 genelde kullan�lan)
 */
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false;//http ile �al��t���m i�in false yapt�m.
    opt.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidAudience = JwtTokenSettings.Audience,//linleyici localde dinliyorum.jwttoken setting te gereki ayar� yapt�m.
        ValidIssuer = JwtTokenSettings.Issuer,//Yay�nca // localde yay�n yap�yorum. yay�n de�i�ince de�i�tirme gerekecek. 
        ClockSkew = TimeSpan.Zero,
        ValidateLifetime = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenSettings.Key)),//16 karekterden fazla ver.
        /*3 t�r �ifreleme var
          //ak�n hocam�z 32 karekter yapt�.Fakl� bir kullan�m� �ekli ile 
         //google de bir �rnekte de 16 karekte li diye g�rd�m Minumum mu ????. Ara�t�r. Anlayamad�m

        1)Symetrik: �ifreyi yay�nlayanda, dinleyende ayn� key ile �al���yor. Data kayb� yok
        2)Asimetrik
        3)Hash : Data bu yolla �ifrelendi�inde art�k kaybolur. Daha ��zemeyiz biz o datay�
         */


        ValidateIssuerSigningKey = true//�ifreyi ge�erli k�l
    };
});

var app = builder.Build();

//kimlik do�rulama
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



