using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace GForms.Shared
{
    public class Test
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [JsonIgnore]
        [MaxLength(450)]
        public ApplicationUser? ApplicationUser { get; set; }

        public List<Question>? Questions { get; set; }
    }
}
