using Crud_Cadastro.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud_Cadastro.Data;

public class BdContext : DbContext
{
    public BdContext(DbContextOptions<BdContext> options) : base(options)
    {
    }
    
    public DbSet<ContatoModel> Contatos { get; set; }
    public DbSet<UsuarioModel> Usuarios { get; set; }
}