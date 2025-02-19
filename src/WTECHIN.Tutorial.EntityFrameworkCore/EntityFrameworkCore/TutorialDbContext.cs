using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using WTECHIN.Tutorial.Books;
using Volo.Abp.Domain.Entities;
using WTECHIN.Tutorial.Authors;

namespace WTECHIN.Tutorial.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class TutorialDbContext :
    AbpDbContext<TutorialDbContext>,
    ITenantManagementDbContext,
    IIdentityDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */
    public DbSet<Book> Books { get; set; } //Book sınıfını veritabanındaki bir tablo olarak tanımlar.Books, EF Core’un bu tabloya erişmesini sağlar.Eğer DbSet<Book> eklemezsen:Entity Framework Core Books tablosunu tanımaz.
    //book entityi temsil eder books tablo ismini temsil eder

    #region Entities from the modules

    /* Notice: We only implemented IIdentityProDbContext and ISaasDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityProDbContext and ISaasDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    // Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; }
    public DbSet<IdentitySession> Sessions { get; set; }
    public DbSet<Author> Authors { get; set; } //bu kısmı ekledim

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public TutorialDbContext(DbContextOptions<TutorialDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureFeatureManagement();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureTenantManagement();
        builder.ConfigureBlobStoring();

        /* Configure your own tables/entities inside here */

        builder.Entity<Book>(b => //EF Core'un Book sınıfının nasıl bir veritabanı tablosuna dönüştürüleceğini belirlemek için kullanılır.
        {//Book varlığı için özel ayarlar tanımlıyoruz.b nesnesi üzerinden yapılandırmaları belirliyoruz.
            b.ToTable(TutorialConsts.DbTablePrefix + "Books", TutorialConsts.DbSchema);//Oluşturulan tablonun ismini ve şemasını belirler.ToTable("Books") → Books adlı bir tablo oluşturur.TutorialConsts.DbTablePrefix → Eğer bu değişken "App_" gibi bir değer içeriyorsa, tablo adı "App_Books" olur.TutorialConsts.DbSchema → Şema adı belirleyerek tabloyu farklı bir şemada oluşturabiliriz.
            b.ConfigureByConvention(); //auto configure for the base class props.Base class'tan gelen özellikleri (örn: Id, CreationTime, LastModificationTime) otomatik olarak eşler.
            b.Property(x => x.Name).IsRequired().HasMaxLength(BookConsts.MaxNameLength);
             //        Name sütununun zorunlu(NULL olamaz) olmasını sağlar.
              //Maksimum 128 karakter uzunluğunda bir nvarchar(128) olarak ayarlar.


        });
        builder.Entity<Author>(b =>
        {
            b.ToTable(TutorialConsts.DbTablePrefix + "Authors", TutorialConsts.DbSchema);//Author sınıfını bir veritabanı tablosuyla ilişkilendirir
            b.ConfigureByConvention();
            b.Property(x => x.Name).IsRequired().HasMaxLength(AuthorConsts.MaxNameLength);
            b.HasIndex(x => x.Name); //Name alanına bir indeks ekler ?? bu index ne işe yarar
            
        });
    }
}
