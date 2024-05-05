
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
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

        public Task DeleteTest(int id)
        {
            throw new NotImplementedException();
        }

        public Task GetApplicationUsers()
        {
            throw new NotImplementedException();
        }

        public Task<Test> GetTest(int id)
        {
            throw new NotImplementedException();
        }

        //public async Task GetTests()
        //{
        //    var result = await _http.GetFromJsonAsync<List<Test>>("api/Tests");
        //    if (result != null)
        //        Tests = result;
        //}

        public async Task<List<Test>> GetTests()
        {
            var result = await _http.GetFromJsonAsync<List<Test>>("api/Tests");
            if (result != null)
                return result;
            else
                return new List<Test>();
        }

        public Task PostTest(Test test)
        {
            throw new NotImplementedException();
        }

        public Task PutTest(int id, Test test)
        {
            throw new NotImplementedException();
        }
    }
}
