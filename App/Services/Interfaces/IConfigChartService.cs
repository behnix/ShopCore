using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Domain.Entities.Product;

namespace App.Services.Interfaces
{
    public interface IConfigChartService
    {
        Task<List<ConfigChart>> GetAllConfigChart();

        Task<List<ConfigChart>> GetAllConfigChartInConfigGroup(int categoryId, int configGroupId);

        Task CreateConfigChart(ConfigChart configChart,int categoryId, int configGroupId);

        Task<List<ConfigChart>> GetAllConfigChartByCategoryId(int categoryId);

        void EditConfigChart(ConfigChart configChartId);

        Task<bool> RemoveConfigChart(int? configChartId);

        bool ConfigChartExists(int id);

        Task<ConfigChart> GetConfigChartById(int? id);

        int GetLastOrder(int categoryId, int configGroupId);

        Task Shift(int configChartId, string method);

        Task SaveChangeAsync();
    }
}
