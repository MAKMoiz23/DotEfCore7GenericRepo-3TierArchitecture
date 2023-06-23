using BAL.Services.IService;
using Microsoft.AspNetCore.Mvc;
using Pos_API.GlobalAndCommon;

namespace POS_Cashier.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerController : ControllerBase
	{
		private readonly ILogger<CustomerController> _logger;
		private readonly ICustomerService _service;

		public CustomerController(ILogger<CustomerController> logger, ICustomerService dataService)
		{
			_logger = logger;
			_service = dataService;
		}

		[HttpGet]
		[Route("GetAll")]
		public async Task<IActionResult> GetAll()
		{
			_logger.LogInformation("Getting all data...");
			if (!ModelState.IsValid) return BadRequest("Model State is not Valid!");
			var result = await _service.GetAll();
			if (result == null) return NotFound();
			return Ok(new { message = Message.Success, data = result });
		}
	}
}
