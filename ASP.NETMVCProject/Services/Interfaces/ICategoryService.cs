using ASP.NETMVCProject.Models;
using System.Collections;

public interface ICategoryService
{
    List<Category> GetAll();
    Category GetCategoryById(int id);
    void Create(Category category);
    void Update(Category category);
    void Delete(int id);
}
