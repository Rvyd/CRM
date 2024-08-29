using AutoMapper;
using Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using Services.Contracts;

namespace Services
{
    public class AuthManager : IAuthService
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly UserManager<IdentityUser> _userManager;

        private readonly IMapper _mapper;

        public AuthManager(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public IEnumerable<IdentityRole> Roles => _roleManager.Roles;

        public async Task<IdentityResult> CreateUser(UserDtoForCreation userDto)
        {
            var user = _mapper.Map<IdentityUser>(userDto);
            var result = await _userManager.CreateAsync(user, userDto.Password);
            if (!result.Succeeded)
                throw new Exception("Kullanıcı oluşturulamadı");
            if (userDto.Roles.Count > 0)
            {
                var roleResult = await _userManager.AddToRolesAsync(user, userDto.Roles);
                if (!roleResult.Succeeded)
                    throw new Exception("Rol atanamadı");

            }

            return result;

        }

        public async Task<IdentityResult> DeleteUser(string UserName)
        {
            var user = await GetOneUser(UserName);
            return await _userManager.DeleteAsync(user);
        }

        public IEnumerable<IdentityUser> GetAllUsers()
        {
            return _userManager.Users.ToList();
        }

        public async Task<IdentityUser> GetOneUser(string UserName)
        {
            var user = await _userManager.FindByNameAsync(UserName); //isme göre kullanıcıyı bulduk
            if (user is not null)
                return user;
            throw new Exception("Kullanıcı yok");
        }


        public async Task<UserDtoForUpdate> GetOneUserForUpdate(string UserName)
        {
            var user = await GetOneUser(UserName); //kullanıcı bilgilerini aldık
            var userDto = _mapper.Map<UserDtoForUpdate>(user);
            userDto.Roles = new HashSet<string>(Roles.Select(r => r.Name).ToList());
            userDto.UserRoles = new HashSet<string>(await _userManager.GetRolesAsync(user));
            return userDto;

        }

        public async Task<IdentityResult> ResetPassword(ResetDto resetDto)
        {
            var user = await GetOneUser(resetDto.UserName);
            if (user == null)
            {
                throw new Exception("Kullanıcı bulunamadı.");
            }

            await _userManager.RemovePasswordAsync(user);
            var result = await _userManager.AddPasswordAsync(user, resetDto.Password);
            return result;
        }


        public async Task UpdateUser(UserDtoForUpdate userDto)
        {
            var user = await GetOneUser(userDto.UserName);
            user.PhoneNumber = userDto.PhoneNumber;
            user.Email = userDto.Email;

            var result = await _userManager.UpdateAsync(user);
            if (userDto.Roles.Count > 0) //checkbox ta işaretlenme yapıldıysa
            {
                var userRoles = await _userManager.GetRolesAsync(user); //kullanıcıya ait roller
                var r1 = await _userManager.RemoveFromRolesAsync(user, userRoles); //kullanıcının tüm rollerini kaldırdım
                var r2 = await _userManager.AddToRolesAsync(user, userDto.Roles); //form üzerinde tanımlanan rolleri atadım


            }
            return;


        }
    }
}