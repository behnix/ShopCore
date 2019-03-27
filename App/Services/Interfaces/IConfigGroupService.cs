using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Domain.Entities.Product;

namespace App.Services.Interfaces
{
    public interface IConfigGroupService
    {
        Task<List<ConfigGroup>> GetAllConfigGroup();

        Task CreateConfigGroup(ConfigGroup configGroup, int categoryId);

        void EditConfigGroup(ConfigGroup configGroupId);

        bool ConfigGroupExists(int id);

        Task RemoveConfigGroup(int categoryId, int configGroupId);

        Task<ConfigGroup> GetConfigGroupById(int? id);

        void UpdateConfigGroup(ConfigGroup configGroup);

        Task<List<ConfigGroup>> GetAllConfigGroupByCategoryId(int categoryId);

        int GetLastOrder(int categoryId);

        Task SaveChangeAsync();
    }
}
