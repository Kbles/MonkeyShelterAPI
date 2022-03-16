using Microsoft.AspNetCore.Mvc;
using MonkeyShelterAPI.Dtos;
using MonkeyShelterAPI.Models;
using MonkeyShelterAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MonkeyShelterAPI.Controllers
{
    [ApiController]
    [Route("monkeys")]
    public class MonkeysController : ControllerBase
    {
        private readonly IMonkeysRepository repository;

        public MonkeysController(IMonkeysRepository repository)
        {
            this.repository = repository;
        }

        // GET /monkeys
        [HttpGet]
        public async Task<IEnumerable<MonkeyDto>> GetMonkeysAsync()
        {
            var monkeys = (await repository.GetMonkeysAsync())
                            .Select(monkey => monkey.AsDto());
            return monkeys;
        }

        // GET /monkeys/report
        [HttpGet("report")]
        public async Task<IEnumerable<MonkeyCountDto>> GetMonkeysReportAsync()
        {
            var monkeys = (await repository.GetMonkeysAsync()).Select(monkey => monkey.AsDto());
            var monkeyPerSpecies =
                from monkey in monkeys
                group monkey by monkey.Species into speciesGroup
                select new MonkeyCountDto
                {
                    Species = speciesGroup.Key,
                    Count = speciesGroup.Count(),
                };

            return monkeyPerSpecies;
        }

        // GET /monkeys/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<MonkeyDto>> GetMonkeyAsync(Guid id)
        {
            var monkey = await repository.GetMonkeyAsync(id);

            if (monkey is null)
            {
                return NotFound();
            }

            return monkey.AsDto();
        }

        // POST /monkeys
        [HttpPost]
        public async Task<ActionResult<MonkeyDto>> CreateMonkeyAsync(CreateMonkeyDto monkeyDto)
        {
            Monkey monkey = new()
            {
                Id = Guid.NewGuid(),
                Name = monkeyDto.Name,
                Age = monkeyDto.Age,
                Weight = monkeyDto.Weight,
                EyeColor = monkeyDto.EyeColor,
                Species = monkeyDto.Species,
                Registered = DateTime.UtcNow.ToString("ddd MMM dd yyyy HH:mm:ss", CultureInfo.CreateSpecificCulture("en-US")),
                FavoriteFruit = monkeyDto.FavoriteFruit
            };

            await repository.CreateMonkeyAsync(monkey);

            return CreatedAtAction(nameof(GetMonkeyAsync), new { id = monkey.Id }, monkey.AsDto());
        }

        // PUT /monkeys/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItemAsync(Guid id, UpdateMonkeyDto monkeyDto)
        {
            var monkeyToUpdate = await repository.GetMonkeyAsync(id);

            if (monkeyToUpdate is null)
                return NotFound();

            monkeyToUpdate.Name = monkeyDto.Name;
            monkeyToUpdate.Age = monkeyDto.Age;
            monkeyToUpdate.Weight = monkeyDto.Weight;
            monkeyToUpdate.EyeColor = monkeyDto.EyeColor;
            monkeyToUpdate.Species = monkeyDto.Species;
            monkeyToUpdate.FavoriteFruit = monkeyDto.FavoriteFruit;

            await repository.UpdateMonkeyAsync(monkeyToUpdate);

            return NoContent();
        }

        // DELETE /items/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItemAsync(Guid id)
        {
            var monkeyToDelete = repository.GetMonkeyAsync(id);

            if (monkeyToDelete is null)
                return NotFound();

            await repository.DeleteMonkeyAsync(id);

            return NoContent();
        }
    }
}