using System;
using SantaApi.DataContracts;
using SantaApi.Model;

namespace SantaApi.BusinessService
{
	public interface IGiftsService
	{
		Task<GiftListResponse> GetAllAsync();
		Task CreateAsync(NewGiftRequest newGiftRequest);
		Task UpdateAsync(string giftName, string childName, int childAge, UpdateGiftRequest request);

    }
}

