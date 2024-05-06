using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GForms.Shared
{
    public class Question
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [JsonIgnore]
        public Test? Test { get; set; }

        public List<AnswerVariant>? AnswerVariants { get; set; }
        
        public List<Answer>? Answers { get; set; }
    }
}
