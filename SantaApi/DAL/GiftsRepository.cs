using System;
using Microsoft.EntityFrameworkCore;
using SantaApi.Model;
using SantaApi.Persistence;

namespace SantaApi.DAL
{
	public class GiftsRepository : IGiftsRepository
    {
        private SantaDb _santaDb { get; }
        public GiftsRepository(SantaDb santaDb)
        {
            _santaDb = santaDb;
        }

        public async Task<List<Gift>> GetAllAsync()
        {
            return await _santaDb.Gifts.ToListAsync();
        }
    }
}

