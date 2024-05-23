using System.Threading.Tasks;
using BlazorContosoUniversity.Client.Services;
using BlazorContosoUniversity.Shared;
using Microsoft.AspNetCore.Components;

namespace BlazorContosoUniversity.Client.Pages.Courses
{
    public class DetailsModel : ComponentBase
    {
        [Parameter] public string CourseID { get; set; }

        [Inject()] CoursesServiceClient Client { get; set; }

        public string CourseIDProp { get { return CourseID; } }

        public CourseDto Course { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Course = await Client.GetDetails(CourseID);
        }

    }
}