using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorContosoUniversity.Client.Services;
using BlazorContosoUniversity.Shared;
using System.Linq;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorContosoUniversity.Client.Pages
{
    public class AboutModel : ComponentBase
    {
        [Inject] StatisticsServiceClient Client { get; set; }
        [Inject] IJSRuntime jsRuntime { get; set; }

        public bool IsBusy { get; set; }

        public StatisticsDto Stats { get; set; } = null;

        List<EnrollmentDateGroupDto> enrollmentsData = new List<EnrollmentDateGroupDto>();

        protected override async Task OnInitializedAsync()
        {
            IsBusy = true;
            await LoadStats();
            await LoadEnrollmentStats();
            IsBusy = false;
        }

        private async Task LoadEnrollmentStats()=>
            enrollmentsData = await Client.GetEnrollmentStats();

        protected override async Task OnAfterRenderAsync(bool firstRender)=>
            await jsRuntime.InvokeAsync<bool>("drawEnrollmentStatsChart", enrollmentsData);

        async Task LoadStats() => 
            Stats = await Client.Get();
    }
}