﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Domain.Filter;
using WebStore.Infrastructure.Interfaces;
using WebStore.ViewModels;

namespace WebStore.ViewComponents
{
    public class Brands : ViewComponent
    {
        private readonly IProductService _productService;

        public Brands(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var brands = GetBrands();
            return View(brands);
        }
        public IEnumerable<BrandViewModel> GetBrands()
        {
            var brands = _productService.GetBrands();
            var products = _productService.GetProducts(new ProductFilter());
            //return brands.Select(p => new BrandViewModel
            //        {
            //            Id = p.Id,
            //            Name = p.Name,
            //            Order = p.Order,
            //            ProductCount = 0
            //        })
            //    .OrderBy(p => p.Order)
            //    .ToList();
            return brands.Select(p => new BrandViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Order = p.Order,
                ProductCount = products.Where(o => o.BrandId == p.Id).Count()
            })
                .OrderBy(p => p.Order)
                .ToList();

        }
    }
}
