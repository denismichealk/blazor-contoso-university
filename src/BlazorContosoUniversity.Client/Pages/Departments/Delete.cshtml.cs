using BlazorContosoUniversity.Client.Services;
using BlazorContosoUniversity.Shared;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace BlazorContosoUniversity.Client.Pages.Departments
{
    public class DeleteModel : ComponentBase
    {
        [Inject] NavigationManager UriHelper { get; set; }
        [Parameter] public string DepartmentID { get; set; }
        [Inject] DepartmentsServiceClient Client { get; set; }


        public bool IsBusy { get; set; }
        public DepartmentDto Department;

        protected override async Task OnInitializedAsync()
        {
            IsBusy = true;
            await LoadDepartment(DepartmentID);
            IsBusy = false;
        }

        async Task LoadDepartment(string deptId)
        {
            Department = await Client.GetDetails(deptId);
        }

        public async Task OnDeleteClick()
        {
            var deleted = await Client.Delete(DepartmentID);
            UriHelper.NavigateTo("/departments");
        }
    }
}