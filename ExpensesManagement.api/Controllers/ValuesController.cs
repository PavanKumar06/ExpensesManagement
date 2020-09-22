using System.IO;
using System.Threading.Tasks;
using ExpensesManagement.api.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpensesManagement.api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IValuesRepository Repo;
        public ValuesController(IValuesRepository repo)
        {
            Repo = repo;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetValues() 
        {
            var empvalues = await Repo.GetValues();

            return Ok(empvalues);    
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetValue(string username)
        {
            var empvalue = await Repo.GetValue(username);

            return Ok(empvalue);
        }

        [HttpGet("register/{path}")]
        public async Task<IActionResult> DownloadFile(string path)
        {
            var folderName = Path.Combine("Resources");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
            var fullPath = Path.Combine(pathToSave, path);

            var memory = new MemoryStream();

            using (var stream = new FileStream(fullPath, FileMode.Open))  
            {  
                await stream.CopyToAsync(memory);  
            }  

            memory.Position = 0;

            return File(memory, Repo.GetContentType(path), Path.GetFileName(fullPath));
        }
    }
}