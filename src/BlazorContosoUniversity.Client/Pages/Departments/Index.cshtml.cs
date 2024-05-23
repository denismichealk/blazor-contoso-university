using BlazorContosoUniversity.Client.Services;
using BlazorContosoUniversity.Shared;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorContosoUniversity.Client.Pages.Departments
{
    public class IndexModel : ComponentBase
    {
        [Inject] DepartmentsServiceClient Client { get; set; }

        public bool IsBusy { get; set; }
        public List<DepartmentDto> Departments;

        protected override async Task OnInitializedAsync()
        {
            IsBusy = true;
            await LoadDepartments();
            IsBusy = false;
        }

        async Task LoadDepartments()
        {
            Departments = await Client.Get();
        }
    }
}