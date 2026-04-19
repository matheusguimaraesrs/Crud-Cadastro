using Crud_Cadastro.Models;

namespace Crud_Cadastro.Repositories.Usuario;

public interface IUsuarioRepository
{
    UsuarioModel ListForId(int id);
    int AllUsers();
    List<UsuarioModel> PageUsers(int page, int pageSize);
    UsuarioModel Add(UsuarioModel usuarioModel);
    UsuarioModel Update(UsuarioModel usuarioModel);
    bool Delete(int id);
}