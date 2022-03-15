using System;

namespace MonkeyShelterAPI.Dtos
{
    public class MonkeyDto
    {
        /// <summary>Unique database id of the monkey.</summary>
        public Guid Id { get; set; }

        /// <summary>Name of the monkey.</summary>
        public string Name { get; set; }

        /// <summary>Age of the monkey.</summary>
        public int Age { get; set; }

        /// <summary>Weight of the monkey.</summary>
        public int Weight { get; set; }

        /// <summary>Eye color of the monkey.</summary>
        public string EyeColor { get; set; }

        /// <summary>Species of the monkey.</summary>
        public string Species { get; set; }

        /// <summary>Monkey registration date.</summary>
        public string Registered { get; set; }

        /// <summary>Favorite fruit of the monkey.</summary>
        public string FavoriteFruit { get; set; }
    }
}