using System;
using System.Security.Claims;
using System.Threading.Tasks;
using ExpensesManagement.api.Data;
using ExpensesManagement.api.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesManagement.api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TaxController : ControllerBase
    {
        private readonly ITaxRepository Repo;
        public TaxController(ITaxRepository repo)
        {
            Repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> UploadTax()
        {

            var empTaxDto = new EmpTaxDto();

            var files = Request.Form.Files;

            empTaxDto.Username = User.FindFirst(ClaimTypes.Name).Value;
            empTaxDto.Name = User.FindFirst(ClaimTypes.GivenName).Value;
            empTaxDto.FoodAmount = int.Parse(Request.Form["FoodAmount"]);
            empTaxDto.FuelAmount = int.Parse(Request.Form["FuelAmount"]);
            empTaxDto.HraAmount = int.Parse(Request.Form["HraAmount"]);
            empTaxDto.TravelAmount = int.Parse(Request.Form["TravelAmount"]);

            var createdTax = await Repo.UploadTax(empTaxDto, files);

            if (createdTax == null)
            {
                return StatusCode(400);
            }

            return StatusCode(201);
        }
    }
}