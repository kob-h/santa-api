using System;
using Microsoft.EntityFrameworkCore;
using SantaApi.Model;
using SantaApi.Persistence;

namespace SantaApi.DAL
{
	public class ChildrenRepository : IChildrenRepository
    {
        private SantaDb _santaDb { get; }
        public ChildrenRepository(SantaDb santaDb)
		{
            _santaDb = santaDb;
        }

        public async Task<List<Child>> GetAllAsync()
        {
            return await _santaDb.Children.ToListAsync();
        }

        public async Task<Child?> GetAsync(string name, int age)
        {
            return await _santaDb.Children.SingleOrDefaultAsync(child => child.Name == name && child.Age == age);
        }
    }
}

