using GForms.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace GForms.Client.Services.QuestionService
{
    public class QuestionService : IQuestionService
    {
        private HttpClient _http;
        private NavigationManager _navigationManager;

        public QuestionService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<Question> Questions { get; set; } = new List<Question>();
        public List<Test> Tests { get; set; } = new List<Test>();

        public async Task DeleteQuestion(int id)
        {
            await _http.DeleteAsync($"api/Questions/{id}");
            //_navigationManager.NavigateTo("/");
        }

        public async Task<Question> GetQuestion(int id)
        {
            var result = await _http.GetFromJsonAsync<Question>($"api/Questions/{id}");
            if (result != null)
                return result;
            throw new Exception("Question not found!");
        }

        public async Task<List<Question>> GetQuestions()
        {
            var result = await _http.GetFromJsonAsync<List<Question>>("api/Questions");
            if (result != null)
                return result;
            else
                return new List<Question>();
        }

        public async Task PostQuestion(int testId, Question question)
        {
            await _http.PostAsJsonAsync($"api/Questions/{testId}", question);
            _navigationManager.NavigateTo($"/MyTest/{testId}");
        }

        public async Task PutQuestion(int questionId, Question question)
        {
            await _http.PutAsJsonAsync($"api/Questions/{questionId}", question);
            _navigationManager.NavigateTo("/");
        }
    }
}
