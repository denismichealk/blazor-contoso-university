using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorContosoUniversity.Client.Services;
using BlazorContosoUniversity.Shared;
using Microsoft.AspNetCore.Components;

namespace BlazorContosoUniversity.Client.Pages.Courses
{
    public class EditModel : ComponentBase
    {
        [Parameter] public string CourseID { get; set; }
        [Inject] NavigationManager UriHelper { get; set; }
        [Inject] DepartmentsServiceClient DepartmentsClient { get; set; }
        [Inject] CoursesServiceClient CoursesClient { get; set; }

        public bool IsBusy { get; set; } = false;
        public List<DepartmentDto> Departments { get; set; }
        public CourseDto Course { get; set; }

        protected override async Task OnInitializedAsync()
        {
            IsBusy = true;
            await LoadCourse();
            IsBusy = false;
        }

        async Task LoadCourse()
        {
            var departmentsTask = DepartmentsClient.Get();
            var courseTask = CoursesClient.GetDetails(CourseID);

            Departments = await departmentsTask;
            Course = await courseTask;
        }

        public async Task OnSaveClick()
        {
            var updated = await CoursesClient.Update(Course);
            UriHelper.NavigateTo("/courses");
        }
    }
}