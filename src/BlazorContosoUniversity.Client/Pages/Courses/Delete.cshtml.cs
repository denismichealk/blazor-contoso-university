using System.Threading.Tasks;
using BlazorContosoUniversity.Client.Services;
using BlazorContosoUniversity.Shared;
using Microsoft.AspNetCore.Components;

namespace BlazorContosoUniversity.Client.Pages.Courses
{
    public class DeleteModel : ComponentBase
    {
        [Parameter] public string CourseID { get; set; }
        [Inject] CoursesServiceClient Client {get;set;}
        [Inject] NavigationManager UriHelper {get;set;}

        public bool IsBusy { get; set; } = false;
        public CourseDto Course { get; set; }

        protected override async Task OnInitializedAsync()
        {
            IsBusy = true;
            await LoadCourse();
            IsBusy = false;
        }

        async Task LoadCourse()
        {
            Course = await Client.GetDetails(CourseID);
        }

        public async Task OnDeleteClick()
        {
            var deleted = await Client.Delete(CourseID);
            if (deleted)
            {
                UriHelper.NavigateTo("/courses");
            }
        }
    }
}