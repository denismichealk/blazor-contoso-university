using BlazorContosoUniversity.Client.Services;
using BlazorContosoUniversity.Shared;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorContosoUniversity.Client.Pages.Courses
{
    public class IndexModel : ComponentBase
    {
        [Inject]
        CoursesServiceClient Client { get; set; }
        public List<CourseDto> Courses { get; set; } = null;
        public bool IsBusy { get; set; } = false;

        protected override async Task OnInitializedAsync()
        {
            await LoadCourses();
        }

        async Task LoadCourses()
        {
            IsBusy = true;
            Courses = await Client.Get();
            IsBusy = false;
        }
    }
}