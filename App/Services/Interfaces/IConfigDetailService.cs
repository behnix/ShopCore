using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Domain.Entities.Product;

namespace App.Services.Interfaces
{
    public interface IConfigDetailService
    {
        Task<List<ConfigDetail>> GetAllConfigDetails();

        Task<ConfigDetail> GetConfigDetailById(int? configDetailId);

        Task AddConfigDetail(ConfigDetail configDetail);

        Task<List<ConfigDetail>> GetAllConfigDetailsByProductId(int? productId);

        Task<List<ConfigDetail>> GetAllConfigDetailsByConfigGroupId(int? configGroupId);

        Task RemoveConfigDetails(int? configDetailId);

        void UpdateConfigDetail(ConfigDetail configDetail);

        bool ConfigDetailExists(int configDetailId);

        bool AnyConfigDetailsByProductIdAndConfigChartId(int productId, int configChartId);
        
        Task SaveChangeAsync();
    }
}
