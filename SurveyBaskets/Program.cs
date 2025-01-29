
using MapsterMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SurveyBaskets.BLL.Authentication;
using SurveyBaskets.BLL.Interface;
using SurveyBaskets.BLL.Services;
using SurveyBaskets.DAL.Entities;
using SurveyBaskets.DAL.Persistence;
using System.Reflection;
using System.Text;

namespace SurveyBaskets
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // add mapster
            var mapConfig = TypeAdapterConfig.GlobalSettings;
            mapConfig.Scan(Assembly.GetExecutingAssembly());
            builder.Services.AddSingleton<IMapper>(new Mapper(mapConfig));

            //add database and DB Context Configurations
            var connection=builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationDBContext>(options=>options.UseSqlServer(connection));
            builder.Services.AddScoped<IPollServices, PollServices>();
            builder.Services.AddScoped<IAuthServices, AuthServices>();

            //authentication
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDBContext>();
            builder.Services.AddSingleton<IJwtProvider,JwtProvider>();

            // ????? ??? ?? ?? ??? ????? ?????? ????? ???? ???? ??? ????? ???????? 
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("tyffdKAInPGk2EgXx6G6l26BL7gdj1wO")),
                        ValidIssuer = "SurveyBasket",
                        ValidAudience = "Hazem"
                    };
                });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
