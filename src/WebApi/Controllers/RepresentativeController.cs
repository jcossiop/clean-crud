using Application.Features.Representatives.Abstractions;
using Application.Features.Representatives.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

/// <summary>
/// Controller for all Representative methods.
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class RepresentativeController : ControllerBase
{
    private readonly IRepresentativeService _representativeService;

    /// <summary>
    /// Constructor injecting the service
    /// </summary>
    /// <param name="representativeService">Injected Service.</param>
    public RepresentativeController(IRepresentativeService representativeService)
    {
        _representativeService = representativeService;
    }

    /// <summary>
    /// Get all the representatives.
    /// </summary>
    /// <returns>List of representatives</returns>
    [HttpGet(Name = "GetAll")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<RepresentativeDto>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<RepresentativeDto>>> GetAll()
    {
        try
        {
            var representativeList = await _representativeService.GetAll();
            return Ok(representativeList);
        }
        catch
        {
            return Problem("Internal server error.");
        }
    }

    /// <summary>
    /// Add a Representative.
    /// </summary>
    /// <param name="representativeDto">Representative to persist.</param>
    /// <returns>Stored Representative.</returns>
    //[Authorize]
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RepresentativeDto))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<RepresentativeDto>> Add(RepresentativeDto representativeDto)
    {
        try
        { 
            var result = await _representativeService.Add(representativeDto);
            return Ok(result);
        }
        catch
        {
            return Problem("Internal server error.");
        }
    }

    /// <summary>
    /// Remove a Representative by Id.
    /// </summary>
    /// <param name="id">Id of the Representative to delete.</param>
    /// <returns>Task.</returns>
    //[Authorize]
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> Delete(int id)
    {
        if (id < 0)
            return BadRequest("Invalid Representative Id.");

        try 
        { 
            await _representativeService.Delete(id);
            return NoContent();
        }
        catch
        {
            return Problem("Internal server error.");
        }
    }

    /// <summary>
    /// Modify a Representative.
    /// </summary>
    /// <param name="representativeDto">Representative to modify.</param>
    /// <returns>Modified Representative.</returns>
    //[Authorize]
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RepresentativeDto))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<RepresentativeDto>> Update(RepresentativeDto representativeDto)
    {
        try
        {
            var result = await _representativeService.Update(representativeDto);
            return Ok(result);
        }
        catch
        {
            return Problem("Internal server error.");
        }

    }
}
