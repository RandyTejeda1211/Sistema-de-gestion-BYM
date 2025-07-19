using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SGBYM.Application.DTOs;
using SGBYM.Application.DTOs.BillsDTO;
using SGBYM.Application.DTOs.CiteDTO;
using SGBYM.Application.Interfaces;
using SGBYM.Domain.Interfaces;
using SGBYM.Domain.Models;
using SGBYM.Infrastructure.Data;
using SGBYM.Infrastructure.Repositories;


namespace SGBYM.Application.Services
{
    public class CiteService : ICiteService
    {
        private readonly ICiteRepository _citeRepository;
        private readonly AppDbContext _context;
        private readonly BillService _billService;
        
        public CiteService(ICiteRepository citeRepository, 
                            AppDbContext context, 
                            BillService billService)
        {
            _citeRepository = citeRepository;
            _context = context;
            _billService = billService;
        }
        public async Task CreateCite(CiteBillCreateDTO citeBillCreate)
        {
            var cites = new Cite
            {
                fecha = (DateTime)citeBillCreate.fecha,
                idCliente = (int)citeBillCreate.idCliente,
                estado = true,
            };
            await _citeRepository.CreateCita(cites);

            var ServicePRegistered = new ServicePRegistered
            {
                idCita = cites.idCita,
                idServicio = (int)citeBillCreate.idServicio
            };

            _context.servicePRegistereds.Add(ServicePRegistered);
            await _context.SaveChangesAsync();

            var servicio = await _context.serviceProvided
                .FirstOrDefaultAsync(s => s.idServicios == citeBillCreate.idServicio);

            if (servicio == null)
                throw new Exception("El servicio no existe");

            var bill = new Bills
            {
                serial = await _billService.GenerarSerial(),
                fechaEmision = DateTime.Now,
                montoTotal = servicio.precio,
                formaPago = citeBillCreate.formaPago,
                statusPago = false,
                idServicioRegistrado = ServicePRegistered.idServicioRegistrado
            };
           _context.bills.Add(bill);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CiteSummDTO>> GetAllCite()
        {
            var cites = await _citeRepository.GetAllCites();
            if (cites == null)
                throw new Exception("No existe ninguna cita");

            return cites.Select(c => new CiteSummDTO
            {
                fecha = c.fecha,
                idCliente = c.idCliente,
                estado = c.estado,
                NombreCliente = c.Client.Nombre
            });
            
        }

        public async Task UpdateCite(CiteUpdateDTO cite)
        {
            var citeExistent = await _citeRepository.GetById(cite.idCita);

            if (citeExistent == null)
                throw new Exception("No existe esa cita");

            citeExistent.fecha = cite.fecha;
            citeExistent.estado = cite.estado;
            await _citeRepository.UpdateCita(citeExistent);
        }
    }
}
