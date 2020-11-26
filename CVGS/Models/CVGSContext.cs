using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CVGS.Models
{
    public partial class CVGSContext : DbContext
    {
        public CVGSContext()
        {
        }

        public CVGSContext(DbContextOptions<CVGSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AddressMailing> AddressMailing { get; set; }
        public virtual DbSet<AddressShipping> AddressShipping { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<CategoryPreference> CategoryPreference { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<EsrbRating> EsrbRating { get; set; }
        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<GameCategory> GameCategory { get; set; }
        public virtual DbSet<GamePerspective> GamePerspective { get; set; }
        public virtual DbSet<GameStatus> GameStatus { get; set; }
        public virtual DbSet<GameSubCategory> GameSubCategory { get; set; }
        public virtual DbSet<Platform> Platform { get; set; }
        public virtual DbSet<PlatformPreference> PlatformPreference { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<SubCategoryPreference> SubCategoryPreference { get; set; }

        // Unable to generate entity type for table 'dbo.Sku'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-DIEU4LO3\\SQLEXPRESS;Database=CVGS;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<AddressMailing>(entity =>
            {
                entity.HasKey(e => e.MailingId)
                    .HasName("PK__AddressM__4E8DFD561DD20E0B");

                entity.Property(e => e.MailingId)
                    .HasColumnName("mailingId")
                    .ValueGeneratedNever();

                entity.Property(e => e.ApartmentNumber)
                    .IsRequired()
                    .HasColumnName("apartmentNumber")
                    .HasMaxLength(20);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(20);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(20);

                entity.Property(e => e.LastModified)
                    .HasColumnName("lastModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasMaxLength(20);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasColumnName("postalCode")
                    .HasMaxLength(6);

                entity.Property(e => e.Province)
                    .IsRequired()
                    .HasColumnName("province")
                    .HasMaxLength(20);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasColumnName("street")
                    .HasMaxLength(20);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("userId")
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AddressMailing)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AddressMa__userI__7908F585");
            });

            modelBuilder.Entity<AddressShipping>(entity =>
            {
                entity.HasKey(e => e.ShippingId)
                    .HasName("PK__AddressS__EDF80BCA6656726E");

                entity.Property(e => e.ShippingId)
                    .HasColumnName("shippingId")
                    .ValueGeneratedNever();

                entity.Property(e => e.ApartmentNumber)
                    .IsRequired()
                    .HasColumnName("apartmentNumber")
                    .HasMaxLength(20);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(20);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(20);

                entity.Property(e => e.LastModified)
                    .HasColumnName("lastModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasMaxLength(20);

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasColumnName("postalCode")
                    .HasMaxLength(6);

                entity.Property(e => e.Province)
                    .IsRequired()
                    .HasColumnName("province")
                    .HasMaxLength(20);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasColumnName("street")
                    .HasMaxLength(20);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("userId")
                    .HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AddressShipping)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AddressSh__userI__79FD19BE");
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Bio)
                    .IsRequired()
                    .HasDefaultValueSql("('Tell us about yourself.')");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(450);

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(450);

                entity.Property(e => e.DateOfBirth)
                    .HasColumnName("dateOfBirth")
                    .HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FirstName)
                    .HasColumnName("firstName")
                    .HasMaxLength(450);

                entity.Property(e => e.GamerTag)
                    .IsRequired()
                    .HasDefaultValueSql("('YourGamerTag')");

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(450);

                entity.Property(e => e.LastName)
                    .HasColumnName("lastName")
                    .HasMaxLength(450);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.PromoEmailEnabled)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ProvinceState)
                    .HasColumnName("provinceState")
                    .HasMaxLength(450);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<CategoryPreference>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.GamecategoryId })
                    .HasName("PK__Category__5503CE5E31DD18C6");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.GamecategoryId).HasColumnName("gamecategoryId");

                entity.Property(e => e.LastModified)
                    .HasColumnName("lastModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Gamecategory)
                    .WithMany(p => p.CategoryPreference)
                    .HasForeignKey(d => d.GamecategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CategoryP__gamec__61316BF4");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CategoryPreference)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CategoryP__userI__603D47BB");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("Country_PK");

                entity.Property(e => e.Code)
                    .HasMaxLength(3)
                    .ValueGeneratedNever();

                entity.Property(e => e.Alpha2Code)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.EnglishName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FrenchName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<EsrbRating>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("EsrbRatingCode_PK");

                entity.Property(e => e.Code)
                    .HasMaxLength(5)
                    .ValueGeneratedNever();

                entity.Property(e => e.EnglishRating)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.FrenchRating)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .HasName("Game_PK");

                entity.Property(e => e.Guid).ValueGeneratedNever();

                entity.Property(e => e.EnglishDescription).HasMaxLength(4000);

                entity.Property(e => e.EnglishDetail).HasMaxLength(4000);

                entity.Property(e => e.EnglishName)
                    .IsRequired()
                    .HasMaxLength(70);

                entity.Property(e => e.EnglishPlayerCount).HasMaxLength(30);

                entity.Property(e => e.EnglishTrailer).HasMaxLength(4000);

                entity.Property(e => e.EsrbRatingCode)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.Property(e => e.FrenchDescription).HasMaxLength(4000);

                entity.Property(e => e.FrenchDetail).HasMaxLength(4000);

                entity.Property(e => e.FrenchName)
                    .IsRequired()
                    .HasMaxLength(70);

                entity.Property(e => e.FrenchPlayerCount).HasMaxLength(30);

                entity.Property(e => e.FrenchTrailer).HasMaxLength(4000);

                entity.Property(e => e.GamePerspectiveCode).HasMaxLength(1);

                entity.Property(e => e.GameStatusCode)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.LastModified)
                    .HasColumnName("lastModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasDefaultValueSql("('Unknown')");

                entity.HasOne(d => d.EsrbRatingCodeNavigation)
                    .WithMany(p => p.Game)
                    .HasForeignKey(d => d.EsrbRatingCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Game_EsrbRating_FK");

                entity.HasOne(d => d.GameCategory)
                    .WithMany(p => p.Game)
                    .HasForeignKey(d => d.GameCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Game_GameCategory_FK");

                entity.HasOne(d => d.GamePerspectiveCodeNavigation)
                    .WithMany(p => p.Game)
                    .HasForeignKey(d => d.GamePerspectiveCode)
                    .HasConstraintName("Game_GamePerspective_FK");

                entity.HasOne(d => d.GameStatusCodeNavigation)
                    .WithMany(p => p.Game)
                    .HasForeignKey(d => d.GameStatusCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Game_GameStatus_FK");

                entity.HasOne(d => d.GameSubCategory)
                    .WithMany(p => p.Game)
                    .HasForeignKey(d => d.GameSubCategoryId)
                    .HasConstraintName("Game_GameSubCategory_FK");
            });

            modelBuilder.Entity<GameCategory>(entity =>
            {
                entity.Property(e => e.EnglishCategory)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.FrenchCategory)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<GamePerspective>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("GamePerspective_PK");

                entity.Property(e => e.Code)
                    .HasMaxLength(1)
                    .ValueGeneratedNever();

                entity.Property(e => e.EnglishPerspectiveName)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.FrenchPerspectiveName)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<GameStatus>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("GameStatus_PK");

                entity.Property(e => e.Code)
                    .HasMaxLength(1)
                    .ValueGeneratedNever();

                entity.Property(e => e.EnglishCategory)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.FrenchCategory)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<GameSubCategory>(entity =>
            {
                entity.Property(e => e.EnglishCategory)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.FrenchCategory)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Platform>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("Platform_PK");

                entity.Property(e => e.Code)
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.EnglishName)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.FrenchName)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<PlatformPreference>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.PlatformCode })
                    .HasName("PK__Platform__A669FBFE92BE477D");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.PlatformCode)
                    .HasColumnName("platformCode")
                    .HasMaxLength(10);

                entity.Property(e => e.LastModified)
                    .HasColumnName("lastModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.PlatformCodeNavigation)
                    .WithMany(p => p.PlatformPreference)
                    .HasForeignKey(d => d.PlatformCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlatformP__platf__5C6CB6D7");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PlatformPreference)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlatformP__userI__5B78929E");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("ProvinceLookup_PK");

                entity.Property(e => e.Code)
                    .HasMaxLength(2)
                    .ValueGeneratedNever();

                entity.Property(e => e.CountryCode)
                    .IsRequired()
                    .HasMaxLength(3);

                entity.Property(e => e.EnglishName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FederalTax).HasDefaultValueSql("((0))");

                entity.Property(e => e.FederalTaxAcronym).HasMaxLength(10);

                entity.Property(e => e.FrenchName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProvincialTax).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProvincialTaxAcronym).HasMaxLength(10);

                entity.Property(e => e.PstOnGst).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<SubCategoryPreference>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.GameSubcategoryId })
                    .HasName("PK__SubCateg__AEDF96AEA68DA694");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.GameSubcategoryId).HasColumnName("gameSubcategoryId");

                entity.Property(e => e.LastModified)
                    .HasColumnName("lastModified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.GameSubcategory)
                    .WithMany(p => p.SubCategoryPreference)
                    .HasForeignKey(d => d.GameSubcategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SubCatego__gameS__65F62111");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SubCategoryPreference)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SubCatego__userI__6501FCD8");
            });
        }
    }
}
