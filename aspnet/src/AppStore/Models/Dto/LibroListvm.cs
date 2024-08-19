using AppStore.Models.Domain;

namespace AppStore.Models.Dto;

public class LibroListvm
{
    public IQueryable<Libro>? LibroList { get; set; }

    public int PageSize { get; set; }

    public int CurrentPage { get; set; }

    public int TotalPages { get; set; }

    public string? Term { get; set; } 
    
}