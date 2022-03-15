using MonkeyShelterAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonkeyShelterAPI.Repositories
{
    public interface IMonkeysRepository
    {
        Task<Monkey> GetMonkeyAsync(Guid id);
        Task<IEnumerable<Monkey>>GetMonkeysAsync();

        Task CreateMonkeyAsync(Monkey monkey);

        Task UpdateMonkeyAsync(Monkey monkey);

        Task DeleteMonkeyAsync(Guid id);
    }
}