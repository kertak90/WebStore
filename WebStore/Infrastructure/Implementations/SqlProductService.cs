using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.DAL;
using WebStore.Domain.Entities;
using WebStore.Domain.Filter;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Infrastructure.Implementations
{
    public class SqlProductService : IProductService
    {
        private readonly WebStoreContext _context;

        public SqlProductService(WebStoreContext context)
        {
            _context = context;
        }
        public IEnumerable<Brand> GetBrands()
        {
            return _context.Brands.ToList();
        }

        public Product GetProduct(int id)
        {
            return _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Section)
                .FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetProducts(ProductFilter filter)
        {
            var products = _context.Products.AsQueryable();     //В данной фильтрации, фильтрация будет происходить на уровне базы данных
            if (filter.SectionId.HasValue)
                products = products.Where(p => p.SectionId == filter.SectionId);
            if (filter.BrandId.HasValue)
                products = products.Where(p => p.BrandId == filter.BrandId);

            return products.ToList();
        }

        public IEnumerable<Section> GetSections()
        {
            return _context.Sections.ToList();
        }
    }
}
