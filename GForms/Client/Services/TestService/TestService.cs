using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Security.Principal;
using static System.Net.WebRequestMethods;

namespace GForms.Client.Services.TestService
{
    public class TestService : ITestService
    {
        private HttpClient _http;
        private NavigationManager _navigationManager;

        public TestService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<Test> Tests { get; set; } = new List<Test>();
        public List<ApplicationUser> ApplicationUsers { get; set; } = new List<ApplicationUser>();

        public async Task DeleteTest(int id)
        {
            await _http.DeleteAsync($"api/Tests/{id}");
            _navigationManager.NavigateTo("/");
        }

        public async Task<Test> GetTest(int id)
        {
            var result = await _http.GetFromJsonAsync<Test>($"api/Tests/{id}");
            if (result != null)
                return result;
            throw new Exception("Test not found!");
        }

        public async Task<List<Test>> GetTests()
        {
            var result = await _http.GetFromJsonAsync<List<Test>>("api/Tests");
            if (result != null)
                return result;
            else
                return new List<Test>();
        }

        public async Task PostTest(Test test)
        {
            await _http.PostAsJsonAsync("api/Tests", test);
            _navigationManager.NavigateTo("/");
        }

        public async Task PutTest(int id, Test test)
        {
            await _http.PutAsJsonAsync($"api/Tests/{id}", test);
            _navigationManager.NavigateTo("/");
        }
    }
}
