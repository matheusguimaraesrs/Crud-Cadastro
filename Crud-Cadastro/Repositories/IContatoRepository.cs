using Crud_Cadastro.Models;

namespace Crud_Cadastro.Repositories;

public interface IContatoRepository
{
    List<ContatoModel> AllContacts();
    ContatoModel Add(ContatoModel contatoModel);
}