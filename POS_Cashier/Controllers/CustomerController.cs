using BAL.Services.IService;
using DAL.Models;
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
		[HttpGet]
		[Route("GetCustomer/{CustomerID}")]
		public async Task<IActionResult> GetById(int CustomerID)
		{
			_logger.LogInformation("Getting data...");
			if (!ModelState.IsValid) return BadRequest("Model State is not Valid!");
			var result = await _service.GetById(CustomerID);
			if (result == null) return NotFound();
			return Ok(new { message = Message.Success, data = result });
		}
		[HttpPost]
		[Route("Insert")]
		public async Task<IActionResult> Insert(Customer model)
		{
			_logger.LogInformation("Saving data...");
			if (model == null) return BadRequest(Message.CanNotBeNull);
			await _service.Create(model);
			return Ok(new { message = Message.Success });
		}
		[HttpPut]
		[Route("Update")]
		public async Task<IActionResult> Update(Customer model)
		{
			_logger.LogInformation("Updating data...");
			if (model == null) return BadRequest(Message.CanNotBeNull);
			await _service.Update(model);
			return Ok(new { message = Message.Success });
		}
		[HttpDelete]
		[Route("Delete")]
		public async Task<IActionResult> Delete(int CustomerID)
		{
			_logger.LogInformation("Deleting data...");
			if (!ModelState.IsValid) return BadRequest("Model State is not Valid!");
			await _service.Delete(CustomerID);
			return Ok(new { message = Message.Success });
		}
	}
}
