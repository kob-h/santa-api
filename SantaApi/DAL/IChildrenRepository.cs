using System;
using SantaApi.Model;

namespace SantaApi.DAL
{
	public interface IChildrenRepository
	{
        Task<List<Child>> GetAllAsync();
        Task<Child?> GetAsync(string name, int age);
    }
}

