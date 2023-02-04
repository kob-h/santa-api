using System;
using SantaApi.DataContracts;
using SantaApi.Model;

namespace SantaApi.DAL
{
	public interface IChildGiftOwndershipRepository
	{
        Task<List<ChildGiftOwnership>> GetAllAsync();
        Task AddAllAsync(List<ChildGiftOwnership> childGiftOwnerships);
        Task UpdateAsync(string giftName, string childName, int childAge, UpdateGiftRequest request);
    }
}

