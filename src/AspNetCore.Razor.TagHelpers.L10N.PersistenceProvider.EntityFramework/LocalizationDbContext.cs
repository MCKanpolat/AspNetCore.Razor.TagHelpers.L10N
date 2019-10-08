﻿using AspNetCore.Razor.TagHelpers.L10N.PersistenceProvider.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCore.Razor.TagHelpers.L10N.PersistenceProvider.EntityFramework
{
    public class LocalizationDbContext : DbContext
    {
        private readonly L10NDbConfiguration l10NDbConfiguration;

        public LocalizationDbContext(DbContextOptions<LocalizationDbContext> options, L10NDbConfiguration l10NDbConfiguration) : base(options)
        {
            this.l10NDbConfiguration = l10NDbConfiguration ?? throw new ArgumentNullException(nameof(l10NDbConfiguration));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContentTranslationEntity>()
                .ToTable(l10NDbConfiguration.TableName, l10NDbConfiguration.Schema)
                .HasKey(w => w.Id);

            modelBuilder.Entity<ContentTranslationEntity>()
                .HasIndex(w => new { w.CultureInfo, w.Key });
        }

        public virtual DbSet<ContentTranslation> ContentTranslations { get; set; }
    }
}