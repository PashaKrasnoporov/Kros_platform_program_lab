namespace Lab13_API.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("labs")]
public class LabsController : ControllerBase
{
	[HttpPost("1")]
	public async Task<IActionResult> Lab1()
	{
		if (!User.Identity.IsAuthenticated)
		{
			return Unauthorized("You are not authorized.");
		}
		
		using var reader = new StreamReader(Request.Body);
		var input = await reader.ReadToEndAsync();
		return Ok(Lab5ClassLib.Lab1.Run(input));
	}


	[HttpPost("2")]
	public async Task<IActionResult> Lab2()
	{
		if (!User.Identity.IsAuthenticated)
		{
			return Unauthorized("You are not authorized.");
		}
		
		using var reader = new StreamReader(Request.Body);
		var input = await reader.ReadToEndAsync();
		return Ok(Lab5ClassLib.Lab2.Run(input));
	}

	[HttpPost("3")]
	public async Task<IActionResult> Lab3()
	{
		if (!User.Identity.IsAuthenticated)
		{
			return Unauthorized("You are not authorized.");
		}
		
		using var reader = new StreamReader(Request.Body);
		var input = await reader.ReadToEndAsync();
		return Ok(Lab5ClassLib.Lab3.Run(input));
	}
}