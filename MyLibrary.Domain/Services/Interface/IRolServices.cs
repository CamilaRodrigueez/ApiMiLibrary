using Infraestructure.Entity.Models.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary.Domain.Services.Interface
{
    public interface IRolServices
    {
        List<RolEntity> GetAll();
    }
}
