using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechTonic.API.Data;
using TechTonic.API.Models.Domain;
using TechTonic.API.Models.DTO;

namespace TechTonic.API.Controllers
{
    //http(s)://localhost:xxxx/api/controller
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext dbContext;

        public CategoriesController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestDto request)
        {
            //Map DTO to Domain Model
            var category = new Category
            {
                Name = request.Name,
                UrlHandle = request.UrlHandle
            };

            await dbContext.Categories.AddAsync(category);
            await dbContext.SaveChangesAsync();

            //Map Domain Models to DTO
            var response = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle
            };

            return Ok(response);
        }
    }
}