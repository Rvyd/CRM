using Entities.Dtos;
using Microsoft.AspNetCore.Identity;

namespace Services.Contracts
{
    public interface IAuthService
    {
        //sistemdeki rolleri bir bütün olarak getirmek için
        IEnumerable<IdentityRole> Roles{get;}
        //Sistemdeki kullanıcıları listelemek için gereklidir.
        IEnumerable<IdentityUser> GetAllUsers();

        //kullanıcılar üzerinde crud işlemleri

        Task<IdentityResult> CreateUser(UserDtoForCreation userDto);

       //roller ile birlikte kullananıcı bilgilerini almak için
        Task<UserDtoForUpdate> GetOneUserForUpdate(string UserName);
        Task<IdentityUser> GetOneUser(string UserName);
        Task UpdateUser(UserDtoForUpdate userDto);

        Task<IdentityResult> ResetPassword(ResetDto reserDto);
        Task<IdentityResult> DeleteUser(string UserName);

        
    }
}