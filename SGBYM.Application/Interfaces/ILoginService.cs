using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBYM.Application.DTOs.LoginDTO;

namespace SGBYM.Application.Interfaces
{
    public interface ILoginService
    {
        Task<LoginResponseDTO> LoginAsync(string correo, string password);
    }
}
