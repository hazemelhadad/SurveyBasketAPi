
using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using SurveyBaskets.BLL.Interface;
using SurveyBaskets.BLL.Services;
using SurveyBaskets.DAL.Entities;
using SurveyBaskets.DAL.Persistence;
using System.Reflection;

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
