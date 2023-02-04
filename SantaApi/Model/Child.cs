using System;
namespace SantaApi.Model
{
	public class Child
	{
		public long Id { get; set; }
		public int Age { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public virtual List<ChildGiftOwnership> ChildGiftOwnership { get; set; }
	}
}

