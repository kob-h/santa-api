using System;
using SantaApi.Model;

namespace SantaApi.DataContracts
{
    public class GiftListResponse
    {
        public GiftListResponse()
        {
            GiftsToChildren = new List<GiftsToChildren>();
        }
        public List<GiftsToChildren> GiftsToChildren { get; set; }
    }

    public class GiftsToChildren
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Gift> Gifts { get; set; } = new List<Gift>();
    }

}

