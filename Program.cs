using Microsoft.EntityFrameworkCore;
using LockAiAPI.Data;

var builder = WebApplication.CreateBuilder(args);


//builder.Services.AddDbContext<DataContext>(options =>
//  options.UseInMemoryDatabase("TestDB"));

/*builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer("Server=localhost,1433;Database=LockAiDb;User Id=sa;Password=*123456HAS*;TrustServerCertificate=True;"));
*/

builder.Services.AddDbContext<DataContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoSomee"));
    });


builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
