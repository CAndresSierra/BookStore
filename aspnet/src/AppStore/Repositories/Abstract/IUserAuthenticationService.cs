using Appstore.Models.Dto;
using AppStore.Models.Dto;

namespace AppStore.Repositories.Abstract;

public interface IUserAuthenticationService
{

     Task<Status> LoginAsync(LoginModel login);

     Task LogoutAsync();

}