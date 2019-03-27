using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Data;
using App.Domain.Entities.Product;
using App.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace App.Services
{
    public class ConfigDetailService : IConfigDetailService
    {
        private readonly ApplicationDbContext _context;

        public ConfigDetailService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ConfigDetail>> GetAllConfigDetails()
        {
            return await _context.ConfigDetails.ToListAsync();
        }

        public async Task<ConfigDetail> GetConfigDetailById(int? configDetailId)
        {
            return await _context.ConfigDetails.SingleOrDefaultAsync(b => b.Id == configDetailId);
        }

        public async Task AddConfigDetail(ConfigDetail configDetail)
        {
            _context.ConfigDetails.Add(configDetail);
            await SaveChangeAsync();
        }

        public async Task<List<ConfigDetail>> GetAllConfigDetailsByProductId(int? productId)
        {
            return await _context.ConfigDetails.Where(cd=>cd.ProductId == productId).ToListAsync();
        }

        public async Task<List<ConfigDetail>> GetAllConfigDetailsByConfigGroupId(int? configGroupId)
        {
            return await _context.ConfigDetails.Where(cd => cd.ConfigGroupId == configGroupId).ToListAsync();
        }

        public async Task RemoveConfigDetails(int? configDetailId)
        {
            _context.ConfigDetails.Remove(await GetConfigDetailById(configDetailId));
            await _context.SaveChangesAsync();
        }

        public void UpdateConfigDetail(ConfigDetail configDetail)
        {
            _context.ConfigDetails.Update(configDetail);
        }

        public bool ConfigDetailExists(int configDetailId)
        {
            return _context.ConfigDetails.Any(b => b.Id == configDetailId);
        }

        public bool AnyConfigDetailsByProductIdAndConfigChartId(int productId, int configChartId)
        {
            return _context.ConfigDetails.Any(cd =>
                cd.ProductId == productId && cd.ConfigChartId == configChartId);
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
