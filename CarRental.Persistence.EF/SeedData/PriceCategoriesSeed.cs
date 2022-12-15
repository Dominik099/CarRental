using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Persistence.EF.SeedData
{
    public class PriceCategoriesSeed
    {
        public static List<PriceCategory> Get()
        {
            List<PriceCategory> priceCategories = new List<PriceCategory>();

            var category1 = new PriceCategory()
            {
                Id = PriceCategoriesSeedId.Basic,
                Category = "Basic",
                Multiplier = 1.0m
            };
            priceCategories.Add(category1);

            var category2 = new PriceCategory()
            {
                Id = PriceCategoriesSeedId.Standard,
                Category = "Standard",
                Multiplier = 1.3m
            };
            priceCategories.Add(category2);

            var category3 = new PriceCategory()
            {
                Id = PriceCategoriesSeedId.Medium,
                Category = "Medium",
                Multiplier = 1.6m
            };
            priceCategories.Add(category3);

            var category4 = new PriceCategory()
            {
                Id = PriceCategoriesSeedId.Premium,
                Category = "Premium",
                Multiplier = 2.0m
            };
            priceCategories.Add(category4);

            return priceCategories;
        }


    }
}
