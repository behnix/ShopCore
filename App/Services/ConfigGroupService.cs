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
    public class ConfigGroupService : IConfigGroupService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfigChartService _configChartService;
        private readonly IConfigDetailService _configDetailService;

        public ConfigGroupService(ApplicationDbContext context, IConfigChartService configChartService, IConfigDetailService configDetailService)
        {
            _context = context;
            _configChartService = configChartService;
            _configDetailService = configDetailService;
        }

        public async Task<List<ConfigGroup>> GetAllConfigGroup()
        {
            return await _context.ConfigGroups.ToListAsync();
        }

        public async Task CreateConfigGroup(ConfigGroup configGroup, int categoryId)
        {
            configGroup.Order = GetLastOrder(categoryId) + 1;
            _context.ConfigGroups.Add(configGroup);
            await SaveChangeAsync();
        }

        public void EditConfigGroup(ConfigGroup configGroup)
        {
            _context.ConfigGroups.Update(configGroup);
        }
        
        public bool ConfigGroupExists(int id)
        {
            return _context.ConfigGroups.Any(e => e.Id == id);
        }

        public async Task RemoveConfigGroup(int categoryId, int configGroupId)
        {
            var configCharts = await _configChartService.GetAllConfigChartInConfigGroup(categoryId, configGroupId);
            var configDetails = await _configDetailService.GetAllConfigDetailsByConfigGroupId(configGroupId);
            foreach (var configChart in configCharts)
                await _configChartService.RemoveConfigChart(configChart.Id);

            foreach (var configDetail in configDetails)
                await _configDetailService.RemoveConfigDetails(configDetail.Id);

            _context.ConfigGroups.Remove(await GetConfigGroupById(configGroupId));
            await _context.SaveChangesAsync();
        }

        public async Task<ConfigGroup> GetConfigGroupById(int? id)
        {
            return await _context.ConfigGroups.SingleOrDefaultAsync(g => g.Id == id);
        }

        public void UpdateConfigGroup(ConfigGroup configGroup)
        {
            _context.ConfigGroups.Update(configGroup);
        }

        public async Task<List<ConfigGroup>> GetAllConfigGroupByCategoryId(int categoryId)
        {
            return await _context.ConfigGroups.Where(cg => cg.CategoryId == categoryId).OrderBy(cg=>cg.Order).ToListAsync();
        }
        public int GetLastOrder(int categoryId)
        {
            return _context.ConfigGroups.Any(cg=>cg.CategoryId == categoryId) ? _context.ConfigGroups.Where(cg=>cg.CategoryId == categoryId).OrderBy(keySelector: cg => cg.Order).FirstOrDefault().Order : 0;
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }
        
    }
}
