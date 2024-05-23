using BlazorContosoUniversity.Client.Services;
using BlazorContosoUniversity.Shared;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace BlazorContosoUniversity.Client.Pages.Instructors
{
    public class DeleteModel : ComponentBase
    {
        [Parameter] public string InstructorID { get; set; }
        [Inject] InstructorsServiceClient Client { get; set; }
        [Inject] NavigationManager UriHelper { get; set; }

        public bool IsBusy { get; set; }
        public InstructorDto Instructor { get; set; }

        protected override async Task OnInitializedAsync()
        {
            IsBusy = true;
            await LoadInstructor(InstructorID);
            IsBusy = false;
        }

        private async Task LoadInstructor(string instructorID)
        {
            Instructor = await Client.GetDetails(instructorID);
        }

        public async Task OnDeleteClick()
        {
            var deleted = await Client.Delete(InstructorID);
            if (deleted)
            {
                UriHelper.NavigateTo("/instructors");
            }
        }

    }
}