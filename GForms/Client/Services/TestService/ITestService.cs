using System.Security.Principal;

namespace GForms.Client.Services.TestService
{
    public interface ITestService
    {
        List<Test> Tests { get; set; }
        List<ApplicationUser> ApplicationUsers { get; set; }
        Task<List<Test>> GetTests();
        Task<Test> GetTest(int id);
        Task PostTest(Test test);
        Task PutTest(int id, Test test);
        Task DeleteTest(int id);
    }
}
