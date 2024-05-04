using System.ComponentModel.DataAnnotations;

namespace GForms.Shared
{
    public class Answer
    {
        public int Id { get; set; }

        [Required]
        public DateTime Data { get; set; }
        
        [Required]
        public string Text { get; set; }

        //[Required]
        //public int Score { get; set; }

        public Question? Question { get; set; }
    }
}
