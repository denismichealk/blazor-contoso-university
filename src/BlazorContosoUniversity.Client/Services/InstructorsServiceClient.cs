using BlazorContosoUniversity.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorContosoUniversity.Client.Services
{
    public class InstructorsServiceClient
    {
        string _baseUrl = "/api/instructors";
        HttpClient _client;

        public InstructorsServiceClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<InstructorDto>> Get() 
            => await _client.GetFromJsonAsync<List<InstructorDto>>(_baseUrl);

        public async Task<InstructorDto> GetDetails(string id)
        {
            var url = $"{_baseUrl}/{id}";
            return await _client.GetFromJsonAsync<InstructorDto>(url);
        }

        public async Task<bool> Create(InstructorDto instructor)
        {
            var url = $"{_baseUrl}";
            var created = false;
            try
            {
                await _client.PostAsJsonAsync<InstructorDto>(url, instructor);
                created = true;
            }
            catch
            {
                created = false;
            }
            return created;
        }

        public async Task<bool> Update(InstructorDto instructor)
        {
            var url = $"{_baseUrl}/{instructor.Id}";
            var updated = false;
            try
            {
                await _client.PutAsJsonAsync<InstructorDto>(url, instructor);
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
