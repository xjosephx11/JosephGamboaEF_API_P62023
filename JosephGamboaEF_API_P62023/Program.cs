using JosephGamboaEF_API_P62023.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace JosephGamboaEF_API_P62023
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            var CnnStrBuilder = new SqlConnectionStringBuilder(builder.Configuration.GetConnectionString("CNNSTR"));
            CnnStrBuilder.Password = "123456";
            string cnnStr = CnnStrBuilder.ConnectionString;
            builder.Services.AddDbContext<AnswersDBContext>(options => options.UseSqlServer(cnnStr));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}