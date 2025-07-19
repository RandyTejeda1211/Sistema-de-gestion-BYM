using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBYM.Application.DTOs.LoginDTO;
using SGBYM.Application.Interfaces;
using SGBYM.Domain.Interfaces;

namespace SGBYM.Application.Services
{ 
    public class LoginServices : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly JwtService _jwtService;
        public LoginServices(ILoginRepository loginRepository, JwtService jwtService)
        {
            _loginRepository = loginRepository;
            _jwtService = jwtService;
        }

        public async Task<LoginResponseDTO> LoginAsync(string correo, string password)
        {
            var user = await _loginRepository.GetByEmailAsync(correo);
            if (user is null)
                throw new UnauthorizedAccessException("Credenciales invalidas");

            bool passValid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);

            if (!passValid)
                throw new UnauthorizedAccessException("Credenciales invalidas");

            ;


            var token = _jwtService.GenerateToken(user.IdCliente.ToString(), user.Correo);

            return new LoginResponseDTO
            {
                Correo = user.Correo,
                IdCliente = user.IdCliente,
                Token = token
            };
        }
    }
}
