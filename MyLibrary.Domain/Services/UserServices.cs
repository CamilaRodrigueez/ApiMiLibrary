using Common.Utils.Exceptions;
using Common.Utils.Resorces;
using Common.Utils.Utils;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Models.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MiLibrary.Domain.Dto;
using MyLibrary.Domain.Dto;
using MyLibrary.Domain.Services.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Common.Utils.Constant.Const;
using static Common.Utils.Enums.Enums;

namespace MyLibrary.Domain.Services
{
    public class UserServices: IUserServices
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        #endregion

        #region Builder
        public UserServices(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }
        #endregion

        #region authentication
        public TokenDto Login(LoginDto login)
        {
            UserEntity user = _unitOfWork.UserRepository.FirstOrDefault(x => x.Email == login.UserName
                                                                            && x.Password == login.Password,
                                                                           r => r.RolUserEntities);
            if (user == null)
                throw new BusinessException(GeneralMessages.BadCredentials);

            //TOKEN
            return GenerateTokenJWT(user);
        }

        public TokenDto GenerateTokenJWT(UserEntity userEntity)
        {
            IConfigurationSection tokenAppSetting = _configuration.GetSection("Tokens");

            var _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenAppSetting.GetSection("Key").Value));
            var _signingCredentials = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var _header = new JwtHeader(_signingCredentials);

            var _Claims = new[] {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(TypeClaims.IdUser,userEntity.IdUser.ToString()),
                new Claim(TypeClaims.UserName,userEntity.FullName),
                new Claim(TypeClaims.Email,userEntity.Email),
                new Claim(TypeClaims.IdRol,string.Join(",",userEntity.RolUserEntities.Select(x=>x.IdRol))),
            };

            var _payload = new JwtPayload(
                    issuer: tokenAppSetting.GetSection("Issuer").Value,
                    audience: tokenAppSetting.GetSection("Audience").Value,
                    claims: _Claims,
                    notBefore: DateTime.UtcNow,
                    expires: DateTime.UtcNow.AddMinutes(60)
                );

            var _token = new JwtSecurityToken(
                    _header,
                    _payload
                );

            TokenDto token = new TokenDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(_token),
                Expiration = Utils.ConvertToUnixTimestamp(_token.ValidTo),
            };
            return token;
        }
        #endregion
        #region Methods Crud


        public List<UserDto> GetAllUsers()
        {
            var users = _unitOfWork.RolUserRepository.GetAll(p => p.RolEntity, x => x.UserEntity);
                                                            
            List<UserDto> list = users.Select(x => new UserDto
            {  IdRol = x.RolEntity.IdRol,
               IdUser = x.UserEntity.IdUser,
               Name = x.UserEntity.Name,
               LastName = x.UserEntity.LastName,
               UserName = x.UserEntity.Email,
               NameRol = x.RolEntity.Rol,
               Password = "No disponible",
               ConfirmPassword ="No disponible"
                
            }).ToList();



            return list;
        }

        public async Task<ResponseDto> Register(RegisterDto data)
        {
            ResponseDto result = new ResponseDto();

            if (Utils.ValidateEmail(data.UserName))
            {
                if (_unitOfWork.UserRepository.FirstOrDefault(x => x.Email == data.UserName) == null)
                {

                    RolUserEntity rolUser = new RolUserEntity()
                    {
                        IdRol = RolUser.Estandar.GetHashCode(),
                        UserEntity = new UserEntity()
                        {
                            Email = data.UserName,
                            LastName = data.LastName,
                            Name = data.Name,
                            Password = data.Password
                        }
                    };

                    _unitOfWork.RolUserRepository.Insert(rolUser);
                    result.IsSuccess = await _unitOfWork.Save() > 0;
                }
                else
                    result.Message = "Email ya se encuestra registrado, utilizar otro!";
            }
            else
                result.Message = "Usuario con Email Inválido";

            return result;
        }
        #endregion
    }
}
