

namespace AppStore.Models.Domain;

public class LibroCategoria
{
    
    public int Id { get; set; }
    public int CategoriaId{get;set;}
    public int LibroId{get;set;}
    public Categoria? Categoria{get;set;}
    public Libro? Libro{get;set;}
}