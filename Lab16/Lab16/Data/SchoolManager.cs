using System.Collections.Generic;
using System.Threading.Tasks;
using Lab16.Model;

namespace Lab16.Data
{
    public class SchoolManager
    {
        private IRestService _restService;
        
        public SchoolManager(IRestService service)
        {
            _restService = service;
        }

        public Task<List<School>> GetTasksAsync()
        {
            return _restService.RefreshDataAsync();
        }
        
        public Task SaveTaskAsync (School item, bool isNew = false)
        {
            return _restService.SaveSchoolAsync(item, isNew);
        }
        
        public Task DeleteTaskAsync (School item)
        {
            return _restService.DeleteSchoolAsync(item.Id);
        }
    }
}