using DAL.DTOS.RequestDTO;
using DAL.DTOS.ResponseDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IQuickRegister
    {
          Task <AuthResponse> QuickRegisteration(QuickRegisterDTO quickregister);

    }
}
