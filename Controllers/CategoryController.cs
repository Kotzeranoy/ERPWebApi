using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERPWebApi.DTO;
using ERPWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERPWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ErpdbconnectContext _context;
        public CategoryController(ErpdbconnectContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
        {
            var categories = await _context.Tcategories
                .Include(c => c.Tmaterials)
                .Include(c => c.SubCategories)
                .Where(c => c.CatParent == null)
                .Select(c => new CategoryDto
                {
                    CatCode = c.CatCode,
                    CatParent = c.CatParent,
                    CatName = c.CatName,
                    SubCategories = c.SubCategories.Select(sub => new CategoryDto
                    {
                        CatCode = sub.CatCode,
                        CatParent = sub.CatParent,
                        CatName = sub.CatName,
                        Materials = sub.Tmaterials.Select(m => new MaterialDto
                        {
                            MatCode = m.MatCode,
                            MatName = m.MatName
                        }).ToList()
                    }).ToList(),
                    Materials = c.Tmaterials.Select(m => new MaterialDto
                    {
                        MatCode = m.MatCode,
                        MatName = m.MatName
                    }).ToList()
                })
                .ToListAsync();

            return Ok(categories);
        }

        // GET: api/Categories/{catCode}
        [HttpGet("{catCode}")]
        public async Task<ActionResult<CategoryDto>> GetCategory(string catCode)
        {
            var category = await _context.Tcategories
                .Include(c => c.Tmaterials)
                .Include(c => c.SubCategories)
                .Where(c => c.CatCode == catCode)
                .Select(c => new CategoryDto
                {
                    CatCode = c.CatCode,
                    CatParent = c.CatParent,
                    CatName = c.CatName,
                    SubCategories = c.SubCategories.Select(sub => new CategoryDto
                    {
                        CatCode = sub.CatCode,
                        CatParent = sub.CatParent,
                        CatName = sub.CatName,
                        Materials = sub.Tmaterials.Select(m => new MaterialDto
                        {
                            MatCode = m.MatCode,
                            MatName = m.MatName
                        }).ToList()
                    }).ToList(),
                    Materials = c.Tmaterials.Select(m => new MaterialDto
                    {
                        MatCode = m.MatCode,
                        MatName = m.MatName
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }
    }
}