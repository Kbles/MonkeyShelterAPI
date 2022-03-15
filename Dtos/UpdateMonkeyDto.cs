using System.ComponentModel.DataAnnotations;

namespace MonkeyShelterAPI.Dtos
{
    public class UpdateMonkeyDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1, 999)]
        public int Age { get; set; }

        [Required]
        [Range(1, 5000)]
        public int Weight { get; set; }

        [Required]
        public string EyeColor { get; set; }

        [Required]
        public string Species { get; set; }

        [Required]
        public string FavoriteFruit { get; set; }
    }
}