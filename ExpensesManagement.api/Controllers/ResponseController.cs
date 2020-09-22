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
    public class ResponseController : ControllerBase
    {
        private readonly IResponseRepository Repo;
        public ResponseController(IResponseRepository repo)
        {
            Repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> PostResponse(ManagerResponseDto managerResponseDto)
        {
            var result = await Repo.PostResponses(managerResponseDto);

            return StatusCode(201);
        }

        [HttpGet("{username}")]
        public  async Task<IActionResult> GetResponse(string username)
        {
            var response = await Repo.GetResponse(username);

            if(response == null)
            {
                return StatusCode(404);
            }

            return Ok(response);
        }
    }
}