using Crud_Cadastro.Data;
using Crud_Cadastro.Repositories.Contato;
using Crud_Cadastro.Repositories.Usuario;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Verifica se o ambiente é Desenvolvimento
if (builder.Environment.IsDevelopment())
{
    // Se for, SQL Server localmente
    builder.Services.AddDbContext<BdContext>(
        o => o.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));
}
else
{
    // Se não, use SQLite para hospedar gratuitamente
    builder.Services.AddDbContext<BdContext>(o => o.UseSqlite("Data Source=database.db"));
}
builder.Services.AddScoped<IContatoRepository, ContatoRepository>(); //Pesquisar sobre injeção de dependência 
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>(); //Pesquisar sobre injeção de dependência 

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<BdContext>();
        context.Database.Migrate(); // Isso cria o banco e aplica as tabelas
    }
    catch (Exception ex)
    {
        Console.WriteLine("Erro ao aplicar migrations: " + ex.Message);
    }
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Login}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();