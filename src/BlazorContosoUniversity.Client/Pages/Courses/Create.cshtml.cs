using BlazorContosoUniversity.Client.Services;
using BlazorContosoUniversity.Shared;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorContosoUniversity.Client.Pages.Courses
{
    public class CreateModel : ComponentBase
    {
        [Inject] NavigationManager MyNavigationManager { get; set; } = default!;
        [Inject] DepartmentsServiceClient DepartmentsClient { get; set; }
        [Inject] CoursesServiceClient CoursesClient { get; set; }

        public bool IsBusy { get; set; } = false;
        public List<DepartmentDto> Departments { get; set; }
        public CourseDto Course { get; set; }

        protected override async Task OnInitializedAsync()
        {
            IsBusy = true;
            await LoadDepartments();
            IsBusy = false;
        }

        async Task LoadDepartments()
        {
            var departmentsTask = DepartmentsClient.Get();
            Departments = await departmentsTask;
            Course = new CourseDto();
        }

        public async Task OnSaveClick()
        {
            var updated = await CoursesClient.Create(Course);
            MyNavigationManager.NavigateTo("/courses");
        }
    }
}