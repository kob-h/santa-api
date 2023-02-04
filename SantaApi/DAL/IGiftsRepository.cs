using System;
using SantaApi.Model;

namespace SantaApi.DAL
{
	public interface IGiftsRepository
	{
        Task<List<Gift>> GetAllAsync();
    }
}

