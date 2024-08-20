using System.ComponentModel.DataAnnotations;

namespace AppStore.Models.Dto;

public class LoginModel
{
    [Required]
    public string? UserName {get;set;}
    [Required]
    public string? Password {get;set;}
}