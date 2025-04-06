using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP.NETMVCProject.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
