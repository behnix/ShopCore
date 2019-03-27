using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Data;
using App.Domain.Entities.Product;
using App.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace App.Services
{
    public class ConfigChartService : IConfigChartService
    {
        private readonly ApplicationDbContext _context;

        public ConfigChartService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ConfigChart>> GetAllConfigChart()
        {
            return await _context.ConfigCharts.OrderBy(cc=>cc.Order).ToListAsync();
        }
        public async Task<List<ConfigChart>> GetAllConfigChartInConfigGroup(int categoryId, int configGroupId)
        {
            return await _context.ConfigCharts.Where(cc=>cc.ConfigGroupId == configGroupId && cc.CategoryId == categoryId).OrderBy(cc => cc.Order).ToListAsync();
        }

        public async Task CreateConfigChart(ConfigChart configChart, int categoryId, int configGroupId)
        {
            configChart.Order = GetLastOrder(categoryId, configGroupId) + 1;
            _context.ConfigCharts.Add(configChart);
            await SaveChangeAsync();
        }

        public async Task<List<ConfigChart>> GetAllConfigChartByCategoryId(int categoryId)
        {
            return await _context.ConfigCharts.Where(cc => cc.CategoryId == categoryId).OrderBy(cc => cc.Order).ToListAsync();
        }

        public void EditConfigChart(ConfigChart configChart)
        {
            _context.ConfigCharts.Update(configChart);
        }

        public async Task<bool> RemoveConfigChart(int? configChartId)
        {
            var configChart = await GetConfigChartById(configChartId);
            _context.ConfigCharts.Remove(configChart);
            return _context.SaveChanges() != 0;
        }

        public bool ConfigChartExists(int id)
        {
            return _context.ConfigCharts.Any(e => e.Id == id);
        }

        public async Task<ConfigChart> GetConfigChartById(int? id)
        {
            return await _context.ConfigCharts.SingleOrDefaultAsync(g => g.Id == id);
        }

        public int GetLastOrder(int categoryId, int configGroupId)
        {
            return _context.ConfigCharts.Any(cc => cc.CategoryId == categoryId && cc.ConfigGroupId == configGroupId)
                ? _context.ConfigCharts.Where(cc => cc.CategoryId == categoryId && cc.ConfigGroupId == configGroupId).OrderBy(keySelector: cg => cg.Order)
                    .FirstOrDefault().Order
                : 0;
        }

        public async Task Shift(int configChartId, string method)
        {
            var configChart = await GetConfigChartById(configChartId);
            var allConfigChartInGroup = await GetAllConfigChartInConfigGroup(configChart.CategoryId, configChart.ConfigGroupId);
            var indexOfConfigChartSelectedToExchange = 0;
            switch (method)
            {
                case "ShiftToUp":
                    indexOfConfigChartSelectedToExchange = allConfigChartInGroup.IndexOf(configChart) - 1;
                    break;
                case "ShiftToDown":
                    indexOfConfigChartSelectedToExchange = allConfigChartInGroup.IndexOf(configChart) + 1;
                    break;
            }
            var selectedConfigChartToExchange = allConfigChartInGroup.ElementAt(indexOfConfigChartSelectedToExchange);
            var orderOfConfigChart = configChart.Order;
            configChart.Order = selectedConfigChartToExchange.Order;
            selectedConfigChartToExchange.Order = orderOfConfigChart;
            await SaveChangeAsync();
        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
