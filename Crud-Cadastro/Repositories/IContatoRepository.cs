using Crud_Cadastro.Models;

namespace Crud_Cadastro.Repositories;

public interface IContatoRepository
{
    ContatoModel ListForId(int id);
    List<ContatoModel> AllContacts();
    ContatoModel Add(ContatoModel contatoModel);
    ContatoModel Update(ContatoModel contatoModel);
    bool Delete(int id);
}