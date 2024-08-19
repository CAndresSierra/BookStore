using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppStore.Models.Domain;

public class Libro
{
    [Key]
    [Required]
    public int Id {get;set;}

    public string? Title {get;set;}
    public string? CreateDate { get; set; }
    public string? Image {get;set;}

    [Required]
    public string? Author {get;set;}
    public virtual ICollection<Categoria>? CategoriaRelationList {get;set;}
    public virtual ICollection<LibroCategoria>? LibroCategoriaRelationList {get;set;}
    
    [NotMapped]
    public List<int>? Categorias { get; set; }

    [NotMapped]
    public string? categoriasNames { get; set; }
}