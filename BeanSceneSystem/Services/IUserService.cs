﻿using BeanSceneSystem.Models;
namespace BeanSceneSystem.Services
{
    public interface IUserService
    {
        Task<Status> RegisterAsync(RegistrationModel model);
        Task<Status> LoginAsync(LoginModel model);
        Task LogoutAsync();
        Task<Status> ChangePasswordAsync(ChangePasswordModel model, string username);
    }
}
