using System.ComponentModel.DataAnnotations;

namespace GForms.Shared
{
    public class AnswerVariant
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public string TypeOfAnswer { get; set; }

        //[Required]
        //public bool IsTrue { get; set; }
    }
}
