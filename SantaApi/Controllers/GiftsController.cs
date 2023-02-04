using Microsoft.AspNetCore.Mvc;
using SantaApi.BusinessService;
using SantaApi.DataContracts;

namespace SantaApi.Controllers;

[ApiController]
[Route("[controller]")]
public class GiftsController : ControllerBase
{
    private readonly IGiftsService _giftsService;

    public GiftsController(
        [FromServices] IGiftsService giftsService)
    {
        _giftsService = giftsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var items = await _giftsService.GetAllAsync();
        return Ok(items);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] NewGiftRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _giftsService.CreateAsync(request);

        return NoContent();
    }

    [HttpPut("{giftName}/children/{childName}/{childAge}")]
    public async Task<IActionResult> Update(string giftName, string childName, int childAge, [FromBody] UpdateGiftRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _giftsService.UpdateAsync(giftName, childName, childAge,request);

        return NoContent();
    }
}

