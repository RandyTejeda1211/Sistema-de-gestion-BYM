using SGBYM.Application.DTOs.AdminitratorDTO;
using SGBYM.Application.Interfaces;
using SGBYM.Application.Interfaces.security;
using SGBYM.Domain.Interfaces;
using SGBYM.Domain.Models;

namespace SGBYM.Application.Services
{
    public class AdminService : IAdminService
    {

        private readonly IAdminRepository _adminRepository;
        private readonly IPassHasher _passHasher;

        public AdminService(IAdminRepository adminRepository, IPassHasher passHasher)
        {
            _adminRepository = adminRepository;
            _passHasher = passHasher;
        }
        public async Task CreateAdmin(AdminCreateDTO admin)
        {
            var administrator = new Administrator
            {
                username = admin.username,
                passwordHash = _passHasher.HashPassword(admin.passwordHash),
                correo = admin.correo
            };
            await _adminRepository.CreateAdmin(administrator);
        }

        public async Task DeleteAdmin(int id)
        {
            await _adminRepository.DeleteAdmin(id);
        }

        public async Task<IEnumerable<AdminSummDTO>> GetAllAdmins()
        {
            var admins = await _adminRepository.GetAllAdmins();
            return admins.Select(a => new AdminSummDTO
            {
                idAdmin = a.idAdmin,
                username = a.username,
                correo = a.correo
            });
            
        }

        public async Task<AdminSummDTO> GetById(int id)
        {
            var admins = await _adminRepository.GetById(id);
            return new AdminSummDTO
            {
                idAdmin = admins.idAdmin,
                username = admins.username,
                correo = admins.correo
            };
        }

        public async Task UpdateAdmin(UpdateClienteDTO admin)
        {
            var admins = await _adminRepository.GetById(admin.idAdmin);
            if (admins == null)
                throw new Exception("Administrator not found");

            admins.username = admin.username;
            admins.correo = admin.correo;
            if (!string.IsNullOrEmpty(admin.passwordHash))
            {
                admins.passwordHash = _passHasher.HashPassword(admin.passwordHash);
            }
            await _adminRepository.UpdateAdmin(admins);
        }
    }
}
