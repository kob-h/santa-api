using System;
using System.Linq;
using SantaApi.DAL;
using SantaApi.DataContracts;
using SantaApi.Model;

namespace SantaApi.BusinessService
{
	public class GiftsService : IGiftsService
    {
        private readonly IGiftsRepository _giftsRepository;
        private readonly IChildrenRepository _childrenRepository;
        private readonly IChildGiftOwndershipRepository _childGiftOwndershipRepository;

        public GiftsService(
            IGiftsRepository giftsRepository,
            IChildrenRepository childrenRepository,
            IChildGiftOwndershipRepository childGiftOwndershipRepository)
		{
            _giftsRepository = giftsRepository;
            _childrenRepository = childrenRepository;
            _childGiftOwndershipRepository = childGiftOwndershipRepository;
        }

        public async Task CreateAsync(NewGiftRequest newGiftRequest)
        {

            var allPersistentGifts = await _giftsRepository.GetAllAsync();

            var newGifts = newGiftRequest.NewGifts;
            bool allGiftAvailable = AllGiftAvailable(allPersistentGifts, newGifts);
            bool allGiftsAreUnique = AllGiftsAreUnique(newGifts);

            var child = await _childrenRepository.GetAsync(newGiftRequest.Name, newGiftRequest.Age);
            if (allGiftAvailable && allGiftsAreUnique && child != null)
            {
                var allGiftsDict = allPersistentGifts.ToDictionary(g => g.Name);
                List<ChildGiftOwnership> giftChildOwnserships = PopulateOwnershipEntity(newGifts, child, allGiftsDict);

                await _childGiftOwndershipRepository.AddAllAsync(giftChildOwnserships);
            }
        }

        public async Task<GiftListResponse> GetAllAsync()
        {
            var childrenGiftOwnership = await _childGiftOwndershipRepository.GetAllAsync();
            var giftsByChildren = childrenGiftOwnership.GroupBy(cgo => cgo.Child);

            var response = new GiftListResponse();
            PopulateGetAllResponse(giftsByChildren, response);

            return response;
        }

        public async Task UpdateAsync(string giftName, string childName, int childAge, UpdateGiftRequest request)
        {
            await _childGiftOwndershipRepository.UpdateAsync(giftName, childName, childAge, request);
        }

        private static void PopulateGetAllResponse(IEnumerable<IGrouping<Child, ChildGiftOwnership>> giftsByChildren, GiftListResponse response)
        {
            foreach (var grp in giftsByChildren)
            {
                response.GiftsToChildren.Add(new GiftsToChildren()
                {
                    Age = grp.Key.Age,
                    Name = grp.Key.Name,
                    Gifts = MapGift(grp)
                });
            }
        }

        private static List<DataContracts.Gift> MapGift(IGrouping<Child, ChildGiftOwnership> grp)
        {
            return grp.Select(cgo => { var g = cgo.Gift; return new DataContracts.Gift() { Id = g.Id, Name = g.Name, Color = cgo.Color, Cost = g.Cost }; }).ToList();
        }

        private static List<ChildGiftOwnership> PopulateOwnershipEntity(List<DataContracts.NewGift> newGifts, Child? child, Dictionary<string, Model.Gift> allGiftsDict)
        {
            return newGifts.Select(ng => new ChildGiftOwnership()
            {
                Child = child,
                Gift = allGiftsDict[ng.Name],
                Color = ng.Color
            })
            .ToList();
        }

        private static bool AllGiftsAreUnique(List<DataContracts.NewGift> newGifts)
        {

            //Add validation that gifts are not identical.
            return newGifts.Select(g => g.Name).Distinct().Count() == newGifts.Select(g => g.Name).Count();
        }

        private static bool AllGiftAvailable(List<Model.Gift> allPersistentGifts, List<DataContracts.NewGift> newGifts)
        {
            //Add validation that all gifts are in the defined list in db.
            return newGifts.Select(g => g.Name).All(giftName => allPersistentGifts.Select(g => g.Name).Contains(giftName));
        }


    }
}

