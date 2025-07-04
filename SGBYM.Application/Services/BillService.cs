using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SGBYM.Application.DTOs.AdminitratorDTO;
using SGBYM.Application.DTOs.BillsDTO;
using SGBYM.Application.Interfaces;
using SGBYM.Domain.Interfaces;
using SGBYM.Domain.Models;
using SGBYM.Infrastructure.Data;

namespace SGBYM.Application.Services
{
    public class BillService 
    {
        private readonly AppDbContext _context;
        public BillService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<string> GenerarSerial()
        {
            var fecha = DateTime.Today;
            int totalFactura = await _context.bills
                .CountAsync(f => f.fechaEmision.Date == fecha);

            int nuevoNumero = totalFactura + 1;

            string fechaParte = fecha.ToString("yyyyMMdd");
            string numeroParte = nuevoNumero.ToString("DS");

            return $"FACT-{fechaParte}-{numeroParte}";
        }
        
    }
}
