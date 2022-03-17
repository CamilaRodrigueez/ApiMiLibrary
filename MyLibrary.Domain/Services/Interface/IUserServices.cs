using Infraestructure.Entity.Models.Security;
using MiLibrary.Domain.Dto;
using MyLibrary.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Domain.Services.Interface
{
    public interface IUserServices
    {
        #region Auth
        TokenDto Login(LoginDto login);
        Task<ResponseDto> Register(RegisterDto data);
        #endregion
        #region Methods Crud
        List<UserDto> GetAllUsers();
        
        #endregion
    }
}
