using System;

namespace MonkeyShelterAPI.Dtos
{
    public class MonkeyCountDto
    {
        /// <summary>Species of the monkey.</summary>
        public string Species { get; set; }

        /// <summary>Monkey count by species.</summary>
        public int Count { get; set; }
    }
}