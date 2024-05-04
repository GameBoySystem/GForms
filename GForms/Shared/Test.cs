using System.ComponentModel.DataAnnotations;

namespace GForms.Shared
{
    public class Test
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [MaxLength(450)]
        public ApplicationUser? ApplicationUser { get; set; }

        public List<Question>? Questions { get; set; }
    }
}
