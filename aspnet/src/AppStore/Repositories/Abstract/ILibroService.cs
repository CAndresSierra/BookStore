using AppStore.Models.Domain;
using AppStore.Models.Dto;

namespace AppStore.Repositories.Abstract;

public interface ILibroService
{
    bool Add(Libro libro);

    bool Update(Libro libro);

    Libro GetById(int id);

    bool Delete(int id);

    LibroListvm List(string term="", bool paging = false, int currentPage = 0);

    List<int> GetCategoriaByLibroId(int libroId);
}