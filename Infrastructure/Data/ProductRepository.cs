﻿using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ProductRepository : IProductRepository
{
    private readonly StoreContext _context;

    public ProductRepository (StoreContext context)
    {
        _context = context;
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<IReadOnlyList<Product>> GetProductsAsync()
    {
        return await _context.Products.ToListAsync();
    }
    public async Task<IReadOnlyList<ProductBrand>> GetProductsBrandsAsync()
    {
        return await _context.ProductBrand.ToListAsync();
    }

    public async Task<IReadOnlyList<ProductType>> GetProductsTypeAsync()
    {
        return await _context.ProductType.ToListAsync();
    }
}