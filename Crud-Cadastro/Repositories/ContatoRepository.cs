using Crud_Cadastro.Data;
using Crud_Cadastro.Models;

namespace Crud_Cadastro.Repositories;

public class ContatoRepository : IContatoRepository
{
    private readonly BdContext _dbContext;
    public ContatoRepository(BdContext bdContext)
    {
        _dbContext = bdContext;
    }

    public List<ContatoModel> AllContacts()
    {
        return _dbContext.Contatos.ToList();
    }

    public ContatoModel Add(ContatoModel contato)
    {
        _dbContext.Contatos.Add(contato);
        _dbContext.SaveChanges();
        return contato;
    }
}
