using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GForms.Shared
{
    public class AnswerVariant
    {
        public int Id { get; set; }

        public string? Text { get; set; }

        [Required]
        public string? TypeOfAnswer { get; set; }

        //[Required]
        //public bool IsTrue { get; set; }

        [JsonIgnore]
        public Question? Question { get; set; }
    }
}
