using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPWebApi.DTO
{
    public class CategoryDto
    {

        public string CatCode { get; set; }
        public string? CatParent { get; set; }
        public string? CatName { get; set; }
        public List<CategoryDto> SubCategories { get; set; } = new List<CategoryDto>();
        public List<MaterialDto> Materials { get; set; } = new List<MaterialDto>();
    }
    public class MaterialDto
    {
        public string MatCode { get; set; }
        public string? MatName { get; set; }
    }
}


