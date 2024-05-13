using GForms.Client.Services.QuestionService;
using GForms.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace GForms.Client.Services.AnswerVariantService
{
    public class AnswerVariantService : IAnswerVariantService
    {
        private HttpClient _http;
        private NavigationManager _navigationManager;

        public AnswerVariantService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<AnswerVariant> AnswerVariants { get; set; } = new List<AnswerVariant>();
        public List<Question> Questions { get; set; } = new List<Question>();

        public Task DeleteAnswerVariant(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AnswerVariant>> GetAllAnswerVariants()
        {
            var result = await _http.GetFromJsonAsync<List<AnswerVariant>>("api/AnswerVariants");
            if (result != null)
                return result;
            else
                return new List<AnswerVariant>();
        }

        public async Task<AnswerVariant> GetAnswerVariant(int id)
        {
            var result = await _http.GetFromJsonAsync<AnswerVariant>($"api/AnswerVariants/{id}");
            if (result != null)
                return result;
            throw new Exception("AnswerVariant not found!");
        }

        public async Task PostAnswerVariant(AnswerVariant answerVariant)
        {
            await _http.PostAsJsonAsync("api/AnswerVariants", answerVariant);
            //_navigationManager.NavigateTo("/MyTest/{testId}/"); Старая переадрессация
        }

        public Task PutAnswerVariant(int id, AnswerVariant answerVariant)
        {
            throw new NotImplementedException();
        }
    }
}
