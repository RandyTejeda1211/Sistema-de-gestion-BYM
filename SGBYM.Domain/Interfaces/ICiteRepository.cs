using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBYM.Domain.Models;

namespace SGBYM.Domain.Interfaces
{
    public interface ICiteRepository
    {
        Task<IEnumerable<Cite>> GetAllCites();
        Task<Cite> GetById(int id);
        Task CreateCita(Cite cite);
        Task UpdateCita(Cite cite);
        Task DeleteCita(int id);

    }
}
