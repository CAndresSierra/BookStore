

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AppStore.Models.Domain;

public class LoadDatabase
{
    public static async Task InsertarData(DatabaseContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
      if(!roleManager.Roles.Any())
      {
         await roleManager.CreateAsync(new IdentityRole("ADMIN"));
      }

      if(!userManager.Users.Any())
      {
        var usuario = new ApplicationUser {
            Nombre = "Camilo Sierra",
            Email = "csierra@mail.com",
            UserName = "BUSHIDO"
        };

        await userManager.CreateAsync(usuario, "Camilo2702@");
        await userManager.AddToRoleAsync(usuario, "ADMIN");

      }
         
         

      if(!context.Categorias.Any())
      {
        await context.Categorias.AddRangeAsync(
            new Categoria { Name = "Fantasia", },
            new Categoria { Name = "Drama", },
            new Categoria { Name = "Comedia", },
            new Categoria { Name = "Accion", },
            new Categoria { Name = "Terror", },
            new Categoria { Name = "Aventura", }

        );

        await context.SaveChangesAsync();
      }

      if(!context.Libros.Any())
      {

       

        await context.Libros.AddRangeAsync(
            new Libro {
             Title = "Don Quijote de la mancha",
             CreateDate = "20/05/2003", 
             Image = "quijote.jpg", 
             Author = "J. R. R. Tolkien"
             },

            new Libro {
             Title = "Harry Potter",
             CreateDate = "26/06/1997", 
             Image = "harryPotter.jpg", 
             Author = "J. K. Rowling"
             },

            new Libro {
             Title = "La Catedral",
             CreateDate = "30/06/2002", 
             Image = "catedral.jpg", 
             Author = "Cesar Mallorqui"
             },

            new Libro {
             Title = "Cien Años de soledad",
             CreateDate = "26/06/1967", 
             Image = "cien.jpg", 
             Author = "Gabriel Garcia Marquez"
             },

            new Libro {
             Title = "Lazarillo de Tormes",
             CreateDate = "13/02/1554", 
             Image = "lazarillo.jpg", 
             Author = "Diego Hurtado de Mendoza"
             }



        );

        await context.SaveChangesAsync();
      }

      if(!context.LibroCategorias.Any())
      {
        await context.LibroCategorias.AddRangeAsync(
            new LibroCategoria {CategoriaId = 1, LibroId = 1},
            new LibroCategoria {CategoriaId = 2, LibroId = 2}

           
        );
         await context.SaveChangesAsync();
      }
    }
}