using System.Net.Http;
using System.Threading.Tasks;
using BlazorContosoUniversity.Shared;
using BlazorContosoUniversity.Client.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorContosoUniversity.Client.Pages.Students
{
    public class DetailsModel : ComponentBase
    {
        [Parameter]
        public string StudentId { get; set; }

        [Inject()]
        StudentsServiceClient Client { get; set; }

        public StudentDetailsDto Student { get; set; } = null;

        protected override async Task OnInitializedAsync()
        {
            Student = await Client.GetDetails(StudentId);
            StateHasChanged();
        }
    }
}