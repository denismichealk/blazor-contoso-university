using BlazorContosoUniversity.Client.Services;
using BlazorContosoUniversity.Shared;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace BlazorContosoUniversity.Client.Pages.Students
{
    public class DeleteModel : ComponentBase
    {
        [Parameter]
        public string StudentId { get; set; }
        [Inject()]
        StudentsServiceClient Client { get; set; }
        [Inject()]
        NavigationManager UriHelper { get; set; }

        public StudentDto Student { get; set; } = null;

        protected override async Task OnInitializedAsync()
        {
            Student = await Client.Get(StudentId);
        }

        public async void OnDeleteClick()
        {
            var deleted = await Client.Delete(Student.Id);
            if(deleted)
            {
                UriHelper.NavigateTo("/students");
            }

        }
    }
}