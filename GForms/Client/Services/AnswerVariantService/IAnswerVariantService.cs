namespace GForms.Client.Services.AnswerVariantService
{
    public interface IAnswerVariantService
    {
        List<AnswerVariant> AnswerVariants { get; set; }
        List<Question> Questions { get; set; }
        Task<List<AnswerVariant>> GetAllAnswerVariants();
        //Task<List<AnswerVariant>> GetAnswerVariants(int questionId);
        Task<AnswerVariant> GetAnswerVariant(int id);
        Task PostAnswerVariant(AnswerVariant answerVariant);
        Task PutAnswerVariant(int id, AnswerVariant answerVariant);
        Task DeleteAnswerVariant(int id);
    }
}