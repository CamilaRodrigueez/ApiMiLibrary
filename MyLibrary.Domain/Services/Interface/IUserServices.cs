using Infraestructure.Entity.Models.Security;
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
        Task<ResponseDto> Register(UserDto data);
        #endregion
        #region Methods Crud
        List<UserEntity> GetAll();
        UserEntity GetUser(int idUser);

        Task<bool> UpdateUser(UserEntity user);
        Task<bool> DeleteUser(int idUser);
        Task<ResponseDto> CreateUser(UserEntity data);
        #endregion
    }
}
