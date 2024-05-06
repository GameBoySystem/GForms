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

        public Task DeleteQuestion(int id)
        {
            throw new NotImplementedException();
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

        public Task PostQuestion(Question question)
        {
            throw new NotImplementedException();
        }

        public Task PutQuestion(int id, Question question)
        {
            throw new NotImplementedException();
        }
    }
}
