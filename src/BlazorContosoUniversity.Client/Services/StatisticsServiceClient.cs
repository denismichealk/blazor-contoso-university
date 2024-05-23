using BlazorContosoUniversity.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorContosoUniversity.Client.Services
{
    public class StatisticsServiceClient
    {
        HttpClient _client;
        var _baseUrl = "/api/statistics";
        public StatisticsServiceClient(HttpClient client) =>
            _client = client;

        public async Task<StatisticsDto> Get() => 
            await _client.GetFromJsonAsync<StatisticsDto>(_baseUrl);

        public async Task<List<EnrollmentDateGroupDto>> GetEnrollmentStats() =>
            await _client.GetFromJsonAsync<List<EnrollmentDateGroupDto>>($"{_baseUrl}/enrollments");
    }
}
