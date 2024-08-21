using AppStore.Models.Domain;
using AppStore.Repositories.Abstract;

namespace AppStore.Repositories.Implementation;


public class CategoriaService : ICategoriaService
{

    private readonly DatabaseContext ctx;

    public CategoriaService(DatabaseContext ctx)
    {
        this.ctx = ctx;
    }

    public IQueryable<Categoria> List()
    {
        return ctx.Categorias.AsQueryable();

    }
}