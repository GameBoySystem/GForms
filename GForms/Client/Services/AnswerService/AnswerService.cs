using GForms.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace GForms.Client.Services.AnswerService
{
    public class AnswerService : IAnswerService
    {
        private HttpClient _http;
        private NavigationManager _navigationManager;

        public AnswerService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<Answer> Answers { get; set; } = new List<Answer>();
        public List<Question> Questions { get; set; } = new List<Question>();

        public async Task PostAnswer(Answer answer, int questionId)
        {
            await _http.PostAsJsonAsync($"api/Answers/{questionId}", answer);
        }
    }
}
