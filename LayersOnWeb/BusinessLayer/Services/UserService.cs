using BusinessLayer.Contracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UserService: IUserService
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserService(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.signInManager = signInManager;
            this._userManager = userManager;
            this._roleManager = roleManager;
        }

        public async Task<UserModel> Register(RegisterUserModel newUser)
        {
            try
            {
                foreach (var role in newUser.Roles)
                {
                    var roleFindResult = await _roleManager.FindByNameAsync(role.Name);
                    if (roleFindResult == null) return null;
                }

                if (newUser != null)
                {
                    var user = new IdentityUser
                    {
                        UserName = newUser.Username,
                    };
                    var result = await _userManager.CreateAsync(user, newUser.Password);
                    if (result != IdentityResult.Success)
                    {
                        return null;
                    }

                    var registeredUser = await _userManager.FindByNameAsync(user.UserName);

                    foreach (var role in newUser.Roles)
                    {
                        var roleAddResult = await _userManager.AddToRoleAsync(registeredUser, role.Name);
                        if (roleAddResult != IdentityResult.Success)
                        {
                            return null;
                        }
                    }

                    var createdUser = new UserModel
                    {
                        Username = newUser.Username
                    };
                    return createdUser;
                }
                else
                {

                    return null;

                }
            }
            catch(Exception e)
            {
                return null;
            }

        }
        public async Task<UserModel> Login(LoginUserModel user)
        {
            try
            {

                if (user != null)
                {
                    var existingUser = await _userManager.FindByNameAsync(user.Username);

                    if (existingUser != null)
                    {
                        var result = await signInManager.PasswordSignInAsync(existingUser, user.Password, false, false);

                        if (result.Succeeded)
                        {

                            var userRoles = await _userManager.GetRolesAsync(existingUser);
                            var rolesList = new List<RoleModel>();
                            foreach (var role in userRoles)
                            {
                                var roleEntity = await _roleManager.FindByNameAsync(role);
                                rolesList.Add(new RoleModel
                                {
                                    Id = roleEntity.Id,
                                    RoleName = roleEntity.Name
                                });
                            }

                            return new UserModel
                            {
                                Username = user.Username,
                                Roles = rolesList
                            };

                        }
                    }
                }

                return null;
            }
            catch
            {
                return null;
            }
        }


        public async Task<UserModel> RegisterCashier(RegisterUserModel newUser)
        {
            IdentityRole role = await _roleManager.FindByNameAsync("User");
            newUser.Roles = new List<IdentityRole>();
            newUser.Roles.Add(role);
            var registered =  await Register(newUser);
            return registered;
        }

        public async Task<UserModel> UpdateCashier(UserModel newUser)
        {
            if (!ExistsUser(newUser.Id))
            {
                return null;
            }

            var user = await _userManager.FindByIdAsync(newUser.Id.ToString());
            var isCashier = await _userManager.IsInRoleAsync(user, "User");

            if (!isCashier)
            {
                return null;
            }
            user.UserName = newUser.Username;
            var updateResult = await _userManager.UpdateAsync(user);
            if(updateResult != IdentityResult.Success)
            {
                return null;
            }
            var updatedUser = new UserModel
            {
                Id = Guid.Parse(user.Id),
                Username = user.UserName
            };
            return updatedUser;
        }

        public async Task DeleteCashier(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            var isCashier = await _userManager.IsInRoleAsync(user, "User");

            if (!isCashier)
            {
                return;
            }
            await _userManager.DeleteAsync(user);
        }

        public async Task<List<UserModel>> GetCashiers()
        {
            var cashiers = await _userManager.GetUsersInRoleAsync("User");
            var cashierModels = new List<UserModel>();
            foreach(var cashier in cashiers)
            {
                cashierModels.Add(new UserModel { Id = Guid.Parse(cashier.Id), Username = cashier.UserName });
            }
            return cashierModels;
        }

        public async Task<UserModel> GetCashierById(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            var isCashier = await _userManager.IsInRoleAsync(user, "User");

            if (!isCashier)
            {
                return null;
            }
            return new UserModel
            {
                Id = Guid.Parse(user.Id),
                Username = user.UserName,
            };
        }

        public async Task<List<UserModel>> GetUsers()
        {
            return _userManager.Users.Select(u => new UserModel
            {
                Id = Guid.Parse(u.Id),
                Username = u.UserName
            }).ToList();
        }

        public bool ExistsUser(Guid id)
        {
            return _userManager.Users.Any(u => u.Id.Equals(id.ToString()));
        }

        public string GetUserName(Guid id)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Id.Equals(id.ToString()));
            return user == null ? "??" : user.UserName;
        }
    }
}
