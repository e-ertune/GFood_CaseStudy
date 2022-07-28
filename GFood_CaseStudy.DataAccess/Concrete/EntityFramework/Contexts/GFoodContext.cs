using GFood_CaseStudy.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace GFood_CaseStudy.DataAccess.Concrete.EntityFramework.Contexts
{
    public class GFoodContext : DbContext
    {
        public GFoodContext() { }

        public GFoodContext(DbContextOptions<GFoodContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Database=GFood;Username=postgres;Password=s9k15JN3&pLn");
                AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
                //optionsBuilder.UseLazyLoadingProxies();
            }
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketProduct> BasketProducts { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<CampaignCondition> CampaignConditions { get; set; }
        public DbSet<CampaignConditionProduct> CampaignConditionProducts { get; set; }
        public DbSet<CampaignGoal> CampaignGoals { get; set; }
        public DbSet<CampaignGoalProduct> CampaignGoalProducts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductPrice> ProductPrices { get; set; }
        public DbSet<BasketCampaign> BasketCampaigns { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Products");
                entity.HasIndex(e => e.Code).HasDatabaseName("IX_Products_Code");
                entity.HasIndex(e => e.CreatedAt).HasDatabaseName("IX_Products_CreatedAt");
                entity.HasIndex(e => e.UpdatedAt).HasDatabaseName("IX_Products_UpdatedAt");
                entity.HasMany(e => e.BasketProducts).WithOne(e => e.Product);
                entity.HasMany(e => e.ProductCategories).WithOne(e => e.Product);
                entity.HasMany(e => e.ProductPrices).WithOne(e => e.Product);
                entity.HasMany(e => e.CampaignConditionProducts).WithOne(e => e.Product);
                entity.HasMany(e => e.CampaignGoalProducts).WithOne(e => e.Product);
            });

            modelBuilder.Entity<Basket>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Baskets");
                entity.HasIndex(e => e.CreatedAt).HasDatabaseName("IX_Baskets_CreatedAt");
                entity.HasIndex(e => e.UpdatedAt).HasDatabaseName("IX_Baskets_UpdatedAt");
                entity.HasMany(e => e.BasketProducts).WithOne(e => e.Basket);
                entity.HasMany(e => e.BasketCampaigns).WithOne(e => e.Basket);
            });

            modelBuilder.Entity<Campaign>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Campaigns");
                entity.HasIndex(e => e.CreatedAt).HasDatabaseName("IX_Campaigns_CreatedAt");
                entity.HasIndex(e => e.UpdatedAt).HasDatabaseName("IX_Campaigns_UpdatedAt");
                entity.HasMany(e => e.CampaignGoals).WithOne(e => e.Campaign);
                entity.HasMany(e => e.CampaignConditions).WithOne(e => e.Campaign);
                entity.HasMany(e => e.BasketCampaigns).WithOne(e => e.Campaign);
            });

            modelBuilder.Entity<CampaignCondition>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_CampaignConditions");
                entity.HasIndex(e => e.CreatedAt).HasDatabaseName("IX_CampaignConditions_CreatedAt");
                entity.HasIndex(e => e.UpdatedAt).HasDatabaseName("IX_CampaignConditions_UpdatedAt");
                entity.HasMany(e => e.CampaignConditionProducts).WithOne(e => e.CampaignCondition);
            });

            modelBuilder.Entity<CampaignConditionProduct>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.CampaignConditionId }).HasName("PK_CampaignConditionProducts");
            });

            modelBuilder.Entity<CampaignGoal>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_CampaignGoals");
                entity.HasIndex(e => e.CreatedAt).HasDatabaseName("IX_CampaignGoals_CreatedAt");
                entity.HasIndex(e => e.UpdatedAt).HasDatabaseName("IX_CampaignGoals_UpdatedAt");
                entity.HasMany(e => e.CampaignGoalProducts).WithOne(e => e.CampaignGoal);
            });

            modelBuilder.Entity<CampaignGoalProduct>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.CampaignGoalId }).HasName("PK_CampaignGoalProducts");
            });

            modelBuilder.Entity<BasketProduct>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.BasketId }).HasName("PK_BasketProducts");
                entity.HasIndex(e => e.CreatedAt).HasDatabaseName("IX_BasketProducts_CreatedAt");
                entity.HasIndex(e => e.UpdatedAt).HasDatabaseName("IX_BasketProducts_UpdatedAt");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Categories");
                entity.HasIndex(e => e.CreatedAt).HasDatabaseName("IX_Categories_CreatedAt");
                entity.HasIndex(e => e.UpdatedAt).HasDatabaseName("IX_Categories_UpdatedAt");
                entity.HasIndex(e => e.ParentId).HasDatabaseName("IX_Categories_ParentId");
                entity.HasMany(e => e.SubCategories).WithOne(e => e.ParentCategory);
                entity.HasMany(e => e.ProductCategories).WithOne(e => e.Category);
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.CategoryId }).HasName("PK_ProductCategories");
            });

            modelBuilder.Entity<ProductPrice>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_ProductPrices");
                entity.HasIndex(e => e.CreatedAt).HasDatabaseName("IX_ProductPrices_CreatedAt");
            });

            modelBuilder.Entity<BasketCampaign>(entity =>
            {
                entity.HasKey(e => new { e.BasketId, e.CampaignId }).HasName("PK_BasketCampaigns");
            });
        }
    }
}
