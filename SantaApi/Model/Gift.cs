using System;
namespace SantaApi.Model
{
	public class Gift
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public string Color { get; set; }
		public decimal Cost { get; set; }
        public virtual List<ChildGiftOwnership> ChildGiftOwnership { get; set; }
    }
}

