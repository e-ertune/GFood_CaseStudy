﻿namespace GFood_CaseStudy.Entities.Models
{
    public class Product : BaseEntity
    {
        public Product()
        {
            BasketProducts = new HashSet<BasketProduct>();
            ProductCategories = new HashSet<ProductCategory>();
            ProductPrices = new HashSet<ProductPrice>();
            CampaignConditionProducts = new HashSet<CampaignConditionProduct>();
            CampaignGoalProducts = new HashSet<CampaignGoalProduct>();
        }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public bool IsDeleted { get; set; } = false;

        public virtual ICollection<BasketProduct> BasketProducts { get; set; }
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }
        public virtual ICollection<ProductPrice> ProductPrices { get; set; }
        public virtual ICollection<CampaignConditionProduct> CampaignConditionProducts { get; set; }
        public virtual ICollection<CampaignGoalProduct> CampaignGoalProducts { get; set; }
    }
}
