using BlazorContosoUniversity.Client.Services;
using BlazorContosoUniversity.Shared;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorContosoUniversity.Client.Pages.Instructors
{
    public class IndexModel : ComponentBase
    {
        [Inject] InstructorsServiceClient Client { get; set; }

        public List<InstructorDto> Instructors { get; set; } = null;
        public bool IsBusy { get; set; } = false;

        protected override async Task OnInitializedAsync()
        {
            IsBusy = true;
            await LoadCourses();
            IsBusy = false;
        }

        async Task LoadCourses()
        {
            Instructors = await Client.Get();
        }

    }
}