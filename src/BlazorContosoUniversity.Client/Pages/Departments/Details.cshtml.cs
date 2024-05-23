using System.Threading.Tasks;
using BlazorContosoUniversity.Client.Services;
using BlazorContosoUniversity.Shared;
using Microsoft.AspNetCore.Components;

namespace BlazorContosoUniversity.Client.Pages.Departments
{
    public class DetailsModel : ComponentBase
    {
        [Parameter] public string DeptID { get; set; }
        [Inject] DepartmentsServiceClient Client { get; set; }

        public bool IsBusy { get; set; }
        public DepartmentDto Department;

        protected override async Task OnInitializedAsync()
        {
            IsBusy = true;
            await LoadDepartment(DeptID);
            IsBusy = false;
        }

        async Task LoadDepartment(string deptId)
        {
            Department = await Client.GetDetails(deptId);
        }
    }
}