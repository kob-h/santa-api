using System;
namespace SantaApi.Model
{
	public class ChildGiftOwnership
	{
        public long ChildId { get; set; }
        public virtual Child Child { get; set; }

        public long GiftId { get; set; }
        public virtual Gift Gift { get; set; }

        public string Color { get; set; }

    }
}

