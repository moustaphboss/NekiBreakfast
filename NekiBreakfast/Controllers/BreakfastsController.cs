using Microsoft.AspNetCore.Mvc;
using NekiBreakfast.Contracts.Breakfast;
using NekiBreakfast.Models;
using NekiBreakfast.Services.Breakfasts;

namespace NekiBreakfast.Controllers;

[ApiController]
[Route("[controller]")]
// [Route("breakfasts")] same as above
public class BreakfastsController : ControllerBase
{
    private readonly IBreakfastService _breakfastService;

    public BreakfastsController(IBreakfastService breakfastService)
    {
        _breakfastService = breakfastService;
    }

    [HttpPost]
    public IActionResult CreateBreakfast(CreateBreakfastRequest request) {
        var breakfast = new Breakfast(
            Guid.NewGuid(),
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Savory,
            request.Sweet);

        // TODO Save Breakfast to database
        _breakfastService.CreateBreakfast(breakfast);

        var response = new BreakfastResponse(
            breakfast.Id,
            breakfast.Name,
            breakfast.Description,
            breakfast.StartDateTime,
            breakfast.EndDateTime,
            breakfast.LastModifiedDateTime,
            breakfast.Savory,
            breakfast.Sweet);

        return CreatedAtAction(
            actionName : nameof(GetBreakfast),
            routeValues : new {id = breakfast.Id},
            value : response);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetBreakfast(Guid id) {
        Breakfast breakfast = _breakfastService.GetBreakfast(id);

        var response = new BreakfastResponse(
            breakfast.Id,
            breakfast.Name,
            breakfast.Description,
            breakfast.StartDateTime,
            breakfast.EndDateTime,
            breakfast.LastModifiedDateTime,
            breakfast.Savory,
            breakfast.Sweet);
            
        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertBreakfast(Guid id, UpsertBreakfastRequest request) {
        var breakfast = new Breakfast(
            id,
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Savory,
            request.Sweet);

        // Updating the breakfast in the database
        _breakfastService.UpsertBreakfast(breakfast);

        // TODO Return 201 if a new breakfast was created
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteBreakfast(Guid id) {
        // Deleting the breakfast from the database
        _breakfastService.DeleteBreakfast(id);
        return Ok(id);
    }
}