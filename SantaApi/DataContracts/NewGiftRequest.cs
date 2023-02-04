using System;
using System.ComponentModel.DataAnnotations;

namespace SantaApi.DataContracts
{
	public class NewGiftRequest
	{
		[Required]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Name can contain up to 20 characters")]
        public string Name { get; set; }
        [Required]
        [Range(1, 18, ErrorMessage = "You must be a child!")]
        public int Age { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 1, ErrorMessage = "Address can contain up to 60 characters")]
        public string Address { get; set; }
        [Required]
        public List<NewGift> NewGifts { get; set; }
	}

    public class NewGift
    {
        public string Name{ get; set; }
        public string Color { get; set; }
    }
}