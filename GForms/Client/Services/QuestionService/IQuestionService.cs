namespace GForms.Client.Services.QuestionService
{
    public interface IQuestionService
    {
        List<Question> Questions { get; set; }
        List<Test> Tests { get; set; }
        Task<List<Question>> GetQuestions();
        Task<Question> GetQuestion(int id);
        Task PostQuestion(int testId, Question question);
        Task PutQuestion(int id, Question question);
        Task DeleteQuestion(int id);
    }
}