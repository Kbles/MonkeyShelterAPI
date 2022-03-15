using MonkeyShelterAPI.Dtos;
using MonkeyShelterAPI.Models;

namespace MonkeyShelterAPI
{
    public static class Extensions
    {
        public static MonkeyDto AsDto(this Monkey monkey)
        {
            return new MonkeyDto
            {
                Id = monkey.Id,
                Name = monkey.Name,
                Age = monkey.Age,
                Weight = monkey.Weight,
                EyeColor = monkey.EyeColor,
                Species = monkey.Species,
                Registered = monkey.Registered,
                FavoriteFruit = monkey.FavoriteFruit
            };
        }

    }
}