using ASP.NETMVCProject.Models;
using System.Collections.Generic;

namespace ASP.NETMVCProject.Models.DTOs
{
    public class PagedProductResult
    {
        public List<Product> Products { get; set; }
        public int TotalPages { get; set; }
    }
}
