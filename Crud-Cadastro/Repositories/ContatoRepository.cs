using Crud_Cadastro.Data;
using Crud_Cadastro.Models;
using Microsoft.EntityFrameworkCore;

namespace Crud_Cadastro.Repositories;

public class ContatoRepository : IContatoRepository
{
    private readonly BdContext _dbContext;
    public ContatoRepository(BdContext bdContext)
    {
        _dbContext = bdContext;
    }

    public ContatoModel ListForId(int id)
    {
        return _dbContext.Contatos.FirstOrDefault(c => c.Id == id);
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
