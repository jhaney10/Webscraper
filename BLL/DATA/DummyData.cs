using System;
using System.Collections.Generic;
using System.Text;
using Webscraper.Models;

namespace BLL.DATA
{
    public class DummyData
    {
        public List<ProductListing> Products;
        public DummyData()
        {
            Products = new List<ProductListing>();
            Products.Add(new ProductListing(1, "stila Stay All Day Waterproof Liquid Eye Liner", 2000.00m, Category.Beauty));
            Products.Add(new ProductListing(2, "Honest Beauty Extreme Length Mascara + Lash Primer | 2-in-1 Boosts Lash Length, " +
                "Volume & Definition", 2000.00m, Category.Beauty));
            Products.Add(new ProductListing(3, "NYX PROFESSIONAL MAKEUP Butter Gloss - Creme Brulee, Natural", 6000.00m, Category.Beauty));
            Products.Add(new ProductListing(4, "Covergirl Lash Blast Volume Mascara, Very Black", 4700.00m, Category.Beauty));
            Products.Add(new ProductListing(5, "Grande Cosmetics GrandeLASH-MD Lash Enhancing Serum", 8000.00m, Category.Beauty));
            Products.Add(new ProductListing(6, "NYX PROFESSIONAL MAKEUP Control Freak Eyebrow Gel", 9000.00m, Category.Beauty));
            Products.Add(new ProductListing(7, "Maybelline Total Temptation Eyebrow Definer Pencil, Soft Brown, 1 Count", 9000.00m, Category.Beauty));
            Products.Add(new ProductListing(8, "NYX PROFESSIONAL MAKEUP Mechanical Eye Liner Pencil, Black", 2000.00m, Category.Beauty));


        }
    }
}
