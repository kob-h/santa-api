using System;
using Microsoft.EntityFrameworkCore;
using SantaApi.DataContracts;
using SantaApi.Model;
using SantaApi.Persistence;

namespace SantaApi.DAL
{
	public class ChildGiftOwndershipRepository : IChildGiftOwndershipRepository
    {   
        private SantaDb _santaDb { get; }
        public ChildGiftOwndershipRepository(SantaDb santaDb)
	    {
            _santaDb = santaDb;
        }

        public async Task<List<ChildGiftOwnership>> GetAllAsync()
        {
            return await _santaDb.ChildGiftOwnership.Include(cgo =>cgo.Child).Include(cgo => cgo.Gift).ToListAsync();
        }

        public async Task AddAllAsync(List<ChildGiftOwnership> childGiftOwnerships)
        {
            await _santaDb.ChildGiftOwnership.AddRangeAsync(childGiftOwnerships);

            await _santaDb.SaveChangesAsync();
        }

        public async Task UpdateAsync(string giftName, string childName, int childAge, UpdateGiftRequest request)
        {
            var child = await _santaDb.Children.SingleOrDefaultAsync(c => c.Name == childName && c.Age == childAge);
            var gift = await _santaDb.Gifts.SingleOrDefaultAsync(g => g.Name == giftName );

            var giftToUpdate = await _santaDb.ChildGiftOwnership
                .SingleOrDefaultAsync(cgo => cgo.ChildId == child.Id && cgo.GiftId == gift.Id);

            if (giftToUpdate != null)
            {
                giftToUpdate.Color = request.Color;
            }

            await _santaDb.SaveChangesAsync();
        }
    }
}

