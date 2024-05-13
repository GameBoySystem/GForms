namespace GForms.Client.Services.AnswerService
{
    public interface IAnswerService
    {
        Task PostAnswer(Answer answer, int questionId);
    }
}