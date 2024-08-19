

using AppStore.Models.Domain;
using AppStore.Models.Dto;
using AppStore.Repositories.Abstract;

namespace AppStore.Repositories.Implementation;

public class LibroService : ILibroService
{
    private readonly DatabaseContext ctx;

    public LibroService(DatabaseContext ctxParameter)
    {
      ctx = ctxParameter;
    }

    public bool Add(Libro libro)
    {
       try{
          ctx.Libros.Add(libro);
          ctx.SaveChanges();

          foreach(int categoriaId in libro.Categorias!)
          {
                var libroCategoria = new LibroCategoria
                {
                    LibroId = libro.Id,
                    CategoriaId = categoriaId
                };

                ctx.LibroCategorias.Add(libroCategoria);
          }
          ctx.SaveChanges();

          return  true;

       } catch(Exception)
       {
        return false;
       }
    
    }

    public bool Delete(int id)
    {
        try
        {
            var data = GetById(id);
            if(data is null){
                return false;
            }

            var libroCategorias = ctx.LibroCategorias.Where(a => a.LibroId == data.Id); 
            ctx.LibroCategorias.RemoveRange(libroCategorias);
            ctx.Libros.Remove(data);

            ctx.SaveChanges();

            return true;

        }catch(Exception){
            return false;
        };
    }

     public bool Update(Libro libro)
    {
       try{
          
          var deleteCategories = ctx.LibroCategorias.Where(a => a.LibroId == libro.Id);
          ctx.LibroCategorias.RemoveRange(deleteCategories);

          foreach(int categoriaId in libro.Categorias!)
          {
            var libroCategoria = new LibroCategoria
            {
              CategoriaId = categoriaId,
              LibroId = libro.Id
            };
            ctx.LibroCategorias.Add(libroCategoria);
          }
          ctx.Libros.Update(libro);
          ctx.SaveChanges();

          return true;


       }catch(Exception)
       {
          return false;
       }
    }

    public Libro GetById(int id)
    {
       return ctx.Libros.Find(id)!;
    }

   
    public LibroListvm List(string term = "", bool paging = false, int currentPage = 0)
    {
        var data = new LibroListvm();
        var list = ctx.Libros.ToList();

        if(!string.IsNullOrEmpty(term))
        {
            term = term.ToLower();
            list = list.Where(a => a.Title!.ToLower().StartsWith(term)).ToList();
        }

        if(paging)
        {
            int pageSize = 5;
            int count = list.Count;
            int totalPages = (int)Math.Ceiling(count/(double)pageSize);
            
            list = list.Skip((currentPage - 1 )* pageSize).Take(pageSize).ToList();
            data.PageSize = pageSize;
            data.TotalPages = totalPages;
            data.CurrentPage = currentPage;

        }

         foreach(var libro in list)
        {
            var categorias = (
                from categoria in ctx.Categorias
                join lc in ctx.LibroCategorias!
                on categoria.Id equals lc.CategoriaId
                where lc.LibroId == libro.Id
                select categoria.Name
            ).ToList();
            string categoriaNombres = string.Join(",", categorias); // drama, horror, accion
            libro.categoriasNames = categoriaNombres;
        }

        data.LibroList = list.AsQueryable();



        return data;
    }

     public List<int> GetCategoriaByLibroId(int libroId)
    {
        return ctx.LibroCategorias.Where(a => a.LibroId == libroId).Select(a => a.CategoriaId).ToList();
    }


   
}