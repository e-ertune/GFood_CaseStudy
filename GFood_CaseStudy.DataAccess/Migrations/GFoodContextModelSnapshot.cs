﻿// <auto-generated />
using System;
using GFood_CaseStudy.DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GFood_CaseStudy.DataAccess.Migrations
{
    [DbContext(typeof(GFoodContext))]
    partial class GFoodContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GFood_CaseStudy.Entities.Models.Basket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("Total")
                        .HasColumnType("numeric");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id")
                        .HasName("PK_Baskets");

                    b.HasIndex("CreatedAt")
                        .HasDatabaseName("IX_Baskets_CreatedAt");

                    b.HasIndex("UpdatedAt")
                        .HasDatabaseName("IX_Baskets_UpdatedAt");

                    b.ToTable("Baskets", (string)null);
                });

            modelBuilder.Entity("GFood_CaseStudy.Entities.Models.BasketCampaign", b =>
                {
                    b.Property<int>("BasketId")
                        .HasColumnType("integer");

                    b.Property<int>("CampaignId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("BasketId", "CampaignId")
                        .HasName("PK_BasketCampaigns");

                    b.HasIndex("CampaignId");

                    b.ToTable("BasketCampaigns", (string)null);
                });

            modelBuilder.Entity("GFood_CaseStudy.Entities.Models.BasketProduct", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("BasketId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("ProductId", "BasketId")
                        .HasName("PK_BasketProducts");

                    b.HasIndex("BasketId");

                    b.HasIndex("CreatedAt")
                        .HasDatabaseName("IX_BasketProducts_CreatedAt");

                    b.HasIndex("UpdatedAt")
                        .HasDatabaseName("IX_BasketProducts_UpdatedAt");

                    b.ToTable("BasketProducts", (string)null);
                });

            modelBuilder.Entity("GFood_CaseStudy.Entities.Models.Campaign", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id")
                        .HasName("PK_Campaigns");

                    b.HasIndex("CreatedAt")
                        .HasDatabaseName("IX_Campaigns_CreatedAt");

                    b.HasIndex("UpdatedAt")
                        .HasDatabaseName("IX_Campaigns_UpdatedAt");

                    b.ToTable("Campaigns", (string)null);
                });

            modelBuilder.Entity("GFood_CaseStudy.Entities.Models.CampaignCondition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<int>("CampaignId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id")
                        .HasName("PK_CampaignConditions");

                    b.HasIndex("CampaignId");

                    b.HasIndex("CreatedAt")
                        .HasDatabaseName("IX_CampaignConditions_CreatedAt");

                    b.HasIndex("UpdatedAt")
                        .HasDatabaseName("IX_CampaignConditions_UpdatedAt");

                    b.ToTable("CampaignConditions", (string)null);
                });

            modelBuilder.Entity("GFood_CaseStudy.Entities.Models.CampaignConditionProduct", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("CampaignConditionId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("ProductId", "CampaignConditionId")
                        .HasName("PK_CampaignConditionProducts");

                    b.HasIndex("CampaignConditionId");

                    b.ToTable("CampaignConditionProducts", (string)null);
                });

            modelBuilder.Entity("GFood_CaseStudy.Entities.Models.CampaignGoal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<int>("CampaignId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsPercentage")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id")
                        .HasName("PK_CampaignGoals");

                    b.HasIndex("CampaignId");

                    b.HasIndex("CreatedAt")
                        .HasDatabaseName("IX_CampaignGoals_CreatedAt");

                    b.HasIndex("UpdatedAt")
                        .HasDatabaseName("IX_CampaignGoals_UpdatedAt");

                    b.ToTable("CampaignGoals", (string)null);
                });

            modelBuilder.Entity("GFood_CaseStudy.Entities.Models.CampaignGoalProduct", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("CampaignGoalId")
                        .HasColumnType("integer");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("ProductId", "CampaignGoalId")
                        .HasName("PK_CampaignGoalProducts");

                    b.HasIndex("CampaignGoalId");

                    b.ToTable("CampaignGoalProducts", (string)null);
                });

            modelBuilder.Entity("GFood_CaseStudy.Entities.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int?>("ParentCategoryId")
                        .HasColumnType("integer");

                    b.Property<int?>("ParentId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id")
                        .HasName("PK_Categories");

                    b.HasIndex("CreatedAt")
                        .HasDatabaseName("IX_Categories_CreatedAt");

                    b.HasIndex("ParentCategoryId");

                    b.HasIndex("ParentId")
                        .HasDatabaseName("IX_Categories_ParentId");

                    b.HasIndex("UpdatedAt")
                        .HasDatabaseName("IX_Categories_UpdatedAt");

                    b.ToTable("Categories", (string)null);
                });

            modelBuilder.Entity("GFood_CaseStudy.Entities.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id")
                        .HasName("PK_Products");

                    b.HasIndex("Code")
                        .HasDatabaseName("IX_Products_Code");

                    b.HasIndex("CreatedAt")
                        .HasDatabaseName("IX_Products_CreatedAt");

                    b.HasIndex("UpdatedAt")
                        .HasDatabaseName("IX_Products_UpdatedAt");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("GFood_CaseStudy.Entities.Models.ProductCategory", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.HasKey("ProductId", "CategoryId")
                        .HasName("PK_ProductCategories");

                    b.HasIndex("CategoryId");

                    b.ToTable("ProductCategories", (string)null);
                });

            modelBuilder.Entity("GFood_CaseStudy.Entities.Models.ProductPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.HasKey("Id")
                        .HasName("PK_ProductPrices");

                    b.HasIndex("CreatedAt")
                        .HasDatabaseName("IX_ProductPrices_CreatedAt");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductPrices", (string)null);
                });

            modelBuilder.Entity("GFood_CaseStudy.Entities.Models.BasketCampaign", b =>
                {
                    b.HasOne("GFood_CaseStudy.Entities.Models.Basket", "Basket")
                        .WithMany("BasketCampaigns")
                        .HasForeignKey("BasketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GFood_CaseStudy.Entities.Models.Campaign", "Campaign")
                        .WithMany("BasketCampaigns")
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Basket");

                    b.Navigation("Campaign");
                });

            modelBuilder.Entity("GFood_CaseStudy.Entities.Models.BasketProduct", b =>
                {
                    b.HasOne("GFood_CaseStudy.Entities.Models.Basket", "Basket")
                        .WithMany("BasketProducts")
                        .HasForeignKey("BasketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GFood_CaseStudy.Entities.Models.Product", "Product")
                        .WithMany("BasketProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Basket");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("GFood_CaseStudy.Entities.Models.CampaignCondition", b =>
                {
                    b.HasOne("GFood_CaseStudy.Entities.Models.Campaign", "Campaign")
                        .WithMany("CampaignConditions")
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Campaign");
                });

            modelBuilder.Entity("GFood_CaseStudy.Entities.Models.CampaignConditionProduct", b =>
                {
                    b.HasOne("GFood_CaseStudy.Entities.Models.CampaignCondition", "CampaignCondition")
                        .WithMany("CampaignConditionProducts")
                        .HasForeignKey("CampaignConditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GFood_CaseStudy.Entities.Models.Product", "Product")
                        .WithMany("CampaignConditionProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CampaignCondition");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("GFood_CaseStudy.Entities.Models.CampaignGoal", b =>
                {
                    b.HasOne("GFood_CaseStudy.Entities.Models.Campaign", "Campaign")
                        .WithMany("CampaignGoals")
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Campaign");
                });

            modelBuilder.Entity("GFood_CaseStudy.Entities.Models.CampaignGoalProduct", b =>
                {
                    b.HasOne("GFood_CaseStudy.Entities.Models.CampaignGoal", "CampaignGoal")
                        .WithMany("CampaignGoalProducts")
                        .HasForeignKey("CampaignGoalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GFood_CaseStudy.Entities.Models.Product", "Product")
                        .WithMany("CampaignGoalProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CampaignGoal");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("GFood_CaseStudy.Entities.Models.Category", b =>
                {
                    b.HasOne("GFood_CaseStudy.Entities.Models.Category", "ParentCategory")
                        .WithMany("SubCategories")
                        .HasForeignKey("ParentCategoryId");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("GFood_CaseStudy.Entities.Models.ProductCategory", b =>
                {
                    b.HasOne("GFood_CaseStudy.Entities.Models.Category", "Category")
                        .WithMany("ProductCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GFood_CaseStudy.Entities.Models.Product", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("GFood_CaseStudy.Entities.Models.ProductPrice", b =>
                {
                    b.HasOne("GFood_CaseStudy.Entities.Models.Product", "Product")
                        .WithMany("ProductPrices")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("GFood_CaseStudy.Entities.Models.Basket", b =>
                {
                    b.Navigation("BasketCampaigns");

                    b.Navigation("BasketProducts");
                });

            modelBuilder.Entity("GFood_CaseStudy.Entities.Models.Campaign", b =>
                {
                    b.Navigation("BasketCampaigns");

                    b.Navigation("CampaignConditions");

                    b.Navigation("CampaignGoals");
                });

            modelBuilder.Entity("GFood_CaseStudy.Entities.Models.CampaignCondition", b =>
                {
                    b.Navigation("CampaignConditionProducts");
                });

            modelBuilder.Entity("GFood_CaseStudy.Entities.Models.CampaignGoal", b =>
                {
                    b.Navigation("CampaignGoalProducts");
                });

            modelBuilder.Entity("GFood_CaseStudy.Entities.Models.Category", b =>
                {
                    b.Navigation("ProductCategories");

                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("GFood_CaseStudy.Entities.Models.Product", b =>
                {
                    b.Navigation("BasketProducts");

                    b.Navigation("CampaignConditionProducts");

                    b.Navigation("CampaignGoalProducts");

                    b.Navigation("ProductCategories");

                    b.Navigation("ProductPrices");
                });
#pragma warning restore 612, 618
        }
    }
}
