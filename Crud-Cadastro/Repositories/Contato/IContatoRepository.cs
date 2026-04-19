using Crud_Cadastro.Models;

namespace Crud_Cadastro.Repositories.Contato;

public interface IContatoRepository
{
    ContatoModel ListForId(int id);
    int AllContacts();
    List<ContatoModel> PageContacts(int page, int pageSize);
    ContatoModel Add(ContatoModel contatoModel);
    ContatoModel Update(ContatoModel contatoModel);
    bool Delete(int id);
}