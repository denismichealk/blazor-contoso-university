using System;
using System.Threading.Tasks;
using BlazorContosoUniversity.Client.Services;
using BlazorContosoUniversity.Shared;
using Microsoft.AspNetCore.Components;

namespace BlazorContosoUniversity.Client.Pages.Students
{
    public class CreateModel : ComponentBase
    {
        [Inject()]
        StudentsServiceClient Client { get; set; }
        [Inject()]
        NavigationManager UriHelper { get; set; }

        public StudentDto Student;
        public int Day;
        public int Month;
        public int Year;
        public int LastDayInMonth;

        protected override async Task OnInitializedAsync()
        {
            Student = new StudentDto()
            {
                EnrollmentDate = DateTime.Today
            };
            Day = DateTime.Today.Day;
            Month = DateTime.Today.Month;
            Year = DateTime.Today.Year;
            LastDayInMonth = DateTime.DaysInMonth(Year, Month);
            await Task.CompletedTask;
        }

        public async Task OnSaveClick()
        {
            Student.EnrollmentDate = DateTime.Parse($"{Year}/{Month}/{Day}");
            var created = await Client.Create(Student);
            UriHelper.NavigateTo("/students");
        }
    }
}