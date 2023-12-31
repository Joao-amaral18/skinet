﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Migrations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(p=>p.Id).IsRequired();
        builder.Property(p=>p.Name).IsRequired().HasMaxLength(100);
        builder.Property(p=>p.Description).IsRequired().HasMaxLength(1000);
        builder.Property(p=>p.Price).HasColumnType("decimal(15,2)");
        builder.Property(p=>p.PictureUrl).IsRequired();
        builder.HasOne(p=>p.ProductBrand).WithMany()
            .HasForeignKey(d=>d.ProductBrandId);
        builder.HasOne(p => p.ProductType).WithMany()
            .HasForeignKey(d => d.ProductTypeId);
        
    }
}