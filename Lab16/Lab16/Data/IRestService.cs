using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lab16.Model;

namespace Lab16.Data
{
    public interface IRestService
    {
        Task<List<School>> RefreshDataAsync();
        Task SaveSchoolAsync(School school, bool isNew);
        Task DeleteSchoolAsync(String id);
    }
}