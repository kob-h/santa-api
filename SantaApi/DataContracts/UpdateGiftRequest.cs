using System;
using System.ComponentModel.DataAnnotations;

namespace SantaApi.DataContracts
{
	public class UpdateGiftRequest
	{
        [Required]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Color can contain up to 10 characters")]
        public string Color { get; set; }
	}
}

