using ASP.NETMVCProject.Data;
using ASP.NETMVCProject.Models;
using ASP.NETMVCProject.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASP.NETMVCProject.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public (List<object> Products, int TotalPages) GetPagedProducts(int page, int pageSize)
        {
            var totalProducts = _context.Products.Count();
            var totalPages = (int)Math.Ceiling((double)totalProducts / pageSize);

            var products = _context.Products
                                   .Include(p => p.Category)
                                   .OrderBy(p => p.ProductId)
                                   .Skip((page - 1) * pageSize)
                                   .Take(pageSize)
                                   .Select(p => new
                                   {
                                       p.ProductId,
                                       p.ProductName,
                                       p.CategoryId,
                                       CategoryName = p.Category.CategoryName
                                   })
                                   .ToList<object>();

            return (products, totalPages);
        }

        public Product GetById(int id)
        {
            return _context.Products.Find(id);
        }

        public void Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.Find(id);
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }


        public void Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }
    }
}
