using BlazorContosoUniversity.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorContosoUniversity.Client.Services
{
    public class DepartmentsServiceClient
    {
        string _baseUrl = "/api/departments";
        HttpClient _client;

        public DepartmentsServiceClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<DepartmentDto>> Get()
        {
            return await _client.GetFromJsonAsync<List<DepartmentDto>>(_baseUrl);
        }

        public async Task<DepartmentDto> GetDetails(string id)
        {
            var url = $"{_baseUrl}/{id}";
            return await _client.GetFromJsonAsync<DepartmentDto>(url);
        }

        public async Task<bool> Create(DepartmentDto department)
        {
            var url = $"{_baseUrl}";
            var created = false;
            try
            {
                await _client.PostAsJsonAsync<DepartmentDto>(url, department);
                created = true;
            }
            catch
            {
                created = false;
            }
            return created;
        }

        public async Task<bool> Update(DepartmentDto department)
        {
            var url = $"{_baseUrl}/{department.DepartmentID}";
            var updated = false;
            try
            {
                await _client.PutAsJsonAsync<DepartmentDto>(url, department);
                updated = true;
            }
            catch
            {
                updated = false;
            }
            return updated;
        }

        public async Task<bool> Delete(string id)
        {
            var url = $"{_baseUrl}/{id}";
            var deleted = false;
            try
            {
                await _client.DeleteAsync(url);
                deleted = true;
            }
            catch { deleted = false; }
            return deleted;
        }
    }
}
