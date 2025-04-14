using ASP.NETMVCProject.Models;
using System.Collections.Generic;

namespace ASP.NETMVCProject.Services.Interfaces
{
    public interface IProductService
    {
        (List<object> Products, int TotalPages) GetPagedProducts(int page, int pageSize);
        Product GetById(int id);
        void Create(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
