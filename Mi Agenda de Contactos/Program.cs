using Mi_Agenda_de_Contactos.Migrations;
using Microsoft.EntityFrameworkCore;

namespace Mi_Agenda_de_Contactos
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
           
            builder.Services.AddDbContext<AgendaContext>(dbContextOptions => dbContextOptions.UseSqlite(  //para crear el contexto de Entity frk
                builder.Configuration["ConnectionStrings:AgendaAPIDBConnectionString"])); // connection string, se suele mandar en otro archivo
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