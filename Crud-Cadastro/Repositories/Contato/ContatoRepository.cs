using Crud_Cadastro.Data;
using Crud_Cadastro.Models;

namespace Crud_Cadastro.Repositories.Contato;

public class ContatoRepository : IContatoRepository
{
    private readonly BdContext _dbContext;
    public ContatoRepository(BdContext bdContext)
    {
        _dbContext = bdContext;
    }

    public ContatoModel? ListForId(int id)
    {
        return _dbContext.Contatos.FirstOrDefault(c => c.Id == id);
    }

    public int AllContacts()
    {
        return  _dbContext.Contatos.Count();
    }

    public List<ContatoModel> PageContacts(int page, int pageSize)
    {
        int skip = (page - 1) * pageSize;
        return _dbContext.Contatos
            .OrderBy(c => c.Id) // Define uma ordem estável para saber quem vem primeiro
            .Skip(skip) // Pula os primeiros x registros (x = skip)
            .Take(pageSize) // da posição x em diante, me dê somente os próximos 10 da lista
            .ToList();
    }

    public ContatoModel Add(ContatoModel contato)
    {
        _dbContext.Contatos.Add(contato);
        _dbContext.SaveChanges();
        return contato;
    }

    public ContatoModel Update(ContatoModel contato)
    {
        ContatoModel dbContato = ListForId(contato.Id);
        if (dbContato == null)
            throw new Exception("Erro de atualização!");
        
        dbContato.Name = contato.Name; 
        dbContato.Email = contato.Email; 
        dbContato.Contact = contato.Contact;
        
        _dbContext.Update(dbContato);
        _dbContext.SaveChanges();
        
        return dbContato;
    }

    public bool Delete(int id)
    {
        ContatoModel dbContato = ListForId(id);
        if (dbContato == null) 
            throw new Exception("Erro ao deletar!");

        _dbContext.Contatos.Remove(dbContato);
        _dbContext.SaveChanges();
        return true;
    }
}
