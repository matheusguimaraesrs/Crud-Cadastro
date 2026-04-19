using Crud_Cadastro.Data;
using Crud_Cadastro.Models;

namespace Crud_Cadastro.Repositories.Usuario;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly BdContext _dbContext;

    public UsuarioRepository(BdContext bdContext)
    {
        _dbContext = bdContext;
    }

    public UsuarioModel? GetByLogin(string login)
    {
        return _dbContext.Usuarios.FirstOrDefault(u => u.Login.ToUpper() == login.ToUpper());
    }

    public UsuarioModel? ListForId(int id)
    {
        return _dbContext.Usuarios.FirstOrDefault(u => u.Id == id);
    }

    public int AllUsers()
    {
        return  _dbContext.Usuarios.Count();
    }

    public List<UsuarioModel> PageUsers(int page, int pageSize)
    {
        int skip = (page - 1) * pageSize;
        return _dbContext.Usuarios
            .OrderBy(c => c.Id) // Define uma ordem estável para saber quem vem primeiro
            .Skip(skip) // Pula os primeiros x registros (x = skip)
            .Take(pageSize) // da posição x em diante, me dê somente os próximos 10 da lista
            .ToList();
    }

    public UsuarioModel Add(UsuarioModel usuario)
    {
        usuario.CreatedOn = DateTime.Now;
        _dbContext.Usuarios.Add(usuario);
        _dbContext.SaveChanges();
        return usuario;
    }

    public UsuarioModel Update(UsuarioModel usuario)
    {
        UsuarioModel dbUsuario = ListForId(usuario.Id);
        if (dbUsuario == null)
            throw new Exception("Erro de atualização!");
        
        dbUsuario.Name = usuario.Name; 
        dbUsuario.Email = usuario.Email; 
        dbUsuario.Login = usuario.Login;
        dbUsuario.Profile = usuario.Profile;
        dbUsuario.UpdatedOn = DateTime.Now;
        
        _dbContext.Update(dbUsuario);
        _dbContext.SaveChanges();
        
        return dbUsuario;
    }

    public bool Delete(int id)
    {
        UsuarioModel dbUsuario = ListForId(id);
        if (dbUsuario == null) 
            throw new Exception("Erro ao deletar!");

        _dbContext.Usuarios.Remove(dbUsuario);
        _dbContext.SaveChanges();
        return true;
    }
}
